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
            this.pointsSettingsTab = new System.Windows.Forms.TabPage();
            this.loggingSettingsTab = new System.Windows.Forms.TabPage();
            this.notificationsSettingsTab = new System.Windows.Forms.TabPage();
            this.pollsSettingsTab = new System.Windows.Forms.TabPage();
            this.campaignsSettingsTab = new System.Windows.Forms.TabPage();
            this.bookmarksSettingsTab = new System.Windows.Forms.TabPage();
            this.canvasTabs.SuspendLayout();
            this.generalSettingsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reconnectNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutNumeric)).BeginInit();
            this.taggingSettingsTab.SuspendLayout();
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
            this.permissionsSettingsTab.Location = new System.Drawing.Point(4, 40);
            this.permissionsSettingsTab.Name = "permissionsSettingsTab";
            this.permissionsSettingsTab.Size = new System.Drawing.Size(413, 315);
            this.permissionsSettingsTab.TabIndex = 1;
            this.permissionsSettingsTab.Text = "Permissions";
            // 
            // pointsSettingsTab
            // 
            this.pointsSettingsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pointsSettingsTab.Location = new System.Drawing.Point(4, 40);
            this.pointsSettingsTab.Name = "pointsSettingsTab";
            this.pointsSettingsTab.Size = new System.Drawing.Size(413, 315);
            this.pointsSettingsTab.TabIndex = 3;
            this.pointsSettingsTab.Text = "Points";
            // 
            // loggingSettingsTab
            // 
            this.loggingSettingsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.loggingSettingsTab.Location = new System.Drawing.Point(4, 40);
            this.loggingSettingsTab.Name = "loggingSettingsTab";
            this.loggingSettingsTab.Size = new System.Drawing.Size(413, 315);
            this.loggingSettingsTab.TabIndex = 4;
            this.loggingSettingsTab.Text = "Logging";
            // 
            // notificationsSettingsTab
            // 
            this.notificationsSettingsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.notificationsSettingsTab.Location = new System.Drawing.Point(4, 40);
            this.notificationsSettingsTab.Name = "notificationsSettingsTab";
            this.notificationsSettingsTab.Size = new System.Drawing.Size(413, 315);
            this.notificationsSettingsTab.TabIndex = 5;
            this.notificationsSettingsTab.Text = "Notifications";
            // 
            // pollsSettingsTab
            // 
            this.pollsSettingsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pollsSettingsTab.Location = new System.Drawing.Point(4, 40);
            this.pollsSettingsTab.Name = "pollsSettingsTab";
            this.pollsSettingsTab.Size = new System.Drawing.Size(413, 315);
            this.pollsSettingsTab.TabIndex = 6;
            this.pollsSettingsTab.Text = "Polls";
            // 
            // campaignsSettingsTab
            // 
            this.campaignsSettingsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.campaignsSettingsTab.Location = new System.Drawing.Point(4, 40);
            this.campaignsSettingsTab.Name = "campaignsSettingsTab";
            this.campaignsSettingsTab.Size = new System.Drawing.Size(413, 315);
            this.campaignsSettingsTab.TabIndex = 7;
            this.campaignsSettingsTab.Text = "Campaigns";
            // 
            // bookmarksSettingsTab
            // 
            this.bookmarksSettingsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bookmarksSettingsTab.Location = new System.Drawing.Point(4, 40);
            this.bookmarksSettingsTab.Name = "bookmarksSettingsTab";
            this.bookmarksSettingsTab.Size = new System.Drawing.Size(413, 315);
            this.bookmarksSettingsTab.TabIndex = 8;
            this.bookmarksSettingsTab.Text = "Bookmarks";
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
    }
}