namespace MilkCanvas.Forms
{
    partial class BaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.actionBar = new MilkCanvas.Controls.ActionBar();
            this.SuspendLayout();
            // 
            // actionBar
            // 
            this.actionBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.actionBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.actionBar.EnableMaximizeButton = false;
            this.actionBar.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.actionBar.HeaderText = "Header Text";
            this.actionBar.Location = new System.Drawing.Point(0, 0);
            this.actionBar.Name = "actionBar";
            this.actionBar.Size = new System.Drawing.Size(300, 20);
            this.actionBar.TabIndex = 0;
            this.actionBar.OnCloseRequested += new System.EventHandler(this.ActionBar_OnCloseRequested);
            this.actionBar.OnSizeSwapRequested += new System.EventHandler(this.ActionBar_OnSizeSwapRequested);
            this.actionBar.OnMinimizeRequested += new System.EventHandler(this.ActionBar_OnMinimizeRequested);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(300, 350);
            this.Controls.Add(this.actionBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);

        }

        #endregion

        private MilkCanvas.Controls.ActionBar actionBar;
    }
}

