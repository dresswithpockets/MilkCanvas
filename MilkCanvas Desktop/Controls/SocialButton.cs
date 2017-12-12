namespace MilkCanvas.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using MilkCanvas.Enums;

    public partial class SocialButton : UserControl
    {
        private Color twitchPurple = Color.FromArgb(255, 100, 64, 164);
        private Color mixerBlue = Color.FromArgb(255, 0, 120, 215);
        private Color youtubeRed = Color.FromArgb(255, 255, 0, 0);
        private Color disabledGray = Color.DimGray;

        private Image twitchLogo = Properties.Resources.Glitch_White_RGB;
        private Image mixerLogo = Properties.Resources.MixerMerge_White;
        private Image youtubeLogo = Properties.Resources.yt_icon_mono_dark;

        private string twitchText = "log in with Twitch";
        private string mixerText = "log in with Mixer";
        private string youtubeText = "log in with YouTube";

        private bool disabled;
        private SocialPlatform platform;

        public SocialButton()
        {
            this.InitializeComponent();

            this.UpdatePlatform();
            this.UpdateDisabled();
        }

        public new event EventHandler Click
        {
            add
            {
                base.Click += value;
                foreach (Control control in this.Controls)
                {
                    control.Click += value;
                }
            }

            remove
            {
                base.Click -= value;
                foreach (Control control in this.Controls)
                {
                    control.Click -= value;
                }
            }
        }

        public SocialPlatform Platform
        {
            get => this.platform;
            set
            {
                this.platform = value;
                this.UpdatePlatform();
                this.UpdateDisabled();
            }
        }

        public bool Disabled
        {
            get => this.disabled;
            set
            {
                this.disabled = value;
                this.UpdateDisabled();
            }
        }

        private void UpdatePlatform()
        {
            switch (this.Platform)
            {
                case SocialPlatform.Twitch:
                    this.connectText.Text = this.twitchText;
                    this.logoBox.BackgroundImage = this.twitchLogo;
                    this.BackColor = this.twitchPurple;
                    break;
                case SocialPlatform.Mixer:
                    this.connectText.Text = this.mixerText;
                    this.logoBox.BackgroundImage = this.mixerLogo;
                    this.BackColor = this.mixerBlue;
                    break;
                case SocialPlatform.YouTube:
                    this.connectText.Text = this.youtubeText;
                    this.logoBox.BackgroundImage = this.youtubeLogo;
                    this.BackColor = this.youtubeRed;
                    break;
            }
        }

        private void UpdateDisabled()
        {
            if (this.Disabled)
            {
                this.BackColor = this.disabledGray;
                this.Cursor = Cursors.Arrow;
            }
            else
            {
                this.Cursor = Cursors.Hand;
                this.UpdatePlatform();
            }
        }
    }
}
