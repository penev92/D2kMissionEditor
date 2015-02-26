using System.Windows.Forms;
using MissionEditor.FileReaderCore;
using MissionEditor.FileReaderCore.Conditions;

namespace MissionEditor.UI.ConditionUI
{
    public partial class UnitExistsUI : UserControl, IConditionUI
    {
        readonly UnitExists condition;

        public UnitExistsUI(MissionFileItem cond)
        {
            InitializeComponent();

            condition = cond as UnitExists;

            sideComboBox.SelectedIndex = condition.FactionIndex;
            unitExistsComboBox.SelectedIndex = condition.UnitIndex;
        }
        public void Apply()
        {
            condition.FactionIndex = (byte)sideComboBox.SelectedIndex;
            condition.UnitIndex = (byte)unitExistsComboBox.SelectedIndex;
        }
    }
}
