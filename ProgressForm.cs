using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FastTouch
{
    public partial class ProgressForm : Form
    {

        List<SessionData> sessions;
        SessionDataViews sessionDataViews;
        short sessionsViewLimit = 300;

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
            StringBuilder progressTableText = new StringBuilder();

            if (sessions.Count < sessionsViewLimit)
            {
                for (int i = sessions.Count - 1; i >= 0; i--)
                {
                    progressTableText.Append(sessionDataViews.GetUserStatsViewString(sessions[i]) + Environment.NewLine);
                    ProgressChart.Series[0].Points.AddXY(i, sessions[i].speed);
                }
            }
            else
            {
                for (int i = sessions.Count - 1; i >= 0; i--)
                {
                    progressTableText.Append(sessionDataViews.GetUserStatsViewString(sessions[i]) + Environment.NewLine);
                }

                for (int i = sessions.Count - sessionsViewLimit; i < sessions.Count; i++)
                {
                    ProgressChart.Series[0].Points.AddXY(i + 1 - (sessions.Count - sessionsViewLimit), sessions[i].speed);
                }
            }

            ProgressData.Text = progressTableText.ToString();
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
