namespace FastTouch
{
    partial class ScoreForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {   
            this.LabelTime = new System.Windows.Forms.Label();
            this.LabelScore = new System.Windows.Forms.Label();
            this.LabelSpeed = new System.Windows.Forms.Label();
            this.LabelMistakes = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // LabelTime
            //
            this.LabelTime.AutoSize = true;
            this.LabelTime.Font = new System.Drawing.Font("Cambria", 11f);
            this.LabelTime.ForeColor = System.Drawing.Color.FromArgb(150, 0x92, 0x8d);
            this.LabelTime.Location = new System.Drawing.Point(0x3e, 0x27);
            this.LabelTime.Name = "LabelTime";
            this.LabelTime.Size = new System.Drawing.Size(0x58, 0x11);
            this.LabelTime.TabIndex = 2;
            this.LabelTime.Text = "Время:  0:00";
            // 
            // LabelScore
            //
            this.LabelScore.AutoSize = true;
            this.LabelScore.Font = new System.Drawing.Font("Cambria", 11f);
            this.LabelScore.Location = new System.Drawing.Point(0x18, 0x3b);
            this.LabelScore.Name = "LabelScore";
            this.LabelScore.Size = new System.Drawing.Size(0x6a, 0x11);
            this.LabelScore.TabIndex = 1;
            this.LabelScore.Text = "Напечатано:  0";
            // 
            // LabelSpeed
            //

            this.LabelSpeed.AutoSize = true;
            this.LabelSpeed.Font = new System.Drawing.Font("Cambria", 11f);
            this.LabelSpeed.Location = new System.Drawing.Point(30, 15);
            this.LabelSpeed.Name = "LabelSpeed";
            this.LabelSpeed.Size = new System.Drawing.Size(0x8f, 0x11);
            this.LabelSpeed.TabIndex = 3;
            this.LabelSpeed.Text = "Скорость:  0 зн/мин";
            // 
            // LabelMistakes
            // 
            this.LabelMistakes.AutoSize = true;
            this.LabelMistakes.Font = new System.Drawing.Font("Cambria", 11f);
            this.LabelMistakes.Location = new System.Drawing.Point(0x26, 0x23);
            this.LabelMistakes.Name = "LabelMistakes";
            this.LabelMistakes.Size = new System.Drawing.Size(0x80, 0x11);
            this.LabelMistakes.TabIndex = 4;
            this.LabelMistakes.Text = "Ошибок:  0.0% (0)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LabelSpeed);
            this.groupBox1.Controls.Add(this.LabelMistakes);
            this.groupBox1.Font = new System.Drawing.Font("Cambria", 12f);
            this.groupBox1.Location = new System.Drawing.Point(12, 0x55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(0xce, 0x41);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            // 
            // ScoreForm
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(0x3b, 0x39, 0x37);
            this.ClientSize = new System.Drawing.Size(230, 160);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LabelTime);
            this.Controls.Add(this.LabelScore);
            this.ForeColor = System.Drawing.Color.FromArgb(150, 0x92, 0x8d);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.Load += new System.EventHandler(this.ScoreForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScoreFormKeyDown);
            this.Name = "ScoreForm";
            this.Text = "Результат";
        }

        #endregion

        private System.Windows.Forms.Label LabelTime;
        private System.Windows.Forms.Label LabelScore;
        private System.Windows.Forms.Label LabelSpeed;
        private System.Windows.Forms.Label LabelMistakes;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}