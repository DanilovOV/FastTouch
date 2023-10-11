using System;
using System.IO;
using System.Windows.Forms;

namespace FastTouch
{
    public partial class ScoreForm : Form
    {
        AppState appStates;

        public ScoreForm(AppState appStates)
        {
            this.appStates = appStates;
            InitializeComponent();
        }

        private void ScoreForm_Load(object sender, EventArgs e)
        {
            LabelTime.Text = Results.time;
            LabelScore.Text = Results.score;
            LabelSpeed.Text = Results.speed;
            LabelMistakes.Text = Results.mistakes;
            Text = !Results.warmingUp ? "Результат" : "Разминка";
        }

        private void ScoreFormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                appStates.SetMenuState();
                File.WriteAllText(Results.mistakesPath, Results.maxNoMistakesCount.ToString());
                Close();
            }
            if (e.KeyCode == Keys.Escape)
            {
                appStates.SetSessionState();
                Close();
            }
        }
    }
}

