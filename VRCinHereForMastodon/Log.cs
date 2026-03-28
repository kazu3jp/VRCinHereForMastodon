using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace VRCinHereForMastodon
{
    internal class Log
    {
        private static Process? VRChatProcess = null;
        private static Thread? ProcessMonitorThread = null;
        private static bool ErrorAlreadyReported = false; // エラー二重投稿防止フラグ

        public static void Monitoring()
        {
            var LogWatcher = new FileSystemWatcher();
            LogWatcher.Path = Environment.GetEnvironmentVariable("HOMEDRIVE") + Environment.GetEnvironmentVariable("HOMEPATH") + @"\AppData\LocalLow\VRChat\vrchat";
            LogWatcher.NotifyFilter = NotifyFilters.FileName;
            LogWatcher.Filter = "output_log_*.txt";
            LogWatcher.Created += new FileSystemEventHandler(LogRead);
            LogWatcher.EnableRaisingEvents = true;

            Debug.WriteLine("[LOG]Target Path -> " + LogWatcher.Path);
            Debug.WriteLine("[LOG]Event detect -> File Created");
            Debug.WriteLine("[LOG]Filter -> " + LogWatcher.Filter);
            Debug.WriteLine("[LOG]Monitoring Start -> " + DateTime.Now);

            // VRChat.exeプロセス監視を開始
            ProcessMonitorThread = new Thread(MonitorVRChatProcess);
            ProcessMonitorThread.IsBackground = true;
            ProcessMonitorThread.Start();
            Debug.WriteLine("[LOG]VRChat Process Monitor Started");
        }

        private static void MonitorVRChatProcess()
        {
            while (true)
            {
                try
                {
                    var Processes = Process.GetProcessesByName("VRChat");
                    if (Processes.Length > 0)
                    {
                        VRChatProcess = Processes[0];
                        VRChatProcess.EnableRaisingEvents = true;
                        VRChatProcess.Exited += new EventHandler(VRChatProcess_Exited);
                        VRChatProcess.WaitForExit();
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("[LOG]Error in MonitorVRChatProcess: " + ex.Message);
                    Thread.Sleep(1000);
                }
            }
        }

        private static void VRChatProcess_Exited(object? sender, EventArgs e)
        {
            if (VRChatProcess != null && sender is Process ProcessInfo)
            {
                var ExitCode = ProcessInfo.ExitCode;
                Debug.WriteLine($"[LOG]VRChat Process Exited with code: {ExitCode}");

                // 終了コードが0でない場合はエラー落ちと判定
                if (ExitCode != 0)
                {
                    Debug.WriteLine("[LOG]VRChat Error Detected by Process Exit Code");
                    ErrorAlreadyReported = true;
                    // Mastodonに投稿
                    Thread.Sleep(2000); // ログ書き込み完了を待機
                    MastodonAPI.SendToot("", "", "", MastodonAPI.InstanceTypeError);
                }
                else
                {
                    Debug.WriteLine("[LOG]VRChat Normal Logout");
                    ErrorAlreadyReported = false;
                }

                VRChatProcess?.Dispose();
                VRChatProcess = null;
            }
        }

        private static void LogRead(object sender, FileSystemEventArgs e)
        {
            Debug.WriteLine("[LOG]File create detect -> " + e.FullPath);
            //VRChatが起動していない場合は処理しない
            if (!IsVRChatLaunch())
            {
                return;
            }

            //ファイルオープン
            using (var fs = new FileStream(e.FullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var sr = new StreamReader(fs, Encoding.GetEncoding("UTF-8")))
            {
                while (true)
                {
                    var LogLine = sr.ReadLine();
                    if (LogLine == "")
                    {
                        continue; //空行は処理スキップ
                    }
                    if (LogLine is null)
                    {
                        //ログファイルの末尾まで到達した場合の処理
                        //5秒待機しVRChatプロセス起動状況を確認、プロセスが存在しない場合はログアウトと判断
                        Thread.Sleep(5 * 1000);
                        if (!IsVRChatLaunch())
                        {
                            // VRChatプロセスが終了している場合、ログの内容をチェック
                            sr.BaseStream.Seek(0, SeekOrigin.Begin);
                            sr.DiscardBufferedData();
                            LogLine = sr.ReadToEnd();

                            // ログアウト判定
                            if (IsNormalLogout(LogLine))
                            {
                                Debug.WriteLine("[LOG]VRChat Normal Logout Detected");
                                MastodonAPI.SendToot("", "", "", MastodonAPI.InstanceTypeLogout);
                            }
                            else if (!ErrorAlreadyReported)
                            {
                                // プロセス監視で既にエラー検出していない場合のみ投稿
                                Debug.WriteLine("[LOG]VRChat Error Detected by Log Analysis");
                                ErrorAlreadyReported = true;
                                MastodonAPI.SendToot("", "", "", MastodonAPI.InstanceTypeError);
                            }
                            else
                            {
                                Debug.WriteLine("[LOG]VRChat Error already reported");
                            }
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    //処理対象行の検知(ワールドJoinログ行検知)
                    if (Regex.IsMatch(LogLine, @".*\[.*\] Entering Room:"))
                    {
                        Debug.WriteLine(LogLine);
                        //ワールド名取得, @文字置き換え
                        var WorldName = Regex.Replace(LogLine, @".*: ", "");
                        WorldName = WorldName.Replace("@", "(at)");
                        WorldName = WorldName.Replace("＠", "(at)");

                        //ワールド名が100文字以上の場合トリミング
                        if (100 <= WorldName.Length)
                        {
                            WorldName = WorldName.Substring(0, 99);
                        }

                        //インスタンス情報の行までログを進める
                        while (true)
                        {
                            LogLine = sr.ReadLine();
                            if (LogLine == null)
                            {
                                Thread.Sleep(1500);
                                continue;
                            }
                            if (Regex.IsMatch(LogLine, @".*\[.*\] Joining wrld_"))
                            {
                                break;
                            }
                        }
                        //ログからワールド情報取得
                        var WorldInfo = Regex.Replace(LogLine, @".*Joining ", "");
                        var WorldID = WorldInfo.Substring(0, WorldInfo.IndexOf(":"));
                        var InstanceID = WorldInfo.Substring(WorldInfo.IndexOf(":") + 1);
                        InstanceID = Uri.EscapeDataString(InstanceID);
                        var InstanceType = () =>
                        {
                            var tmpLine = Regex.Replace(LogLine, @".*:\d*", "");
                            if (tmpLine.Contains("private") && tmpLine.Contains("canRequestInvite"))
                            {
                                return MastodonAPI.InstanceTypeInvitePlus;
                            }
                            else if (tmpLine.Contains("private"))
                            {
                                return MastodonAPI.InstanceTypePrivate;
                            }
                            else if (tmpLine.Contains("friends"))
                            {
                                return MastodonAPI.InstanceTypeFriendsOnly;
                            }
                            else if (tmpLine.Contains("hidden"))
                            {
                                return MastodonAPI.InstanceTypeFriendsPlus;
                            }
                            else if (tmpLine.Contains("group"))
                            {
                                if (tmpLine.Contains("public"))
                                {
                                    return MastodonAPI.InstanceTypeGroupPublic;
                                }
                                else if (tmpLine.Contains("plus"))
                                {
                                    return MastodonAPI.InstanceTypeGroupPlus;
                                }
                                else
                                {
                                    return MastodonAPI.InstanceTypeGroup;
                                }
                            }
                            else
                            {
                                return MastodonAPI.InstanceTypePublic;
                            }
                        };

                        MastodonAPI.SendToot(WorldID, WorldName, InstanceID, InstanceType());
                    }
                }
            }
        }

        public static bool IsVRChatLaunch()
        {
            if (Process.GetProcessesByName("VRChat").Length == 0)
            {
                return false;
            }
            return true;
        }

        private static bool IsNormalLogout(string logContent)
        {
            // ログアウトのマーカーとなる文字列を検出
            // インストーラーの実行を示す文字列
            if (logContent.Contains("install.exe") || logContent.Contains("installer", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            // 正常なシャットダウンのマーカー
            if (logContent.Contains("OnApplicationQuit", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            // ログアウト関連のメッセージ
            if (logContent.Contains("User Signed Out", StringComparison.OrdinalIgnoreCase) ||
                logContent.Contains("Signed Out", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            // アップデートチェック完了後の正常終了
            if (logContent.Contains("Updates Check", StringComparison.OrdinalIgnoreCase) &&
                !logContent.Contains("Exception", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            // その他の明示的なシャットダウンマーカー
            if (logContent.Contains("Shutting down", StringComparison.OrdinalIgnoreCase) &&
                !logContent.Contains("Exception", StringComparison.OrdinalIgnoreCase) &&
                !logContent.Contains("Error", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }
    }
}
