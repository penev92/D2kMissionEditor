using System;
using System.Globalization;
using System.Windows.Forms;
using System.IO;
using MissionEditor.FileReaderCore;
using MissionEditor.UI.ConditionUI;

namespace MissionEditor.UI
{
    public partial class MainForm : Form
    {
        Mission mission = new Mission();
        string currentFilename = "";

        public MainForm()
        {
            InitializeComponent();

            UpdateTitle();
        }

        void UpdateTitle()
        {
            if (string.IsNullOrEmpty(currentFilename))
                Text = "Dune 2000 Mission Editor";
            else
                Text = currentFilename + " - Dune 2000 Mission Editor";
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
                {
                    Filter = "Dune 2000 mission files (*.mis)|*.mis"
                };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            ParseMission(dialog.FileName);
        }

        private void ParseMission(string filePath)
        {
            currentFilename = Path.GetFileNameWithoutExtension(filePath);
            UpdateTitle();
            mission = FileReader.ParseMissionFile(filePath);

            UpdateEventListBox();
            UpdateConditionListBox();

            FillUIFromMission();
            EnableBoxes();
        }

        private void FillUIFromMission()
        {
            //Someone suggested this should all be abstracted. They were right tbh.
            for (var i = 0; i < Mission.FactionCount; i++)
            {
                Controls["techLevel" + (i + 1)].Text = mission.HouseTechLevel[i].ToString(CultureInfo.InvariantCulture);
            }

            for (var i = 0; i < Mission.FactionCount; i++)
            {
                Controls["startingMoney" + (i + 1)].Text = mission.StartingMoney[i].ToString(CultureInfo.InvariantCulture);
            }

            for (var i = 0; i < Mission.FactionCount; i++)
            {
                Controls["index" + (i + 1)].Text = mission.HouseIndexAllocation[i].ToString(CultureInfo.InvariantCulture);
            }

            for (var i = 0; i < Mission.FactionCount; i++)
            {
                for (var j = 0; j < DiplomacyRow.ByteCount; j++)
                {
                    ((ComboBox)Controls["comboBox" + (i + 1) + "to" + (j + 1)]).SelectedIndex = mission.Diplomacy[i].RawData[j];
                }
            }

            tileSetDataTextBox.Text = mission.TilesetData;
            tileSetImageTextBox.Text = mission.Tileset;
            timeLimitTextBox.Text = mission.TimeLimit.ToString(CultureInfo.InvariantCulture);
        }

        private void FillMissionFromUI()
        {
            for (var i = 0; i < 8; i++)
            {
                mission.HouseTechLevel[i] = Convert.ToByte(Controls["techLevel" + (i + 1)].Text);
            }

            for (var i = 0; i < 8; i++)
            {
                mission.StartingMoney[i] = Convert.ToInt32(Controls["startingMoney" + (i + 1)].Text);
            }

            for (var i = 0; i < 8; i++)
            {
                mission.HouseIndexAllocation[i] = Convert.ToByte(Controls["index" + (i + 1)].Text);
            }

            for (var i = 0; i < 8; i++)
            {
                for (var j = 0; j < 8; j++)
                {
                    mission.Diplomacy[i].RawData[j] = (byte)((ComboBox)Controls["comboBox" + (i + 1) + "to" + (j + 1)]).SelectedIndex;
                }
            }

            mission.TilesetDataName = tileSetDataTextBox.Text.ToCharArray();
            mission.TilesetImageName = tileSetImageTextBox.Text.ToCharArray();

            mission.TimeLimit = Convert.ToInt32(timeLimitTextBox.Text);
        }    

