namespace MissionEditor.UI.ConditionUI
{
    partial class BuildingExistsUI
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sideComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buildingExistsComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // sideComboBox
            // 
            this.sideComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sideComboBox.FormattingEnabled = true;
            this.sideComboBox.Items.AddRange(new object[] {
            "Atreides",
            "Harkonnen",
            "Ordos",
            "Emperor",
            "Fremen",
            "Smugglers",
            "Mercenaries",
            "Sandworm"});
            this.sideComboBox.Location = new System.Drawing.Point(19, 37);
            this.sideComboBox.Name = "sideComboBox";
            this.sideComboBox.Size = new System.Drawing.Size(121, 21);
            this.sideComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Side";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Building Index";
            // 
            // buildingExistsComboBox
            // 
            this.buildingExistsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.buildingExistsComboBox.FormattingEnabled = true;
            this.buildingExistsComboBox.Items.AddRange(new object[] {
            "Atreides Construction Yard",
            "Harkonnen Construction Yard",
            "Ordos Construction Yard",
            "Imperial Construction Yard",
            "Atreides Concrete",
            "Harkonnen Concrete",
            "Ordos Concrete",
            "Atreides Test Concrete",
            "Harkonnen Test Concrete",
            "Ordos Test Concrete",
            "Atreides Wind Trap",
            "Harkonnen Wind Trap",
            "Ordos Wind Trap",
            "Atreides Barracks",
            "Harkonnen Barracks",
            "Ordos Barracks",
            "Fremen Barracks",
            "Atreides Wall",
            "Harkonnen Wall",
            "Ordos Wall",
            "Atreides Refinery",
            "Harkonnen Refinery",
            "Ordos Refinery",
            "Atreides Medium Gun Turret",
            "Harkonnen Medium Gun Turret",
            "Ordos Medium Gun Turret",
            "Atreides Outpost",
            "Harkonnen Outpost",
            "Ordos Outpost",
            "Atreides Large Gun Turret",
            "Harkonnen Large Gun Turret",
            "Ordos Large Gun Turret",
            "Atreides High Tech Factory",
            "Harkonnen High Tech Factory",
            "Ordos High Tech Factory",
            "Atreides Light Factory",
            "Harkonnen Light Factory",
            "Ordos Light Factory",
            "Atreides Silo",
            "Harkonnen Silo",
            "Ordos Silo",
            "Atreides Heavy Factory",
            "Harkonnen Heavy Factory",
            "Ordos Heavy Factory",
            "Mercenary Heavy Factory",
            "Imperial Heavy Factory",
            "Atreides Star Port",
            "Harkonnen Star Port",
            "Ordos Star Port",
            "Smuggler Star Port",
            "Atreides Repair Pad",
            "Harkonnen Repair Pad",
            "Ordos Repair Pad",
            "Atreides Research Centre",
            "Harkonnen Research Centre",
            "Ordos Research Centre",
            "Atreides Palace",
            "Harkonnen Palace",
            "Ordos Palace",
            "Imperial Palace",
            "Special Harkonnen Outpost",
            "Special Ordos Outpost"});
            this.buildingExistsComboBox.Location = new System.Drawing.Point(19, 96);
            this.buildingExistsComboBox.Name = "buildingExistsComboBox";
            this.buildingExistsComboBox.Size = new System.Drawing.Size(164, 21);
            this.buildingExistsComboBox.TabIndex = 4;
            // 
            // BuildingExists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buildingExistsComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sideComboBox);
            this.Name = "BuildingExists";
            this.Size = new System.Drawing.Size(188, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox sideComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox buildingExistsComboBox;
    }
}
