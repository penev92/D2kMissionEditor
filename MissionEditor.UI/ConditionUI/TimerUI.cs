using System;
using System.Globalization;
using System.Windows.Forms;
using MissionEditor.FileReaderCore;
using Timer = MissionEditor.FileReaderCore.Conditions.Timer;

namespace MissionEditor.UI.ConditionUI
{
    public partial class TimerUI : UserControl, IConditionUI
    {
        readonly Timer condition;

        public TimerUI(Condition cond)
        {
            InitializeComponent();

            condition = cond as Timer;

            timeTextBox.Text = condition.Time.ToString(CultureInfo.InvariantCulture);
            comparisonFunctionComboBox.SelectedIndex = condition.ComparisonFunction;
        }

        public void Apply()
        {
            condition.Time = Convert.ToUInt32(timeTextBox.Text);
            condition.ComparisonFunction = (byte)comparisonFunctionComboBox.SelectedIndex;
        }
    }
}
