using System;
using System.IO;
using System.Windows.Forms;

namespace FastTouch
{
    public partial class ScoreFormChart : Form
    {

        public ScoreFormChart()
        {
            InitializeComponent();
        }

        private void ScoreFormChart_Load(object sender, EventArgs e)
        {
            LabelTime.Text = Results.time;
            LabelScore.Text = Results.score;
            LabelSpeed.Text = Results.speed;
            LabelMistakes.Text = Results.mistakes;
            Text = !Results.warmingUp ? "Результат" : "Разминка";
        }

        private void ScoreFormChartKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Results.startOrWork = true;
                File.WriteAllText(Results.mistakesPath, Results.maxNoMistakesCount.ToString());
                Close();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Results.startOrWork = false;
                Close();
            }
        }
    }
}

