using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Warframe_ReBa_Farmer
{
    class Module_CursorLock
    {
        static Module_CursorLock()
        {
            CursorLockTimer.Tick += LockCursor_Trigger;
            CursorLockTimer.Interval = 1000;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rcClip);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public static Rectangle WarframeAreaRectangle;
        private static RECT WarframeRECT;
        public static IntPtr WarframeHandle;

        public static void GetWarframeWindow(IntPtr HandleReference)
        {
            WarframeHandle = HandleReference;
            WarframeRECT = new RECT();
            GetWindowRect(WarframeHandle, ref WarframeRECT);
            WarframeAreaRectangle = new Rectangle(WarframeRECT.Left, WarframeRECT.Top, WarframeRECT.Right - WarframeRECT.Left, WarframeRECT.Bottom - WarframeRECT.Top);
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool ClipCursor(ref RECT rcClip);

        [DllImport("user32.dll")]
        static extern bool ClipCursor([In()] IntPtr rcClip);

        private static Timer CursorLockTimer = new Timer();
        public static void LockCursor()
        {
            CursorLockTimer.Start();
            ClipCursor(ref WarframeRECT);
        }

        private static void LockCursor_Trigger(object sender, EventArgs e)
        {
            ClipCursor(ref WarframeRECT);
        }

        public static void UnlockCursor()
        {
            CursorLockTimer.Stop();
            ClipCursor(IntPtr.Zero);
        }

    }
}
