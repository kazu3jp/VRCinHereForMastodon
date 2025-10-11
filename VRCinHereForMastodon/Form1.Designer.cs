namespace VRCinHereForMastodon
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            title = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            ToolStripMenuItemShowWindow = new ToolStripMenuItem();
            ToolStripMenuItemSilentMode = new ToolStripMenuItem();
            ToolStripMenuItemExit = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            ToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem_ResrtSettings = new ToolStripMenuItem();
            groupBox1 = new GroupBox();
            checkBoxPublicJoinURL = new CheckBox();
            checkBoxPublicJoin = new CheckBox();
            groupBox2 = new GroupBox();
            checkBoxFriendsPlusJoinURL = new CheckBox();
            checkBoxFriendsPlusJoin = new CheckBox();
            groupBox3 = new GroupBox();
            checkBoxFriendsOnlyJoinURL = new CheckBox();
            checkBoxFriendsOnlyJoin = new CheckBox();
            groupBox5 = new GroupBox();
            checkBoxInvitePlusWorldName = new CheckBox();
            checkBoxInvitePlusJoin = new CheckBox();
            groupBox4 = new GroupBox();
            checkBoxGroupPublicJoinURL = new CheckBox();
            checkBoxGroupPublicJoin = new CheckBox();
            groupBox10 = new GroupBox();
            checkBoxGroupWorldName = new CheckBox();
            checkBoxGroupJoin = new CheckBox();
            groupBox7 = new GroupBox();
            checkBoxPrivateWorldName = new CheckBox();
            checkBoxPrivateJoin = new CheckBox();
            checkBoxAutoStart = new CheckBox();
            checkBoxSilentMode = new CheckBox();
            checkBoxTootError = new CheckBox();
            checkBoxDateTimeToot = new CheckBox();
            checkBoxTootLogout = new CheckBox();
            groupBox8 = new GroupBox();
            comboBoxPublishType = new ComboBox();
            buttonPostTest = new Button();
            buttonTootTextUpdate = new Button();
            labelTootTextCount = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            textBoxServerDomain = new TextBox();
            label2 = new Label();
            label1 = new Label();
            textBoxTootText = new TextBox();
            textBoxAPIKey = new TextBox();
            groupBox9 = new GroupBox();
            dataGridViewSpecifyWorld = new DataGridView();
            WorldID = new DataGridViewTextBoxColumn();
            WorldName = new DataGridViewTextBoxColumn();
            MuteEnable = new DataGridViewCheckBoxColumn();
            DeleteButton = new DataGridViewButtonColumn();
            checkBoxMaskSpecifyWorldName = new CheckBox();
            buttonAddMuteWorld = new Button();
            checkBoxNotTootSpecifyWorldJoin = new CheckBox();
            groupBox6 = new GroupBox();
            checkBoxGroupPlusJoinURL = new CheckBox();
            checkBoxGroupPlusJoin = new CheckBox();
            contextMenuStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox10.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox8.SuspendLayout();
            groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSpecifyWorld).BeginInit();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "VRChat in Here for Mastodon";
            notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { title, toolStripSeparator1, ToolStripMenuItemShowWindow, ToolStripMenuItemSilentMode, ToolStripMenuItemExit });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(229, 98);
            // 
            // title
            // 
            title.Enabled = false;
            title.Name = "title";
            title.Size = new Size(228, 22);
            title.Text = "VRChat in Here for Mastodon";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(225, 6);
            // 
            // ToolStripMenuItemShowWindow
            // 
            ToolStripMenuItemShowWindow.Name = "ToolStripMenuItemShowWindow";
            ToolStripMenuItemShowWindow.Size = new Size(228, 22);
            ToolStripMenuItemShowWindow.Text = "設定画面表示";
            ToolStripMenuItemShowWindow.Click += ToolStripMenuItemShowWindow_Click;
            // 
            // ToolStripMenuItemSilentMode
            // 
            ToolStripMenuItemSilentMode.Name = "ToolStripMenuItemSilentMode";
            ToolStripMenuItemSilentMode.Size = new Size(228, 22);
            ToolStripMenuItemSilentMode.Text = "投稿一時停止";
            ToolStripMenuItemSilentMode.Click += SwitchSilentMode;
            // 
            // ToolStripMenuItemExit
            // 
            ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            ToolStripMenuItemExit.Size = new Size(228, 22);
            ToolStripMenuItemExit.Text = "終了";
            ToolStripMenuItemExit.Click += ToolStripMenuItemExit_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(864, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItem
            // 
            ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem_ResrtSettings });
            ToolStripMenuItem.Name = "ToolStripMenuItem";
            ToolStripMenuItem.Size = new Size(43, 20);
            ToolStripMenuItem.Text = "設定";
            // 
            // ToolStripMenuItem_ResrtSettings
            // 
            ToolStripMenuItem_ResrtSettings.Name = "ToolStripMenuItem_ResrtSettings";
            ToolStripMenuItem_ResrtSettings.Size = new Size(132, 22);
            ToolStripMenuItem_ResrtSettings.Text = "設定リセット";
            ToolStripMenuItem_ResrtSettings.Click += ToolStripMenuItem_ResrtSettings_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBoxPublicJoinURL);
            groupBox1.Controls.Add(checkBoxPublicJoin);
            groupBox1.Location = new Point(12, 27);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(194, 75);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Public";
            // 
            // checkBoxPublicJoinURL
            // 
            checkBoxPublicJoinURL.AutoSize = true;
            checkBoxPublicJoinURL.Location = new Point(6, 47);
            checkBoxPublicJoinURL.Name = "checkBoxPublicJoinURL";
            checkBoxPublicJoinURL.Size = new Size(153, 19);
            checkBoxPublicJoinURL.TabIndex = 6;
            checkBoxPublicJoinURL.Text = "Join用URLを本文に含める";
            checkBoxPublicJoinURL.UseVisualStyleBackColor = true;
            checkBoxPublicJoinURL.CheckedChanged += checkBoxPublicJoinURL_CheckedChanged;
            // 
            // checkBoxPublicJoin
            // 
            checkBoxPublicJoin.AutoSize = true;
            checkBoxPublicJoin.Location = new Point(6, 22);
            checkBoxPublicJoin.Name = "checkBoxPublicJoin";
            checkBoxPublicJoin.Size = new Size(189, 19);
            checkBoxPublicJoin.TabIndex = 5;
            checkBoxPublicJoin.Text = "インスタンス移動時にトゥートを投稿";
            checkBoxPublicJoin.UseVisualStyleBackColor = true;
            checkBoxPublicJoin.CheckedChanged += checkBoxPublicJoin_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(checkBoxFriendsPlusJoinURL);
            groupBox2.Controls.Add(checkBoxFriendsPlusJoin);
            groupBox2.Location = new Point(12, 108);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(194, 75);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Friends+";
            // 
            // checkBoxFriendsPlusJoinURL
            // 
            checkBoxFriendsPlusJoinURL.AutoSize = true;
            checkBoxFriendsPlusJoinURL.Location = new Point(6, 47);
            checkBoxFriendsPlusJoinURL.Name = "checkBoxFriendsPlusJoinURL";
            checkBoxFriendsPlusJoinURL.Size = new Size(153, 19);
            checkBoxFriendsPlusJoinURL.TabIndex = 6;
            checkBoxFriendsPlusJoinURL.Text = "Join用URLを本文に含める";
            checkBoxFriendsPlusJoinURL.UseVisualStyleBackColor = true;
            checkBoxFriendsPlusJoinURL.CheckedChanged += checkBoxFriendsPlusJoinURL_CheckedChanged;
            // 
            // checkBoxFriendsPlusJoin
            // 
            checkBoxFriendsPlusJoin.AutoSize = true;
            checkBoxFriendsPlusJoin.Location = new Point(6, 22);
            checkBoxFriendsPlusJoin.Name = "checkBoxFriendsPlusJoin";
            checkBoxFriendsPlusJoin.Size = new Size(189, 19);
            checkBoxFriendsPlusJoin.TabIndex = 5;
            checkBoxFriendsPlusJoin.Text = "インスタンス移動時にトゥートを投稿";
            checkBoxFriendsPlusJoin.UseVisualStyleBackColor = true;
            checkBoxFriendsPlusJoin.CheckedChanged += checkBoxFriendsPlusJoin_CheckedChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(checkBoxFriendsOnlyJoinURL);
            groupBox3.Controls.Add(checkBoxFriendsOnlyJoin);
            groupBox3.Location = new Point(12, 189);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(194, 75);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Friends Only";
            // 
            // checkBoxFriendsOnlyJoinURL
            // 
            checkBoxFriendsOnlyJoinURL.AutoSize = true;
            checkBoxFriendsOnlyJoinURL.Location = new Point(6, 47);
            checkBoxFriendsOnlyJoinURL.Name = "checkBoxFriendsOnlyJoinURL";
            checkBoxFriendsOnlyJoinURL.Size = new Size(153, 19);
            checkBoxFriendsOnlyJoinURL.TabIndex = 6;
            checkBoxFriendsOnlyJoinURL.Text = "Join用URLを本文に含める";
            checkBoxFriendsOnlyJoinURL.UseVisualStyleBackColor = true;
            checkBoxFriendsOnlyJoinURL.CheckedChanged += checkBoxFriendsOnlyJoinURL_CheckedChanged;
            // 
            // checkBoxFriendsOnlyJoin
            // 
            checkBoxFriendsOnlyJoin.AutoSize = true;
            checkBoxFriendsOnlyJoin.Location = new Point(6, 22);
            checkBoxFriendsOnlyJoin.Name = "checkBoxFriendsOnlyJoin";
            checkBoxFriendsOnlyJoin.Size = new Size(189, 19);
            checkBoxFriendsOnlyJoin.TabIndex = 5;
            checkBoxFriendsOnlyJoin.Text = "インスタンス移動時にトゥートを投稿";
            checkBoxFriendsOnlyJoin.UseVisualStyleBackColor = true;
            checkBoxFriendsOnlyJoin.CheckedChanged += checkBoxFriendsOnlyJoin_CheckedChanged;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(checkBoxInvitePlusWorldName);
            groupBox5.Controls.Add(checkBoxInvitePlusJoin);
            groupBox5.Location = new Point(12, 270);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(194, 75);
            groupBox5.TabIndex = 11;
            groupBox5.TabStop = false;
            groupBox5.Text = "Invite+";
            // 
            // checkBoxInvitePlusWorldName
            // 
            checkBoxInvitePlusWorldName.AutoSize = true;
            checkBoxInvitePlusWorldName.Location = new Point(6, 47);
            checkBoxInvitePlusWorldName.Name = "checkBoxInvitePlusWorldName";
            checkBoxInvitePlusWorldName.Size = new Size(147, 19);
            checkBoxInvitePlusWorldName.TabIndex = 6;
            checkBoxInvitePlusWorldName.Text = "ワールド名を本文へ含める";
            checkBoxInvitePlusWorldName.UseVisualStyleBackColor = true;
            checkBoxInvitePlusWorldName.CheckedChanged += checkBoxInvitePlusWorldName_CheckedChanged;
            // 
            // checkBoxInvitePlusJoin
            // 
            checkBoxInvitePlusJoin.AutoSize = true;
            checkBoxInvitePlusJoin.Location = new Point(6, 22);
            checkBoxInvitePlusJoin.Name = "checkBoxInvitePlusJoin";
            checkBoxInvitePlusJoin.Size = new Size(189, 19);
            checkBoxInvitePlusJoin.TabIndex = 5;
            checkBoxInvitePlusJoin.Text = "インスタンス移動時にトゥートを投稿";
            checkBoxInvitePlusJoin.UseVisualStyleBackColor = true;
            checkBoxInvitePlusJoin.CheckedChanged += checkBoxInvitePlusJoin_CheckedChanged;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(checkBoxGroupPublicJoinURL);
            groupBox4.Controls.Add(checkBoxGroupPublicJoin);
            groupBox4.Location = new Point(212, 27);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(194, 75);
            groupBox4.TabIndex = 12;
            groupBox4.TabStop = false;
            groupBox4.Text = "グループ Public";
            // 
            // checkBoxGroupPublicJoinURL
            // 
            checkBoxGroupPublicJoinURL.AutoSize = true;
            checkBoxGroupPublicJoinURL.Location = new Point(6, 47);
            checkBoxGroupPublicJoinURL.Name = "checkBoxGroupPublicJoinURL";
            checkBoxGroupPublicJoinURL.Size = new Size(153, 19);
            checkBoxGroupPublicJoinURL.TabIndex = 6;
            checkBoxGroupPublicJoinURL.Text = "Join用URLを本文に含める";
            checkBoxGroupPublicJoinURL.UseVisualStyleBackColor = true;
            checkBoxGroupPublicJoinURL.CheckedChanged += checkBoxGroupPublicJoinURL_CheckedChanged;
            // 
            // checkBoxGroupPublicJoin
            // 
            checkBoxGroupPublicJoin.AutoSize = true;
            checkBoxGroupPublicJoin.Location = new Point(6, 22);
            checkBoxGroupPublicJoin.Name = "checkBoxGroupPublicJoin";
            checkBoxGroupPublicJoin.Size = new Size(189, 19);
            checkBoxGroupPublicJoin.TabIndex = 5;
            checkBoxGroupPublicJoin.Text = "インスタンス移動時にトゥートを投稿";
            checkBoxGroupPublicJoin.UseVisualStyleBackColor = true;
            checkBoxGroupPublicJoin.CheckedChanged += checkBoxGroupPublicJoin_CheckedChanged;
            // 
            // groupBox10
            // 
            groupBox10.Controls.Add(checkBoxGroupWorldName);
            groupBox10.Controls.Add(checkBoxGroupJoin);
            groupBox10.Location = new Point(212, 189);
            groupBox10.Name = "groupBox10";
            groupBox10.Size = new Size(194, 75);
            groupBox10.TabIndex = 14;
            groupBox10.TabStop = false;
            groupBox10.Text = "グループ";
            // 
            // checkBoxGroupWorldName
            // 
            checkBoxGroupWorldName.AutoSize = true;
            checkBoxGroupWorldName.Location = new Point(6, 47);
            checkBoxGroupWorldName.Name = "checkBoxGroupWorldName";
            checkBoxGroupWorldName.Size = new Size(147, 19);
            checkBoxGroupWorldName.TabIndex = 6;
            checkBoxGroupWorldName.Text = "ワールド名を本文へ含める";
            checkBoxGroupWorldName.UseVisualStyleBackColor = true;
            checkBoxGroupWorldName.CheckedChanged += checkBoxGroupWorldName_CheckedChanged;
            // 
            // checkBoxGroupJoin
            // 
            checkBoxGroupJoin.AutoSize = true;
            checkBoxGroupJoin.Location = new Point(6, 22);
            checkBoxGroupJoin.Name = "checkBoxGroupJoin";
            checkBoxGroupJoin.Size = new Size(189, 19);
            checkBoxGroupJoin.TabIndex = 5;
            checkBoxGroupJoin.Text = "インスタンス移動時にトゥートを投稿";
            checkBoxGroupJoin.UseVisualStyleBackColor = true;
            checkBoxGroupJoin.CheckedChanged += checkBoxGroupJoin_CheckedChanged;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(checkBoxPrivateWorldName);
            groupBox7.Controls.Add(checkBoxPrivateJoin);
            groupBox7.Location = new Point(212, 270);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(194, 75);
            groupBox7.TabIndex = 15;
            groupBox7.TabStop = false;
            groupBox7.Text = "Private";
            // 
            // checkBoxPrivateWorldName
            // 
            checkBoxPrivateWorldName.AutoSize = true;
            checkBoxPrivateWorldName.Location = new Point(6, 47);
            checkBoxPrivateWorldName.Name = "checkBoxPrivateWorldName";
            checkBoxPrivateWorldName.Size = new Size(147, 19);
            checkBoxPrivateWorldName.TabIndex = 6;
            checkBoxPrivateWorldName.Text = "ワールド名を本文へ含める";
            checkBoxPrivateWorldName.UseVisualStyleBackColor = true;
            checkBoxPrivateWorldName.CheckedChanged += checkBoxPrivateWorldName_CheckedChanged;
            // 
            // checkBoxPrivateJoin
            // 
            checkBoxPrivateJoin.AutoSize = true;
            checkBoxPrivateJoin.Location = new Point(6, 22);
            checkBoxPrivateJoin.Name = "checkBoxPrivateJoin";
            checkBoxPrivateJoin.Size = new Size(189, 19);
            checkBoxPrivateJoin.TabIndex = 5;
            checkBoxPrivateJoin.Text = "インスタンス移動時にトゥートを投稿";
            checkBoxPrivateJoin.UseVisualStyleBackColor = true;
            checkBoxPrivateJoin.CheckedChanged += checkBoxPrivateJoin_CheckedChanged;
            // 
            // checkBoxAutoStart
            // 
            checkBoxAutoStart.AutoSize = true;
            checkBoxAutoStart.Location = new Point(218, 376);
            checkBoxAutoStart.Name = "checkBoxAutoStart";
            checkBoxAutoStart.Size = new Size(74, 19);
            checkBoxAutoStart.TabIndex = 16;
            checkBoxAutoStart.Text = "自動起動";
            checkBoxAutoStart.UseVisualStyleBackColor = true;
            checkBoxAutoStart.CheckedChanged += checkBoxAutoStart_CheckedChanged;
            // 
            // checkBoxSilentMode
            // 
            checkBoxSilentMode.AutoSize = true;
            checkBoxSilentMode.Location = new Point(218, 351);
            checkBoxSilentMode.Name = "checkBoxSilentMode";
            checkBoxSilentMode.Size = new Size(98, 19);
            checkBoxSilentMode.TabIndex = 17;
            checkBoxSilentMode.Text = "投稿一時停止";
            checkBoxSilentMode.UseVisualStyleBackColor = true;
            checkBoxSilentMode.Click += SwitchSilentMode;
            // 
            // checkBoxTootError
            // 
            checkBoxTootError.AutoSize = true;
            checkBoxTootError.Location = new Point(12, 401);
            checkBoxTootError.Name = "checkBoxTootError";
            checkBoxTootError.Size = new Size(181, 19);
            checkBoxTootError.TabIndex = 18;
            checkBoxTootError.Text = "VRC異常終了を投稿する(テスト)";
            checkBoxTootError.UseVisualStyleBackColor = true;
            checkBoxTootError.CheckedChanged += checkBoxTootError_CheckedChanged;
            // 
            // checkBoxDateTimeToot
            // 
            checkBoxDateTimeToot.AutoSize = true;
            checkBoxDateTimeToot.Location = new Point(12, 351);
            checkBoxDateTimeToot.Name = "checkBoxDateTimeToot";
            checkBoxDateTimeToot.Size = new Size(155, 19);
            checkBoxDateTimeToot.TabIndex = 19;
            checkBoxDateTimeToot.Text = "トゥート本文へ時刻を含める";
            checkBoxDateTimeToot.UseVisualStyleBackColor = true;
            checkBoxDateTimeToot.CheckedChanged += checkBoxDateTimeToot_CheckedChanged;
            // 
            // checkBoxTootLogout
            // 
            checkBoxTootLogout.AutoSize = true;
            checkBoxTootLogout.Location = new Point(12, 376);
            checkBoxTootLogout.Name = "checkBoxTootLogout";
            checkBoxTootLogout.Size = new Size(122, 19);
            checkBoxTootLogout.TabIndex = 20;
            checkBoxTootLogout.Text = "ログアウトを投稿する";
            checkBoxTootLogout.UseVisualStyleBackColor = true;
            checkBoxTootLogout.CheckedChanged += checkBoxTootLogout_CheckedChanged;
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(comboBoxPublishType);
            groupBox8.Controls.Add(buttonPostTest);
            groupBox8.Controls.Add(buttonTootTextUpdate);
            groupBox8.Controls.Add(labelTootTextCount);
            groupBox8.Controls.Add(label5);
            groupBox8.Controls.Add(label4);
            groupBox8.Controls.Add(label3);
            groupBox8.Controls.Add(textBoxServerDomain);
            groupBox8.Controls.Add(label2);
            groupBox8.Controls.Add(label1);
            groupBox8.Controls.Add(textBoxTootText);
            groupBox8.Controls.Add(textBoxAPIKey);
            groupBox8.Location = new Point(12, 426);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(394, 197);
            groupBox8.TabIndex = 21;
            groupBox8.TabStop = false;
            groupBox8.Text = "ノート設定";
            // 
            // comboBoxPublishType
            // 
            comboBoxPublishType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPublishType.FormattingEnabled = true;
            comboBoxPublishType.Items.AddRange(new object[] { "公開", "未収載", "フォロワー限定" });
            comboBoxPublishType.Location = new Point(67, 76);
            comboBoxPublishType.Name = "comboBoxPublishType";
            comboBoxPublishType.Size = new Size(83, 23);
            comboBoxPublishType.TabIndex = 14;
            comboBoxPublishType.SelectedIndexChanged += comboBoxPublishType_SelectedIndexChanged;
            // 
            // buttonPostTest
            // 
            buttonPostTest.Location = new Point(314, 166);
            buttonPostTest.Name = "buttonPostTest";
            buttonPostTest.Size = new Size(74, 23);
            buttonPostTest.TabIndex = 14;
            buttonPostTest.Text = "テスト投稿";
            buttonPostTest.UseVisualStyleBackColor = true;
            buttonPostTest.Click += buttonPostTest_Click;
            // 
            // buttonTootTextUpdate
            // 
            buttonTootTextUpdate.Location = new Point(215, 166);
            buttonTootTextUpdate.Name = "buttonTootTextUpdate";
            buttonTootTextUpdate.Size = new Size(93, 23);
            buttonTootTextUpdate.TabIndex = 14;
            buttonTootTextUpdate.Text = "メッセージ更新";
            buttonTootTextUpdate.UseVisualStyleBackColor = true;
            buttonTootTextUpdate.Click += buttonTootTextUpdate_Click;
            // 
            // labelTootTextCount
            // 
            labelTootTextCount.AutoSize = true;
            labelTootTextCount.Location = new Point(91, 166);
            labelTootTextCount.Name = "labelTootTextCount";
            labelTootTextCount.Size = new Size(42, 15);
            labelTootTextCount.TabIndex = 4;
            labelTootTextCount.Text = "0 / 400";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 79);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 4;
            label5.Text = "公開範囲";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 166);
            label4.Name = "label4";
            label4.Size = new Size(89, 15);
            label4.TabIndex = 4;
            label4.Text = "現在の文字数→";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 55);
            label3.Name = "label3";
            label3.Size = new Size(264, 15);
            label3.TabIndex = 4;
            label3.Text = "トゥートするメッセージ(400文字以内、「@」は使用不可)";
            // 
            // textBoxServerDomain
            // 
            textBoxServerDomain.Location = new Point(55, 25);
            textBoxServerDomain.Name = "textBoxServerDomain";
            textBoxServerDomain.PlaceholderText = "mstdn.jp";
            textBoxServerDomain.Size = new Size(119, 23);
            textBoxServerDomain.TabIndex = 3;
            textBoxServerDomain.Leave += textBoxServerDomain_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(184, 28);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 2;
            label2.Text = "APIキー";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 28);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 2;
            label1.Text = "サーバー";
            // 
            // textBoxTootText
            // 
            textBoxTootText.Location = new Point(6, 105);
            textBoxTootText.MaxLength = 400;
            textBoxTootText.Multiline = true;
            textBoxTootText.Name = "textBoxTootText";
            textBoxTootText.Size = new Size(382, 58);
            textBoxTootText.TabIndex = 3;
            textBoxTootText.UseSystemPasswordChar = true;
            textBoxTootText.TextChanged += textBoxTootText_TextChanged;
            // 
            // textBoxAPIKey
            // 
            textBoxAPIKey.Location = new Point(232, 25);
            textBoxAPIKey.Name = "textBoxAPIKey";
            textBoxAPIKey.Size = new Size(156, 23);
            textBoxAPIKey.TabIndex = 3;
            textBoxAPIKey.UseSystemPasswordChar = true;
            textBoxAPIKey.TextChanged += textBoxAPIKey_TextChanged;
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(dataGridViewSpecifyWorld);
            groupBox9.Controls.Add(checkBoxMaskSpecifyWorldName);
            groupBox9.Controls.Add(buttonAddMuteWorld);
            groupBox9.Controls.Add(checkBoxNotTootSpecifyWorldJoin);
            groupBox9.Location = new Point(412, 27);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new Size(446, 596);
            groupBox9.TabIndex = 22;
            groupBox9.TabStop = false;
            groupBox9.Text = "ワールド名を指定してミュート";
            // 
            // dataGridViewSpecifyWorld
            // 
            dataGridViewSpecifyWorld.AllowUserToAddRows = false;
            dataGridViewSpecifyWorld.AllowUserToDeleteRows = false;
            dataGridViewSpecifyWorld.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSpecifyWorld.Columns.AddRange(new DataGridViewColumn[] { WorldID, WorldName, MuteEnable, DeleteButton });
            dataGridViewSpecifyWorld.Location = new Point(6, 47);
            dataGridViewSpecifyWorld.Name = "dataGridViewSpecifyWorld";
            dataGridViewSpecifyWorld.RowHeadersVisible = false;
            dataGridViewSpecifyWorld.RowHeadersWidth = 72;
            dataGridViewSpecifyWorld.RowTemplate.Height = 35;
            dataGridViewSpecifyWorld.Size = new Size(432, 541);
            dataGridViewSpecifyWorld.TabIndex = 15;
            dataGridViewSpecifyWorld.CellContentClick += dataGridViewSpecifyWorld_CellContentClick;
            dataGridViewSpecifyWorld.CellValueChanged += dataGridViewSpecifyWorld_CellValueChanged;
            dataGridViewSpecifyWorld.MouseUp += dataGridViewSpecifyWorld_MouseUp;
            // 
            // WorldID
            // 
            WorldID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            WorldID.FillWeight = 40F;
            WorldID.HeaderText = "ワールドID";
            WorldID.MinimumWidth = 9;
            WorldID.Name = "WorldID";
            // 
            // WorldName
            // 
            WorldName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            WorldName.FillWeight = 40F;
            WorldName.HeaderText = "ワールド名(メモ用)";
            WorldName.MinimumWidth = 9;
            WorldName.Name = "WorldName";
            // 
            // MuteEnable
            // 
            MuteEnable.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            MuteEnable.FillWeight = 10F;
            MuteEnable.HeaderText = "有効";
            MuteEnable.MinimumWidth = 9;
            MuteEnable.Name = "MuteEnable";
            // 
            // DeleteButton
            // 
            DeleteButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DeleteButton.FillWeight = 10F;
            DeleteButton.HeaderText = "";
            DeleteButton.MinimumWidth = 9;
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Resizable = DataGridViewTriState.True;
            DeleteButton.Text = "削除";
            DeleteButton.UseColumnTextForButtonValue = true;
            // 
            // checkBoxMaskSpecifyWorldName
            // 
            checkBoxMaskSpecifyWorldName.AutoSize = true;
            checkBoxMaskSpecifyWorldName.Location = new Point(177, 22);
            checkBoxMaskSpecifyWorldName.Name = "checkBoxMaskSpecifyWorldName";
            checkBoxMaskSpecifyWorldName.Size = new Size(147, 19);
            checkBoxMaskSpecifyWorldName.TabIndex = 5;
            checkBoxMaskSpecifyWorldName.Text = "ワールド名を本文から隠す";
            checkBoxMaskSpecifyWorldName.UseVisualStyleBackColor = true;
            checkBoxMaskSpecifyWorldName.CheckedChanged += checkBoxMaskSpecifyWorldName_CheckedChanged;
            // 
            // buttonAddMuteWorld
            // 
            buttonAddMuteWorld.Location = new Point(370, 19);
            buttonAddMuteWorld.Name = "buttonAddMuteWorld";
            buttonAddMuteWorld.Size = new Size(68, 23);
            buttonAddMuteWorld.TabIndex = 14;
            buttonAddMuteWorld.Text = "追加";
            buttonAddMuteWorld.UseVisualStyleBackColor = true;
            buttonAddMuteWorld.Click += buttonAddMuteWorld_Click;
            // 
            // checkBoxNotTootSpecifyWorldJoin
            // 
            checkBoxNotTootSpecifyWorldJoin.AutoSize = true;
            checkBoxNotTootSpecifyWorldJoin.Location = new Point(6, 22);
            checkBoxNotTootSpecifyWorldJoin.Name = "checkBoxNotTootSpecifyWorldJoin";
            checkBoxNotTootSpecifyWorldJoin.Size = new Size(165, 19);
            checkBoxNotTootSpecifyWorldJoin.TabIndex = 5;
            checkBoxNotTootSpecifyWorldJoin.Text = "インスタンス移動を投稿しない";
            checkBoxNotTootSpecifyWorldJoin.UseVisualStyleBackColor = true;
            checkBoxNotTootSpecifyWorldJoin.CheckedChanged += checkBoxNotTootSpecifyWorldJoin_CheckedChanged;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(checkBoxGroupPlusJoinURL);
            groupBox6.Controls.Add(checkBoxGroupPlusJoin);
            groupBox6.Location = new Point(212, 108);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(194, 75);
            groupBox6.TabIndex = 13;
            groupBox6.TabStop = false;
            groupBox6.Text = "グループ +";
            // 
            // checkBoxGroupPlusJoinURL
            // 
            checkBoxGroupPlusJoinURL.AutoSize = true;
            checkBoxGroupPlusJoinURL.Location = new Point(6, 47);
            checkBoxGroupPlusJoinURL.Name = "checkBoxGroupPlusJoinURL";
            checkBoxGroupPlusJoinURL.Size = new Size(153, 19);
            checkBoxGroupPlusJoinURL.TabIndex = 6;
            checkBoxGroupPlusJoinURL.Text = "Join用URLを本文に含める";
            checkBoxGroupPlusJoinURL.UseVisualStyleBackColor = true;
            checkBoxGroupPlusJoinURL.CheckedChanged += checkBoxGroupPlusJoinURL_CheckedChanged;
            // 
            // checkBoxGroupPlusJoin
            // 
            checkBoxGroupPlusJoin.AutoSize = true;
            checkBoxGroupPlusJoin.Location = new Point(6, 22);
            checkBoxGroupPlusJoin.Name = "checkBoxGroupPlusJoin";
            checkBoxGroupPlusJoin.Size = new Size(189, 19);
            checkBoxGroupPlusJoin.TabIndex = 5;
            checkBoxGroupPlusJoin.Text = "インスタンス移動時にトゥートを投稿";
            checkBoxGroupPlusJoin.UseVisualStyleBackColor = true;
            checkBoxGroupPlusJoin.CheckedChanged += checkBoxGroupPlusJoin_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(864, 629);
            Controls.Add(groupBox6);
            Controls.Add(groupBox9);
            Controls.Add(groupBox8);
            Controls.Add(checkBoxAutoStart);
            Controls.Add(checkBoxSilentMode);
            Controls.Add(checkBoxTootError);
            Controls.Add(checkBoxDateTimeToot);
            Controls.Add(checkBoxTootLogout);
            Controls.Add(groupBox7);
            Controls.Add(groupBox10);
            Controls.Add(groupBox4);
            Controls.Add(groupBox5);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Form1";
            Text = "VRChat in Here for Mastodon v1.00";
            Shown += Form1_Shown;
            SizeChanged += Form1_SizeChanged;
            contextMenuStrip1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox10.ResumeLayout(false);
            groupBox10.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSpecifyWorld).EndInit();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem ToolStripMenuItem;
        private ToolStripMenuItem ToolStripMenuItem_ResrtSettings;
        private ToolStripMenuItem title;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem ToolStripMenuItemShowWindow;
        private ToolStripMenuItem ToolStripMenuItemSilentMode;
        private ToolStripMenuItem ToolStripMenuItemExit;
        private GroupBox groupBox1;
        private CheckBox checkBoxPublicJoinURL;
        private CheckBox checkBoxPublicJoin;
        private GroupBox groupBox2;
        private CheckBox checkBoxFriendsPlusJoinURL;
        private CheckBox checkBoxFriendsPlusJoin;
        private GroupBox groupBox3;
        private CheckBox checkBoxFriendsOnlyJoinURL;
        private CheckBox checkBoxFriendsOnlyJoin;
        private GroupBox groupBox5;
        private CheckBox checkBoxInvitePlusWorldName;
        private CheckBox checkBoxInvitePlusJoin;
        private GroupBox groupBox4;
        private CheckBox checkBoxGroupPublicJoinURL;
        private CheckBox checkBoxGroupPublicJoin;
        private GroupBox groupBox10;
        private CheckBox checkBoxGroupWorldName;
        private CheckBox checkBoxGroupJoin;
        private GroupBox groupBox7;
        private CheckBox checkBoxPrivateWorldName;
        private CheckBox checkBoxPrivateJoin;
        private CheckBox checkBoxAutoStart;
        private CheckBox checkBoxSilentMode;
        private CheckBox checkBoxTootError;
        private CheckBox checkBoxDateTimeToot;
        private CheckBox checkBoxTootLogout;
        private GroupBox groupBox8;
        private ComboBox comboBoxPublishType;
        private Button buttonPostTest;
        private Button buttonTootTextUpdate;
        private Label labelTootTextCount;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox textBoxServerDomain;
        private Label label2;
        private Label label1;
        private TextBox textBoxTootText;
        private TextBox textBoxAPIKey;
        private GroupBox groupBox9;
        private DataGridView dataGridViewSpecifyWorld;
        private DataGridViewTextBoxColumn WorldID;
        private DataGridViewTextBoxColumn WorldName;
        private DataGridViewCheckBoxColumn MuteEnable;
        private DataGridViewButtonColumn DeleteButton;
        private CheckBox checkBoxMaskSpecifyWorldName;
        private Button buttonAddMuteWorld;
        private CheckBox checkBoxNotTootSpecifyWorldJoin;
        private GroupBox groupBox6;
        private CheckBox checkBoxGroupPlusJoinURL;
        private CheckBox checkBoxGroupPlusJoin;
    }
}
