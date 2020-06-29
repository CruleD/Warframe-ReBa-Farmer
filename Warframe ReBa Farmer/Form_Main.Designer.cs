namespace Warframe_ReBa_Farmer
{
    partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.PrimeData_DL_btn = new System.Windows.Forms.Button();
            this.Relic_Groupbox = new System.Windows.Forms.GroupBox();
            this.Focus_Label = new System.Windows.Forms.Label();
            this.Relic_Button = new System.Windows.Forms.Button();
            this.FLP_ScanType = new System.Windows.Forms.FlowLayoutPanel();
            this.RB_Single = new System.Windows.Forms.RadioButton();
            this.RB_Continuous = new System.Windows.Forms.RadioButton();
            this.FLP_PlayerCount = new System.Windows.Forms.FlowLayoutPanel();
            this.PlayerCount_2 = new System.Windows.Forms.RadioButton();
            this.PlayerCount_3 = new System.Windows.Forms.RadioButton();
            this.PlayerCount_4 = new System.Windows.Forms.RadioButton();
            this.PlayerCount_Auto = new System.Windows.Forms.RadioButton();
            this.Fissure_GroupBox = new System.Windows.Forms.GroupBox();
            this.checkBox_T5 = new System.Windows.Forms.CheckBox();
            this.checkBox_T4 = new System.Windows.Forms.CheckBox();
            this.checkBox_T3 = new System.Windows.Forms.CheckBox();
            this.checkBox_T2 = new System.Windows.Forms.CheckBox();
            this.checkBox_T1 = new System.Windows.Forms.CheckBox();
            this.Fissure_FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Fissure_Timer = new System.Windows.Forms.Timer(this.components);
            this.Fissure_Delay = new System.Windows.Forms.Timer(this.components);
            this.Fissure_BGW = new System.ComponentModel.BackgroundWorker();
            this.Baro_GroupBox = new System.Windows.Forms.GroupBox();
            this.Baro_Button = new System.Windows.Forms.Button();
            this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.CB_LockCursor = new System.Windows.Forms.CheckBox();
            this.CB_Mute = new System.Windows.Forms.CheckBox();
            this.BaroTimer_Timer = new System.Windows.Forms.Timer(this.components);
            this.BaroScan_Timer = new System.Windows.Forms.Timer(this.components);
            this.RelicScan_Timer = new System.Windows.Forms.Timer(this.components);
            this.RelicScanDelay_Timer = new System.Windows.Forms.Timer(this.components);
            this.RelicBGWorker = new System.ComponentModel.BackgroundWorker();
            this.Relic_Groupbox.SuspendLayout();
            this.FLP_ScanType.SuspendLayout();
            this.FLP_PlayerCount.SuspendLayout();
            this.Fissure_GroupBox.SuspendLayout();
            this.Baro_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // PrimeData_DL_btn
            // 
            this.PrimeData_DL_btn.AutoSize = true;
            this.PrimeData_DL_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PrimeData_DL_btn.Location = new System.Drawing.Point(183, 81);
            this.PrimeData_DL_btn.Margin = new System.Windows.Forms.Padding(2);
            this.PrimeData_DL_btn.Name = "PrimeData_DL_btn";
            this.PrimeData_DL_btn.Size = new System.Drawing.Size(98, 23);
            this.PrimeData_DL_btn.TabIndex = 1;
            this.PrimeData_DL_btn.Text = "DL Prime Data";
            this.ToolTips.SetToolTip(this.PrimeData_DL_btn, "Downloads data about Prime Items and Warframe Market data about them.");
            this.PrimeData_DL_btn.UseVisualStyleBackColor = true;
            this.PrimeData_DL_btn.Click += new System.EventHandler(this.PrimeData_DL_btn_Click);
            // 
            // Relic_Groupbox
            // 
            this.Relic_Groupbox.Controls.Add(this.Focus_Label);
            this.Relic_Groupbox.Controls.Add(this.Relic_Button);
            this.Relic_Groupbox.Controls.Add(this.FLP_ScanType);
            this.Relic_Groupbox.Controls.Add(this.FLP_PlayerCount);
            this.Relic_Groupbox.Location = new System.Drawing.Point(10, 9);
            this.Relic_Groupbox.Margin = new System.Windows.Forms.Padding(0);
            this.Relic_Groupbox.Name = "Relic_Groupbox";
            this.Relic_Groupbox.Size = new System.Drawing.Size(270, 70);
            this.Relic_Groupbox.TabIndex = 0;
            this.Relic_Groupbox.TabStop = false;
            this.Relic_Groupbox.Text = "Relic Farmer";
            // 
            // Focus_Label
            // 
            this.Focus_Label.Location = new System.Drawing.Point(154, 39);
            this.Focus_Label.Margin = new System.Windows.Forms.Padding(0);
            this.Focus_Label.Name = "Focus_Label";
            this.Focus_Label.Size = new System.Drawing.Size(18, 23);
            this.Focus_Label.TabIndex = 8;
            // 
            // Relic_Button
            // 
            this.Relic_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Relic_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Relic_Button.Location = new System.Drawing.Point(174, 18);
            this.Relic_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Relic_Button.Name = "Relic_Button";
            this.Relic_Button.Size = new System.Drawing.Size(91, 44);
            this.Relic_Button.TabIndex = 3;
            this.Relic_Button.TabStop = false;
            this.Relic_Button.Text = "Run Relic Scanner";
            this.ToolTips.SetToolTip(this.Relic_Button, "Press to run Relic scan.\r\nRelic scanner scans your screen for Prime Items and dis" +
        "plays data.\r\n\r\nInsert+Home is a Hotkey to run Relic Scanner.\r\nInsert+Del to clos" +
        "e Relic Scanner overlay.");
            this.Relic_Button.UseVisualStyleBackColor = true;
            this.Relic_Button.Click += new System.EventHandler(this.Run_Button_Click);
            // 
            // FLP_ScanType
            // 
            this.FLP_ScanType.AutoSize = true;
            this.FLP_ScanType.Controls.Add(this.RB_Single);
            this.FLP_ScanType.Controls.Add(this.RB_Continuous);
            this.FLP_ScanType.Location = new System.Drawing.Point(5, 41);
            this.FLP_ScanType.Margin = new System.Windows.Forms.Padding(2);
            this.FLP_ScanType.Name = "FLP_ScanType";
            this.FLP_ScanType.Size = new System.Drawing.Size(152, 21);
            this.FLP_ScanType.TabIndex = 7;
            this.FLP_ScanType.WrapContents = false;
            // 
            // RB_Single
            // 
            this.RB_Single.AutoSize = true;
            this.RB_Single.Checked = true;
            this.RB_Single.Location = new System.Drawing.Point(8, 2);
            this.RB_Single.Margin = new System.Windows.Forms.Padding(8, 2, 2, 2);
            this.RB_Single.Name = "RB_Single";
            this.RB_Single.Size = new System.Drawing.Size(54, 17);
            this.RB_Single.TabIndex = 3;
            this.RB_Single.TabStop = true;
            this.RB_Single.Text = "Single";
            this.ToolTips.SetToolTip(this.RB_Single, "Preforms a single scan when run.");
            this.RB_Single.UseVisualStyleBackColor = true;
            this.RB_Single.CheckedChanged += new System.EventHandler(this.RB_Single_CheckedChanged);
            // 
            // RB_Continuous
            // 
            this.RB_Continuous.AutoSize = true;
            this.RB_Continuous.Location = new System.Drawing.Point(72, 2);
            this.RB_Continuous.Margin = new System.Windows.Forms.Padding(8, 2, 2, 2);
            this.RB_Continuous.Name = "RB_Continuous";
            this.RB_Continuous.Size = new System.Drawing.Size(78, 17);
            this.RB_Continuous.TabIndex = 4;
            this.RB_Continuous.Text = "Continuous";
            this.ToolTips.SetToolTip(this.RB_Continuous, "Scans the screen continuously.");
            this.RB_Continuous.UseVisualStyleBackColor = true;
            // 
            // FLP_PlayerCount
            // 
            this.FLP_PlayerCount.AutoSize = true;
            this.FLP_PlayerCount.Controls.Add(this.PlayerCount_2);
            this.FLP_PlayerCount.Controls.Add(this.PlayerCount_3);
            this.FLP_PlayerCount.Controls.Add(this.PlayerCount_4);
            this.FLP_PlayerCount.Controls.Add(this.PlayerCount_Auto);
            this.FLP_PlayerCount.Location = new System.Drawing.Point(5, 18);
            this.FLP_PlayerCount.Margin = new System.Windows.Forms.Padding(2);
            this.FLP_PlayerCount.Name = "FLP_PlayerCount";
            this.FLP_PlayerCount.Size = new System.Drawing.Size(165, 21);
            this.FLP_PlayerCount.TabIndex = 6;
            this.FLP_PlayerCount.WrapContents = false;
            // 
            // PlayerCount_2
            // 
            this.PlayerCount_2.Location = new System.Drawing.Point(8, 2);
            this.PlayerCount_2.Margin = new System.Windows.Forms.Padding(8, 2, 2, 2);
            this.PlayerCount_2.Name = "PlayerCount_2";
            this.PlayerCount_2.Size = new System.Drawing.Size(26, 17);
            this.PlayerCount_2.TabIndex = 2;
            this.PlayerCount_2.Tag = "2";
            this.PlayerCount_2.Text = "2";
            this.PlayerCount_2.UseVisualStyleBackColor = true;
            this.PlayerCount_2.CheckedChanged += new System.EventHandler(this.PlayerCount_CheckedChanged);
            // 
            // PlayerCount_3
            // 
            this.PlayerCount_3.Location = new System.Drawing.Point(44, 2);
            this.PlayerCount_3.Margin = new System.Windows.Forms.Padding(8, 2, 2, 2);
            this.PlayerCount_3.Name = "PlayerCount_3";
            this.PlayerCount_3.Size = new System.Drawing.Size(26, 17);
            this.PlayerCount_3.TabIndex = 3;
            this.PlayerCount_3.Tag = "3";
            this.PlayerCount_3.Text = "3";
            this.PlayerCount_3.UseVisualStyleBackColor = true;
            this.PlayerCount_3.CheckedChanged += new System.EventHandler(this.PlayerCount_CheckedChanged);
            // 
            // PlayerCount_4
            // 
            this.PlayerCount_4.Location = new System.Drawing.Point(80, 2);
            this.PlayerCount_4.Margin = new System.Windows.Forms.Padding(8, 2, 2, 2);
            this.PlayerCount_4.Name = "PlayerCount_4";
            this.PlayerCount_4.Size = new System.Drawing.Size(26, 17);
            this.PlayerCount_4.TabIndex = 3;
            this.PlayerCount_4.Tag = "4";
            this.PlayerCount_4.Text = "4";
            this.PlayerCount_4.UseVisualStyleBackColor = true;
            this.PlayerCount_4.CheckedChanged += new System.EventHandler(this.PlayerCount_CheckedChanged);
            // 
            // PlayerCount_Auto
            // 
            this.PlayerCount_Auto.Checked = true;
            this.PlayerCount_Auto.Location = new System.Drawing.Point(116, 2);
            this.PlayerCount_Auto.Margin = new System.Windows.Forms.Padding(8, 2, 2, 2);
            this.PlayerCount_Auto.Name = "PlayerCount_Auto";
            this.PlayerCount_Auto.Size = new System.Drawing.Size(47, 17);
            this.PlayerCount_Auto.TabIndex = 1;
            this.PlayerCount_Auto.TabStop = true;
            this.PlayerCount_Auto.Tag = "1";
            this.PlayerCount_Auto.Text = "Auto";
            this.PlayerCount_Auto.UseVisualStyleBackColor = true;
            this.PlayerCount_Auto.CheckedChanged += new System.EventHandler(this.PlayerCount_CheckedChanged);
            // 
            // Fissure_GroupBox
            // 
            this.Fissure_GroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Fissure_GroupBox.Controls.Add(this.checkBox_T5);
            this.Fissure_GroupBox.Controls.Add(this.checkBox_T4);
            this.Fissure_GroupBox.Controls.Add(this.checkBox_T3);
            this.Fissure_GroupBox.Controls.Add(this.checkBox_T2);
            this.Fissure_GroupBox.Controls.Add(this.checkBox_T1);
            this.Fissure_GroupBox.Controls.Add(this.Fissure_FlowLayoutPanel);
            this.Fissure_GroupBox.Location = new System.Drawing.Point(10, 156);
            this.Fissure_GroupBox.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.Fissure_GroupBox.MaximumSize = new System.Drawing.Size(284, 0);
            this.Fissure_GroupBox.MinimumSize = new System.Drawing.Size(266, 40);
            this.Fissure_GroupBox.Name = "Fissure_GroupBox";
            this.Fissure_GroupBox.Size = new System.Drawing.Size(270, 40);
            this.Fissure_GroupBox.TabIndex = 8;
            this.Fissure_GroupBox.TabStop = false;
            this.Fissure_GroupBox.Text = "Void Fissures";
            this.ToolTips.SetToolTip(this.Fissure_GroupBox, resources.GetString("Fissure_GroupBox.ToolTip"));
            // 
            // checkBox_T5
            // 
            this.checkBox_T5.AutoSize = true;
            this.checkBox_T5.Checked = true;
            this.checkBox_T5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_T5.Location = new System.Drawing.Point(200, 16);
            this.checkBox_T5.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.checkBox_T5.Name = "checkBox_T5";
            this.checkBox_T5.Size = new System.Drawing.Size(68, 17);
            this.checkBox_T5.TabIndex = 5;
            this.checkBox_T5.TabStop = false;
            this.checkBox_T5.Text = "Requiem";
            this.checkBox_T5.UseVisualStyleBackColor = true;
            this.checkBox_T5.CheckedChanged += new System.EventHandler(this.checkBox_T_CheckedChanged);
            // 
            // checkBox_T4
            // 
            this.checkBox_T4.AutoSize = true;
            this.checkBox_T4.Checked = true;
            this.checkBox_T4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_T4.Location = new System.Drawing.Point(158, 16);
            this.checkBox_T4.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.checkBox_T4.Name = "checkBox_T4";
            this.checkBox_T4.Size = new System.Drawing.Size(40, 17);
            this.checkBox_T4.TabIndex = 4;
            this.checkBox_T4.TabStop = false;
            this.checkBox_T4.Text = "Axi";
            this.checkBox_T4.UseVisualStyleBackColor = true;
            this.checkBox_T4.CheckedChanged += new System.EventHandler(this.checkBox_T_CheckedChanged);
            // 
            // checkBox_T3
            // 
            this.checkBox_T3.AutoSize = true;
            this.checkBox_T3.Checked = true;
            this.checkBox_T3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_T3.Location = new System.Drawing.Point(108, 16);
            this.checkBox_T3.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.checkBox_T3.Name = "checkBox_T3";
            this.checkBox_T3.Size = new System.Drawing.Size(46, 17);
            this.checkBox_T3.TabIndex = 3;
            this.checkBox_T3.TabStop = false;
            this.checkBox_T3.Text = "Neo";
            this.checkBox_T3.UseVisualStyleBackColor = true;
            this.checkBox_T3.CheckedChanged += new System.EventHandler(this.checkBox_T_CheckedChanged);
            // 
            // checkBox_T2
            // 
            this.checkBox_T2.AutoSize = true;
            this.checkBox_T2.Checked = true;
            this.checkBox_T2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_T2.Location = new System.Drawing.Point(52, 16);
            this.checkBox_T2.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.checkBox_T2.Name = "checkBox_T2";
            this.checkBox_T2.Size = new System.Drawing.Size(52, 17);
            this.checkBox_T2.TabIndex = 2;
            this.checkBox_T2.TabStop = false;
            this.checkBox_T2.Text = "Meso";
            this.checkBox_T2.UseVisualStyleBackColor = true;
            this.checkBox_T2.CheckedChanged += new System.EventHandler(this.checkBox_T_CheckedChanged);
            // 
            // checkBox_T1
            // 
            this.checkBox_T1.AutoSize = true;
            this.checkBox_T1.Checked = true;
            this.checkBox_T1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_T1.Location = new System.Drawing.Point(5, 16);
            this.checkBox_T1.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.checkBox_T1.Name = "checkBox_T1";
            this.checkBox_T1.Size = new System.Drawing.Size(43, 17);
            this.checkBox_T1.TabIndex = 1;
            this.checkBox_T1.TabStop = false;
            this.checkBox_T1.Text = "Lith";
            this.checkBox_T1.UseVisualStyleBackColor = true;
            this.checkBox_T1.CheckedChanged += new System.EventHandler(this.checkBox_T_CheckedChanged);
            // 
            // Fissure_FlowLayoutPanel
            // 
            this.Fissure_FlowLayoutPanel.AutoSize = true;
            this.Fissure_FlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Fissure_FlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.Fissure_FlowLayoutPanel.Location = new System.Drawing.Point(5, 33);
            this.Fissure_FlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.Fissure_FlowLayoutPanel.MinimumSize = new System.Drawing.Size(256, 4);
            this.Fissure_FlowLayoutPanel.Name = "Fissure_FlowLayoutPanel";
            this.Fissure_FlowLayoutPanel.Size = new System.Drawing.Size(256, 4);
            this.Fissure_FlowLayoutPanel.TabIndex = 0;
            // 
            // Fissure_Timer
            // 
            this.Fissure_Timer.Interval = 1000;
            this.Fissure_Timer.Tick += new System.EventHandler(this.Fissure_Timer_Tick);
            // 
            // Fissure_Delay
            // 
            this.Fissure_Delay.Interval = 1000;
            this.Fissure_Delay.Tick += new System.EventHandler(this.Fissure_Delay_Tick);
            // 
            // Fissure_BGW
            // 
            this.Fissure_BGW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Fissure_BGW_DoWork);
            this.Fissure_BGW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Fissure_BGW_RunWorkerCompleted);
            // 
            // Baro_GroupBox
            // 
            this.Baro_GroupBox.Controls.Add(this.Baro_Button);
            this.Baro_GroupBox.Location = new System.Drawing.Point(10, 110);
            this.Baro_GroupBox.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.Baro_GroupBox.Name = "Baro_GroupBox";
            this.Baro_GroupBox.Size = new System.Drawing.Size(270, 42);
            this.Baro_GroupBox.TabIndex = 1;
            this.Baro_GroupBox.TabStop = false;
            this.Baro_GroupBox.Text = "Baro Farmer (Arrives in 13d 23h 59m)";
            // 
            // Baro_Button
            // 
            this.Baro_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Baro_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Baro_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Baro_Button.Location = new System.Drawing.Point(3, 16);
            this.Baro_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Baro_Button.Name = "Baro_Button";
            this.Baro_Button.Size = new System.Drawing.Size(264, 23);
            this.Baro_Button.TabIndex = 5;
            this.Baro_Button.TabStop = false;
            this.Baro_Button.Text = "Run Baro Scanner";
            this.ToolTips.SetToolTip(this.Baro_Button, "Press to run Baro scanner.\r\nBaro scanner scans your screen for Prime Items in Bar" +
        "o window and displays data.\r\n\r\nInsert+End is a Hotkey to run Baro Scanner.");
            this.Baro_Button.UseVisualStyleBackColor = true;
            this.Baro_Button.Click += new System.EventHandler(this.Baro_Button_Click);
            // 
            // ToolTips
            // 
            this.ToolTips.AutoPopDelay = 30000;
            this.ToolTips.InitialDelay = 500;
            this.ToolTips.ReshowDelay = 100;
            // 
            // CB_LockCursor
            // 
            this.CB_LockCursor.AutoSize = true;
            this.CB_LockCursor.Location = new System.Drawing.Point(10, 85);
            this.CB_LockCursor.Margin = new System.Windows.Forms.Padding(0);
            this.CB_LockCursor.Name = "CB_LockCursor";
            this.CB_LockCursor.Size = new System.Drawing.Size(83, 17);
            this.CB_LockCursor.TabIndex = 9;
            this.CB_LockCursor.TabStop = false;
            this.CB_LockCursor.Text = "Lock Cursor";
            this.ToolTips.SetToolTip(this.CB_LockCursor, "Locks Cursor to Warframe window area.\r\n\r\nPress PageUp to enable, PageDown or Wind" +
        "ows Key to disable.");
            this.CB_LockCursor.UseVisualStyleBackColor = true;
            this.CB_LockCursor.CheckedChanged += new System.EventHandler(this.checkBox_LockCursor_CheckedChanged);
            // 
            // CB_Mute
            // 
            this.CB_Mute.AutoSize = true;
            this.CB_Mute.Location = new System.Drawing.Point(93, 85);
            this.CB_Mute.Margin = new System.Windows.Forms.Padding(0);
            this.CB_Mute.Name = "CB_Mute";
            this.CB_Mute.Size = new System.Drawing.Size(84, 17);
            this.CB_Mute.TabIndex = 10;
            this.CB_Mute.TabStop = false;
            this.CB_Mute.Text = "Mute Sound";
            this.ToolTips.SetToolTip(this.CB_Mute, "Mute app sounds.");
            this.CB_Mute.UseVisualStyleBackColor = true;
            this.CB_Mute.CheckedChanged += new System.EventHandler(this.CB_Mute_CheckedChanged);
            // 
            // BaroTimer_Timer
            // 
            this.BaroTimer_Timer.Interval = 60000;
            this.BaroTimer_Timer.Tick += new System.EventHandler(this.Baro_Timer_Tick);
            // 
            // BaroScan_Timer
            // 
            this.BaroScan_Timer.Interval = 1000;
            this.BaroScan_Timer.Tick += new System.EventHandler(this.BaroScan_Timer_Tick);
            // 
            // RelicScan_Timer
            // 
            this.RelicScan_Timer.Interval = 1000;
            this.RelicScan_Timer.Tick += new System.EventHandler(this.RelicScan_Timer_Tick);
            // 
            // RelicScanDelay_Timer
            // 
            this.RelicScanDelay_Timer.Interval = 30000;
            this.RelicScanDelay_Timer.Tick += new System.EventHandler(this.RelicScanDelay_Timer_Tick);
            // 
            // RelicBGWorker
            // 
            this.RelicBGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RelicBGWorker_DoWork);
            this.RelicBGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.RelicBGWorker_RunWorkerCompleted);
            // 
            // Form_Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(290, 205);
            this.Controls.Add(this.CB_Mute);
            this.Controls.Add(this.CB_LockCursor);
            this.Controls.Add(this.Baro_GroupBox);
            this.Controls.Add(this.PrimeData_DL_btn);
            this.Controls.Add(this.Fissure_GroupBox);
            this.Controls.Add(this.Relic_Groupbox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(306, 244);
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warframe ReBa Farmer";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.Relic_Groupbox.ResumeLayout(false);
            this.Relic_Groupbox.PerformLayout();
            this.FLP_ScanType.ResumeLayout(false);
            this.FLP_ScanType.PerformLayout();
            this.FLP_PlayerCount.ResumeLayout(false);
            this.Fissure_GroupBox.ResumeLayout(false);
            this.Fissure_GroupBox.PerformLayout();
            this.Baro_GroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.GroupBox Relic_Groupbox;
        private System.Windows.Forms.FlowLayoutPanel FLP_PlayerCount;
        internal System.Windows.Forms.RadioButton PlayerCount_2;
        internal System.Windows.Forms.RadioButton PlayerCount_3;
        internal System.Windows.Forms.RadioButton PlayerCount_4;
        internal System.Windows.Forms.RadioButton PlayerCount_Auto;
        internal System.Windows.Forms.Button Relic_Button;
        private System.Windows.Forms.FlowLayoutPanel FLP_ScanType;
        internal System.Windows.Forms.RadioButton RB_Single;
        internal System.Windows.Forms.RadioButton RB_Continuous;
        internal System.Windows.Forms.GroupBox Fissure_GroupBox;
        private System.Windows.Forms.CheckBox checkBox_T5;
        private System.Windows.Forms.CheckBox checkBox_T4;
        private System.Windows.Forms.CheckBox checkBox_T3;
        private System.Windows.Forms.CheckBox checkBox_T2;
        private System.Windows.Forms.CheckBox checkBox_T1;
        internal System.Windows.Forms.FlowLayoutPanel Fissure_FlowLayoutPanel;
        private System.Windows.Forms.Timer Fissure_Timer;
        private System.Windows.Forms.Timer Fissure_Delay;
        private System.ComponentModel.BackgroundWorker Fissure_BGW;
        internal System.Windows.Forms.GroupBox Baro_GroupBox;
        internal System.Windows.Forms.ToolTip ToolTips;
        internal System.Windows.Forms.Button Baro_Button;
        internal System.Windows.Forms.Timer BaroTimer_Timer;
        private System.Windows.Forms.Label Focus_Label;
        internal System.Windows.Forms.Timer BaroScan_Timer;
        internal System.Windows.Forms.Timer RelicScan_Timer;
        internal System.Windows.Forms.Timer RelicScanDelay_Timer;
        private System.ComponentModel.BackgroundWorker RelicBGWorker;
        internal System.Windows.Forms.Button PrimeData_DL_btn;
        internal System.Windows.Forms.CheckBox CB_LockCursor;
        internal System.Windows.Forms.CheckBox CB_Mute;
    }
}

