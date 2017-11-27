using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkCanvas_Client
{
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

        public new event EventHandler Click
        {
            add
            {
                base.Click += value;
                foreach (Control control in Controls)
                {
                    control.Click += value;
                }
            }
            remove
            {
                base.Click -= value;
                foreach (Control control in Controls)
                {
                    control.Click -= value;
                }
            }
        }

        public SocialPlatform Platform
        {
            get => platform;
            set
            {
                platform = value;
                UpdatePlatform();
                UpdateDisabled();
            }
        }

        public bool Disabled
        {
            get => disabled;
            set
            {
                disabled = value;
                UpdateDisabled();
            }
        }

        public SocialButton()
        {
            InitializeComponent();

            UpdatePlatform();
            UpdateDisabled();
        }

        private void UpdatePlatform()
        {
            switch (Platform)
            {
                case SocialPlatform.Twitch:
                    connectText.Text = twitchText;
                    logoBox.BackgroundImage = twitchLogo;
                    BackColor = twitchPurple;
                    break;
                case SocialPlatform.Mixer:
                    connectText.Text = mixerText;
                    logoBox.BackgroundImage = mixerLogo;
                    BackColor = mixerBlue;
                    break;
                case SocialPlatform.YouTube:
                    connectText.Text = youtubeText;
                    logoBox.BackgroundImage = youtubeLogo;
                    BackColor = youtubeRed;
                    break;
            }
        }

        private void UpdateDisabled()
        {
            if (Disabled)
            {
                BackColor = disabledGray;
                Cursor = Cursors.Arrow;
            }
            else
            {
                Cursor = Cursors.Hand;
                UpdatePlatform();
            }
        }
    }

    public enum SocialPlatform
    {
        Twitch,
        Mixer,
        YouTube
    }
}
