namespace ContactsAPPUI
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NumberTextBox = new System.Windows.Forms.TextBox();
            this.ColorComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.VisibilityCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // NumberTextBox
            // 
            this.NumberTextBox.Location = new System.Drawing.Point(273, 27);
            this.NumberTextBox.Name = "NumberTextBox";
            this.NumberTextBox.Size = new System.Drawing.Size(121, 22);
            this.NumberTextBox.TabIndex = 0;
            this.NumberTextBox.TextChanged += new System.EventHandler(this.NumberTextBox_TextChanged);
            // 
            // ColorComboBox
            // 
            this.ColorComboBox.FormattingEnabled = true;
            this.ColorComboBox.Location = new System.Drawing.Point(273, 64);
            this.ColorComboBox.Name = "ColorComboBox";
            this.ColorComboBox.Size = new System.Drawing.Size(121, 24);
            this.ColorComboBox.TabIndex = 1;
            this.ColorComboBox.SelectedIndexChanged += new System.EventHandler(this.ColorComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Введите число (0-100):";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Выберите цвет:";
            // 
            // VisibilityCheckBox
            // 
            this.VisibilityCheckBox.AutoSize = true;
            this.VisibilityCheckBox.Location = new System.Drawing.Point(119, 104);
            this.VisibilityCheckBox.Name = "VisibilityCheckBox";
            this.VisibilityCheckBox.Size = new System.Drawing.Size(246, 20);
            this.VisibilityCheckBox.TabIndex = 5;
            this.VisibilityCheckBox.Text = "Сделать ColorTextBox невидимым";
            this.VisibilityCheckBox.UseVisualStyleBackColor = true;
            this.VisibilityCheckBox.CheckedChanged += new System.EventHandler(this.VisibilityCheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 410);
            this.Controls.Add(this.VisibilityCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ColorComboBox);
            this.Controls.Add(this.NumberTextBox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NumberTextBox;
        private System.Windows.Forms.ComboBox ColorComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox VisibilityCheckBox;
    }
}

