namespace MilkCanvas.Forms
{
    partial class LoginForm
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
            this.twitchConnectButton = new MilkCanvas.Controls.SocialButton();
            this.mixerConnectButton = new MilkCanvas.Controls.SocialButton();
            this.youtubeConnectButton = new MilkCanvas.Controls.SocialButton();
            this.SuspendLayout();
            // 
            // twitchConnectButton
            // 
            this.twitchConnectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(64)))), ((int)(((byte)(164)))));
            this.twitchConnectButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.twitchConnectButton.Disabled = false;
            this.twitchConnectButton.Location = new System.Drawing.Point(22, 46);
            this.twitchConnectButton.Name = "twitchConnectButton";
            this.twitchConnectButton.Platform = MilkCanvas.Enums.SocialPlatform.Twitch;
            this.twitchConnectButton.Size = new System.Drawing.Size(256, 36);
            this.twitchConnectButton.TabIndex = 1;
            this.twitchConnectButton.Click += new System.EventHandler(this.TwitchConnectButton_Click);
            // 
            // mixerConnectButton
            // 
            this.mixerConnectButton.BackColor = System.Drawing.Color.DimGray;
            this.mixerConnectButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.mixerConnectButton.Disabled = true;
            this.mixerConnectButton.Location = new System.Drawing.Point(22, 88);
            this.mixerConnectButton.Name = "mixerConnectButton";
            this.mixerConnectButton.Platform = MilkCanvas.Enums.SocialPlatform.Mixer;
            this.mixerConnectButton.Size = new System.Drawing.Size(256, 36);
            this.mixerConnectButton.TabIndex = 2;
            // 
            // youtubeConnectButton
            // 
            this.youtubeConnectButton.BackColor = System.Drawing.Color.DimGray;
            this.youtubeConnectButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.youtubeConnectButton.Disabled = true;
            this.youtubeConnectButton.Location = new System.Drawing.Point(22, 130);
            this.youtubeConnectButton.Name = "youtubeConnectButton";
            this.youtubeConnectButton.Platform = MilkCanvas.Enums.SocialPlatform.YouTube;
            this.youtubeConnectButton.Size = new System.Drawing.Size(256, 36);
            this.youtubeConnectButton.TabIndex = 3;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 201);
            this.Controls.Add(this.youtubeConnectButton);
            this.Controls.Add(this.mixerConnectButton);
            this.Controls.Add(this.twitchConnectButton);
            this.HeaderText = "Log In";
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Controls.SetChildIndex(this.twitchConnectButton, 0);
            this.Controls.SetChildIndex(this.mixerConnectButton, 0);
            this.Controls.SetChildIndex(this.youtubeConnectButton, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.SocialButton twitchConnectButton;
        private Controls.SocialButton mixerConnectButton;
        private Controls.SocialButton youtubeConnectButton;
    }
}