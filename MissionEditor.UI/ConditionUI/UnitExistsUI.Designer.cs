namespace MissionEditor.UI.ConditionUI
{
    partial class UnitExistsUI
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
            this.unitExistsComboBox = new System.Windows.Forms.ComboBox();
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
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Unit Index";
            // 
            // unitExistsComboBox
            // 
            this.unitExistsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unitExistsComboBox.FormattingEnabled = true;
            this.unitExistsComboBox.Items.AddRange(new object[] {
            "Light Infantry",
            "Trooper",
            "Engineer",
            "Thumper",
            "Sardaukar",
            "Trike",
            "Raider",
            "Quad",
            "Harvester",
            "A Combat Tank",
            "H Combat Tank",
            "O Combat Tank",
            "MCV",
            "Missile tank",
            "Deviator",
            "Seige Tank",
            "Sonic Tank",
            "Devastator",
            "Carryall",
            "A Carryall",
            "Ornithopter (useless)",
            "Stealth Fremen",
            "Fremen",
            "Saboteur",
            "Death Hand Missle",
            "Glitched Unit",
            "Frigate (Starport)",
            "Grenadier",
            "Stealth Raider",
            "MP Sardaukar"});
            this.unitExistsComboBox.Location = new System.Drawing.Point(19, 96);
            this.unitExistsComboBox.Name = "unitExistsComboBox";
            this.unitExistsComboBox.Size = new System.Drawing.Size(121, 21);
            this.unitExistsComboBox.TabIndex = 3;
            // 
            // UnitExists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.unitExistsComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sideComboBox);
            this.Name = "UnitExists";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox sideComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox unitExistsComboBox;
    }
}
