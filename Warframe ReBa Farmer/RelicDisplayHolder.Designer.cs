namespace Warframe_ReBa_Farmer
{
    partial class RelicDisplayHolder
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
            this.components = new System.ComponentModel.Container();
            this.Label_Title = new System.Windows.Forms.Label();
            this.contextMenuStrip_Fissure = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.FLP_RotationHolder = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox_RelicTier = new System.Windows.Forms.PictureBox();
            this.toolTip_Holder = new System.Windows.Forms.ToolTip(this.components);
            this.copyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_Fissure.SuspendLayout();
            this.FLP_RotationHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_RelicTier)).BeginInit();
            this.SuspendLayout();
            // 
            // Label_Title
            // 
            this.Label_Title.ContextMenuStrip = this.contextMenuStrip_Fissure;
            this.Label_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.Label_Title.Location = new System.Drawing.Point(2, 0);
            this.Label_Title.Margin = new System.Windows.Forms.Padding(2);
            this.Label_Title.Name = "Label_Title";
            this.Label_Title.Size = new System.Drawing.Size(252, 16);
            this.Label_Title.TabIndex = 1;
            this.Label_Title.Text = "Title";
            this.Label_Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // contextMenuStrip_Fissure
            // 
            this.contextMenuStrip_Fissure.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToClipboardToolStripMenuItem});
            this.contextMenuStrip_Fissure.Name = "contextMenuStrip1";
            this.contextMenuStrip_Fissure.Size = new System.Drawing.Size(181, 48);
            // 
            // FLP_RotationHolder
            // 
            this.FLP_RotationHolder.ContextMenuStrip = this.contextMenuStrip_Fissure;
            this.FLP_RotationHolder.Controls.Add(this.label1);
            this.FLP_RotationHolder.Controls.Add(this.label2);
            this.FLP_RotationHolder.Controls.Add(this.label3);
            this.FLP_RotationHolder.Location = new System.Drawing.Point(52, 18);
            this.FLP_RotationHolder.Margin = new System.Windows.Forms.Padding(4, 2, 2, 2);
            this.FLP_RotationHolder.Name = "FLP_RotationHolder";
            this.FLP_RotationHolder.Size = new System.Drawing.Size(202, 44);
            this.FLP_RotationHolder.TabIndex = 5;
            this.FLP_RotationHolder.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.FLP_RotationHolder_ControlAdded);
            // 
            // label1
            // 
            this.label1.ContextMenuStrip = this.contextMenuStrip_Fissure;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Test1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.ContextMenuStrip = this.contextMenuStrip_Fissure;
            this.label2.Location = new System.Drawing.Point(0, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Test2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.ContextMenuStrip = this.contextMenuStrip_Fissure;
            this.label3.Location = new System.Drawing.Point(0, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Test3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox_RelicTier
            // 
            this.pictureBox_RelicTier.BackgroundImage = global::Warframe_ReBa_Farmer.Properties.Resources.VoidT4;
            this.pictureBox_RelicTier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox_RelicTier.ContextMenuStrip = this.contextMenuStrip_Fissure;
            this.pictureBox_RelicTier.Location = new System.Drawing.Point(2, 18);
            this.pictureBox_RelicTier.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_RelicTier.Name = "pictureBox_RelicTier";
            this.pictureBox_RelicTier.Size = new System.Drawing.Size(44, 44);
            this.pictureBox_RelicTier.TabIndex = 0;
            this.pictureBox_RelicTier.TabStop = false;
            // 
            // toolTip_Holder
            // 
            this.toolTip_Holder.AutoPopDelay = 0;
            this.toolTip_Holder.InitialDelay = 500;
            this.toolTip_Holder.ReshowDelay = 100;
            // 
            // copyToClipboardToolStripMenuItem
            // 
            this.copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
            this.copyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyToClipboardToolStripMenuItem.Text = "Copy to Clipboard";
            this.copyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyToClipboardToolStripMenuItem_Click);
            // 
            // RelicDisplayHolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.contextMenuStrip_Fissure;
            this.Controls.Add(this.FLP_RotationHolder);
            this.Controls.Add(this.Label_Title);
            this.Controls.Add(this.pictureBox_RelicTier);
            this.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.Name = "RelicDisplayHolder";
            this.Size = new System.Drawing.Size(256, 64);
            this.contextMenuStrip_Fissure.ResumeLayout(false);
            this.FLP_RotationHolder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_RelicTier)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel FLP_RotationHolder;
        private System.Windows.Forms.PictureBox pictureBox_RelicTier;
        private System.Windows.Forms.Label Label_Title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip_Holder;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Fissure;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem;
    }
}
