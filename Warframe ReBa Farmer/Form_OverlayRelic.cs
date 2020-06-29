using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Warframe_ReBa_Farmer
{
    public partial class Form_OverlayRelic : Form
    {
        public static Form_OverlayRelic _FormReference;

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_TRANSPARENT = 0x20;

        public Form_OverlayRelic()
        {
            InitializeComponent();

            //HotkeyTimer.Start();

            // Make it Click-Through
            SetWindowLong(this.Handle, GWL_EXSTYLE, GetWindowLong(this.Handle, GWL_EXSTYLE) | WS_EX_TRANSPARENT); // Or is actualy and,  Transparent = &H20, Layered = &H80000
        }

        private void Form_OverlayRelic_Load(object sender, EventArgs e)
        {
            _FormReference = this;
        }

        public void SetLocation(int PassedInterval, int PointX = 0, int PointY = 0)
        {
            this.Location = new Point(Module_CursorLock.WarframeAreaRectangle.X + PointX, Module_CursorLock.WarframeAreaRectangle.Y + 264 + PointY);
            CloseTimer.Interval = PassedInterval;
            CloseTimer.Start();
        }

        private void CloseTimer_Tick(object sender, EventArgs e)
        {
            this.Close();
            //if (!Form_Main.StopRelicScan && Form_Main.RB_Continious.Checked)
            //{
            //    Form_Main.ScanDelay_Timer.Start();
            //}
        }

        private void Form_OverlayRelic_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FormReference = null;
            Module_Hotkeys.HotkeyTimer.Start();
        }

    }
}
