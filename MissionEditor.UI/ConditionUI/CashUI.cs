using System;
using System.Globalization;
using System.Windows.Forms;
using MissionEditor.FileReaderCore;
using MissionEditor.FileReaderCore.Conditions;

namespace MissionEditor.UI.ConditionUI
{
    public partial class CashUI : UserControl, IConditionUI
    {
        readonly Cash condition;

        public CashUI(Condition cond)
        {
            InitializeComponent();

            condition = cond as Cash;

            cashTextBox.Text = condition.CashAmmount.ToString(CultureInfo.InvariantCulture);
        }
        public void Apply()
        {
            condition.CashAmmount = Convert.ToUInt32(cashTextBox.Text);
        }
    }
}
