namespace MilkCanvas.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// A dockable control with useful features for a centered header text, as well as form control buttons.
    /// </summary>
    public partial class ActionBar : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionBar"/> class.
        /// </summary>
        public ActionBar()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Raised when the user requests to close the form.
        /// </summary>
        [Description("Raised when the user requests to close the form.")]
        [Category("Action")]
        public event EventHandler OnCloseRequested;

        /// <summary>
        /// Raised when the user requests to maximize or unmaximize the form.
        /// </summary>
        [Description("Raised when the user requests to maximize or unmaximize the form.")]
        [Category("Action")]
        public event EventHandler OnSizeSwapRequested;

        /// <summary>
        /// Raised when the user requests to minimize the form.
        /// </summary>
        [Description("Raised when the user requests to minimize the form.")]
        [Category("Action")]
        public event EventHandler OnMinimizeRequested;

        /// <summary>
        /// Gets or sets a value indicating whether or not the Maximize Button should react to the user's input.
        /// </summary>
        [Description("Whether or not the Maximize Button should react to the user.")]
        [Category("Behavior")]
        public bool EnableMaximizeButton
        {
            get => this.maximizeButton.Enabled;
            set => this.maximizeButton.Enabled = value;
        }

        /// <summary>
        /// Gets or sets the text displayed in the center of the action bar.
        /// </summary>
        [Description("The text displayed in the center of the bar.")]
        [Category("Appearance")]
        public string HeaderText
        {
            get => this.textLabel.Text;
            set
            {
                this.textLabel.Text = value;
                var newLoc = this.textLabel.Location;
                newLoc.X = (this.Size.Width / 2) - (this.textLabel.Width / 2);
                this.textLabel.Location = newLoc;
            }
        }

        /// <summary>
        /// Whether or not <paramref name="hWnd"/> represents any of the controls in this control.
        /// </summary>
        /// <param name="hWnd">The handle to compare against this control.</param>
        /// <returns>True if <paramref name="hWnd"/> represents any of the controls in this control. False otherwise.</returns>
        public bool VerifyHandle(IntPtr hWnd)
        {
            var control = FromHandle(hWnd)?.GetHashCode();

            return this.canvasLabel.GetHashCode().Equals(control) ||
                this.textLabel.GetHashCode().Equals(control) ||
                this.GetHashCode().Equals(control);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.OnCloseRequested?.Invoke(sender, e);
        }

        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            this.OnSizeSwapRequested?.Invoke(sender, e);
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.OnMinimizeRequested?.Invoke(sender, e);
        }
    }
}
