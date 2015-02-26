using System;
using System.Globalization;
using System.Windows.Forms;
using MissionEditor.FileReaderCore;
using MissionEditor.FileReaderCore.Conditions;

namespace MissionEditor.UI.ConditionUI
{
    public partial class BaseDestroyedUI : UserControl, IConditionUI
    {
        readonly BaseDestroyed condition;

        public BaseDestroyedUI(Condition cond)
        {
            InitializeComponent();

            condition = cond as BaseDestroyed;

            unknownBD1.Text = condition.Unknown1.ToString(CultureInfo.InvariantCulture);
            sideComboBox.SelectedIndex = condition.FactionIndex;
        }

        public void Apply()
        {
            condition.Unknown1 = Convert.ToByte(unknownBD1.Text);
            condition.FactionIndex = (byte)sideComboBox.SelectedIndex;
        }
    }
}
