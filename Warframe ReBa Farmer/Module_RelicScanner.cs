using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Warframe_ReBa_Farmer
{
    class Module_RelicScanner
    {
        public static bool RunRelicContinuous = false;
        public static void Relic_ContinuousToggle()
        {
            RunRelicContinuous = !RunRelicContinuous;
            if (RunRelicContinuous)
            {
                //My.Computer.Audio.Play(My.Resources.Baro_on, AudioPlayMode.Background);
                Form_Main._FormReference.Relic_Button.Text = "Stop Relic Scanner";
            }
            else
            {
                //My.Computer.Audio.Play(My.Resources.Baro_off, AudioPlayMode.Background);
                Form_Main._FormReference.Relic_Button.Text = "Run Relic Scanner";
            }
        }


        private static List<string> OCR_Results = new List<string>();
        private static int OCR_Counter;
        public static List<Bitmap> Screenshot_Cuts = new List<Bitmap>();
        public static void Run_RelicScanner()
        {
            if (VoidFissure_Test4RewardsScreen())
            {
                Form_Main._FormReference.Invoke(new Action(() => 
                {
                    if (Form_OverlayRelic._FormReference != null) { Form_OverlayRelic._FormReference.Close(); }
                    Form_OverlayRelic._FormReference = new Form_OverlayRelic();
                    Form_OverlayRelic._FormReference.Show(); 
                }));

                Bitmap BitmapHolder = Module_Screenshot.SaveScreenshot(true);
                int RewardCounter = Player_Number == 1 ? VoidFissure_RewardsCount(BitmapHolder) : Player_Number;
                Debug.Print(RewardCounter.ToString());
                VoidFissure_CutScreenshot("1920x1080", BitmapHolder, RewardCounter);

                for (int i = 0; i < RewardCounter; i++)
                {
                    OCR_Results.Add(i.ToString()); //reserve place
                    BackgroundWorker bgworker = new BackgroundWorker();
                    bgworker.DoWork += RelicBackgroundWorker_DoWork;
                    bgworker.RunWorkerCompleted += RelicBackgroundWorker_RunWorkerCompleted;
                    bgworker.RunWorkerAsync(i);
                }
                BitmapHolder.Dispose();
            }
            else
            {
                if (RunRelicContinuous) { Form_Main._FormReference.RelicScan_Timer.Start(); }
            }

        }

        private static Color TextColour;
        private static bool VoidFissure_Test4RewardsScreen()
        {
            //VOID FISSURE/REWARDS text top left of screen test for RRD
            //Capture letters
            Bitmap TS_VFR = new Bitmap(3, 36, PixelFormat.Format32bppArgb);
            Graphics.FromImage(TS_VFR).CopyFromScreen(new Point(637, 49), new Point(0, 0), new Size(1, 36)); //R
            Graphics.FromImage(TS_VFR).CopyFromScreen(new Point(759, 49), new Point(1, 0), new Size(1, 36)); //R
            Graphics.FromImage(TS_VFR).CopyFromScreen(new Point(788, 49), new Point(2, 0), new Size(1, 36)); //D

            //Get Bytes
            BitmapData LockedBitmapData = TS_VFR.LockBits(new Rectangle(0, 0, TS_VFR.Width, TS_VFR.Height), ImageLockMode.ReadOnly, TS_VFR.PixelFormat);
            int numBytes = Math.Abs(LockedBitmapData.Stride) * LockedBitmapData.Height;
            byte[] LockedBitmapBytes = new byte[numBytes];
            Marshal.Copy(LockedBitmapData.Scan0, LockedBitmapBytes, 0, numBytes); // Copy the RGB values into the array.
            int PixelSize = 4; // 32 bits/8 = 4 bytes

            for (int PixelPosition = PixelSize; PixelPosition < numBytes; PixelPosition += PixelSize)
            {
                //ARGB is reversed in bytes to BGRA
                int C_Colour_Red = LockedBitmapBytes[PixelPosition + 2];
                int C_Colour_Green = LockedBitmapBytes[PixelPosition + 1];
                int C_Colour_Blue = LockedBitmapBytes[PixelPosition];

                int P_Colour_Red = LockedBitmapBytes[PixelPosition - 2];
                int P_Colour_Green = LockedBitmapBytes[PixelPosition - 3];
                int P_Colour_Blue = LockedBitmapBytes[PixelPosition - 4];

                if (!(C_Colour_Red == P_Colour_Red && C_Colour_Green == P_Colour_Green && C_Colour_Blue == P_Colour_Blue))
                {
                    TS_VFR.Dispose();
                    return false;
                }
            }          
            TextColour = Module_ThemeFinder.FindTheme(LockedBitmapBytes[2], LockedBitmapBytes[1], LockedBitmapBytes[0]);
            TS_VFR.Dispose();
            return true;
        }

        public static int Player_Number = 1;
        private static int VoidFissure_RewardsCount(Bitmap PassedBitmap)
        {
            Bitmap TS_VFRC = new Bitmap(1920, 1, PixelFormat.Format24bppRgb);
            //Graphics.FromImage(TS_VFRC).CopyFromScreen(new Point(477, 445), new Point(0, 0), TS_VFRC.Size); //Can only try item find color of item name, can't find anything else that's consistent
            Graphics.FromImage(TS_VFRC).DrawImage(PassedBitmap, 0, 0, new Rectangle(new Point(0, 445), TS_VFRC.Size), GraphicsUnit.Pixel);

            //Get Bytes
            BitmapData LockedBitmapData = TS_VFRC.LockBits(new Rectangle(0, 0, TS_VFRC.Width, TS_VFRC.Height), ImageLockMode.ReadOnly, TS_VFRC.PixelFormat);
            int numBytes = Math.Abs(LockedBitmapData.Stride) * LockedBitmapData.Height;
            byte[] LockedBitmapBytes = new byte[numBytes];
            Marshal.Copy(LockedBitmapData.Scan0, LockedBitmapBytes, 0, numBytes); // Copy the RGB values into the array.
            int PixelSize = 3; // 24 bits/8 = 3 bytes

            for (int PixelPosition = 1341; PixelPosition < 4236; PixelPosition += PixelSize) //447*3=1341, +(965*3=)2895=4236
            {
                //RGB is reversed in bytes to BGR
                int Color_Red = LockedBitmapBytes[PixelPosition + 2];
                int Color_Green = LockedBitmapBytes[PixelPosition + 1];
                int Color_Blue = LockedBitmapBytes[PixelPosition];

                if (Color_Red == TextColour.R && Color_Green == TextColour.G && Color_Blue == TextColour.B)
                {
                    int TriggerPixelPosition = PixelPosition / 3;
                    if (TriggerPixelPosition < 600)
                    {
                        return 4;
                    }
                    else if (TriggerPixelPosition < 720)
                    {
                        return 3;
                    }
                    else if (TriggerPixelPosition < 840)
                    {
                        return 2;
                    }
                }
            }
            return 0;
        }

        private static Dictionary<string, Dictionary<int, List<int>>> LocationHolder = new Dictionary<string, Dictionary<int, List<int>>>();
        static Module_RelicScanner()
        {
            Dictionary<int, List<int>> Points1920x1080 = new Dictionary<int, List<int>>
            {
                { 4, new List<int> { 479, 721, 964, 1206 } },
                { 3, new List<int> { 601, 843, 1086 } },
                { 2, new List<int> { 721, 964 } }
            };
            LocationHolder.Add("1920x1080", Points1920x1080);
        }

        public static void VoidFissure_CutScreenshot(string Resolution, Bitmap FullScreenshot, int NumberOfCuts)
        {
            foreach (int LocationPoint in LocationHolder[Resolution][NumberOfCuts])
            {
                Bitmap TempImage = new Bitmap(235, 50, PixelFormat.Format24bppRgb);
                Graphics.FromImage(TempImage).DrawImage(FullScreenshot, 0, 0, new Rectangle(new Point(LocationPoint, 410), TempImage.Size), GraphicsUnit.Pixel);
                ChangeColor(TempImage, LocationPoint);
                Screenshot_Cuts.Add(TempImage);
            }
        }

        private static void ChangeColor(Bitmap PassedImage, int LocationPoint = 0)
        {
            //http://csharpexamples.com/fast-image-processing-c/ alternative, but slower for some reason

            //Get Bytes
            BitmapData LockedBitmapData = PassedImage.LockBits(new Rectangle(0, 0, PassedImage.Width, PassedImage.Height), ImageLockMode.ReadWrite, PassedImage.PixelFormat);
            int numBytes = Math.Abs(LockedBitmapData.Stride) * LockedBitmapData.Height;
            byte[] LockedBitmapBytes = new byte[numBytes];
            Marshal.Copy(LockedBitmapData.Scan0, LockedBitmapBytes, 0, numBytes); // Copy the RGB values into the array.
            int PixelSize = 3; // 24 bits/8 = 3 bytes

            for (int PixelPosition = 0; PixelPosition < numBytes; PixelPosition += PixelSize)
            {
                //RGB is reversed in bytes to BGR
                int Color_Red = LockedBitmapBytes[PixelPosition + 2];
                int Color_Green = LockedBitmapBytes[PixelPosition + 1];
                int Color_Blue = LockedBitmapBytes[PixelPosition];

                if (Color_Red == TextColour.R && Color_Green == TextColour.G && Color_Blue == TextColour.B)
                {
                    LockedBitmapBytes[PixelPosition + 2] = 0;
                    LockedBitmapBytes[PixelPosition + 1] = 0;
                    LockedBitmapBytes[PixelPosition] = 0;
                }
                else
                {
                    LockedBitmapBytes[PixelPosition + 2] = 255;
                    LockedBitmapBytes[PixelPosition + 1] = 255;
                    LockedBitmapBytes[PixelPosition] = 255;
                }
            }
            Marshal.Copy(LockedBitmapBytes, 0, LockedBitmapData.Scan0, numBytes); // Copy the RGB values back into bitmap.
            PassedImage.UnlockBits(LockedBitmapData);
            //PassedImage.Save("ScreenshotCut_" + LocationPoint + "_" + DateTime.Now.ToString("yyyy-MM-dd@HH.mm.ss") + ".png", ImageFormat.Png);
        }

        private static void RelicBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int WorkerIndex = (int)e.Argument;
            Bitmap PassedBitmap = Screenshot_Cuts[WorkerIndex];
            string FoundText = Module_OCR.OCR_Image(PassedBitmap);
            e.Result = WorkerIndex + "," + FoundText;

            if (FoundText.Contains("Forma")) { return; }
            if (Module_Data.PrimeItemsData.ContainsKey(FoundText))
            {
                Overlay OverlayItem = new Overlay(FoundText, LocationHolder["1920x1080"][Screenshot_Cuts.Count][WorkerIndex]);
                OverlayHolder.Add(OverlayItem);
                //_Form_OverlayRelic.Invoke((Action) (()=> { _Form_OverlayRelic.Controls.Add(OverlayItem); }));
            }
            else
            {
                Debug.Print(FoundText);
                FlowLayoutPanel TempFLP = new FlowLayoutPanel()
                {
                    FlowDirection = FlowDirection.TopDown,
                    Margin = new Padding(0, 0, 0, 0),
                    Location = new Point(LocationHolder["1920x1080"][Screenshot_Cuts.Count][WorkerIndex], 32),
                    AutoSize = true
                };
                Label FailLabel = new Label()
                {
                    Text = string.Format(@"OCR Fail!!! - {0}", FoundText.Replace("&","&&")),
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                    MaximumSize = new Size(235, 0),
                    AutoSize = true,
                    BackColor = SystemColors.Control,
                    BorderStyle = BorderStyle.FixedSingle
                };
                PictureBox SomePic = new PictureBox()
                {
                    BackgroundImage = PassedBitmap,
                    BackgroundImageLayout = ImageLayout.Center,
                    Size = new Size(235, 50),
                    BorderStyle = BorderStyle.FixedSingle
                };
                TempFLP.Controls.AddRange(new Control[]{ FailLabel, SomePic });
                Form_OverlayRelic._FormReference.BeginInvoke(new Action( ()=> { Form_OverlayRelic._FormReference.Controls.Add(TempFLP); }));
            }

        }
        
        private static List<Overlay> OverlayHolder = new List<Overlay>();
        private static void RelicBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            OCR_Counter += 1;
            string[] ResultHolder = e.Result.ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            int WorkerIndex = int.Parse(ResultHolder[0]);
            OCR_Results[WorkerIndex] = ResultHolder[1];
            if (OCR_Results.Count == OCR_Counter)
            {
                //Needs more delay to remove blinking
                //_Form_OverlayRelic = new Form_OverlayRelic();
                //_Form_OverlayRelic.Show();
                Form_OverlayRelic._FormReference.BeginInvoke(new Action(() => { Form_OverlayRelic._FormReference.Controls.AddRange(OverlayHolder.ToArray()); }));
                
                Bitmap TimerScreenshotPart = new Bitmap(44, 52, PixelFormat.Format24bppRgb);
                Graphics.FromImage(TimerScreenshotPart).CopyFromScreen(935, 140, 0, 0, TimerScreenshotPart.Size);

                //Get Bytes
                BitmapData LockedBitmapData = TimerScreenshotPart.LockBits(new Rectangle(0, 0, TimerScreenshotPart.Width, TimerScreenshotPart.Height), ImageLockMode.ReadWrite, TimerScreenshotPart.PixelFormat);
                int numBytes = Math.Abs(LockedBitmapData.Stride) * LockedBitmapData.Height;
                byte[] LockedBitmapBytes = new byte[numBytes];
                Marshal.Copy(LockedBitmapData.Scan0, LockedBitmapBytes, 0, numBytes); // Copy the RGB values into the array.
                int PixelSize = 3; // 24 bits/8 = 3 bytes

                for (int PixelPosition = 0; PixelPosition <= (numBytes - PixelSize); PixelPosition += PixelSize)
                {
                    //RGB is reversed in bytes to BGR
                    int Color_Red = LockedBitmapBytes[PixelPosition + 2];
                    int Color_Green = LockedBitmapBytes[PixelPosition + 1];
                    int Color_Blue = LockedBitmapBytes[PixelPosition];
                    if (Color_Red == 239 && Color_Green == 239 && Color_Blue == 239)
                    {
                        LockedBitmapBytes[PixelPosition + 2] = 0;
                        LockedBitmapBytes[PixelPosition + 1] = 0;
                        LockedBitmapBytes[PixelPosition] = 0;
                    }
                    else
                    {
                        LockedBitmapBytes[PixelPosition + 2] = 255;
                        LockedBitmapBytes[PixelPosition + 1] = 255;
                        LockedBitmapBytes[PixelPosition] = 255;
                    }
                }
                Marshal.Copy(LockedBitmapBytes, 0, LockedBitmapData.Scan0, numBytes); // Copy the RGB values back into bitmap.
                TimerScreenshotPart.UnlockBits(LockedBitmapData);
                //TimerScreenshotPart.Save("ScreenshotTimer_" + DateTime.Now.ToString("000yyyy-MM-dd@HH.mm.ss") + ".png", ImageFormat.Png);

                int RemainingTime = Module_OCR.OCR_Timer(TimerScreenshotPart) * 1000 - 500;
                Form_OverlayRelic._FormReference.BeginInvoke(new Action(() => { Form_OverlayRelic._FormReference.SetLocation(RemainingTime); }));

                OCR_Results.Clear();
                OCR_Counter = 0;
                Screenshot_Cuts.Clear();
                OverlayHolder.Clear();
            }
            GC.Collect();
            Form_Main._FormReference.RelicScanDelay_Timer.Start();
        }

    }

}

//https://stackoverflow.com/a/911225/8810532
//https://www.cyotek.com/blog/capturing-screenshots-using-csharp-and-p-invoke also works