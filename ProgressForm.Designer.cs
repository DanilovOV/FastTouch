namespace FastTouch
{
    partial class ProgressForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.LabelNowSymbols = new System.Windows.Forms.Label();
            this.LabelAllSymbols = new System.Windows.Forms.Label();
            this.LabelNoMistakes = new System.Windows.Forms.Label();
            this.ProgressData = new System.Windows.Forms.TextBox();
            this.ProgressChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.LabelAverageSpeed = new System.Windows.Forms.Label();
            this.LabelAverageSpeedDay = new System.Windows.Forms.Label();
            this.LabelAverageSpeedMonth = new System.Windows.Forms.Label();
            this.LabelAverageSpeedWeek = new System.Windows.Forms.Label();
            this.LabelAverageSpeedYear = new System.Windows.Forms.Label();
            this.LabelAverageSpeedCommon = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressChart)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelNowSymbols
            // 
            this.LabelNowSymbols.AutoSize = true;
            this.LabelNowSymbols.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LabelNowSymbols.Location = new System.Drawing.Point(264, 190);
            this.LabelNowSymbols.Name = "LabelNowSymbols";
            this.LabelNowSymbols.Size = new System.Drawing.Size(123, 13);
            this.LabelNowSymbols.TabIndex = 1;
            this.LabelNowSymbols.Text = "Напечатано символов:";
            // 
            // LabelAllSymbols
            // 
            this.LabelAllSymbols.AutoSize = true;
            this.LabelAllSymbols.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LabelAllSymbols.Location = new System.Drawing.Point(264, 215);
            this.LabelAllSymbols.Name = "LabelAllSymbols";
            this.LabelAllSymbols.Size = new System.Drawing.Size(93, 13);
            this.LabelAllSymbols.TabIndex = 0;
            this.LabelAllSymbols.Text = "Всего символов:";
            // 
            // LabelNoMistakes
            // 
            this.LabelNoMistakes.AutoSize = true;
            this.LabelNoMistakes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LabelNoMistakes.Location = new System.Drawing.Point(264, 265);
            this.LabelNoMistakes.Name = "LabelNoMistakes";
            this.LabelNoMistakes.Size = new System.Drawing.Size(148, 13);
            this.LabelNoMistakes.TabIndex = 5;
            this.LabelNoMistakes.Text = "Знаков подряд без ошибок:";
            // 
            // ProgressData
            // 
            this.ProgressData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(57)))), ((int)(((byte)(55)))));
            this.ProgressData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProgressData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.55F);
            this.ProgressData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(146)))), ((int)(((byte)(141)))));
            this.ProgressData.Location = new System.Drawing.Point(12, 12);
            this.ProgressData.MaximumSize = new System.Drawing.Size(100, 10000);
            this.ProgressData.MinimumSize = new System.Drawing.Size(230, 200);
            this.ProgressData.Multiline = true;
            this.ProgressData.Name = "ProgressData";
            this.ProgressData.ReadOnly = true;
            this.ProgressData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProgressData.ShortcutsEnabled = false;
            this.ProgressData.Size = new System.Drawing.Size(230, 274);
            this.ProgressData.TabIndex = 3;
            this.ProgressData.TabStop = false;
            this.ProgressData.WordWrap = false;
            // 
            // ProgressChart
            // 
            this.ProgressChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(57)))), ((int)(((byte)(55)))));
            chartArea10.AxisX.IsLabelAutoFit = false;
            chartArea10.AxisX.IsMarginVisible = false;
            chartArea10.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea10.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            chartArea10.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(146)))), ((int)(((byte)(141)))));
            chartArea10.AxisX.MajorGrid.Interval = 0D;
            chartArea10.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea10.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea10.AxisX.MajorTickMark.Enabled = false;
            chartArea10.AxisX.Minimum = 1D;
            chartArea10.AxisY.IsLabelAutoFit = false;
            chartArea10.AxisY.IsStartedFromZero = false;
            chartArea10.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea10.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            chartArea10.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(146)))), ((int)(((byte)(141)))));
            chartArea10.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea10.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea10.AxisY.MajorTickMark.Enabled = false;
            chartArea10.InnerPlotPosition.Auto = false;
            chartArea10.InnerPlotPosition.Height = 85F;
            chartArea10.InnerPlotPosition.Width = 90F;
            chartArea10.InnerPlotPosition.X = 4F;
            chartArea10.InnerPlotPosition.Y = 4F;
            chartArea10.IsSameFontSizeForAllAxes = true;
            chartArea10.Name = "ChartArea1";
            chartArea10.Position.Auto = false;
            chartArea10.Position.Height = 94F;
            chartArea10.Position.Width = 94F;
            chartArea10.Position.X = 2F;
            chartArea10.Position.Y = 2F;
            this.ProgressChart.ChartAreas.Add(chartArea10);
            this.ProgressChart.Location = new System.Drawing.Point(258, 5);
            this.ProgressChart.Name = "ProgressChart";
            this.ProgressChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            series10.Name = "Series1";
            this.ProgressChart.Series.Add(series10);
            this.ProgressChart.Size = new System.Drawing.Size(469, 161);
            this.ProgressChart.TabIndex = 2;
            // 
            // LabelAverageSpeed
            // 
            this.LabelAverageSpeed.AutoSize = true;
            this.LabelAverageSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LabelAverageSpeed.Location = new System.Drawing.Point(496, 190);
            this.LabelAverageSpeed.Name = "LabelAverageSpeed";
            this.LabelAverageSpeed.Size = new System.Drawing.Size(140, 13);
            this.LabelAverageSpeed.TabIndex = 6;
            this.LabelAverageSpeed.Text = "Средняя скорость печати:";
            // 
            // LabelAverageSpeedDay
            // 
            this.LabelAverageSpeedDay.AutoSize = true;
            this.LabelAverageSpeedDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LabelAverageSpeedDay.Location = new System.Drawing.Point(496, 215);
            this.LabelAverageSpeedDay.Name = "LabelAverageSpeedDay";
            this.LabelAverageSpeedDay.Size = new System.Drawing.Size(34, 13);
            this.LabelAverageSpeedDay.TabIndex = 7;
            this.LabelAverageSpeedDay.Text = "День";
            // 
            // LabelAverageSpeedMonth
            // 
            this.LabelAverageSpeedMonth.AutoSize = true;
            this.LabelAverageSpeedMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LabelAverageSpeedMonth.Location = new System.Drawing.Point(496, 240);
            this.LabelAverageSpeedMonth.Name = "LabelAverageSpeedMonth";
            this.LabelAverageSpeedMonth.Size = new System.Drawing.Size(40, 13);
            this.LabelAverageSpeedMonth.TabIndex = 8;
            this.LabelAverageSpeedMonth.Text = "Месяц";
            // 
            // LabelAverageSpeedWeek
            // 
            this.LabelAverageSpeedWeek.AutoSize = true;
            this.LabelAverageSpeedWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LabelAverageSpeedWeek.Location = new System.Drawing.Point(611, 215);
            this.LabelAverageSpeedWeek.Name = "LabelAverageSpeedWeek";
            this.LabelAverageSpeedWeek.Size = new System.Drawing.Size(45, 13);
            this.LabelAverageSpeedWeek.TabIndex = 9;
            this.LabelAverageSpeedWeek.Text = "Неделя";
            // 
            // LabelAverageSpeedYear
            // 
            this.LabelAverageSpeedYear.AutoSize = true;
            this.LabelAverageSpeedYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LabelAverageSpeedYear.Location = new System.Drawing.Point(611, 240);
            this.LabelAverageSpeedYear.Name = "LabelAverageSpeedYear";
            this.LabelAverageSpeedYear.Size = new System.Drawing.Size(25, 13);
            this.LabelAverageSpeedYear.TabIndex = 10;
            this.LabelAverageSpeedYear.Text = "Год";
            // 
            // LabelAverageSpeedCommon
            // 
            this.LabelAverageSpeedCommon.AutoSize = true;
            this.LabelAverageSpeedCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LabelAverageSpeedCommon.Location = new System.Drawing.Point(496, 265);
            this.LabelAverageSpeedCommon.Name = "LabelAverageSpeedCommon";
            this.LabelAverageSpeedCommon.Size = new System.Drawing.Size(76, 13);
            this.LabelAverageSpeedCommon.TabIndex = 11;
            this.LabelAverageSpeedCommon.Text = "За все время";
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(57)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(693, 287);
            this.ControlBox = false;
            this.Controls.Add(this.LabelAverageSpeedCommon);
            this.Controls.Add(this.LabelAverageSpeedYear);
            this.Controls.Add(this.LabelAverageSpeedWeek);
            this.Controls.Add(this.LabelAverageSpeedMonth);
            this.Controls.Add(this.LabelAverageSpeedDay);
            this.Controls.Add(this.LabelAverageSpeed);
            this.Controls.Add(this.LabelNoMistakes);
            this.Controls.Add(this.LabelNowSymbols);
            this.Controls.Add(this.ProgressData);
            this.Controls.Add(this.LabelAllSymbols);
            this.Controls.Add(this.ProgressChart);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(146)))), ((int)(((byte)(141)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "ProgressForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Прогресс";
            this.Load += new System.EventHandler(this.ProgressForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProgressFormKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ProgressChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelNowSymbols;
        private System.Windows.Forms.Label LabelAllSymbols;
        private System.Windows.Forms.Label LabelNoMistakes;
        public System.Windows.Forms.DataVisualization.Charting.Chart ProgressChart;
        public System.Windows.Forms.TextBox ProgressData;
        private System.Windows.Forms.Label LabelAverageSpeed;
        private System.Windows.Forms.Label LabelAverageSpeedDay;
        private System.Windows.Forms.Label LabelAverageSpeedMonth;
        private System.Windows.Forms.Label LabelAverageSpeedWeek;
        private System.Windows.Forms.Label LabelAverageSpeedYear;
        private System.Windows.Forms.Label LabelAverageSpeedCommon;
    }
}