using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MissionEditor.FileReaderCore;

namespace MissionEditor.UI
{
    public partial class SelectConditionTypeDialog : Form
    {
        readonly Dictionary<string, int> entries = new Dictionary<string, int>();
        
        int conditionCode = -1;

        public int ConditionCode
        {
            get { return conditionCode; }
        }

        public SelectConditionTypeDialog(int initialConditionCode)
        {
            InitializeComponent();

            for (var i = 0; i < Statics.ConditionNames.Length - 1; i++)
            {
                entries.Add(Statics.ConditionNames[i], i);
            }

            var selectedIndex = -1;
            conditionCode = initialConditionCode;

            for (var i = 0; i < entries.Count; i++)
            {
                comboBox1.Items.Add(entries.ElementAt(i).Key);

                if (conditionCode == entries.ElementAt(i).Value)
                    selectedIndex = i;
            }
            comboBox1.SelectedIndex = selectedIndex;
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conditionCode = entries[comboBox1.SelectedItem.ToString()];
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
