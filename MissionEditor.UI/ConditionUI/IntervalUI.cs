using System;
using System.Globalization;
using System.Windows.Forms;
using MissionEditor.FileReaderCore;
using MissionEditor.FileReaderCore.Conditions;

namespace MissionEditor.UI.ConditionUI
{
    public partial class IntervalUI : UserControl, IConditionUI
    {
        readonly Interval condition;

        public IntervalUI(Condition cond)
        {
            InitializeComponent();

            condition = cond as Interval;

            intervalTextBox.Text = condition.TimeInterval.ToString(CultureInfo.InvariantCulture);
            startDelayTextBox.Text = condition.StartDelay.ToString(CultureInfo.InvariantCulture);
            runCountTextBox.Text = condition.RunCount.ToString(CultureInfo.InvariantCulture);
        }

        public void Apply()
        {
            condition.TimeInterval = Convert.ToUInt32(intervalTextBox.Text);
            condition.StartDelay = Convert.ToUInt32(startDelayTextBox.Text);
            condition.RunCount = Convert.ToUInt32(runCountTextBox.Text);
        }
    }
}
