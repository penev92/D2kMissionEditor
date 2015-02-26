using System;
using System.Globalization;
using System.Windows.Forms;
using MissionEditor.FileReaderCore;
using MissionEditor.FileReaderCore.Conditions;

namespace MissionEditor.UI.ConditionUI
{
    public partial class UnitsDestroyedUI : UserControl, IConditionUI
    {
        readonly UnitsDestroyed condition;

        public UnitsDestroyedUI(Condition cond)
        {
            InitializeComponent();

            condition = cond as UnitsDestroyed;

            unknownUD1.Text = condition.Unknown1.ToString(CultureInfo.InvariantCulture);
            sideComboBox.SelectedIndex = condition.FactionIndex;
        }
        public void Apply()
        {
            condition.Unknown1 = Convert.ToByte(unknownUD1.Text);
            condition.FactionIndex = (byte)sideComboBox.SelectedIndex;
        }
    }
}
