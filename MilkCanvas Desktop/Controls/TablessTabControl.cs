namespace MilkCanvas.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public class TablessTabControl : TabControl
    {
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x1328 && !this.DesignMode)
            {
                m.Result = (IntPtr)1;
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
}
