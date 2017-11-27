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
    public partial class ActionBar : UserControl
    {
        [Description("Whether or not the Maximize Button should react to the user."), Category("Behavior")]
        public bool EnableMaximizeButton
        {
            get => maximizeButton.Enabled;
            set => maximizeButton.Enabled = value;
        }

        [Description("The text displayed in the center of the bar."), Category("Appearance")]
        public string HeaderText
        {
            get => textLabel.Text;
            set
            {
                textLabel.Text = value;
                var newLoc = textLabel.Location;
                newLoc.X = (Size.Width / 2) - (textLabel.Width / 2);
                textLabel.Location = newLoc;
            }
        }

        [Description("Raised when the user requests to close the form."), Category("Action")]
        public event EventHandler OnCloseRequested;
        [Description("Raised when the user requests to maximize or unmaximize the form."), Category("Action")]
        public event EventHandler OnSizeSwapRequested;
        [Description("Raised when the user requests to minimize the form."), Category("Action")]
        public event EventHandler OnMinimizeRequested;

        public ActionBar()
        {
            InitializeComponent();
        }

        public bool VerifyHandle(IntPtr hWnd)
        {
            var control = FromHandle(hWnd).GetHashCode();

            return canvasLabel.GetHashCode().Equals(control) ||
                textLabel.GetHashCode().Equals(control) ||
                GetHashCode().Equals(control);
        }

        private void closeButton_Click(object sender, EventArgs e)
            => OnCloseRequested?.Invoke(sender, e);

        private void maximizeButton_Click(object sender, EventArgs e)
            => OnSizeSwapRequested?.Invoke(sender, e);

        private void minimizeButton_Click(object sender, EventArgs e)
            => OnMinimizeRequested?.Invoke(sender, e);
    }
}