        // Why is this even used?
        private void EnableBoxes()
        {
            for (var i = 0; i < 8; i++)
            {
                Controls["techLevel" + (i + 1)].Enabled = true;
            }

            for (var i = 0; i < 8; i++)
            {
                Controls["startingMoney" + (i + 1)].Enabled = true;
            }

            for (var i = 0; i < 8; i++)
            {
                Controls["index" + (i + 1)].Enabled = true;
            }

            for (var i = 0; i < 8; i++)
            {
                for (var j = 0; j < 8; j++)
                {
                    Controls["comboBox" + (i + 1) + "to" + (j + 1)].Enabled = true;
                }
            }

            saveButton.Enabled = true;
            tileSetDataTextBox.Enabled = true;
            tileSetImageTextBox.Enabled = true;
            timeLimitTextBox.Enabled = true;

            applyEventChangesButton.Enabled = true;
            applyConditionChangesButton.Enabled = true;
            eventPanel.Controls.Clear();
            conditionPanel.Controls.Clear();
            eventConditionMappingTableLayoutPanel.RowCount = 0;
            eventConditionMappingTableLayoutPanel.Controls.Clear();
            selectedEventTitle.Text = "";
            selectedConditionTitle.Text = "";

            changeEventTypeButton.Enabled = true;
            changeConditionTypeButton.Enabled = true;

            addEventButton.Enabled = true;
            addConditionButton.Enabled = true;

            deleteEventButton.Enabled = true;
            deleteConditionButton.Enabled = true;

            addMappingButton.Enabled = true;
            deleteLastMappingButton.Enabled = true;

            importAISegmentButton.Enabled = true;
            exportAISegmentButton.Enabled = true;
            editSegmentsButton.Enabled = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //Let the user pick the files to parse
            var dialog = new SaveFileDialog
                {
                    FileName = currentFilename,
                    Filter = "Dune 2000 mission files (*.mis)|*.mis"
                };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            FillMissionFromUI();
            SaveMission(dialog.FileName);
        }

        private void SaveMission(string filename)
        {
            //mission.SaveToFile(filename);
        }

        private void addEventButton_Click(object sender, EventArgs e)
        {
            //if (mission.EventCount >= Mission.MaxEventCount)
            //    return;

            //mission.EventCount++;
            //mission.Events[mission.EventCount - 1] = new Event();
            //UpdateEventListBox();
            //eventPanel.Controls.Clear();
            //eventConditionMappingTableLayoutPanel.Controls.Clear();
        }

        private void UpdateEventListBox()
        {
            //eventListBox.Items.Clear();

            //for (var i = 0; i < mission.EventCount; i++)
            //{
            //    eventListBox.Items.Add(i + " - " + Statics.EventNames[(int)mission.Events[i].Type]);
            //}
        }

        private void UpdateConditionListBox()
        {
            conditionListBox.Items.Clear();

            for (var i = 0; i < mission.ConditionCount; i++)
            {
                conditionListBox.Items.Add(i + " - " + Statics.ConditionNames[(int)mission.Conditions[i].Type]);
            }
        }

        private void addConditionButton_Click(object sender, EventArgs e)
        {
            if (mission.ConditionCount >= Mission.MaxConditionCount)
                return;

            mission.Conditions[mission.ConditionCount++] = new Condition(new byte[Condition.ByteCount]);

            UpdateConditionListBox();
            conditionPanel.Controls.Clear();
        }

        // Called when a condition is selected in the ListBox.
        // Creates the condition-specific UI and populates it with the relevant data.
        private void conditionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (conditionListBox.SelectedIndex == -1)
                return;

            var condition = mission.Conditions[conditionListBox.SelectedIndex];
            selectedConditionTitle.Text = conditionListBox.SelectedItem.ToString();
            conditionPanel.Controls.Clear();

            switch (condition.Type)
            {
                case ConditionType.BuildingExists:
                    conditionPanel.Controls.Add(new BuildingExistsUI(condition));
                    break;
                case ConditionType.UnitExists:
                    conditionPanel.Controls.Add(new UnitExistsUI(condition));
                    break;
                case ConditionType.Interval:
                    conditionPanel.Controls.Add(new IntervalUI(condition));
                    break;
                case ConditionType.Timer:
                    conditionPanel.Controls.Add(new TimerUI(condition));
                    break;
                case ConditionType.Casualties:
                    conditionPanel.Controls.Add(new CasualtiesUI(condition));
                    break;
                case ConditionType.BaseDestroyed:
                    conditionPanel.Controls.Add(new BaseDestroyedUI(condition));
                    break;
                case ConditionType.UnitsDestroyed:
                    conditionPanel.Controls.Add(new UnitsDestroyedUI(condition));
                    break;
                case ConditionType.UnitInTile:
                    conditionPanel.Controls.Add(new UnitInTileUI(condition));
                    break;
                case ConditionType.Cash:
                    conditionPanel.Controls.Add(new CashUI(condition));
                    break;
                case ConditionType.DummyCondition:
                    conditionPanel.Controls.Add(new DummyUI(condition));
                    break;
            }
        }

