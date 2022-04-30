using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FastTouch
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            LabelNoMistakes.Text = $"Знаков подряд без ошибок: {Results.maxNoMistakesCount}";
            LabelNowSymbols.Text = $"Напечатано символов: {Results.nowSymbols}";
            LabelAllSymbols.Text = $"Всего символов: {Results.allSymbols}";
            ProgressData.SelectionStart = 0;
        }

        private void ProgressFormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter || e.KeyCode == Keys.F2)
            {
                Results.x = 1;
                ProgressChart.Series[0].Points.Clear();
                ProgressData.Text = "";
                ActiveForm.Close();
            }
        }
    }
}
