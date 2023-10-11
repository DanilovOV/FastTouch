using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FastTouch
{
    public partial class ProgressForm : Form
    {

        List<SessionData> sessions;
        SessionDataViews sessionDataViews;

        public ProgressForm()
        {
            InitializeComponent();
            sessionDataViews = new SessionDataViews();
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            LabelNoMistakes.Text = $"Знаков подряд без ошибок: {Results.maxNoMistakesCount}";
            LabelNowSymbols.Text = $"Напечатано символов: {Results.nowSymbols}";
            LabelAllSymbols.Text = $"Всего символов: {Results.allSymbols}";
            ProgressData.SelectionStart = 0;

            initFileStats();

            // ТЕСТИРУЕТСЯ ======================================
            PeriodStats periodStats = new PeriodStats(sessions);
            // ТЕСТИРУЕТСЯ ======================================
        }

        private void initFileStats()
        {
            sessions = GetSessions();
            SetProgressChartData();
        }

        private List<SessionData> GetSessions()
        {
            string[] sessionsStrings = File.ReadAllLines(Results.statsPath);
            List<SessionData> sessions = new List<SessionData>();

            foreach (string sessionString in sessionsStrings)
            {
                sessions.Add(new SessionData(sessionString));
            }

            return sessions;
        }

        private void SetProgressChartData()
        {
            for (int i = sessions.Count - 1; i >= 0; i--) 
            {
                ProgressData.Text += (sessionDataViews.GetUserStatsViewString(sessions[i]) + Environment.NewLine);
                ProgressChart.Series[0].Points.AddXY(i, sessions[i].speed);
            }
        }

        private void ProgressFormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter || e.KeyCode == Keys.F2)
            {
                CloseForm();
            }
        }

        private void CloseForm()
        {
            Results.x = 1;
            ProgressChart.Series[0].Points.Clear();
            ProgressData.Text = "";
            ActiveForm.Close();
        }
    }
}