        private void applyConditionChangesButton_Click(object sender, EventArgs e)
        {
            if (conditionPanel.Controls.Count == 1)
                ((IConditionUI)conditionPanel.Controls[0]).Apply();
        }

        private void eventListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (eventListBox.SelectedIndex == -1)
                return;
            var selectedEvent = mission.Events[eventListBox.SelectedIndex];
            selectedEventTitle.Text = eventListBox.SelectedItem.ToString();

            UpdateConditionMappingTable();


            eventPanel.Controls.Clear();
            //switch (selectedEvent.raw[13])
            //{
            //    case 0:
            //        eventPanel.Controls.Add(new Reinforcement(selectedEvent));
            //        break;
            //    case 1:
            //        eventPanel.Controls.Add(new StarportDelivery(selectedEvent));
            //        break;
            //    case 2:
            //        eventPanel.Controls.Add(new Diplomacy(selectedEvent));
            //        break;
            //    case 4:
            //        eventPanel.Controls.Add(new Beserk(selectedEvent));
            //        break;
            //    case 6:
            //        eventPanel.Controls.Add(new Unknown6(selectedEvent));
            //        break;
            //    case 10:
            //        eventPanel.Controls.Add(new MissionWin(selectedEvent));
            //        break;
            //    case 11:
            //        eventPanel.Controls.Add(new MissionWin(selectedEvent));
            //        break;
            //    case 14:
            //        eventPanel.Controls.Add(new RevealMap(selectedEvent));
            //        break;
            //    case 16:
            //        eventPanel.Controls.Add(new TimeLimitDisable(selectedEvent));
            //        break;
            //    case 17:
            //        eventPanel.Controls.Add(new EventUI.Message(selectedEvent));
            //        break;
            //    case 18:
            //        eventPanel.Controls.Add(new UnitSpawn(selectedEvent));
            //        break;
            //    case 19:
            //        eventPanel.Controls.Add(new SetCondition(selectedEvent));
            //        break;
                
