namespace Warframe_ReBa_Farmer
{
    partial class Form_OverlayBaro
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
            this.VaultSymbol = new System.Windows.Forms.PictureBox();
            this.PlatinumHolder = new System.Windows.Forms.FlowLayoutPanel();
            this.PlatinumPic = new System.Windows.Forms.Label();
            this.PlatinumLabelMin = new System.Windows.Forms.Label();
            this.PlatinumLabelAvg = new System.Windows.Forms.Label();
            this.PlatinumLabelMax = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.VaultSymbol)).BeginInit();
            this.PlatinumHolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // VaultSymbol
            // 
            this.VaultSymbol.BackColor = System.Drawing.Color.Green;
            this.VaultSymbol.BackgroundImage = global::Warframe_ReBa_Farmer.Properties.Resources.PrimeVaultSmall;
            this.VaultSymbol.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.VaultSymbol.Location = new System.Drawing.Point(0, 66);
            this.VaultSymbol.Margin = new System.Windows.Forms.Padding(38, 4, 0, 0);
            this.VaultSymbol.Name = "VaultSymbol";
            this.VaultSymbol.Size = new System.Drawing.Size(160, 30);
            this.VaultSymbol.TabIndex = 7;
            this.VaultSymbol.TabStop = false;
            // 
            // PlatinumHolder
            // 
            this.PlatinumHolder.BackColor = System.Drawing.SystemColors.Control;
            this.PlatinumHolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlatinumHolder.Controls.Add(this.PlatinumPic);
            this.PlatinumHolder.Controls.Add(this.PlatinumLabelMin);
            this.PlatinumHolder.Controls.Add(this.PlatinumLabelAvg);
            this.PlatinumHolder.Controls.Add(this.PlatinumLabelMax);
            this.PlatinumHolder.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.PlatinumHolder.Location = new System.Drawing.Point(0, 0);
            this.PlatinumHolder.Margin = new System.Windows.Forms.Padding(38, 4, 0, 0);
            this.PlatinumHolder.MaximumSize = new System.Drawing.Size(160, 64);
            this.PlatinumHolder.Name = "PlatinumHolder";
            this.PlatinumHolder.Size = new System.Drawing.Size(160, 64);
            this.PlatinumHolder.TabIndex = 6;
            // 
            // PlatinumPic
            // 
            this.PlatinumPic.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlatinumPic.Image = global::Warframe_ReBa_Farmer.Properties.Resources.Platinum;
            this.PlatinumPic.Location = new System.Drawing.Point(5, 0);
            this.PlatinumPic.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.PlatinumPic.Name = "PlatinumPic";
            this.PlatinumPic.Size = new System.Drawing.Size(64, 64);
            this.PlatinumPic.TabIndex = 0;
            this.PlatinumPic.Text = "0";
            this.PlatinumPic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlatinumLabelMin
            // 
            this.PlatinumLabelMin.AutoSize = true;
            this.PlatinumLabelMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlatinumLabelMin.Location = new System.Drawing.Point(79, 3);
            this.PlatinumLabelMin.Margin = new System.Windows.Forms.Padding(10, 3, 0, 0);
            this.PlatinumLabelMin.Name = "PlatinumLabelMin";
            this.PlatinumLabelMin.Size = new System.Drawing.Size(42, 16);
            this.PlatinumLabelMin.TabIndex = 1;
            this.PlatinumLabelMin.Tag = "Min: ";
            this.PlatinumLabelMin.Text = "Min: 0";
            this.PlatinumLabelMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlatinumLabelAvg
            // 
            this.PlatinumLabelAvg.AutoSize = true;
            this.PlatinumLabelAvg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlatinumLabelAvg.Location = new System.Drawing.Point(79, 22);
            this.PlatinumLabelAvg.Margin = new System.Windows.Forms.Padding(10, 3, 0, 0);
            this.PlatinumLabelAvg.Name = "PlatinumLabelAvg";
            this.PlatinumLabelAvg.Size = new System.Drawing.Size(48, 16);
            this.PlatinumLabelAvg.TabIndex = 2;
            this.PlatinumLabelAvg.Tag = "Avg: ";
            this.PlatinumLabelAvg.Text = "Avg:  0";
            this.PlatinumLabelAvg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlatinumLabelMax
            // 
            this.PlatinumLabelMax.AutoSize = true;
            this.PlatinumLabelMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlatinumLabelMax.Location = new System.Drawing.Point(79, 41);
            this.PlatinumLabelMax.Margin = new System.Windows.Forms.Padding(10, 3, 0, 0);
            this.PlatinumLabelMax.Name = "PlatinumLabelMax";
            this.PlatinumLabelMax.Size = new System.Drawing.Size(46, 16);
            this.PlatinumLabelMax.TabIndex = 3;
            this.PlatinumLabelMax.Tag = "Max: ";
            this.PlatinumLabelMax.Text = "Max: 0";
            this.PlatinumLabelMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form_OverlayBaro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(160, 96);
            this.Controls.Add(this.VaultSymbol);
            this.Controls.Add(this.PlatinumHolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_OverlayBaro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form_Baro";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Green;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_OverlayBaro_FormClosed);
            this.Load += new System.EventHandler(this.Form_OverlayBaro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VaultSymbol)).EndInit();
            this.PlatinumHolder.ResumeLayout(false);
            this.PlatinumHolder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox VaultSymbol;
        internal System.Windows.Forms.FlowLayoutPanel PlatinumHolder;
        internal System.Windows.Forms.Label PlatinumPic;
        internal System.Windows.Forms.Label PlatinumLabelMin;
        internal System.Windows.Forms.Label PlatinumLabelAvg;
        internal System.Windows.Forms.Label PlatinumLabelMax;
    }
}