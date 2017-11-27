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

namespace MilkCanvas_Client
{
    public partial class BaseForm : Form, IMessageFilter
    {
        [Description("The text displayed in the center of the bar."), Category("Appearance")]
        public string HeaderText
        {
            get => actionBar.HeaderText;
            set => actionBar.HeaderText = value;
        }

        public BaseForm()
        {
            InitializeComponent();

            Application.AddMessageFilter(this);
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_LBUTTONDOWN && actionBar.VerifyHandle(m.HWnd))
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, NativeMethods.WM_NCLBUTTONDOWN, NativeMethods.HT_CAPTION, 0);
                return true;
            }

            return false;
        }

        protected virtual void actionBar_OnCloseRequested(object sender, EventArgs e)
        {
            Close();
        }

        protected virtual void actionBar_OnMinimizeRequested(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        protected virtual void actionBar_OnSizeSwapRequested(object sender, EventArgs e)
        {
            switch (WindowState)
            {
                case FormWindowState.Normal:
                    WindowState = FormWindowState.Maximized;
                    break;
                case FormWindowState.Maximized:
                    WindowState = FormWindowState.Normal;
                    break;
            }
        }
    }
}