            //    default:
            //        break;
            //}
        }

        private void UpdateConditionMappingTable()
        {
            //eventConditionMappingTableLayoutPanel.Controls.Clear();
            //if (eventListBox.SelectedIndex >= 0)
            //{
            //    Event selectedEvent = mission.Events[eventListBox.SelectedIndex];

            //    int numberOfMappings = selectedEvent.raw[12];
            //    eventConditionMappingTableLayoutPanel.ColumnCount = 2;
            //    //eventConditionMappingTableLayoutPanel.RowCount = numberOfMappings;

            //    for (int i = 0; i < numberOfMappings; i++)
            //    {
            //        CheckBox checkBox = new CheckBox();
            //        //checkBox.AutoSize = true;
            //        checkBox.Width = 140;
            //        checkBox.Text = conditionListBox.Items[selectedEvent.raw[19 + i]].ToString();
            //        checkBox.Checked = selectedEvent.raw[33 + i] == 1;
            //        checkBox.Name = "CheckBox" + i;
            //        checkBox.CheckedChanged += new EventHandler(checkBox_CheckedChanged);
            //        eventConditionMappingTableLayoutPanel.Controls.Add(checkBox, 0, i);
            //        Button button = new Button();
            //        button.Name = "MappingButton" + i;
            //        button.Click += new EventHandler(mappingButton_Click);
            //        button.Text = "Set Index";
            //        eventConditionMappingTableLayoutPanel.Controls.Add(button, 1, i);
            //    }
            //}
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            //Event selectedEvent = mission.events[eventListBox.SelectedIndex];
            //int index = Convert.ToInt32(((CheckBox)sender).Name.Substring("CheckBox".Length));

            //selectedEvent.raw[33 + index] = (byte)((selectedEvent.raw[33 + index] == 1) ? 0 : 1);
        }
        private void mappingButton_Click(object sender, EventArgs e)
        {
            //Event selectedEvent = mission.events[eventListBox.SelectedIndex];
            //int index = Convert.ToInt32(((Button)sender).Name.Substring("MappingButton".Length));

            //string result = selectedEvent.raw[19 + index].ToString();
            //if (Extensions.InputBox("Change Event-Condition Mapping", "Changing this value will change the mapping entry's target condition.\nBe careful that you map it to a real condition.", ref result) == DialogResult.OK)
            //{
            //    selectedEvent.raw[19 + index] = Convert.ToByte(result);
            //    UpdateConditionMappingTable();
            //}
        }
        
        private void applyEventChangesButton_Click(object sender, EventArgs e)
        {
            //if(eventPanel.Controls.Count == 1)
            //    ((IEventUI)eventPanel.Controls[0]).Apply();
        }

        private void addMappingButton_Click(object sender, EventArgs e)
        {
            //if (eventListBox.SelectedIndex >= 0)
            //{
            //    Event selectedEvent = mission.events[eventListBox.SelectedIndex];

            //    int mappingCount = selectedEvent.raw[12];
            //    if (mappingCount < 14)
            //    {
            //        selectedEvent.raw[12]++;
            //        selectedEvent.raw[19 + mappingCount] = 0;
            //        selectedEvent.raw[33 + mappingCount] = 0;
            //        UpdateConditionMappingTable();
            //    }
            //}
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.mvinetwork.co.uk/dune"); 
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            //AboutWindow window = new AboutWindow();
            //window.ShowDialog();
        }

        private void changeEventTypeButton_Click(object sender, EventArgs e)
        {
            if (eventListBox.SelectedIndex >= 0)
            {
                var selectedEvent = mission.Events[eventListBox.SelectedIndex];
                //SelectEventTypeDialog dialog = new SelectEventTypeDialog(selectedEvent.raw[13]);
                //if (dialog.ShowDialog() == DialogResult.OK)
                //{
                //    mission.events[eventListBox.SelectedIndex] = new Event();
                //    mission.events[eventListBox.SelectedIndex].raw[13] = (byte)dialog.EventCode;
                //    UpdateEventListBox();
                //    eventPanel.Controls.Clear();
                //    eventConditionMappingTableLayoutPanel.Controls.Clear();
                //}
            }
        }

        private void deleteLastMappingButton_Click(object sender, EventArgs e)
        {
            //if (eventListBox.SelectedIndex >= 0)
            //{
            //    Event selectedEvent = mission.events[eventListBox.SelectedIndex];

            //    int mappingCount = selectedEvent.raw[12];
            //    if (mappingCount > 1)
            //    {
            //        selectedEvent.raw[12]--;
            //        UpdateConditionMappingTable();
            //    }
            //}
        }

        private void changeConditionTypeButton_Click(object sender, EventArgs e)
        {
            if (conditionListBox.SelectedIndex < 0)
                return;
            
            var selectedCondition = mission.Conditions[conditionListBox.SelectedIndex];
            var dialog = new SelectConditionTypeDialog(selectedCondition.RawData[Condition.ConditionTypeByteIndex]);
             
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            
            mission.Conditions[conditionListBox.SelectedIndex] = new Condition(new byte[Condition.ByteCount]);
            mission.Conditions[conditionListBox.SelectedIndex].RawData[Condition.ConditionTypeByteIndex] = (byte)dialog.ConditionCode;
            UpdateConditionListBox();
            conditionPanel.Controls.Clear();
        }

        private void deleteEventButton_Click(object sender, EventArgs e)
        {
            if (eventListBox.SelectedIndex < 0)
                return;
            
            for (var i = eventListBox.SelectedIndex; i < mission.EventCount-1; i++)
            {
                mission.Events[i] = mission.Events[i + 1];
            }

            mission.EventCount--;
            UpdateEventListBox();
            eventPanel.Controls.Clear();
            eventConditionMappingTableLayoutPanel.Controls.Clear();
        }

        private void deleteConditionButton_Click(object sender, EventArgs e)
        {
            //if (conditionListBox.SelectedIndex >= 0)
            //{
            //    int selectedIndex = conditionListBox.SelectedIndex;
            //    for (int i = conditionListBox.SelectedIndex; i < mission.conditionCount - 1; i++)
            //    {
            //        mission.conditions[i] = mission.conditions[i + 1];
            //    }
            //    mission.conditionCount--;
            //    UpdateConditionListBox();
            //    conditionPanel.Controls.Clear();
            //    if (MessageBox.Show("Do you wish to update the event-condition mappings?\n\nThis is STRONGLY advised unless you are an advanced\nuser who knows exactly what you're doing.", "Update Event-Condition Mappings?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        // TODO: Update

            //        for (int j = 0; j < mission.eventCount; j++)
            //        {
            //            int mappingCount = mission.events[j].raw[12];

            //            for (int k = 0; k < mappingCount; k++)
            //            {
            //                if (mission.events[j].raw[19 + k] > selectedIndex)
            //                {
            //                    mission.events[j].raw[19 + k]--;
            //                }
            //            }
            //        }
            //        UpdateConditionMappingTable();
            //    }
            //}
        }

        private void exportAISegmentButton_Click(object sender, EventArgs e)
        {
            string sideIndexString = "0";
            if (Extensions.InputBox("Select Side", "Please select a side index to export AI from.", ref  sideIndexString) == DialogResult.OK)
            {
                int sideIndex = Convert.ToInt32(sideIndexString);
                if(sideIndex >= 0 && sideIndex < 8)
                {
                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.FileName = currentFilename + "Seg" + sideIndex;
                    dialog.Filter = "D2K+ AI Segment files (*.misai)|*.misai";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportAISegment(sideIndex, dialog.FileName);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a side index between 0 and 7");
                }
            }
        }

        private void ExportAISegment(Mission mission, int sideIndex, string filename)
        {
            var fs = new FileStream(filename, FileMode.Create);
            var bw = new BinaryWriter(fs);
            var buffer = new byte[7607];

            for (var i = 0; i < 7607; i++)
            {
                buffer[i] = mission.AISection[sideIndex].RawData[i + 1];
            }

            bw.Write(buffer);
            bw.Close();
            fs.Close();
            //MessageBox.Show("Exported side " + sideIndex + " as " + Path.GetFileName(filename));
        }

        private void ExportAISegment(int sideIndex, string filename)
        {
            var fs = new FileStream(filename, FileMode.Create);
            var bw = new BinaryWriter(fs);
            var buffer = new byte[7607];

            for (var i = 0; i < 7607; i++)
            {
                buffer[i] = mission.AISection[sideIndex].RawData[i + 1];
            }

            bw.Write(buffer);
            bw.Close();
            fs.Close();
            MessageBox.Show("Exported side " + sideIndex + " as " + Path.GetFileName(filename));
        }

        private void importAISegmentButton_Click(object sender, EventArgs e)
        {
            string sideIndexString = "0";
            if (Extensions.InputBox("Select Side", "Please select a side index to OVERWRITE with AI from file.", ref  sideIndexString) == DialogResult.OK)
            {
                int sideIndex = Convert.ToInt32(sideIndexString);
                if (sideIndex >= 0 && sideIndex < 8)
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.FileName = currentFilename + "Seg" + sideIndex;
                    dialog.Filter = "D2K+ AI Segment files (*.misai)|*.misai";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        ImportAISegment(sideIndex, dialog.FileName);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a side index between 0 and 7");
                }
            }
        }

        private void ImportAISegment(int sideIndex, string filename)
        {
            var fs = new FileStream(filename, FileMode.Open);
            var br = new BinaryReader(fs);
            var buffer = new byte[7607];

            br.Read(buffer, 0, 7607);
            br.Close();
            fs.Close();

            mission.AISection[sideIndex].RawData[0] = (byte)sideIndex;

            for (var i = 0; i < 7607; i++)
            {
                mission.AISection[sideIndex].RawData[i + 1] = buffer[i];
            }

            MessageBox.Show("Overwrote side " + sideIndex + " with " + Path.GetFileName(filename));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Let the user pick the files to parse
            //OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter = "Dune 2000 mission files (*.mis)|*.mis";
            //dialog.Multiselect = true;
            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    for (int i = 0; i < dialog.FileNames.Length; i++)
            //    {
            //        Mission mission = new Mission();
            //        mission.LoadFromFile(dialog.FileNames[i]);
            //        for (int j = 0; j < 8; j++)
            //        {
            //            string filename = Path.GetFileNameWithoutExtension(dialog.FileNames[i]);
            //            string path = Path.GetDirectoryName(dialog.FileNames[i]);
            //            filename = path + "\\" + filename + "-" + j.ToString() + ".misai";
            //            ExportAISegment(mission, j, filename);
            //        }
            //    }
            //    MessageBox.Show("Exported sides");                
            //}
        }

        private void editSegmentsButton_Click(object sender, EventArgs e)
        {
            //EditSegmentForm form = new EditSegmentForm(this.mission);
            //form.ShowDialog();
        }

    }
}
