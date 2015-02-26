using System;
using System.Linq;

namespace MissionEditor.FileReaderCore.Events
{
    public class StarportDelivery : UnitSpawn
    {
        public StarportDelivery(byte[] data)
            : base(data) { }

        public override string ToString()
        {
            var type = Statics.EventNames[Type];
            var faction = Statics.FactionNames[FactionIndex];
            var units = Units.Select(u => Statics.GetUnitNameFromIndex(u));

            return string.Format("{0}: {1} receive a delivery of {{ {2} }} at coordinates ({3}, {4})."
                + " (Note: uses the primary starport's location regardless of the specifies coordinates!){5}",
                type, faction, string.Join(", ", units), CoordinateX, CoordinateY, PrintConditions());
        }

        //private void addUnitButton_Click(object sender, EventArgs e)
        //{
        //    if (numberOfUnits < 25)
        //    {
        //        numberOfUnits++;
                
        //        ComboBox comboBox = new ComboBox();
        //        comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        //        comboBox.Items.AddRange(Mission.Units);
        //        comboBox.SelectedIndex = 0;
        //        tableLayoutPanel1.Controls.Add(comboBox, 0, numberOfUnits);
        //        tableLayoutPanel1.RowCount = numberOfUnits;
        //    }
        //}

        //private void deleteLastUnitButton_Click(object sender, EventArgs e)
        //{
        //    if(numberOfUnits > 1)
        //    {
        //        numberOfUnits--;
                
        //        tableLayoutPanel1.Controls.RemoveAt(numberOfUnits);
        //        tableLayoutPanel1.RowCount = numberOfUnits;
        //    }
        //}
    }
}
