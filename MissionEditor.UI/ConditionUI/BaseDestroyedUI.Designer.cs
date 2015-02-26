namespace MissionEditor.UI.ConditionUI
{
    partial class BaseDestroyedUI
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
            this.unknownBD1 = new System.Windows.Forms.TextBox();
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
            this.sideComboBox.Location = new System.Drawing.Point(15, 96);
            this.sideComboBox.Name = "sideComboBox";
            this.sideComboBox.Size = new System.Drawing.Size(121, 21);
            this.sideComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Side";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Unknown BD1";
            // 
            // unknownBD1
            // 
            this.unknownBD1.Location = new System.Drawing.Point(15, 43);
            this.unknownBD1.Name = "unknownBD1";
            this.unknownBD1.Size = new System.Drawing.Size(100, 20);
            this.unknownBD1.TabIndex = 3;
            // 
            // BaseDestroyed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.unknownBD1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sideComboBox);
            this.Name = "BaseDestroyed";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox sideComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox unknownBD1;
    }
}
