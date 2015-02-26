using System;
using System.Collections.Generic;
using System.Linq;

namespace MissionEditor.FileReaderCore.Events
{
    public class UnitSpawn : Event
    {
        public const int MaxNumberOfUnits = 25;

        public UInt32 CoordinateX;
        public UInt32 CoordinateY;
        public byte NumberOfUnits;
        public byte FactionIndex;
        public byte DeployAction;
        public List<byte> Units;

        public UnitSpawn(byte[] data)
            : base(data)
        {
            CoordinateX = BitConverter.ToUInt32(RawData, (int)ByteIndices.CoordinateX);
            CoordinateY = BitConverter.ToUInt32(RawData, (int)ByteIndices.CoordinateY);
            NumberOfUnits = RawData[(int)ByteIndices.NumberOfUnits];
            FactionIndex = RawData[(int)ByteIndices.FactionIndex];
            DeployAction = RawData[(int)ByteIndices.DeployAction];

            Units = new List<byte>();
            for (var i = 0; i < NumberOfUnits; i++)
                Units.Add(RawData[(int)ByteIndices.FirstUnitTypeIndexIndex + i]);
        }

        public override void WriteData()
        {
            BitConverter.GetBytes(CoordinateX).CopyTo(RawData, (int)ByteIndices.CoordinateX);
            BitConverter.GetBytes(CoordinateY).CopyTo(RawData, (int)ByteIndices.CoordinateY);
            RawData[(int)ByteIndices.NumberOfUnits] = NumberOfUnits;
            RawData[(int)ByteIndices.FactionIndex] = FactionIndex;
            RawData[(int)ByteIndices.DeployAction] = DeployAction;

            for (var i = 0; i < NumberOfUnits; i++)
                RawData[(int)ByteIndices.FirstUnitTypeIndexIndex + i] = Units[i];
        }

        public override string ToString()
        {
            var type = Statics.EventNames[Type];
            var faction = Statics.FactionNames[FactionIndex];
            var units = Units.Select(u => Statics.GetUnitNameFromIndex(u));

            return string.Format("{0}: Spawn units {{ {1} }} for {2} at coordinates ({3}, {4}).{5}",
                type, string.Join(", ", units), faction, CoordinateX, CoordinateY, PrintConditions());
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

        public enum ByteIndices
        {
            CoordinateX = 0,
            CoordinateY = 4,
            NumberOfUnits = 14,
            FactionIndex = 15,
            DeployAction = 18,
            FirstUnitTypeIndexIndex = 47
        }
    }
}
