namespace FastTouch
{
    partial class StartForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            this.LabelText = new System.Windows.Forms.Label();
            this.LabelPastText = new System.Windows.Forms.Label();
            this.TimerLabel = new System.Windows.Forms.Label();
            this.LabelSubText = new System.Windows.Forms.Label();
            this.LabelSubPastText = new System.Windows.Forms.Label();
            this.TextBoxInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LabelText
            // 
            this.LabelText.AutoSize = true;
            this.LabelText.BackColor = System.Drawing.Color.Transparent;
            this.LabelText.Font = new System.Drawing.Font("Cambria", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelText.ForeColor = System.Drawing.Color.Black;
            this.LabelText.Location = new System.Drawing.Point(-7, 0);
            this.LabelText.Margin = new System.Windows.Forms.Padding(0);
            this.LabelText.MinimumSize = new System.Drawing.Size(550, 60);
            this.LabelText.Name = "LabelText";
            this.LabelText.Size = new System.Drawing.Size(550, 60);
            this.LabelText.TabIndex = 10;
            this.LabelText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelPastText
            // 
            this.LabelPastText.AutoSize = true;
            this.LabelPastText.BackColor = System.Drawing.Color.Transparent;
            this.LabelPastText.Font = new System.Drawing.Font("Cambria", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelPastText.ForeColor = System.Drawing.Color.Black;
            this.LabelPastText.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LabelPastText.Location = new System.Drawing.Point(9, 0);
            this.LabelPastText.Margin = new System.Windows.Forms.Padding(0);
            this.LabelPastText.MaximumSize = new System.Drawing.Size(850, 50);
            this.LabelPastText.MinimumSize = new System.Drawing.Size(850, 60);
            this.LabelPastText.Name = "LabelPastText";
            this.LabelPastText.Size = new System.Drawing.Size(850, 60);
            this.LabelPastText.TabIndex = 1;
            this.LabelPastText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TimerLabel
            // 
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.BackColor = System.Drawing.Color.Transparent;
            this.TimerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimerLabel.ForeColor = System.Drawing.Color.White;
            this.TimerLabel.Location = new System.Drawing.Point(898, 9);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(50, 30);
            this.TimerLabel.TabIndex = 11;
            this.TimerLabel.Text = "0:00";
            this.TimerLabel.UseCompatibleTextRendering = true;
            // 
            // LabelSubText
            // 
            this.LabelSubText.AutoSize = true;
            this.LabelSubText.BackColor = System.Drawing.Color.White;
            this.LabelSubText.Font = new System.Drawing.Font("Cambria", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelSubText.ForeColor = System.Drawing.Color.Black;
            this.LabelSubText.Location = new System.Drawing.Point(469, 155);
            this.LabelSubText.Margin = new System.Windows.Forms.Padding(0);
            this.LabelSubText.MinimumSize = new System.Drawing.Size(550, 60);
            this.LabelSubText.Name = "LabelSubText";
            this.LabelSubText.Size = new System.Drawing.Size(550, 60);
            this.LabelSubText.TabIndex = 12;
            this.LabelSubText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelSubPastText
            // 
            this.LabelSubPastText.AutoSize = true;
            this.LabelSubPastText.BackColor = System.Drawing.Color.Lavender;
            this.LabelSubPastText.Font = new System.Drawing.Font("Cambria", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelSubPastText.ForeColor = System.Drawing.Color.Black;
            this.LabelSubPastText.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LabelSubPastText.Location = new System.Drawing.Point(-381, 155);
            this.LabelSubPastText.Margin = new System.Windows.Forms.Padding(0);
            this.LabelSubPastText.MaximumSize = new System.Drawing.Size(850, 50);
            this.LabelSubPastText.MinimumSize = new System.Drawing.Size(850, 60);
            this.LabelSubPastText.Name = "LabelSubPastText";
            this.LabelSubPastText.Size = new System.Drawing.Size(850, 60);
            this.LabelSubPastText.TabIndex = 13;
            this.LabelSubPastText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextBoxInput
            // 
            this.TextBoxInput.BackColor = System.Drawing.Color.Gray;
            this.TextBoxInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxInput.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.TextBoxInput.Location = new System.Drawing.Point(0, 0);
            this.TextBoxInput.Name = "TextBoxInput";
            this.TextBoxInput.Size = new System.Drawing.Size(0, 13);
            this.TextBoxInput.TabIndex = 1;
            this.TextBoxInput.TextChanged += new System.EventHandler(this.TextIsChanged);
            this.TextBoxInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyCommandHandler);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(960, 325);
            this.ControlBox = false;
            this.Controls.Add(this.LabelSubPastText);
            this.Controls.Add(this.LabelSubText);
            this.Controls.Add(this.TimerLabel);
            this.Controls.Add(this.LabelPastText);
            this.Controls.Add(this.TextBoxInput);
            this.Controls.Add(this.LabelText);
            this.ForeColor = System.Drawing.Color.Coral;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FastTouch";
            this.TransparencyKey = this.BackColor;
            this.Load += new System.EventHandler(this.StartForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StartForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelText;
        private System.Windows.Forms.Label LabelPastText;
        private System.Windows.Forms.Label TimerLabel;
        private System.Windows.Forms.Label LabelSubText;
        private System.Windows.Forms.Label LabelSubPastText;
        private System.Windows.Forms.TextBox TextBoxInput;
    }
}

