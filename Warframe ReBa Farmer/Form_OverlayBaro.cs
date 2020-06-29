using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Warframe_ReBa_Farmer
{
    public partial class Form_OverlayBaro : Form
    {
        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_TRANSPARENT = 0x20;

        private void Form_OverlayBaro_Load(object sender, EventArgs e)
        {
            // Make it Click-Through
            SetWindowLong(this.Handle, GWL_EXSTYLE, GetWindowLong(this.Handle, GWL_EXSTYLE) | WS_EX_TRANSPARENT); // Or is actualy and,  Transparent = &H20, Layered = &H80000
        }


        public static Form_OverlayBaro _FormReference;

        public Form_OverlayBaro()
        {
            InitializeComponent();
        }

        public Form_OverlayBaro(string FoundText, Point BaroWindowPoint)
        {
            InitializeComponent();
            PlatinumLabelAvg.Text = "Avg: " + Module_Data.PrimeItemsData[FoundText].Platinum_Average;
            PlatinumLabelMin.Text = "Min: " + Module_Data.PrimeItemsData[FoundText].Platinum_Min;
            PlatinumLabelMax.Text = "Max: " + Module_Data.PrimeItemsData[FoundText].Platinum_Max;
            PlatinumPic.Text = Module_Data.PrimeItemsData[FoundText].Market_Count;
            VaultSymbol.Visible = Module_Data.PrimeItemsData[FoundText].isVaulted;
            Location = new Point(BaroWindowPoint.X - 175, BaroWindowPoint.Y - 2);
            _FormReference = this;
        }

        public void ChangeData(string FoundText, Point BaroWindowPoint)
        {
            PlatinumLabelAvg.Text = "Avg: " + Module_Data.PrimeItemsData[FoundText].Platinum_Average;
            PlatinumLabelMin.Text = "Min: " + Module_Data.PrimeItemsData[FoundText].Platinum_Min;
            PlatinumLabelMax.Text = "Max: " + Module_Data.PrimeItemsData[FoundText].Platinum_Max;
            PlatinumPic.Text = Module_Data.PrimeItemsData[FoundText].Market_Count;
            VaultSymbol.Visible = Module_Data.PrimeItemsData[FoundText].isVaulted;
            Location = new Point(BaroWindowPoint.X - 175, BaroWindowPoint.Y - 2);
        }

        private void Form_OverlayBaro_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FormReference = null;
        }
    }
}
