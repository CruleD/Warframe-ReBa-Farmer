using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Warframe_ReBa_Farmer.Properties;

namespace Warframe_ReBa_Farmer
{
    public partial class Form_Main : Form
    {

        public static Form_Main _FormReference;

        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            _FormReference = this;

            ServicePointManager.DefaultConnectionLimit = 4;
            Module_Data.DataModule_Initialize();
            ListFissures();
            Module_OCR.OCR_Initialize();
            Module_Baro.RefreshBaro();
            this.CenterToScreen();
            Module_Hotkeys.Module_Hotkeys_Initialize();
            CB_Mute.Checked = Settings.Default.MuteSounds;
        }



        #region RelicScan Stuff

        private void PlayerCount_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton SenderTag = (RadioButton)sender;
            if (SenderTag.Checked)
            {
                Module_RelicScanner.Player_Number = int.Parse(SenderTag.Tag.ToString());
            }
        }

        private void RB_Single_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_Single.Checked) 
            {
                if (Relic_Button.Text.Contains("Stop"))
                {
                    Module_RelicScanner.Relic_ContinuousToggle();
                    RelicScan_Timer.Stop();
                    RelicScanDelay_Timer.Stop();
                }
            }
        }
        private void Run_Button_Click(object sender, EventArgs e)
        {
            Focus_Label.Focus();

            if (Check4WarframeLaunched())
            {
                if (Baro_Button.Text.Contains("Stop")) { Baro_Button.PerformClick(); }

                if (RB_Continuous.Checked)
                {
                    Module_RelicScanner.Relic_ContinuousToggle();
                }
                else
                {
                    Relic_Button.Enabled = false;
                }
                if (Relic_Button.Text.Contains("Run")) { RelicBGWorker.RunWorkerAsync(); }
            }
            else
            {
                MessageBox.Show("Warframe is not running.", "Warframe Relic Scanner", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void RelicScan_Timer_Tick(object sender, EventArgs e)
        {
            RelicScan_Timer.Stop();
            RelicBGWorker.RunWorkerAsync();
        }

        private void RelicScanDelay_Timer_Tick(object sender, EventArgs e)
        {
            RelicScanDelay_Timer.Stop();
            RelicScan_Timer.Start();
        }

        private void RelicBGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Module_RelicScanner.Run_RelicScanner();
        }

        private void RelicBGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Relic_Button.Enabled = true;
            Module_Hotkeys.HotkeyTimer.Start();
        }

        #endregion



        private void PrimeData_DL_btn_Click(object sender, EventArgs e)
        {
            Focus_Label.Focus();
            PrimeData_DL_btn.Enabled = false;
            PrimeData_DL_btn.Text = "DLing...";
            BackgroundWorker PDDLBGW = new BackgroundWorker();
            PDDLBGW.DoWork += Module_Data.PrimeItemData_Download;
            PDDLBGW.RunWorkerCompleted += Module_Data.PrimeItemData_DownloadFinished;
            PDDLBGW.RunWorkerAsync();
        }



        #region Fissure Stuff

        public void ListFissures()
        {
            DrawingControl.SuspendDrawing(Fissure_FlowLayoutPanel);
            Fissure_FlowLayoutPanel.SuspendLayout();
            Fissure_FlowLayoutPanel.Controls.Clear();
            foreach (CheckBox CheckBoxLoop in Fissure_GroupBox.Controls.OfType<CheckBox>().Reverse())
            {
                if (CheckBoxLoop.Checked)
                {
                    string FissureTier = Module_Data.Translator_Fissure2Tier[CheckBoxLoop.Text];
                    List<string> FissureDataList = Module_Data.FissureList[FissureTier];
                    CheckBoxLoop.Tag = FissureDataList.Count;
                    foreach (string FissureDataInList in FissureDataList)
                    {
                        Fissure_FlowLayoutPanel.Controls.Add(new RelicDisplayHolder(FissureDataInList, FissureTier));
                    }
                }
            }
            Fissure_FlowLayoutPanel.ResumeLayout();
            DrawingControl.ResumeDrawing(Fissure_FlowLayoutPanel);
            Fissure_GroupBox.Height = 40 + Fissure_FlowLayoutPanel.Height;
            this.Height = this.MinimumSize.Height - 9 + (Fissure_FlowLayoutPanel.Height + 4 + 5);

            //Make it look nicer
            TimeSpan RemainingTime = Module_Data.FissureEndsAt - DateTime.UtcNow;
            if (RemainingTime.TotalMilliseconds < 0)
            {
                Fissure_GroupBox.Text = "Void Fissures (Waiting for refresh...)";
            }
            else
            {
                Fissure_GroupBox.Text = String.Format("Void Fissures (Refreshes in {0}h {1}m {2}s)", RemainingTime.Hours, RemainingTime.Minutes, RemainingTime.Seconds);
            }

            Fissure_Timer.Start();
        }

        private void Fissure_Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan RemainingTime = Module_Data.FissureEndsAt - DateTime.UtcNow;
            if (RemainingTime.TotalMilliseconds < 0)
            {
                Fissure_Timer.Stop();
                Fissure_Delay.Start();
                Fissure_GroupBox.Text = "Void Fissures (Waiting for refresh...)";
            }
            else
            {
                Fissure_GroupBox.Text = String.Format("Void Fissures (Refreshes in {0}h {1}m {2}s)", RemainingTime.Hours, RemainingTime.Minutes, RemainingTime.Seconds);
            }
        }

        private void Fissure_Delay_Tick(object sender, EventArgs e)
        {
            Fissure_Delay.Stop();
            Fissure_BGW.RunWorkerAsync();
        }

        private void Fissure_BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(15000); //wait 15s
            Module_Data.GetFissureData();
        }

        private void Fissure_BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ListFissures();
        }

        private void checkBox_T_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox GetSender = (CheckBox)sender;
            if (!GetSender.Tag.ToString().Equals("0"))
            {
                ListFissures();
            }
        }


        #endregion



        #region Baro Stuff

        private void Baro_Timer_Tick(object sender, EventArgs e)
        {
            Module_Baro.RefreshBaro();
        }

        private void Baro_Button_Click(object sender, EventArgs e)
        {
            Focus_Label.Focus();

            if (Module_Baro.RunBaroCheck)
            {
                Module_Baro.Baro_Toggle();
            }
            else
            {
                if (Relic_Button.Text.Contains("Stop")) { Relic_Button.PerformClick(); }

                if (Check4WarframeLaunched())
                {
                    Module_Baro.Baro_Toggle();
                }
                else
                {
                    MessageBox.Show("Warframe is not running.", "Warframe Baro Scanner", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BaroScan_Timer_Tick(object sender, EventArgs e)
        {
            BaroScan_Timer.Stop();
            if (Module_Baro.RunBaroCheck) { Module_Baro.Run_Baro_Scanner(); }
        }

        #endregion



        #region Warframe Window Stuff

        private bool Check4WarframeLaunched()
        {
            //Check if Warframe Game is launched
            Process[] ProcessList = Process.GetProcesses();
            foreach (Process RunningProcess in ProcessList)
            {
                if (!String.IsNullOrEmpty(RunningProcess.MainWindowTitle))
                {
                    if (RunningProcess.ProcessName.Equals("Warframe.x64")) //|| RunningProcess.ProcessName.Equals("i_view64"))
                    {
                        Module_CursorLock.GetWarframeWindow(RunningProcess.MainWindowHandle);
                        return true;
                    }
                }
            }

            return false;
        }


        private void checkBox_LockCursor_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_LockCursor.Checked)
            {
                if (Check4WarframeLaunched())
                {
                    Module_CursorLock.LockCursor();
                }
            }
            else
            {
                Module_CursorLock.UnlockCursor();
            }

        }

        #endregion

        private void CB_Mute_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.MuteSounds = CB_Mute.Checked;
            Settings.Default.Save();
        }

    }
}
