using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MissionEditor
{
    public partial class SelectEventTypeDialog : Form
    {
        int eventCode = -1;
        Dictionary<string, int> entries = new Dictionary<string, int>();

        public int EventCode
        {
            get { return eventCode; }
        }


        public SelectEventTypeDialog(int initialEventCode)
        {
            eventCode = initialEventCode;
            InitializeComponent();
            entries.Add("Reinforcement", 0);
            entries.Add("Starport Delivery", 1);
            entries.Add("Diplomacy", 2);
            entries.Add("Beserk", 4);
            entries.Add("Unknown6", 6);
            entries.Add("Mission Win", 10);
            entries.Add("Mission Fail", 11);
            entries.Add("Reveal Map", 14);
            entries.Add("Time Limit Disable", 16);
            entries.Add("Message", 17);
            entries.Add("Unit Spawn", 18);
            entries.Add("Set Condition", 19);

            int selectedIndex = -1;

            for (int i = 0; i < entries.Count; i++)
			{
                comboBox1.Items.Add(entries.ElementAt(i).Key);
                if (eventCode == entries.ElementAt(i).Value)
                    selectedIndex = i;
			}
            comboBox1.SelectedIndex = selectedIndex;
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            eventCode = entries[comboBox1.SelectedItem.ToString()];
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
