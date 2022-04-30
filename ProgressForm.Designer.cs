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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.LabelNowSymbols = new System.Windows.Forms.Label();
            this.LabelAllSymbols = new System.Windows.Forms.Label();
            this.LabelNoMistakes = new System.Windows.Forms.Label();
            this.ProgressData = new System.Windows.Forms.TextBox();
            this.ProgressChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressChart)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelNowSymbols
            // 
            this.LabelNowSymbols.AutoSize = true;
            this.LabelNowSymbols.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LabelNowSymbols.Location = new System.Drawing.Point(279, 202);
            this.LabelNowSymbols.Name = "LabelNowSymbols";
            this.LabelNowSymbols.Size = new System.Drawing.Size(123, 13);
            this.LabelNowSymbols.TabIndex = 1;
            this.LabelNowSymbols.Text = "Напечатано символов:";
            // 
            // LabelAllSymbols
            // 
            this.LabelAllSymbols.AutoSize = true;
            this.LabelAllSymbols.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LabelAllSymbols.Location = new System.Drawing.Point(309, 228);
            this.LabelAllSymbols.Name = "LabelAllSymbols";
            this.LabelAllSymbols.Size = new System.Drawing.Size(93, 13);
            this.LabelAllSymbols.TabIndex = 0;
            this.LabelAllSymbols.Text = "Всего символов:";
            // 
            // LabelNoMistakes
            // 
            this.LabelNoMistakes.AutoSize = true;
            this.LabelNoMistakes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LabelNoMistakes.Location = new System.Drawing.Point(487, 202);
            this.LabelNoMistakes.Name = "LabelNoMistakes";
            this.LabelNoMistakes.Size = new System.Drawing.Size(166, 15);
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
            this.ProgressData.Size = new System.Drawing.Size(230, 253);
            this.ProgressData.TabIndex = 3;
            this.ProgressData.TabStop = false;
            this.ProgressData.WordWrap = false;
            // 
            // ProgressChart
            // 
            this.ProgressChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(57)))), ((int)(((byte)(55)))));
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.IsMarginVisible = false;
            chartArea2.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(146)))), ((int)(((byte)(141)))));
            chartArea2.AxisX.MajorGrid.Interval = 0D;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisX.MajorTickMark.Enabled = false;
            chartArea2.AxisX.Minimum = 1D;
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.IsStartedFromZero = false;
            chartArea2.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(146)))), ((int)(((byte)(141)))));
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisY.MajorTickMark.Enabled = false;
            chartArea2.InnerPlotPosition.Auto = false;
            chartArea2.InnerPlotPosition.Height = 85F;
            chartArea2.InnerPlotPosition.Width = 90F;
            chartArea2.InnerPlotPosition.X = 4F;
            chartArea2.InnerPlotPosition.Y = 4F;
            chartArea2.IsSameFontSizeForAllAxes = true;
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 94F;
            chartArea2.Position.Width = 94F;
            chartArea2.Position.X = 2F;
            chartArea2.Position.Y = 2F;
            this.ProgressChart.ChartAreas.Add(chartArea2);
            this.ProgressChart.Location = new System.Drawing.Point(258, 5);
            this.ProgressChart.Name = "ProgressChart";
            this.ProgressChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            series2.Name = "Series1";
            this.ProgressChart.Series.Add(series2);
            this.ProgressChart.Size = new System.Drawing.Size(469, 161);
            this.ProgressChart.TabIndex = 2;
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(0x3b, 0x39, 0x37);
            this.ClientSize = new System.Drawing.Size(0x2b4, 0x10b);
            this.ControlBox = false;
            this.Controls.Add(this.LabelNoMistakes);
            this.Controls.Add(this.LabelNowSymbols);
            this.Controls.Add(this.ProgressData);
            this.Controls.Add(this.LabelAllSymbols);
            this.Controls.Add(this.ProgressChart);
            this.ForeColor = System.Drawing.Color.FromArgb(150, 0x92, 0x8d);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "ProgressForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Прогресс";
            this.Load += new System.EventHandler(this.ProgressForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProgressFormKeyDown);
            this.ProgressChart.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label LabelNowSymbols;
        private System.Windows.Forms.Label LabelAllSymbols;
        private System.Windows.Forms.Label LabelNoMistakes;
        public System.Windows.Forms.DataVisualization.Charting.Chart ProgressChart;
        public System.Windows.Forms.TextBox ProgressData;
    }
}