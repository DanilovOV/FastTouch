using System;
using System.IO;
using System.Windows.Forms;

namespace FastTouch
{
    public partial class ScoreFormChart : Form
    {
        AppState appState;

        public ScoreFormChart(AppState appState)
        {
            this.appState = appState;
            InitializeComponent();
        }

        private void ScoreFormChart_Load(object sender, EventArgs e)
        {
            LabelTime.Text = Results.time;
            LabelScore.Text = Results.score;
            LabelSpeed.Text = Results.speed;
            LabelMistakes.Text = Results.mistakes;
            Text = !Results.warmingUp ? "Результат" : "Разминка";
            appState.SetScoreState();
        }

        private void ScoreFormChartKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                appState.SetMenuState();
                File.WriteAllText(Results.mistakesPath, Results.maxNoMistakesCount.ToString());
                Close();
            }
            if (e.KeyCode == Keys.Escape)
            {
                appState.SetWaitInputState();
                Close();
            }
        }
    }
}
