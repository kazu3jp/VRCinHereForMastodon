using System.Collections.Specialized;
using System.Diagnostics;

namespace VRCinHereForMastodon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //コマンドライン引数の確認
            foreach (var args in Environment.GetCommandLineArgs())
            {
                Debug.WriteLine("[Boot]args:" + args);
                if (args == "-AutoStart")
                {
                    Debug.WriteLine("[Boot]Startup wait ON");
                    AutoStart = true;
                }
            }
        }

        //自動起動からの起動判定変数
        public static bool AutoStart = false;

        //起動時処理中判定変数
        public static bool Initializing = true;

        //サイレントモード状態変数
        public static bool SilentMode = false;

        private void Form1_Shown(object sender, EventArgs e)
        {
            //各設定値をフォームへ反映
            checkBoxPublicJoin.Checked = Properties.Settings.Default.TootPublicJoin;
            checkBoxPublicJoinURL.Checked = Properties.Settings.Default.TootPublicJoinURL;
            checkBoxFriendsPlusJoin.Checked = Properties.Settings.Default.TootFriendsPlusJoin;
            checkBoxFriendsPlusJoinURL.Checked = Properties.Settings.Default.TootFriendsPlusJoinURL;
            checkBoxFriendsOnlyJoin.Checked = Properties.Settings.Default.TootFriendsOnlyJoin;
            checkBoxFriendsOnlyJoinURL.Checked = Properties.Settings.Default.TootFriendsOnlyJoinURL;
            checkBoxGroupPublicJoin.Checked = Properties.Settings.Default.TootGroupPublicJoin;
            checkBoxGroupPublicJoinURL.Checked = Properties.Settings.Default.TootGroupPublicJoinURL;
            checkBoxGroupPlusJoin.Checked = Properties.Settings.Default.TootGroupPlusJoin;
            checkBoxGroupPlusJoinURL.Checked = Properties.Settings.Default.TootGroupPlusJoinURL;
            checkBoxGroupJoin.Checked = Properties.Settings.Default.TootGroupJoin;
            checkBoxGroupWorldName.Checked = Properties.Settings.Default.TootGroupJoinWorldName;
            checkBoxInvitePlusJoin.Checked = Properties.Settings.Default.TootInvitePlusJoin;
            checkBoxInvitePlusWorldName.Checked = Properties.Settings.Default.TootInvitePlusJoinWorldName;
            checkBoxPrivateJoin.Checked = Properties.Settings.Default.TootPrivateJoin;
            checkBoxPrivateWorldName.Checked = Properties.Settings.Default.TootPrivateJoinWorldName;
            checkBoxTootLogout.Checked = Properties.Settings.Default.TootLogout;
            checkBoxTootError.Checked = Properties.Settings.Default.TootError;
            checkBoxDateTimeToot.Checked = Properties.Settings.Default.TootDateTime;
            checkBoxAutoStart.Checked = Properties.Settings.Default.AutoStart;

            //ワールド名指定ミュート設定フォーム反映
            checkBoxNotTootSpecifyWorldJoin.Checked = Properties.Settings.Default.NotTootSpecifyWorldJoin;
            checkBoxMaskSpecifyWorldName.Checked = Properties.Settings.Default.MaskSpecifyWorldName;
            if (Properties.Settings.Default.SpecifyWorldList is not null)
            {
                foreach (var SpecifyWorldData in Properties.Settings.Default.SpecifyWorldList)
                {
                    var SpecifyWorldRow = SpecifyWorldData.Split('\t');
                    if (SpecifyWorldRow[2] == "0")
                    {
                        dataGridViewSpecifyWorld.Rows.Add(SpecifyWorldRow[0], SpecifyWorldRow[1], false);
                    }
                    else
                    {
                        dataGridViewSpecifyWorld.Rows.Add(SpecifyWorldRow[0], SpecifyWorldRow[1], true);
                    }
                }
            }

            //Mastodon投稿設定フォーム反映
            textBoxServerDomain.Text = Properties.Settings.Default.ServerDomain;
            if (Properties.Settings.Default.APIKey == "")
            {
                textBoxAPIKey.Text = "";
            }
            else
            {
                textBoxAPIKey.Text = Common.Decrypt(Properties.Settings.Default.APIKey);
            }
            comboBoxPublishType.SelectedIndex = Properties.Settings.Default.TootPublishType;
            textBoxTootText.Text = Properties.Settings.Default.TootText;

            if (AutoStart)
            {
                Visible = false;
            }

            Initializing = false;
            Log.Monitoring();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Visible = false;
            }
        }

        private void ToolStripMenuItem_ResrtSettings_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("設定をリセットします", "VRChat in Here for Mastodon", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            Properties.Settings.Default.Reset();
            if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup)) + @"\VRChatInHereForMastodon.lnk"))
            {
                //スタートアップへショートカット作成済みの場合→ショートカットを削除
                File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup)) + @"\VRChatInHereForMastodon.lnk");
            }
            Application.Restart();
        }

        private void checkBoxPublicJoin_CheckedChanged(object sender, EventArgs e)
        {
            if (Initializing) return;

            Properties.Settings.Default.TootPublicJoin = checkBoxPublicJoin.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxPublicJoinURL_CheckedChanged(object sender, EventArgs e)
        {
            if (Initializing) return;

            Properties.Settings.Default.TootPublicJoinURL = checkBoxPublicJoinURL.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxFriendsPlusJoin_CheckedChanged(object sender, EventArgs e)
        {
            if (Initializing) return;

            Properties.Settings.Default.TootFriendsPlusJoin = checkBoxFriendsPlusJoin.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxFriendsPlusJoinURL_CheckedChanged(object sender, EventArgs e)
        {
            if (Initializing) return;

            Properties.Settings.Default.TootFriendsPlusJoinURL = checkBoxFriendsPlusJoinURL.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxFriendsOnlyJoin_CheckedChanged(object sender, EventArgs e)
        {
            if (Initializing) return;

            Properties.Settings.Default.TootFriendsOnlyJoin = checkBoxFriendsOnlyJoin.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxFriendsOnlyJoinURL_CheckedChanged(object sender, EventArgs e)
        {
            if (Initializing) return;

            Properties.Settings.Default.TootFriendsOnlyJoinURL = checkBoxFriendsOnlyJoinURL.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxGroupPublicJoin_CheckedChanged(object sender, EventArgs e)
        {
            if (Initializing) return;

            Properties.Settings.Default.TootGroupPublicJoin = checkBoxGroupPublicJoin.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxGroupPublicJoinURL_CheckedChanged(object sender, EventArgs e)
        {
            if (Initializing) return;

            Properties.Settings.Default.TootGroupPublicJoinURL = checkBoxGroupPublicJoinURL.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxGroupPlusJoin_CheckedChanged(object sender, EventArgs e)
        {
            if (Initializing) return;

            Properties.Settings.Default.TootGroupPlusJoin = checkBoxGroupPlusJoin.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxGroupPlusJoinURL_CheckedChanged(object sender, EventArgs e)
        {
            if (Initializing) return;

            Properties.Settings.Default.TootGroupPlusJoinURL = checkBoxGroupPlusJoinURL.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxGroupJoin_CheckedChanged(object sender, EventArgs e)
        {
            if (Initializing) return;

            Properties.Settings.Default.TootGroupJoin = checkBoxGroupJoin.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxGroupWorldName_CheckedChanged(object sender, EventArgs e)
        {
            if (Initializing) return;

            Properties.Settings.Default.TootGroupJoinWorldName = checkBoxGroupWorldName.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxInvitePlusJoin_CheckedChanged(object sender, EventArgs e)
        {
            if (Initializing) return;

            Properties.Settings.Default.TootInvitePlusJoin = checkBoxInvitePlusJoin.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxInvitePlusWorldName_CheckedChanged(object sender, EventArgs e)
        {
            if (Initializing) return;

            Properties.Settings.Default.TootInvitePlusJoinWorldName = checkBoxInvitePlusWorldName.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxPrivateJoin_CheckedChanged(object sender, EventArgs e)
        {
            if (Initializing) return;

            Properties.Settings.Default.TootPrivateJoin = checkBoxPrivateJoin.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxPrivateWorldName_CheckedChanged(object sender, EventArgs e)
        {
            if (Initializing) return;

            Properties.Settings.Default.TootPrivateJoinWorldName = checkBoxPrivateWorldName.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxTootLogout_CheckedChanged(object sender, EventArgs e)
        {
            if (Initializing) return;

            Properties.Settings.Default.TootLogout = checkBoxTootLogout.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            if (Initializing) return;

            if (Properties.Settings.Default.AutoStart == checkBoxAutoStart.Checked)
            {
                return;
            }
            Properties.Settings.Default.AutoStart = checkBoxAutoStart.Checked;
            Properties.Settings.Default.Save();

            if (checkBoxAutoStart.Checked)
            {
                //自動起動がONされた場合、ショートカット作成
                if (!File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup)) + @"\VRChatInHereForMastodon.lnk"))
                {
                    //スタートアップへショートカットが存在しない場合作成
                    CreateStartupShortcut();
                }
            }
            else
            {
                //自動起動がOFFされた場合、ショートカット削除
                if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup)) + @"\VRChatInHereForMastodon.lnk"))
                {
                    //スタートアップへショートカット作成済みの場合→ショートカットを削除
                    File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup)) + @"\VRChatInHereForMastodon.lnk");
                }
            }
        }

        private void CreateStartupShortcut()
        {
            //ショートカット作成
            string shortcutPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), @"VRChatInHereForMastodon.lnk");
            var di = new DirectoryInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var targetPath = di.Parent.FullName + @"\VRCinHereForMastodon.exe";

            //WshShellを作成
            Type t = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8"));
            dynamic shell = Activator.CreateInstance(t);

            //WshShortcutを作成
            var shortcut = shell.CreateShortcut(shortcutPath);

            //リンク先
            shortcut.TargetPath = targetPath;

            //コマンドライン引数
            shortcut.Arguments = "-AutoStart";

            //作業ディレクトリ
            shortcut.WorkingDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            //ショートカットを作成
            shortcut.Save();

            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(shortcut);
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(shell);

            return;
        }

        private void textBoxServerDomain_Leave(object sender, EventArgs e)
        {
            if (Initializing) return;

            Properties.Settings.Default.ServerDomain = textBoxServerDomain.Text;
            Properties.Settings.Default.Save();
        }

        private void textBoxAPIKey_TextChanged(object sender, EventArgs e)
        {
            if (Initializing) return;

            Properties.Settings.Default.APIKey = Common.Encrypt(textBoxAPIKey.Text);
            Properties.Settings.Default.Save();
        }

        private void comboBoxPublishType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Initializing) return;

            Properties.Settings.Default.TootPublishType = comboBoxPublishType.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void textBoxTootText_TextChanged(object sender, EventArgs e)
        {
            labelTootTextCount.Text = textBoxTootText.Text.Length.ToString() + " / 400";
        }

        private void buttonTootTextUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxTootText.Text.Contains("@") | textBoxTootText.Text.Contains("＠"))
            {
                MessageBox.Show("トゥート本文へ @ を使用することはできません。", "VRChat in Here for Mastodon");
                return;
            }

            Properties.Settings.Default.TootText = textBoxTootText.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("トゥートする文章を更新しました。", "VRChat in Here for Mastodon");
        }

        private void checkBoxNotTootSpecifyWorldJoin_CheckedChanged(object sender, EventArgs e)
        {
            if (Initializing) return;

            Properties.Settings.Default.NotTootSpecifyWorldJoin = checkBoxNotTootSpecifyWorldJoin.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxMaskSpecifyWorldName_CheckedChanged(object sender, EventArgs e)
        {
            if (Initializing) return;

            Properties.Settings.Default.MaskSpecifyWorldName = checkBoxMaskSpecifyWorldName.Checked;
            Properties.Settings.Default.Save();
        }

        private void buttonAddMuteWorld_Click(object sender, EventArgs e)
        {
            dataGridViewSpecifyWorld.Rows.Add("", "", true);
        }

        private void dataGridViewSpecifyWorld_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Initializing) return;

            //変更されたセルがワールドID列の場合、既存のワールドIDセルと競合しないか確認
            var EditingCell = dataGridViewSpecifyWorld.Rows[e.RowIndex].Cells[e.ColumnIndex];
            Debug.WriteLine(EditingCell);
            if (EditingCell.ColumnIndex == 0)
            {
                //ワールドID列の文字列を全て取得しリストへ格納, リスト内で重複しないか判定 空白はOKとする
                var CheckWorldIdDuplicateList = new List<string>();
                foreach (DataGridViewRow tmpRow in dataGridViewSpecifyWorld.Rows)
                {
                    if (tmpRow.Cells[0].Value.ToString() == "")
                    {
                        continue;
                    }
                    Debug.WriteLine(tmpRow.Cells[0].Value.ToString());
                    CheckWorldIdDuplicateList.Add(tmpRow.Cells[0].Value.ToString());
                }

                var IsDuplicate = CheckWorldIdDuplicateList.GroupBy(s => s).Any(g => g.Count() > 1);
                if (IsDuplicate)
                {
                    MessageBox.Show("ワールドIDが重複しています\nワールドIDは重複しないよう入力してください", "VRChat in Here for Mastodon");
                    EditingCell.Value = "";
                    return;
                }
            }
            //ミュートワールドリスト保存
            SaveSpecifyWorldList();
        }

        //チェックボックス左右の余白をクリックした場合もチェックボックスをクリックしたと同様の動作とする仕組み
        private void dataGridViewSpecifyWorld_MouseUp(object sender, MouseEventArgs e)
        {
            var ht = dataGridViewSpecifyWorld.HitTest(e.X, e.Y);
            if (ht.Type == DataGridViewHitTestType.Cell)
            {
                var cell = dataGridViewSpecifyWorld[ht.ColumnIndex, ht.RowIndex] as DataGridViewCheckBoxCell;
                if (cell == null)
                {
                    return;
                }

                if (System.Convert.ToBoolean(cell.Value.ToString()))
                {
                    dataGridViewSpecifyWorld["MuteEnable", ht.RowIndex].Value = false;
                }
                else
                {
                    dataGridViewSpecifyWorld["MuteEnable", ht.RowIndex].Value = true;
                }
                dataGridViewSpecifyWorld.EndEdit();
            }
        }

        //削除ボタンクリック
        private void dataGridViewSpecifyWorld_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name != "DeleteButton")
            {
                return;
            }
            dataGridViewSpecifyWorld.Rows.RemoveAt(e.RowIndex);
            SaveSpecifyWorldList();
        }

        private void SaveSpecifyWorldList()
        {
            var SaveStringCollection = new StringCollection();
            foreach (DataGridViewRow tmpRow in dataGridViewSpecifyWorld.Rows)
            {
                var WorldID = tmpRow.Cells[0].Value.ToString();
                var WorldName = tmpRow.Cells[1].Value.ToString();
                var Check = (bool)tmpRow.Cells[2].Value;

                var ConfigString = WorldID + "\t" + WorldName + "\t";
                if (Check)
                {
                    ConfigString += "1";
                }
                else
                {
                    ConfigString += "0";
                }
                Debug.WriteLine(ConfigString);
                SaveStringCollection.Add(ConfigString);
            }
            Properties.Settings.Default.SpecifyWorldList = SaveStringCollection;
            Properties.Settings.Default.Save();
        }

        private void ToolStripMenuItemShowWindow_Click(object sender, EventArgs e)
        {
            Visible = true;
            WindowState = FormWindowState.Normal;
        }

        private void SwitchSilentMode(object sender, EventArgs e)
        {
            SilentMode = !SilentMode;
            checkBoxSilentMode.Checked = SilentMode;
            ToolStripMenuItemSilentMode.Checked = SilentMode;
        }

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            notifyIcon1.Dispose();
            Close();
        }

        private void buttonPostTest_Click(object sender, EventArgs e)
        {
            MastodonAPI.SendToot("", "", "", MastodonAPI.InstanceTypePostTest);
        }

        private void checkBoxTootError_CheckedChanged(object sender, EventArgs e)
        {
            if (Initializing) return;

            if (checkBoxTootError.Checked)
            {
                MessageBox.Show("本機能は実験版のため全てのVRC異常終了を検知できない場合があります\n" +
                "VRCが異常終了したにもかかわらず異常終了用のメッセージが投稿されなかった場合、VRCのログファイルを提供いただけるとたすかります");
            }
            Properties.Settings.Default.TootError = checkBoxTootError.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxDateTimeToot_CheckedChanged(object sender, EventArgs e)
        {
            if (Initializing) return;

            Properties.Settings.Default.TootDateTime = checkBoxDateTimeToot.Checked;
            Properties.Settings.Default.Save();
        }
    }

}
