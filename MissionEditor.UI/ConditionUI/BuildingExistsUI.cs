using System.Windows.Forms;
using MissionEditor.FileReaderCore;
using MissionEditor.FileReaderCore.Conditions;

namespace MissionEditor.UI.ConditionUI
{
    public partial class BuildingExistsUI : UserControl, IConditionUI
    {
        readonly BuildingExists condition;

        public BuildingExistsUI(Condition cond)
        {
            InitializeComponent();

            condition = cond as BuildingExists;

            sideComboBox.SelectedIndex = condition.FactionIndex;
            buildingExistsComboBox.SelectedIndex = condition.BuildingIndex;
        }
        public void Apply()
        {
            condition.FactionIndex = (byte)sideComboBox.SelectedIndex;
            condition.BuildingIndex = (byte)buildingExistsComboBox.SelectedIndex;
        }
    }
}
