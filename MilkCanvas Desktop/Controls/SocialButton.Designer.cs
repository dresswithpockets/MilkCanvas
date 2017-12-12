namespace MilkCanvas.Controls
{
    partial class SocialButton
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.connectText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // logoBox
            // 
            this.logoBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logoBox.Location = new System.Drawing.Point(3, 3);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(30, 30);
            this.logoBox.TabIndex = 0;
            this.logoBox.TabStop = false;
            // 
            // connectText
            // 
            this.connectText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.connectText.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectText.ForeColor = System.Drawing.Color.White;
            this.connectText.Location = new System.Drawing.Point(39, 3);
            this.connectText.Name = "connectText";
            this.connectText.Size = new System.Drawing.Size(214, 30);
            this.connectText.TabIndex = 1;
            this.connectText.Text = "log in with YouTube";
            this.connectText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SocialButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.connectText);
            this.Controls.Add(this.logoBox);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "SocialButton";
            this.Size = new System.Drawing.Size(256, 36);
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.Label connectText;
    }
}
