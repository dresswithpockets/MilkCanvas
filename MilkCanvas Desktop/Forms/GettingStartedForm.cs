namespace MilkCanvas.Forms
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

    public partial class GettingStartedForm : BaseForm
    {
        public GettingStartedForm()
        {
            this.InitializeComponent();
        }

        private void NextPageButton_Click(object sender, EventArgs e)
        {
            if (this.gettingStartedTabs.TabIndex < this.gettingStartedTabs.TabCount)
            {
                this.gettingStartedTabs.TabIndex++;
            }
            else
            {
                this.Close();
            }
        }
    }
}
