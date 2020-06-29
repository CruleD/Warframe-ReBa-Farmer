using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Warframe_ReBa_Farmer
{
    class Module_Screenshot
    {
        public static Bitmap SaveScreenshot(bool DoSaveScreenshot)
        {
            Bitmap ScreenshotBitmap = new Bitmap(Module_CursorLock.WarframeAreaRectangle.Width, Module_CursorLock.WarframeAreaRectangle.Height, PixelFormat.Format24bppRgb); //Imaging.PixelFormat.Format16bppRgb555
            using (var g = Graphics.FromImage(ScreenshotBitmap))
            {
                g.CopyFromScreen(new Point(Module_CursorLock.WarframeAreaRectangle.Left, Module_CursorLock.WarframeAreaRectangle.Top), new Point(0, 0), Module_CursorLock.WarframeAreaRectangle.Size);
            }

            if (DoSaveScreenshot)
            {
                ScreenshotBitmap.Save("Screenshot_" + DateTime.Now.ToString("yyyy-MM-dd@HH.mm.ss") + ".png", ImageFormat.Png);
            }

            return ScreenshotBitmap;
        }

    }
}
