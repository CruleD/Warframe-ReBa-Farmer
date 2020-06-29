using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Warframe_ReBa_Farmer
{
    class Module_Baro
    {
        public static void RefreshBaro()
        {
            string BaroGBText = "Baro Farmer (";
            DateTime BaroTimeHolder = Module_Data.BaroStartsAt;
            if (DateTime.UtcNow < Module_Data.BaroStartsAt)
            {
                BaroGBText += "Arrives in ";
            }
            else
            {
                BaroGBText += "Leaves in ";
                BaroTimeHolder = BaroTimeHolder.AddDays(2);
                if (DateTime.UtcNow > BaroTimeHolder)
                {
                    Module_Data.GetBaroData();
                    return;
                }
            }
            TimeSpan TimeSpanHolder = BaroTimeHolder - DateTime.UtcNow;
            string String_Days = TimeSpanHolder.TotalDays < 1 ? "" : (TimeSpanHolder.Days.ToString() + "d ");
            string String_Hours = TimeSpanHolder.TotalHours < 1 ? "" : (TimeSpanHolder.Hours.ToString() + "h ");
            string String_Minutes = TimeSpanHolder.TotalMinutes < 1 ? "" : (TimeSpanHolder.Minutes.ToString() + "m ");
            Form_Main._FormReference.Baro_GroupBox.Text = BaroGBText + string.Format("{0}{1}{2}{3})", String_Days, String_Hours, String_Minutes, TimeSpanHolder.TotalMinutes <= 1 ? TimeSpanHolder.Seconds.ToString() + "s" : "");
            Form_Main._FormReference.BaroTimer_Timer.Stop();
            Form_Main._FormReference.BaroTimer_Timer.Interval = 1000 * (TimeSpanHolder.TotalMinutes < 2 ? 1 : 60);
            Form_Main._FormReference.BaroTimer_Timer.Start();
        }

        public static bool RunBaroCheck = false;
        public static void Baro_Toggle()
        {
            RunBaroCheck = !RunBaroCheck;
            if (RunBaroCheck)
            {
                if (!Form_Main._FormReference.CB_Mute.Checked)
                {
                    SoundPlayer BaroPlayer = new SoundPlayer(Properties.Resources.Baro_on);
                    BaroPlayer.Play();
                }
                Form_Main._FormReference.Baro_Button.Text = "Stop Baro Scanner";
                Form_Main._FormReference.BaroScan_Timer.Start();
            }
            else
            {
                if (!Form_Main._FormReference.CB_Mute.Checked)
                {
                    SoundPlayer BaroPlayer = new SoundPlayer(Properties.Resources.Baro_off);
                    BaroPlayer.Play();
                }
                Form_Main._FormReference.Baro_Button.Text = "Run Baro Scanner";
                Form_Main._FormReference.BaroScan_Timer.Stop();
            }
        }

        public static void Run_Baro_Scanner()
        {
            BackgroundWorker BaroBGW = new BackgroundWorker();
            BaroBGW.DoWork += Baro_BGW_DoWork;
            BaroBGW.RunWorkerCompleted += Baro_BGW_RunWorkerCompleted;
            BaroBGW.RunWorkerAsync();
        }

        private static void Baro_BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Baro_Test4KioskScreen())
            {
                Bitmap BitmapHolder = Module_Screenshot.SaveScreenshot(false);
                Point ItemWindowLocation = Baro_Check4Mouseover(ref BitmapHolder);

                if (ItemWindowLocation.X == -1) { return; }

                string BaroResult = Baro_ReadWindow(ref BitmapHolder, ItemWindowLocation);

                if (Module_Data.PrimeItemsData.ContainsKey(BaroResult))
                {
                    e.Result = new object[] { BaroResult, ItemWindowLocation };
                }
                else
                {
                    Debug.Print(BaroResult);
                }
                BitmapHolder.Dispose();
            }
        }

        private static void Baro_BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                object[] Results = (object[])e.Result;

                if (Form_OverlayBaro._FormReference != null)
                {
                    Form_OverlayBaro._FormReference.ChangeData(Results[0].ToString(), (Point)Results[1]);
                }
                else
                {
                    var holder = new Form_OverlayBaro(Results[0].ToString(), (Point)Results[1]);
                    holder.Show();
                }
            }
            else
            {
                if (Form_OverlayBaro._FormReference != null) { Form_OverlayBaro._FormReference.Close(); }
                GC.Collect();
            }
            Form_Main._FormReference.BaroScan_Timer.Start();
        }

        private static Color TextColour;
        private static bool Baro_Test4KioskScreen()
        {
            //Test for Baro kiosk screen
            Bitmap TS_BDK = new Bitmap(3, 36, PixelFormat.Format32bppArgb);
            Graphics.FromImage(TS_BDK).CopyFromScreen(new Point(472, 49), new Point(0, 0), new Size(1, 36)); //D
            Graphics.FromImage(TS_BDK).CopyFromScreen(new Point(589, 49), new Point(1, 0), new Size(1, 36)); //T
            Graphics.FromImage(TS_BDK).CopyFromScreen(new Point(746, 49), new Point(2, 0), new Size(1, 36)); //K

            //Get Bytes
            BitmapData LockedBitmapData = TS_BDK.LockBits(new Rectangle(0, 0, TS_BDK.Width, TS_BDK.Height), ImageLockMode.ReadOnly, TS_BDK.PixelFormat);
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
                    TS_BDK.Dispose();
                    return false;
                }
            }
            TextColour = Color.FromArgb(LockedBitmapBytes[2], LockedBitmapBytes[1], LockedBitmapBytes[0]);
            TS_BDK.Dispose();
            return true;
        }

        private static Point Baro_Check4Mouseover(ref Bitmap ScreenshotReference)
        {
            int PixelY = Baro_GetPixelY(ref ScreenshotReference);
            if (PixelY == 0) { return new Point(-1,-1); } //nothing found
            int PixelX = Baro_GetPixelX(ref ScreenshotReference, PixelY);
            PixelX += 8;
            return new Point(PixelX, PixelY);
        }

        private static int Baro_GetPixelY(ref Bitmap ScreenshotReference)
        {
            //Cursor position can be negative so make it positive
            int CursorX = Cursor.Position.X;
            if (CursorX < 0) { CursorX *= -1; }

            //Vertical Location
            Bitmap BaroVTest = new Bitmap(1, 1080, PixelFormat.Format24bppRgb);
            Graphics.FromImage(BaroVTest).DrawImage(ScreenshotReference, 0, 0, new Rectangle(new Point(CursorX + 300, 0), BaroVTest.Size), GraphicsUnit.Pixel);
            //Get Bytes
            BitmapData LockedBitmapData = BaroVTest.LockBits(new Rectangle(0, 0, BaroVTest.Width, BaroVTest.Height), ImageLockMode.ReadOnly, BaroVTest.PixelFormat);
            int numBytes = Math.Abs(LockedBitmapData.Stride) * LockedBitmapData.Height;
            byte[] LockedBitmapBytes = new byte[numBytes];
            Marshal.Copy(LockedBitmapData.Scan0, LockedBitmapBytes, 0, numBytes); // Copy the RGB values into the array.
            int PixelSize = 3; // 24 bits/8 = 3 bytes

            int TriggerCounter = 0;
            int FirstTriggerY = 0;
            for (int PixelPosition = 200 * PixelSize; PixelPosition < numBytes; PixelPosition += 4)
            {
                int Color_Red = LockedBitmapBytes[PixelPosition + 2];
                int Color_Green = LockedBitmapBytes[PixelPosition + 1];
                int Color_Blue = LockedBitmapBytes[PixelPosition];
                if (Color_Red == 20 && Color_Green == 19 && Color_Blue == 29)
                {
                    TriggerCounter += 1;
                    if (TriggerCounter > 3) 
                    {
                        FirstTriggerY = PixelPosition / 4 - 3;
                        break; 
                    }
                }
                else
                {
                    TriggerCounter = 0;
                }
            }
            BaroVTest.UnlockBits(LockedBitmapData);
            BaroVTest.Dispose();

            return FirstTriggerY;
        }

        private static int Baro_GetPixelX(ref Bitmap ScreenshotReference, int CursorY)
        {
            //Horizontal Location
            Bitmap BaroHTest = new Bitmap(1920, 1, PixelFormat.Format24bppRgb);
            Graphics.FromImage(BaroHTest).DrawImage(ScreenshotReference, 0, 0, new Rectangle(new Point(0, CursorY), BaroHTest.Size), GraphicsUnit.Pixel);
            //Get Bytes
            BitmapData LockedBitmapData = BaroHTest.LockBits(new Rectangle(0, 0, BaroHTest.Width, BaroHTest.Height), ImageLockMode.ReadOnly, BaroHTest.PixelFormat);
            int numBytes = Math.Abs(LockedBitmapData.Stride) * LockedBitmapData.Height;
            byte[] LockedBitmapBytes = new byte[numBytes];
            Marshal.Copy(LockedBitmapData.Scan0, LockedBitmapBytes, 0, numBytes); // Copy the RGB values into the array.
            int PixelSize = 3; // 24 bits/8 = 3 bytes

            int TriggerCounter = 0;
            int FirstTriggerX = 0;
            for (int PixelPosition = 100 * PixelSize; PixelPosition < numBytes; PixelPosition += PixelSize)
            {
                int Color_Red = LockedBitmapBytes[PixelPosition + 2];
                int Color_Green = LockedBitmapBytes[PixelPosition + 1];
                int Color_Blue = LockedBitmapBytes[PixelPosition];
                if (Color_Red == 20 && Color_Green == 19 && Color_Blue == 29)
                {
                    TriggerCounter += 1;
                    if (TriggerCounter > 3)
                    {
                        FirstTriggerX = PixelPosition / 3 - 3;
                        break;
                    }
                }
                else
                {
                    TriggerCounter = 0;
                }
            }
            BaroHTest.UnlockBits(LockedBitmapData);
            BaroHTest.Dispose();

            return FirstTriggerX;
        }

        private static string Baro_ReadWindow(ref Bitmap ScreenshotReference, Point StartPoint)
        {
            Bitmap BaroItem = new Bitmap(400, 60, PixelFormat.Format24bppRgb);
            Graphics.FromImage(BaroItem).DrawImage(ScreenshotReference, 0, 0, new Rectangle(StartPoint, BaroItem.Size), GraphicsUnit.Pixel);

            BitmapData LockedBitmapData = BaroItem.LockBits(new Rectangle(0, 0, BaroItem.Width, BaroItem.Height), ImageLockMode.ReadWrite, BaroItem.PixelFormat);
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
                    LockedBitmapBytes[PixelPosition + 2] = 255;
                    LockedBitmapBytes[PixelPosition + 1] = 255;
                    LockedBitmapBytes[PixelPosition] = 255;
                }
                else
                {
                    LockedBitmapBytes[PixelPosition + 2] = 0;
                    LockedBitmapBytes[PixelPosition + 1] = 0;
                    LockedBitmapBytes[PixelPosition] = 0;
                }
            }
            Marshal.Copy(LockedBitmapBytes, 0, LockedBitmapData.Scan0, numBytes); // Copy the RGB values back into bitmap.
            BaroItem.UnlockBits(LockedBitmapData);
            //BaroItem.Save("ScreenshotBaroItem_" + DateTime.Now.ToString("yyyy-MM-dd@HH.mm.ss") + ".png", ImageFormat.Png);

            string BaroResult = Module_OCR.OCR_Image(BaroItem).ToLower();
            if (BaroResult.Contains("blueprint")) { BaroResult = BaroResult.Substring(0, BaroResult.IndexOf("blueprint") + "blueprint".Length); }
            BaroResult = new CultureInfo("en-US", false).TextInfo.ToTitleCase(BaroResult);
            BaroItem.Dispose();

            return BaroResult;
        }

    }

}
