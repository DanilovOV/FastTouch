namespace FastTouch
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.RadioButtonTransparent = new System.Windows.Forms.RadioButton();
            this.RadioButtonColor = new System.Windows.Forms.RadioButton();
            this.RadioButtonImage = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TextBoxImagePath = new System.Windows.Forms.TextBox();
            this.ComboBoxColour = new System.Windows.Forms.ComboBox();
            this.TextBoxMinTime = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 139);
            this.label1.MaximumSize = new System.Drawing.Size(195, 0);
            this.label1.MinimumSize = new System.Drawing.Size(195, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 40);
            this.label1.TabIndex = 7;
            this.label1.Text = "Минимальное время для попадания в статистику (секунд):";
            // 
            // RadioButtonTransparent
            // 
            this.RadioButtonTransparent.AutoSize = true;
            this.RadioButtonTransparent.Location = new System.Drawing.Point(6, 31);
            this.RadioButtonTransparent.Name = "RadioButtonTransparent";
            this.RadioButtonTransparent.Size = new System.Drawing.Size(88, 17);
            this.RadioButtonTransparent.TabIndex = 2;
            this.RadioButtonTransparent.TabStop = true;
            this.RadioButtonTransparent.Text = "Прозрачный";
            this.RadioButtonTransparent.UseVisualStyleBackColor = true;
            // 
            // RadioButtonColor
            // 
            this.RadioButtonColor.AutoSize = true;
            this.RadioButtonColor.Location = new System.Drawing.Point(6, 77);
            this.RadioButtonColor.Name = "RadioButtonColor";
            this.RadioButtonColor.Size = new System.Drawing.Size(94, 17);
            this.RadioButtonColor.TabIndex = 3;
            this.RadioButtonColor.TabStop = true;
            this.RadioButtonColor.Text = "Одноцветный";
            this.RadioButtonColor.UseVisualStyleBackColor = true;
            // 
            // RadioButtonImage
            // 
            this.RadioButtonImage.AutoSize = true;
            this.RadioButtonImage.Location = new System.Drawing.Point(6, 54);
            this.RadioButtonImage.Name = "RadioButtonImage";
            this.RadioButtonImage.Size = new System.Drawing.Size(95, 17);
            this.RadioButtonImage.TabIndex = 4;
            this.RadioButtonImage.TabStop = true;
            this.RadioButtonImage.Text = "Изображение";
            this.RadioButtonImage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TextBoxImagePath);
            this.groupBox1.Controls.Add(this.ComboBoxColour);
            this.groupBox1.Controls.Add(this.RadioButtonImage);
            this.groupBox1.Controls.Add(this.RadioButtonTransparent);
            this.groupBox1.Controls.Add(this.RadioButtonColor);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 112);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Режим фона:";
            // 
            // TextBoxImagePath
            // 
            this.TextBoxImagePath.Location = new System.Drawing.Point(107, 54);
            this.TextBoxImagePath.Name = "TextBoxImagePath";
            this.TextBoxImagePath.Size = new System.Drawing.Size(213, 20);
            this.TextBoxImagePath.TabIndex = 10;
            // 
            // ComboBoxColour
            // 
            this.ComboBoxColour.FormattingEnabled = true;
            this.ComboBoxColour.Location = new System.Drawing.Point(107, 76);
            this.ComboBoxColour.Name = "ComboBoxColour";
            this.ComboBoxColour.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxColour.TabIndex = 9;
            // 
            // TextBoxMinTime
            // 
            this.TextBoxMinTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxMinTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.55F);
            this.TextBoxMinTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TextBoxMinTime.Location = new System.Drawing.Point(130, 153);
            this.TextBoxMinTime.Name = "TextBoxMinTime";
            this.TextBoxMinTime.Size = new System.Drawing.Size(35, 13);
            this.TextBoxMinTime.TabIndex = 8;
            this.TextBoxMinTime.Text = "120";
            this.TextBoxMinTime.ValidatingType = typeof(int);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(342, 199);
            this.ControlBox = false;
            this.Controls.Add(this.TextBoxMinTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SettingsFormKeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RadioButtonTransparent;
        private System.Windows.Forms.RadioButton RadioButtonColor;
        private System.Windows.Forms.RadioButton RadioButtonImage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TextBoxImagePath;
        private System.Windows.Forms.ComboBox ComboBoxColour;
        private System.Windows.Forms.MaskedTextBox TextBoxMinTime;
    }
}