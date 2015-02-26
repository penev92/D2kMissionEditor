namespace MissionEditor.UI.ConditionUI
{
    partial class CasualtiesUI
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
            this.casualtyThresholdTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.unknownC1TextBox = new System.Windows.Forms.TextBox();
            this.unknownC2TextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.sideComboBox.Location = new System.Drawing.Point(19, 126);
            this.sideComboBox.Name = "sideComboBox";
            this.sideComboBox.Size = new System.Drawing.Size(121, 21);
            this.sideComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Side";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Casualty Threshold";
            // 
            // casualtyThresholdTextBox
            // 
            this.casualtyThresholdTextBox.Location = new System.Drawing.Point(19, 16);
            this.casualtyThresholdTextBox.Name = "casualtyThresholdTextBox";
            this.casualtyThresholdTextBox.Size = new System.Drawing.Size(100, 20);
            this.casualtyThresholdTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "unknown C1";
            // 
            // unknownC1TextBox
            // 
            this.unknownC1TextBox.Location = new System.Drawing.Point(19, 56);
            this.unknownC1TextBox.Name = "unknownC1TextBox";
            this.unknownC1TextBox.Size = new System.Drawing.Size(100, 20);
            this.unknownC1TextBox.TabIndex = 5;
            // 
            // unknownC2TextBox
            // 
            this.unknownC2TextBox.Location = new System.Drawing.Point(19, 91);
            this.unknownC2TextBox.Name = "unknownC2TextBox";
            this.unknownC2TextBox.Size = new System.Drawing.Size(100, 20);
            this.unknownC2TextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "unknown C2";
            // 
            // Casualties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.unknownC2TextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.unknownC1TextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.casualtyThresholdTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sideComboBox);
            this.Name = "Casualties";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox sideComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox casualtyThresholdTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox unknownC1TextBox;
        private System.Windows.Forms.TextBox unknownC2TextBox;
        private System.Windows.Forms.Label label4;
    }
}
