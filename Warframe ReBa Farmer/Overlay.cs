using System.Drawing;
using System.Windows.Forms;

namespace Warframe_ReBa_Farmer
{
    public partial class Overlay : UserControl
    {
        public Overlay()
        {
            InitializeComponent();
        }

        public Overlay(string FoundText, int PointX)
        {
            InitializeComponent();
            Name = Module_Data.PrimeItemsData[FoundText].Name;
            Ducat_Value = Module_Data.PrimeItemsData[FoundText].Ducat_Value;
            Platinum_Average = Module_Data.PrimeItemsData[FoundText].Platinum_Average;
            Platinum_Min = Module_Data.PrimeItemsData[FoundText].Platinum_Min;
            Platinum_Max = Module_Data.PrimeItemsData[FoundText].Platinum_Max;
            Market_Count = Module_Data.PrimeItemsData[FoundText].Market_Count;
            isVaulted = Module_Data.PrimeItemsData[FoundText].isVaulted;
            Location = new Point(PointX, 0);
            //Form_OverlayRelic._FormReference.Controls.Add(this);
        }

        public string Ducat_Value
        {
            set
            {
                DucatLabel.Text = value;
            }
            get
            {
                return DucatLabel.Text;
            }
        }

        public string Platinum_Average
        {
            set
            {
                PlatinumLabelAvg.Text = string.Format("{0}{1}", PlatinumLabelAvg.Tag, value);
            }
            get
            {
                return PlatinumLabelAvg.Text;
            }
        }

        public string Platinum_Min
        {
            set
            {
                PlatinumLabelMin.Text = string.Format("{0}{1}", PlatinumLabelMin.Tag, value);
            }
            get
            {
                return PlatinumLabelMin.Text;
            }
        }

        public string Platinum_Max
        {
            set
            {
                PlatinumLabelMax.Text = string.Format("{0}{1}", PlatinumLabelMax.Tag, value);
            }
            get
            {
                return PlatinumLabelMax.Text;
            }
        }

        public string Market_Count
        {
            set
            {
                PlatinumPic.Text = value;
            }
            get
            {
                return PlatinumPic.Text;
            }
        }

        public bool isVaulted
        {
            set
            {
                VaultSymbol.Visible = value;
                //Update();
            }
            get
            {
                return VaultSymbol.Visible;
            }
        }
    }
}
