namespace MilkCanvas.Forms
{
    partial class GettingStartedForm
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
            this.nextPageButton = new System.Windows.Forms.Button();
            this.gettingStarted1 = new System.Windows.Forms.TabPage();
            this.gettingStartedBox1 = new System.Windows.Forms.PictureBox();
            this.gettingStartedTabs = new MilkCanvas.Controls.TablessTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gettingStarted1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gettingStartedBox1)).BeginInit();
            this.gettingStartedTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // nextPageButton
            // 
            this.nextPageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextPageButton.FlatAppearance.BorderSize = 0;
            this.nextPageButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.nextPageButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.nextPageButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nextPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextPageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextPageButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.nextPageButton.Location = new System.Drawing.Point(221, 318);
            this.nextPageButton.Name = "nextPageButton";
            this.nextPageButton.Size = new System.Drawing.Size(65, 20);
            this.nextPageButton.TabIndex = 1;
            this.nextPageButton.Text = "Got it!";
            this.nextPageButton.UseVisualStyleBackColor = true;
            this.nextPageButton.Click += new System.EventHandler(this.NextPageButton_Click);
            // 
            // gettingStarted1
            // 
            this.gettingStarted1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gettingStarted1.Controls.Add(this.gettingStartedBox1);
            this.gettingStarted1.Location = new System.Drawing.Point(4, 22);
            this.gettingStarted1.Name = "gettingStarted1";
            this.gettingStarted1.Padding = new System.Windows.Forms.Padding(3);
            this.gettingStarted1.Size = new System.Drawing.Size(264, 260);
            this.gettingStarted1.TabIndex = 0;
            this.gettingStarted1.Text = "A";
            // 
            // gettingStartedBox1
            // 
            this.gettingStartedBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gettingStartedBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gettingStartedBox1.Image = global::MilkCanvas.Properties.Resources.GettingStarted1;
            this.gettingStartedBox1.Location = new System.Drawing.Point(3, 3);
            this.gettingStartedBox1.Name = "gettingStartedBox1";
            this.gettingStartedBox1.Size = new System.Drawing.Size(258, 254);
            this.gettingStartedBox1.TabIndex = 0;
            this.gettingStartedBox1.TabStop = false;
            // 
            // gettingStartedTabs
            // 
            this.gettingStartedTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gettingStartedTabs.Controls.Add(this.gettingStarted1);
            this.gettingStartedTabs.Controls.Add(this.tabPage1);
            this.gettingStartedTabs.Location = new System.Drawing.Point(14, 26);
            this.gettingStartedTabs.Name = "gettingStartedTabs";
            this.gettingStartedTabs.SelectedIndex = 0;
            this.gettingStartedTabs.Size = new System.Drawing.Size(272, 286);
            this.gettingStartedTabs.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(264, 260);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "tabPage1";
            // 
            // GettingStartedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 350);
            this.Controls.Add(this.gettingStartedTabs);
            this.Controls.Add(this.nextPageButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderText = "Getting Started";
            this.Name = "GettingStartedForm";
            this.Text = "BeginnerForm";
            this.Controls.SetChildIndex(this.nextPageButton, 0);
            this.Controls.SetChildIndex(this.gettingStartedTabs, 0);
            this.gettingStarted1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gettingStartedBox1)).EndInit();
            this.gettingStartedTabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button nextPageButton;
        private System.Windows.Forms.TabPage gettingStarted1;
        private System.Windows.Forms.PictureBox gettingStartedBox1;
        private Controls.TablessTabControl gettingStartedTabs;
        private System.Windows.Forms.TabPage tabPage1;
    }
}