namespace MilkCanvas.Forms
{
    partial class Canvas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.canvasTabs = new System.Windows.Forms.TabControl();
            this.generalSettingsTab = new System.Windows.Forms.TabPage();
            this.helpLinkLabel = new System.Windows.Forms.LinkLabel();
            this.altAccountNameLabel = new System.Windows.Forms.Label();
            this.reconnectLabel2 = new System.Windows.Forms.Label();
            this.reconnectNumeric = new System.Windows.Forms.NumericUpDown();
            this.reconnectLabel1 = new System.Windows.Forms.Label();
            this.reconnectCheckbox = new System.Windows.Forms.CheckBox();
            this.timeoutLabel2 = new System.Windows.Forms.Label();
            this.timeoutNumeric = new System.Windows.Forms.NumericUpDown();
            this.timeoutLabel1 = new System.Windows.Forms.Label();
            this.commandDelayCheckbox = new System.Windows.Forms.CheckBox();
            this.giftedSubscriptionText = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.resubMessageText = new System.Windows.Forms.TextBox();
            this.resubMessageCheckbox = new System.Windows.Forms.CheckBox();
            this.subMessageText = new System.Windows.Forms.TextBox();
            this.subMessageCheckbox = new System.Windows.Forms.CheckBox();
            this.altAccountLabel = new System.Windows.Forms.Label();
            this.altAccountLogin = new MilkCanvas.Controls.SocialButton();
            this.chatBotCheckbox = new System.Windows.Forms.CheckBox();
            this.taggingSettingsTab = new System.Windows.Forms.TabPage();
            this.modsPseudoTagHelpLabel = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.modsPseudoTagUsersCheckbox = new System.Windows.Forms.CheckBox();
            this.tagUsersCheckbox = new System.Windows.Forms.CheckBox();
            this.permissionsSettingsTab = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.modsRemoveAliasesCheckbox = new System.Windows.Forms.CheckBox();
            this.modsSetAliasesCheckbox = new System.Windows.Forms.CheckBox();
            this.modsRemoveCommandsCheckbox = new System.Windows.Forms.CheckBox();
            this.modsSetCommandsCheckbox = new System.Windows.Forms.CheckBox();
            this.exemptModsDelayCheckbox = new System.Windows.Forms.CheckBox();
            this.pointsSettingsTab = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.loggingSettingsTab = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.notificationsSettingsTab = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.pollsSettingsTab = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.campaignsSettingsTab = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.bookmarksSettingsTab = new System.Windows.Forms.TabPage();
            this.hotkeyComboBox = new System.Windows.Forms.ComboBox();
            this.hotkeyLabelRight = new System.Windows.Forms.Label();
            this.shiftCheckbox = new System.Windows.Forms.CheckBox();
            this.altCheckbox = new System.Windows.Forms.CheckBox();
            this.controlCheckbox = new System.Windows.Forms.CheckBox();
            this.hotkeyLabelLeft = new System.Windows.Forms.Label();
            this.useBookmarkHotkeyCheckbox = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.canvasTabs.SuspendLayout();
            this.generalSettingsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reconnectNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutNumeric)).BeginInit();
            this.taggingSettingsTab.SuspendLayout();
            this.permissionsSettingsTab.SuspendLayout();
            this.pointsSettingsTab.SuspendLayout();
            this.loggingSettingsTab.SuspendLayout();
            this.notificationsSettingsTab.SuspendLayout();
            this.pollsSettingsTab.SuspendLayout();
            this.campaignsSettingsTab.SuspendLayout();
            this.bookmarksSettingsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvasTabs
            // 
            this.canvasTabs.Controls.Add(this.generalSettingsTab);
            this.canvasTabs.Controls.Add(this.taggingSettingsTab);
            this.canvasTabs.Controls.Add(this.permissionsSettingsTab);
            this.canvasTabs.Controls.Add(this.pointsSettingsTab);
            this.canvasTabs.Controls.Add(this.loggingSettingsTab);
            this.canvasTabs.Controls.Add(this.notificationsSettingsTab);
            this.canvasTabs.Controls.Add(this.pollsSettingsTab);
            this.canvasTabs.Controls.Add(this.campaignsSettingsTab);
            this.canvasTabs.Controls.Add(this.bookmarksSettingsTab);
            this.canvasTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasTabs.HotTrack = true;
            this.canvasTabs.Location = new System.Drawing.Point(0, 20);
            this.canvasTabs.Multiline = true;
            this.canvasTabs.Name = "canvasTabs";
            this.canvasTabs.SelectedIndex = 0;
            this.canvasTabs.Size = new System.Drawing.Size(421, 359);
            this.canvasTabs.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.canvasTabs.TabIndex = 1;
            // 
            // generalSettingsTab
            // 
            this.generalSettingsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.generalSettingsTab.Controls.Add(this.helpLinkLabel);
            this.generalSettingsTab.Controls.Add(this.altAccountNameLabel);
            this.generalSettingsTab.Controls.Add(this.reconnectLabel2);
            this.generalSettingsTab.Controls.Add(this.reconnectNumeric);
            this.generalSettingsTab.Controls.Add(this.reconnectLabel1);
            this.generalSettingsTab.Controls.Add(this.reconnectCheckbox);
            this.generalSettingsTab.Controls.Add(this.timeoutLabel2);
            this.generalSettingsTab.Controls.Add(this.timeoutNumeric);
            this.generalSettingsTab.Controls.Add(this.timeoutLabel1);
            this.generalSettingsTab.Controls.Add(this.commandDelayCheckbox);
            this.generalSettingsTab.Controls.Add(this.giftedSubscriptionText);
            this.generalSettingsTab.Controls.Add(this.checkBox2);
            this.generalSettingsTab.Controls.Add(this.resubMessageText);
            this.generalSettingsTab.Controls.Add(this.resubMessageCheckbox);
            this.generalSettingsTab.Controls.Add(this.subMessageText);
            this.generalSettingsTab.Controls.Add(this.subMessageCheckbox);
            this.generalSettingsTab.Controls.Add(this.altAccountLabel);
            this.generalSettingsTab.Controls.Add(this.altAccountLogin);
            this.generalSettingsTab.Controls.Add(this.chatBotCheckbox);
            this.generalSettingsTab.Location = new System.Drawing.Point(4, 40);
            this.generalSettingsTab.Name = "generalSettingsTab";
            this.generalSettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.generalSettingsTab.Size = new System.Drawing.Size(413, 315);
            this.generalSettingsTab.TabIndex = 0;
            this.generalSettingsTab.Text = "General";
            // 
            // helpLinkLabel
            // 
            this.helpLinkLabel.ActiveLinkColor = System.Drawing.Color.Red;
            this.helpLinkLabel.AutoSize = true;
            this.helpLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.helpLinkLabel.Location = new System.Drawing.Point(310, 292);
            this.helpLinkLabel.Name = "helpLinkLabel";
            this.helpLinkLabel.Size = new System.Drawing.Size(97, 13);
            this.helpLinkLabel.TabIndex = 18;
            this.helpLinkLabel.TabStop = true;
            this.helpLinkLabel.Text = "Getting Started";
            this.helpLinkLabel.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(115)))), ((int)(((byte)(150)))));
            this.helpLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.HelpLinkLabel_LinkClicked);
            // 
            // altAccountNameLabel
            // 
            this.altAccountNameLabel.AutoSize = true;
            this.altAccountNameLabel.Location = new System.Drawing.Point(276, 7);
            this.altAccountNameLabel.Name = "altAccountNameLabel";
            this.altAccountNameLabel.Size = new System.Drawing.Size(61, 13);
            this.altAccountNameLabel.TabIndex = 17;
            this.altAccountNameLabel.Text = "{account}";
            this.altAccountNameLabel.Visible = false;
            // 
            // reconnectLabel2
            // 
            this.reconnectLabel2.AutoSize = true;
            this.reconnectLabel2.Location = new System.Drawing.Point(236, 292);
            this.reconnectLabel2.Name = "reconnectLabel2";
            this.reconnectLabel2.Size = new System.Drawing.Size(55, 13);
            this.reconnectLabel2.TabIndex = 16;
            this.reconnectLabel2.Text = "seconds.";
            // 
            // reconnectNumeric
            // 
            this.reconnectNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.reconnectNumeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.reconnectNumeric.Location = new System.Drawing.Point(139, 290);
            this.reconnectNumeric.Name = "reconnectNumeric";
            this.reconnectNumeric.Size = new System.Drawing.Size(91, 20);
            this.reconnectNumeric.TabIndex = 15;
            this.reconnectNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.reconnectNumeric.ValueChanged += new System.EventHandler(this.ReconnectNumeric_ValueChanged);
            // 
            // reconnectLabel1
            // 
            this.reconnectLabel1.AutoSize = true;
            this.reconnectLabel1.Location = new System.Drawing.Point(12, 292);
            this.reconnectLabel1.Name = "reconnectLabel1";
            this.reconnectLabel1.Size = new System.Drawing.Size(121, 13);
            this.reconnectLabel1.TabIndex = 14;
            this.reconnectLabel1.Text = "Retry connect every";
            // 
            // reconnectCheckbox
            // 
            this.reconnectCheckbox.AutoSize = true;
            this.reconnectCheckbox.Location = new System.Drawing.Point(6, 267);
            this.reconnectCheckbox.Name = "reconnectCheckbox";
            this.reconnectCheckbox.Size = new System.Drawing.Size(284, 17);
            this.reconnectCheckbox.TabIndex = 13;
            this.reconnectCheckbox.Text = "Reconnect MilkCanvas if connection is lost.";
            this.reconnectCheckbox.UseVisualStyleBackColor = true;
            this.reconnectCheckbox.CheckedChanged += new System.EventHandler(this.ReconnectCheckbox_CheckedChanged);
            // 
            // timeoutLabel2
            // 
            this.timeoutLabel2.AutoSize = true;
            this.timeoutLabel2.Location = new System.Drawing.Point(236, 242);
            this.timeoutLabel2.Name = "timeoutLabel2";
            this.timeoutLabel2.Size = new System.Drawing.Size(55, 13);
            this.timeoutLabel2.TabIndex = 12;
            this.timeoutLabel2.Text = "seconds.";
            // 
            // timeoutNumeric
            // 
            this.timeoutNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.timeoutNumeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.timeoutNumeric.Location = new System.Drawing.Point(139, 240);
            this.timeoutNumeric.Name = "timeoutNumeric";
            this.timeoutNumeric.Size = new System.Drawing.Size(91, 20);
            this.timeoutNumeric.TabIndex = 11;
            this.timeoutNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timeoutNumeric.ValueChanged += new System.EventHandler(this.TimeoutNumeric_ValueChanged);
            // 
            // timeoutLabel1
            // 
            this.timeoutLabel1.AutoSize = true;
            this.timeoutLabel1.Location = new System.Drawing.Point(6, 242);
            this.timeoutLabel1.Name = "timeoutLabel1";
            this.timeoutLabel1.Size = new System.Drawing.Size(127, 13);
            this.timeoutLabel1.TabIndex = 10;
            this.timeoutLabel1.Text = "Timeout commands for";
            // 
            // commandDelayCheckbox
            // 
            this.commandDelayCheckbox.AutoSize = true;
            this.commandDelayCheckbox.Location = new System.Drawing.Point(6, 218);
            this.commandDelayCheckbox.Name = "commandDelayCheckbox";
            this.commandDelayCheckbox.Size = new System.Drawing.Size(224, 17);
            this.commandDelayCheckbox.TabIndex = 9;
            this.commandDelayCheckbox.Text = "Timeout commands to prevent spam?";
            this.commandDelayCheckbox.UseVisualStyleBackColor = true;
            this.commandDelayCheckbox.CheckedChanged += new System.EventHandler(this.CommandDelayCheckbox_CheckedChanged);
            // 
            // giftedSubscriptionText
            // 
            this.giftedSubscriptionText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.giftedSubscriptionText.Enabled = false;
            this.giftedSubscriptionText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.giftedSubscriptionText.Location = new System.Drawing.Point(8, 192);
            this.giftedSubscriptionText.Name = "giftedSubscriptionText";
            this.giftedSubscriptionText.Size = new System.Drawing.Size(399, 20);
            this.giftedSubscriptionText.TabIndex = 8;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Enabled = false;
            this.checkBox2.ForeColor = System.Drawing.Color.Black;
            this.checkBox2.Location = new System.Drawing.Point(6, 169);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(368, 17);
            this.checkBox2.TabIndex = 7;
            this.checkBox2.Text = "Relay message after a gifted subscription? (coming soon!)";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // resubMessageText
            // 
            this.resubMessageText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.resubMessageText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.resubMessageText.Location = new System.Drawing.Point(8, 143);
            this.resubMessageText.Name = "resubMessageText";
            this.resubMessageText.Size = new System.Drawing.Size(399, 20);
            this.resubMessageText.TabIndex = 6;
            this.resubMessageText.TextChanged += new System.EventHandler(this.ResubMessageText_TextChanged);
            // 
            // resubMessageCheckbox
            // 
            this.resubMessageCheckbox.AutoSize = true;
            this.resubMessageCheckbox.Location = new System.Drawing.Point(6, 120);
            this.resubMessageCheckbox.Name = "resubMessageCheckbox";
            this.resubMessageCheckbox.Size = new System.Drawing.Size(248, 17);
            this.resubMessageCheckbox.TabIndex = 5;
            this.resubMessageCheckbox.Text = "Relay message after a resubscription?";
            this.resubMessageCheckbox.UseVisualStyleBackColor = true;
            this.resubMessageCheckbox.CheckedChanged += new System.EventHandler(this.ResubMessageCheckbox_CheckedChanged);
            // 
            // subMessageText
            // 
            this.subMessageText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.subMessageText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.subMessageText.Location = new System.Drawing.Point(8, 94);
            this.subMessageText.Name = "subMessageText";
            this.subMessageText.Size = new System.Drawing.Size(399, 20);
            this.subMessageText.TabIndex = 4;
            this.subMessageText.TextChanged += new System.EventHandler(this.SubMessageText_TextChanged);
            // 
            // subMessageCheckbox
            // 
            this.subMessageCheckbox.AutoSize = true;
            this.subMessageCheckbox.Location = new System.Drawing.Point(6, 71);
            this.subMessageCheckbox.Name = "subMessageCheckbox";
            this.subMessageCheckbox.Size = new System.Drawing.Size(260, 17);
            this.subMessageCheckbox.TabIndex = 3;
            this.subMessageCheckbox.Text = "Relay message after a new subscription?";
            this.subMessageCheckbox.UseVisualStyleBackColor = true;
            this.subMessageCheckbox.CheckedChanged += new System.EventHandler(this.SubMessageCheckbox_CheckedChanged);
            // 
            // altAccountLabel
            // 
            this.altAccountLabel.AutoSize = true;
            this.altAccountLabel.Location = new System.Drawing.Point(209, 7);
            this.altAccountLabel.Name = "altAccountLabel";
            this.altAccountLabel.Size = new System.Drawing.Size(61, 13);
            this.altAccountLabel.TabIndex = 2;
            this.altAccountLabel.Text = "Account: ";
            this.altAccountLabel.Visible = false;
            // 
            // altAccountLogin
            // 
            this.altAccountLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(64)))), ((int)(((byte)(164)))));
            this.altAccountLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.altAccountLogin.Disabled = false;
            this.altAccountLogin.Location = new System.Drawing.Point(6, 29);
            this.altAccountLogin.Name = "altAccountLogin";
            this.altAccountLogin.Platform = MilkCanvas.Enums.SocialPlatform.Twitch;
            this.altAccountLogin.Size = new System.Drawing.Size(401, 36);
            this.altAccountLogin.TabIndex = 1;
            this.altAccountLogin.Click += new System.EventHandler(this.AltAccountLogin_Click);
            // 
            // chatBotCheckbox
            // 
            this.chatBotCheckbox.AutoSize = true;
            this.chatBotCheckbox.Location = new System.Drawing.Point(6, 6);
            this.chatBotCheckbox.Name = "chatBotCheckbox";
            this.chatBotCheckbox.Size = new System.Drawing.Size(206, 17);
            this.chatBotCheckbox.TabIndex = 0;
            this.chatBotCheckbox.Text = "Alternate Account for Chatbot?";
            this.chatBotCheckbox.UseVisualStyleBackColor = true;
            this.chatBotCheckbox.CheckedChanged += new System.EventHandler(this.ChatBotCheckbox_CheckedChanged);
            // 
            // taggingSettingsTab
            // 
            this.taggingSettingsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.taggingSettingsTab.Controls.Add(this.modsPseudoTagHelpLabel);
            this.taggingSettingsTab.Controls.Add(this.label1);
            this.taggingSettingsTab.Controls.Add(this.modsPseudoTagUsersCheckbox);
            this.taggingSettingsTab.Controls.Add(this.tagUsersCheckbox);
            this.taggingSettingsTab.Location = new System.Drawing.Point(4, 40);
            this.taggingSettingsTab.Name = "taggingSettingsTab";
            this.taggingSettingsTab.Size = new System.Drawing.Size(413, 315);
            this.taggingSettingsTab.TabIndex = 2;
            this.taggingSettingsTab.Text = "Tagging/Mentions";
            // 
            // modsPseudoTagHelpLabel
            // 
            this.modsPseudoTagHelpLabel.ActiveLinkColor = System.Drawing.Color.Red;
            this.modsPseudoTagHelpLabel.AutoSize = true;
            this.modsPseudoTagHelpLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.modsPseudoTagHelpLabel.Location = new System.Drawing.Point(224, 30);
            this.modsPseudoTagHelpLabel.Name = "modsPseudoTagHelpLabel";
            this.modsPseudoTagHelpLabel.Size = new System.Drawing.Size(73, 13);
            this.modsPseudoTagHelpLabel.TabIndex = 19;
            this.modsPseudoTagHelpLabel.TabStop = true;
            this.modsPseudoTagHelpLabel.Text = "Whats this?";
            this.modsPseudoTagHelpLabel.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(115)))), ((int)(((byte)(150)))));
            this.modsPseudoTagHelpLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ModsPseudoTagHelpLabel_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 65);
            this.label1.TabIndex = 3;
            this.label1.Text = "Have suggestions for adding more depth to these options?\r\n\r\nYou can email me at t" +
    "risten@tristenhorton.com\r\n\r\nOr add me on steam at steamcommunity.com/id/TristenM" +
    "ilk";
            // 
            // modsPseudoTagUsersCheckbox
            // 
            this.modsPseudoTagUsersCheckbox.AutoSize = true;
            this.modsPseudoTagUsersCheckbox.Location = new System.Drawing.Point(6, 29);
            this.modsPseudoTagUsersCheckbox.Name = "modsPseudoTagUsersCheckbox";
            this.modsPseudoTagUsersCheckbox.Size = new System.Drawing.Size(212, 17);
            this.modsPseudoTagUsersCheckbox.TabIndex = 2;
            this.modsPseudoTagUsersCheckbox.Text = "Moderators can pseudo tag users";
            this.modsPseudoTagUsersCheckbox.UseVisualStyleBackColor = true;
            this.modsPseudoTagUsersCheckbox.CheckedChanged += new System.EventHandler(this.ModsPseudoTagUsersCheckbox_CheckedChanged);
            // 
            // tagUsersCheckbox
            // 
            this.tagUsersCheckbox.AutoSize = true;
            this.tagUsersCheckbox.Location = new System.Drawing.Point(6, 6);
            this.tagUsersCheckbox.Name = "tagUsersCheckbox";
            this.tagUsersCheckbox.Size = new System.Drawing.Size(188, 17);
            this.tagUsersCheckbox.TabIndex = 1;
            this.tagUsersCheckbox.Text = "Tag users who call commands";
            this.tagUsersCheckbox.UseVisualStyleBackColor = true;
            this.tagUsersCheckbox.CheckedChanged += new System.EventHandler(this.TagUsersCheckbox_CheckedChanged);
            // 
            // permissionsSettingsTab
            // 
            this.permissionsSettingsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.permissionsSettingsTab.Controls.Add(this.label2);
            this.permissionsSettingsTab.Controls.Add(this.modsRemoveAliasesCheckbox);
            this.permissionsSettingsTab.Controls.Add(this.modsSetAliasesCheckbox);
            this.permissionsSettingsTab.Controls.Add(this.modsRemoveCommandsCheckbox);
            this.permissionsSettingsTab.Controls.Add(this.modsSetCommandsCheckbox);
            this.permissionsSettingsTab.Controls.Add(this.exemptModsDelayCheckbox);
            this.permissionsSettingsTab.Location = new System.Drawing.Point(4, 40);
            this.permissionsSettingsTab.Name = "permissionsSettingsTab";
            this.permissionsSettingsTab.Size = new System.Drawing.Size(413, 315);
            this.permissionsSettingsTab.TabIndex = 1;
            this.permissionsSettingsTab.Text = "Permissions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(355, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "These settings have higher precedent than your !permission\r\nsettings.";
            // 
            // modsRemoveAliasesCheckbox
            // 
            this.modsRemoveAliasesCheckbox.AutoSize = true;
            this.modsRemoveAliasesCheckbox.Location = new System.Drawing.Point(6, 98);
            this.modsRemoveAliasesCheckbox.Name = "modsRemoveAliasesCheckbox";
            this.modsRemoveAliasesCheckbox.Size = new System.Drawing.Size(200, 17);
            this.modsRemoveAliasesCheckbox.TabIndex = 6;
            this.modsRemoveAliasesCheckbox.Text = "Moderators can remove aliases";
            this.modsRemoveAliasesCheckbox.UseVisualStyleBackColor = true;
            this.modsRemoveAliasesCheckbox.CheckedChanged += new System.EventHandler(this.ModsRemoveAliasesCheckbox_CheckedChanged);
            // 
            // modsSetAliasesCheckbox
            // 
            this.modsSetAliasesCheckbox.AutoSize = true;
            this.modsSetAliasesCheckbox.Location = new System.Drawing.Point(6, 75);
            this.modsSetAliasesCheckbox.Name = "modsSetAliasesCheckbox";
            this.modsSetAliasesCheckbox.Size = new System.Drawing.Size(182, 17);
            this.modsSetAliasesCheckbox.TabIndex = 5;
            this.modsSetAliasesCheckbox.Text = "Moderators can set aliases";
            this.modsSetAliasesCheckbox.UseVisualStyleBackColor = true;
            this.modsSetAliasesCheckbox.CheckedChanged += new System.EventHandler(this.ModsSetAliasesCheckbox_CheckedChanged);
            // 
            // modsRemoveCommandsCheckbox
            // 
            this.modsRemoveCommandsCheckbox.AutoSize = true;
            this.modsRemoveCommandsCheckbox.Location = new System.Drawing.Point(6, 52);
            this.modsRemoveCommandsCheckbox.Name = "modsRemoveCommandsCheckbox";
            this.modsRemoveCommandsCheckbox.Size = new System.Drawing.Size(236, 17);
            this.modsRemoveCommandsCheckbox.TabIndex = 4;
            this.modsRemoveCommandsCheckbox.Text = "Moderators can remove chat commands";
            this.modsRemoveCommandsCheckbox.UseVisualStyleBackColor = true;
            this.modsRemoveCommandsCheckbox.CheckedChanged += new System.EventHandler(this.ModsRemoveCommandsCheckbox_CheckedChanged);
            // 
            // modsSetCommandsCheckbox
            // 
            this.modsSetCommandsCheckbox.AutoSize = true;
            this.modsSetCommandsCheckbox.Location = new System.Drawing.Point(6, 29);
            this.modsSetCommandsCheckbox.Name = "modsSetCommandsCheckbox";
            this.modsSetCommandsCheckbox.Size = new System.Drawing.Size(218, 17);
            this.modsSetCommandsCheckbox.TabIndex = 3;
            this.modsSetCommandsCheckbox.Text = "Moderators can set chat commands";
            this.modsSetCommandsCheckbox.UseVisualStyleBackColor = true;
            this.modsSetCommandsCheckbox.CheckedChanged += new System.EventHandler(this.ModsSetCommandsCheckbox_CheckedChanged);
            // 
            // exemptModsDelayCheckbox
            // 
            this.exemptModsDelayCheckbox.AutoSize = true;
            this.exemptModsDelayCheckbox.Location = new System.Drawing.Point(6, 6);
            this.exemptModsDelayCheckbox.Name = "exemptModsDelayCheckbox";
            this.exemptModsDelayCheckbox.Size = new System.Drawing.Size(266, 17);
            this.exemptModsDelayCheckbox.TabIndex = 2;
            this.exemptModsDelayCheckbox.Text = "Exempt moderators from the command delay";
            this.exemptModsDelayCheckbox.UseVisualStyleBackColor = true;
            this.exemptModsDelayCheckbox.CheckedChanged += new System.EventHandler(this.ExemptModsDelayCheckbox_CheckedChanged);
            // 
            // pointsSettingsTab
            // 
            this.pointsSettingsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pointsSettingsTab.Controls.Add(this.label3);
            this.pointsSettingsTab.Location = new System.Drawing.Point(4, 40);
            this.pointsSettingsTab.Name = "pointsSettingsTab";
            this.pointsSettingsTab.Size = new System.Drawing.Size(413, 315);
            this.pointsSettingsTab.TabIndex = 3;
            this.pointsSettingsTab.Text = "Points";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Coming Soon!";
            // 
            // loggingSettingsTab
            // 
            this.loggingSettingsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.loggingSettingsTab.Controls.Add(this.label4);
            this.loggingSettingsTab.Location = new System.Drawing.Point(4, 40);
            this.loggingSettingsTab.Name = "loggingSettingsTab";
            this.loggingSettingsTab.Size = new System.Drawing.Size(413, 315);
            this.loggingSettingsTab.TabIndex = 4;
            this.loggingSettingsTab.Text = "Logging";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Coming Soon!";
            // 
            // notificationsSettingsTab
            // 
            this.notificationsSettingsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.notificationsSettingsTab.Controls.Add(this.label5);
            this.notificationsSettingsTab.Location = new System.Drawing.Point(4, 40);
            this.notificationsSettingsTab.Name = "notificationsSettingsTab";
            this.notificationsSettingsTab.Size = new System.Drawing.Size(413, 315);
            this.notificationsSettingsTab.TabIndex = 5;
            this.notificationsSettingsTab.Text = "Notifications";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Coming Soon!";
            // 
            // pollsSettingsTab
            // 
            this.pollsSettingsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pollsSettingsTab.Controls.Add(this.label6);
            this.pollsSettingsTab.Location = new System.Drawing.Point(4, 40);
            this.pollsSettingsTab.Name = "pollsSettingsTab";
            this.pollsSettingsTab.Size = new System.Drawing.Size(413, 315);
            this.pollsSettingsTab.TabIndex = 6;
            this.pollsSettingsTab.Text = "Polls";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Coming Soon!";
            // 
            // campaignsSettingsTab
            // 
            this.campaignsSettingsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.campaignsSettingsTab.Controls.Add(this.label7);
            this.campaignsSettingsTab.Location = new System.Drawing.Point(4, 40);
            this.campaignsSettingsTab.Name = "campaignsSettingsTab";
            this.campaignsSettingsTab.Size = new System.Drawing.Size(413, 315);
            this.campaignsSettingsTab.TabIndex = 7;
            this.campaignsSettingsTab.Text = "Campaigns";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Coming Soon!";
            // 
            // bookmarksSettingsTab
            // 
            this.bookmarksSettingsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bookmarksSettingsTab.Controls.Add(this.label8);
            this.bookmarksSettingsTab.Controls.Add(this.hotkeyComboBox);
            this.bookmarksSettingsTab.Controls.Add(this.hotkeyLabelRight);
            this.bookmarksSettingsTab.Controls.Add(this.shiftCheckbox);
            this.bookmarksSettingsTab.Controls.Add(this.altCheckbox);
            this.bookmarksSettingsTab.Controls.Add(this.controlCheckbox);
            this.bookmarksSettingsTab.Controls.Add(this.hotkeyLabelLeft);
            this.bookmarksSettingsTab.Controls.Add(this.useBookmarkHotkeyCheckbox);
            this.bookmarksSettingsTab.Location = new System.Drawing.Point(4, 40);
            this.bookmarksSettingsTab.Name = "bookmarksSettingsTab";
            this.bookmarksSettingsTab.Size = new System.Drawing.Size(413, 315);
            this.bookmarksSettingsTab.TabIndex = 8;
            this.bookmarksSettingsTab.Text = "Bookmarks";
            // 
            // hotkeyComboBox
            // 
            this.hotkeyComboBox.FormattingEnabled = true;
            this.hotkeyComboBox.Location = new System.Drawing.Point(304, 23);
            this.hotkeyComboBox.Name = "hotkeyComboBox";
            this.hotkeyComboBox.Size = new System.Drawing.Size(101, 21);
            this.hotkeyComboBox.TabIndex = 16;
            this.hotkeyComboBox.SelectedIndexChanged += new System.EventHandler(this.UpdateHotkey);
            // 
            // hotkeyLabelRight
            // 
            this.hotkeyLabelRight.AutoSize = true;
            this.hotkeyLabelRight.Location = new System.Drawing.Point(249, 26);
            this.hotkeyLabelRight.Name = "hotkeyLabelRight";
            this.hotkeyLabelRight.Size = new System.Drawing.Size(49, 13);
            this.hotkeyLabelRight.TabIndex = 15;
            this.hotkeyLabelRight.Text = "Hotkey:";
            // 
            // shiftCheckbox
            // 
            this.shiftCheckbox.AutoSize = true;
            this.shiftCheckbox.Location = new System.Drawing.Point(187, 25);
            this.shiftCheckbox.Name = "shiftCheckbox";
            this.shiftCheckbox.Size = new System.Drawing.Size(56, 17);
            this.shiftCheckbox.TabIndex = 14;
            this.shiftCheckbox.Text = "SHIFT";
            this.shiftCheckbox.UseVisualStyleBackColor = true;
            this.shiftCheckbox.CheckedChanged += new System.EventHandler(this.UpdateHotkey);
            // 
            // altCheckbox
            // 
            this.altCheckbox.AutoSize = true;
            this.altCheckbox.Location = new System.Drawing.Point(137, 25);
            this.altCheckbox.Name = "altCheckbox";
            this.altCheckbox.Size = new System.Drawing.Size(44, 17);
            this.altCheckbox.TabIndex = 13;
            this.altCheckbox.Text = "ALT";
            this.altCheckbox.UseVisualStyleBackColor = true;
            this.altCheckbox.CheckedChanged += new System.EventHandler(this.UpdateHotkey);
            // 
            // controlCheckbox
            // 
            this.controlCheckbox.AutoSize = true;
            this.controlCheckbox.Location = new System.Drawing.Point(81, 25);
            this.controlCheckbox.Name = "controlCheckbox";
            this.controlCheckbox.Size = new System.Drawing.Size(50, 17);
            this.controlCheckbox.TabIndex = 12;
            this.controlCheckbox.Text = "CTRL";
            this.controlCheckbox.UseVisualStyleBackColor = true;
            this.controlCheckbox.CheckedChanged += new System.EventHandler(this.UpdateHotkey);
            // 
            // hotkeyLabelLeft
            // 
            this.hotkeyLabelLeft.AutoSize = true;
            this.hotkeyLabelLeft.Location = new System.Drawing.Point(8, 26);
            this.hotkeyLabelLeft.Name = "hotkeyLabelLeft";
            this.hotkeyLabelLeft.Size = new System.Drawing.Size(67, 13);
            this.hotkeyLabelLeft.TabIndex = 11;
            this.hotkeyLabelLeft.Text = "Modifiers:";
            // 
            // useBookmarkHotkeyCheckbox
            // 
            this.useBookmarkHotkeyCheckbox.AutoSize = true;
            this.useBookmarkHotkeyCheckbox.Location = new System.Drawing.Point(6, 6);
            this.useBookmarkHotkeyCheckbox.Name = "useBookmarkHotkeyCheckbox";
            this.useBookmarkHotkeyCheckbox.Size = new System.Drawing.Size(218, 17);
            this.useBookmarkHotkeyCheckbox.TabIndex = 10;
            this.useBookmarkHotkeyCheckbox.Text = "Use Hotkey to Trigger a Bookmark";
            this.useBookmarkHotkeyCheckbox.UseVisualStyleBackColor = true;
            this.useBookmarkHotkeyCheckbox.CheckedChanged += new System.EventHandler(this.UseBookmarkHotkeyCheckbox_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 284);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(337, 26);
            this.label8.TabIndex = 17;
            this.label8.Text = "If this hotkey isn\'t working, try running MilkCanvas as\r\nAdministrator.";
            // 
            // Canvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 379);
            this.Controls.Add(this.canvasTabs);
            this.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.HeaderText = "";
            this.Name = "Canvas";
            this.Text = "Canvas";
            this.Controls.SetChildIndex(this.canvasTabs, 0);
            this.canvasTabs.ResumeLayout(false);
            this.generalSettingsTab.ResumeLayout(false);
            this.generalSettingsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reconnectNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutNumeric)).EndInit();
            this.taggingSettingsTab.ResumeLayout(false);
            this.taggingSettingsTab.PerformLayout();
            this.permissionsSettingsTab.ResumeLayout(false);
            this.permissionsSettingsTab.PerformLayout();
            this.pointsSettingsTab.ResumeLayout(false);
            this.pointsSettingsTab.PerformLayout();
            this.loggingSettingsTab.ResumeLayout(false);
            this.loggingSettingsTab.PerformLayout();
            this.notificationsSettingsTab.ResumeLayout(false);
            this.notificationsSettingsTab.PerformLayout();
            this.pollsSettingsTab.ResumeLayout(false);
            this.pollsSettingsTab.PerformLayout();
            this.campaignsSettingsTab.ResumeLayout(false);
            this.campaignsSettingsTab.PerformLayout();
            this.bookmarksSettingsTab.ResumeLayout(false);
            this.bookmarksSettingsTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl canvasTabs;
        private System.Windows.Forms.TabPage generalSettingsTab;
        private System.Windows.Forms.CheckBox chatBotCheckbox;
        private Controls.SocialButton altAccountLogin;
        private System.Windows.Forms.Label altAccountLabel;
        private System.Windows.Forms.CheckBox subMessageCheckbox;
        private System.Windows.Forms.TextBox subMessageText;
        private System.Windows.Forms.TextBox resubMessageText;
        private System.Windows.Forms.CheckBox resubMessageCheckbox;
        private System.Windows.Forms.TextBox giftedSubscriptionText;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label timeoutLabel1;
        private System.Windows.Forms.CheckBox commandDelayCheckbox;
        private System.Windows.Forms.Label timeoutLabel2;
        private System.Windows.Forms.NumericUpDown timeoutNumeric;
        private System.Windows.Forms.CheckBox reconnectCheckbox;
        private System.Windows.Forms.Label reconnectLabel2;
        private System.Windows.Forms.NumericUpDown reconnectNumeric;
        private System.Windows.Forms.Label reconnectLabel1;
        private System.Windows.Forms.Label altAccountNameLabel;
        private System.Windows.Forms.TabPage taggingSettingsTab;
        private System.Windows.Forms.TabPage permissionsSettingsTab;
        private System.Windows.Forms.TabPage pointsSettingsTab;
        private System.Windows.Forms.TabPage loggingSettingsTab;
        private System.Windows.Forms.TabPage notificationsSettingsTab;
        private System.Windows.Forms.LinkLabel helpLinkLabel;
        private System.Windows.Forms.CheckBox tagUsersCheckbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox modsPseudoTagUsersCheckbox;
        private System.Windows.Forms.LinkLabel modsPseudoTagHelpLabel;
        private System.Windows.Forms.TabPage pollsSettingsTab;
        private System.Windows.Forms.TabPage campaignsSettingsTab;
        private System.Windows.Forms.TabPage bookmarksSettingsTab;
        private System.Windows.Forms.CheckBox exemptModsDelayCheckbox;
        private System.Windows.Forms.CheckBox modsRemoveAliasesCheckbox;
        private System.Windows.Forms.CheckBox modsSetAliasesCheckbox;
        private System.Windows.Forms.CheckBox modsRemoveCommandsCheckbox;
        private System.Windows.Forms.CheckBox modsSetCommandsCheckbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox useBookmarkHotkeyCheckbox;
        private System.Windows.Forms.Label hotkeyLabelLeft;
        private System.Windows.Forms.CheckBox shiftCheckbox;
        private System.Windows.Forms.CheckBox altCheckbox;
        private System.Windows.Forms.CheckBox controlCheckbox;
        private System.Windows.Forms.ComboBox hotkeyComboBox;
        private System.Windows.Forms.Label hotkeyLabelRight;
        private System.Windows.Forms.Label label8;
    }
}