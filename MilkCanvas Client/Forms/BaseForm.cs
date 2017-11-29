namespace MilkCanvas.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class BaseForm : Form, IMessageFilter
    {
        public BaseForm()
        {
            this.InitializeComponent();

            Application.AddMessageFilter(this);
        }

        /// <summary>
        /// Gets or sets the text displayed in the center of the bar.
        /// </summary>
        [Description("The text displayed in the center of the bar.")]
        [Category("Appearance")]
        public string HeaderText
        {
            get => this.actionBar.HeaderText;
            set => this.actionBar.HeaderText = value;
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_LBUTTONDOWN && this.actionBar.VerifyHandle(m.HWnd))
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(this.Handle, NativeMethods.WM_NCLBUTTONDOWN, NativeMethods.HT_CAPTION, 0);
                return true;
            }

            return false;
        }

        protected virtual void ActionBar_OnCloseRequested(object sender, EventArgs e)
        {
            this.Close();
        }

        protected virtual void ActionBar_OnMinimizeRequested(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        protected virtual void ActionBar_OnSizeSwapRequested(object sender, EventArgs e)
        {
            switch (this.WindowState)
            {
                case FormWindowState.Normal:
                    this.WindowState = FormWindowState.Maximized;
                    break;
                case FormWindowState.Maximized:
                    this.WindowState = FormWindowState.Normal;
                    break;
            }
        }
    }
}
