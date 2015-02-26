using System.Windows.Forms;
using MissionEditor.FileReaderCore;
using MissionEditor.FileReaderCore.Conditions;

namespace MissionEditor.UI.ConditionUI
{
    public partial class DummyUI : UserControl, IConditionUI
    {
        readonly Dummy condition;

        public DummyUI(Condition condition)
        {
            InitializeComponent();
        }

        public void Apply()
        {
        }
    }
}
