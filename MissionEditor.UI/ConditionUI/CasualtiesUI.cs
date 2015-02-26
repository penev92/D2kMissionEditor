using System;
using System.Globalization;
using System.Windows.Forms;
using MissionEditor.FileReaderCore;
using MissionEditor.FileReaderCore.Conditions;

namespace MissionEditor.UI.ConditionUI
{
    public partial class CasualtiesUI : UserControl, IConditionUI
    {
        readonly Casualties condition;

        public CasualtiesUI(Condition cond)
        {
            InitializeComponent();

            condition = cond as Casualties;

            casualtyThresholdTextBox.Text = condition.CasualtyThreshold.ToString(CultureInfo.InvariantCulture);
            unknownC1TextBox.Text = condition.Unknown1.ToString(CultureInfo.InvariantCulture);
            unknownC2TextBox.Text = condition.Unknown2.ToString(CultureInfo.InvariantCulture);
            sideComboBox.SelectedIndex = condition.FactionIndex;
            
        }

        public void Apply()
        {
            condition.CasualtyThreshold = Convert.ToByte(casualtyThresholdTextBox.Text);
            condition.Unknown1 = Convert.ToByte(unknownC1TextBox.Text);
            condition.Unknown2 = Convert.ToByte(unknownC2TextBox.Text);
            condition.FactionIndex = (byte)sideComboBox.SelectedIndex;
        }
    }
}
