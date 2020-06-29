namespace Warframe_ReBa_Farmer
{
    partial class Form_OverlayRelic
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
            this.components = new System.ComponentModel.Container();
            this.CloseTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // CloseTimer
            // 
            this.CloseTimer.Interval = 10000;
            this.CloseTimer.Tick += new System.EventHandler(this.CloseTimer_Tick);
            // 
            // Form_OverlayRelic
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(1920, 140);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(9999, 9999);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_OverlayRelic";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form_OverlayRelic";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Green;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_OverlayRelic_FormClosed);
            this.Load += new System.EventHandler(this.Form_OverlayRelic_Load);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Timer CloseTimer;
    }
}