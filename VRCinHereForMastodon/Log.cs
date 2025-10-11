using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VRCinHereForMastodon
{
    internal class Log
    {
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
                        //30秒待機しVRChatプロセス起動状況を確認、プロセスが存在しない場合はログアウトと判断
                        //VRC異常終了投稿がONの場合、異常終了判定を行う
                        Thread.Sleep(30 * 1000);
                        if (!IsVRChatLaunch())
                        {
                            //ログを先頭から末尾まで全て読み込み、VRC異常終了を判定
                            sr.BaseStream.Seek(0, SeekOrigin.Begin);
                            sr.DiscardBufferedData();
                            LogLine = sr.ReadToEnd();
                            if (LogLine.Contains("install.exe"))
                            {
                                Debug.WriteLine("[LOG]VRChat Logout");
                                MastodonAPI.SendToot("", "", "", MastodonAPI.InstanceTypeLogout);
                            }
                            else
                            {
                                Debug.WriteLine("[LOG]VRChat Error");
                                MastodonAPI.SendToot("", "", "", MastodonAPI.InstanceTypeError);
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
    }
}
