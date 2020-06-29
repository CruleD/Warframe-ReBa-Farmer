using System.Drawing;
using System.Windows.Forms;

namespace Warframe_ReBa_Farmer
{
    public partial class RelicDisplayHolder : UserControl
    {
        private void FLP_RotationHolder_ControlAdded(object sender, ControlEventArgs e)
        {
            if (FLP_RotationHolder.Controls.Count == 3)
            {
                FLP_RotationHolder.Padding = new Padding(0, 0, 0, 0);
            }
            else if (FLP_RotationHolder.Controls.Count == 2)
            {
                FLP_RotationHolder.Padding = new Padding(0, 7, 0, 0);
            }
            else
            {
                FLP_RotationHolder.Padding = new Padding(0, 14, 0, 0);
            }
        }

        public RelicDisplayHolder()
        {
            //For design mode
            InitializeComponent();
        }

        public RelicDisplayHolder(string Title, string Tier)
        {
            InitializeComponent();
            string NodeName = Module_Data.Translator_SolarNode[Title].Name;
            Label_Title.Text = string.Format("{0}, {1} ({2})", NodeName, Module_Data.Translator_SolarNode[Title].MissionType, Module_Data.Translator_SolarNode[Title].Enemy);
            pictureBox_RelicTier.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(Tier);
            toolTip_Holder.SetToolTip(pictureBox_RelicTier, Module_Data.Translator_Tier2Fissure[Tier]);
            FLP_RotationHolder.Controls.Clear();
            foreach (string StringRelicData in Module_Data.RelicData[NodeName])
            {
                CreateLabel(StringRelicData);
            }
        }

        private void CreateLabel(string LabelText)
        {
            Label TempLabel = new Label
            {
                AutoSize = false,
                Size = new Size(200, 14),
                Margin = new Padding(0, 0, 0, 0),
                TextAlign = ContentAlignment.MiddleCenter,
                ContextMenuStrip = contextMenuStrip_Fissure,
                Text = LabelText
            };
            FLP_RotationHolder.Controls.Add(TempLabel);
        }

        private void copyToClipboardToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            string RotationData = "";
            foreach (Control LabelText in FLP_RotationHolder.Controls)
            {
                RotationData += LabelText.Text + " | ";
            }
            RotationData = RotationData.Remove(RotationData.Length - 3);

            string RotationDataComplete = string.Format("{0} = {1}",Label_Title.Text.Substring(0, Label_Title.Text.IndexOf(", ")), RotationData);
            Clipboard.SetText(RotationDataComplete);
            toolTip_Holder.Show("Copied to Clipboard.", pictureBox_RelicTier, new Point(80, 8), 1000);
        }

    }
}
