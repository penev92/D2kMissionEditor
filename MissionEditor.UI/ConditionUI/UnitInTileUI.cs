using System;
using System.Globalization;
using System.Windows.Forms;
using MissionEditor.FileReaderCore;
using MissionEditor.FileReaderCore.Conditions;

namespace MissionEditor.UI.ConditionUI
{
    public partial class UnitInTileUI : UserControl, IConditionUI
    {
        readonly UnitInTile condition;

        public UnitInTileUI(Condition cond)
        {
            InitializeComponent();

            condition = cond as UnitInTile;

            xTextBox.Text = condition.CoordinateX.ToString(CultureInfo.InvariantCulture);
            yTextBox.Text = condition.CoordinateY.ToString(CultureInfo.InvariantCulture);
            runCountTextBox.Text = condition.RunCount.ToString(CultureInfo.InvariantCulture);
        }

        public void Apply()
        {
            condition.CoordinateX = Convert.ToUInt32(xTextBox.Text);
            condition.CoordinateY = Convert.ToUInt32(yTextBox.Text);
            condition.RunCount = Convert.ToUInt32(runCountTextBox.Text);
        }
    }
}
