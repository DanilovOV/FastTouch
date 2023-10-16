using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastTouch
{
    public class AppState
    {
        StartForm mainForm;
        public enum States { menu, waitInput, session, score, pause }
        public States state { get; protected set; }

        public AppState(StartForm mainForm) 
        { 
            this.mainForm = mainForm;
        }

        public void SetMenuState()
        {
            state = States.menu;

            mainForm.LabelPastText.Text = "Рекорд: ";
            mainForm.LabelText.Text = $" {mainForm.inputSpeedRecord} зн/мин";
        }

        public void SetWaitInputState()
        {
            state = States.waitInput;
            mainForm.appTickTimer.Stop();
            mainForm.stopwatch.Stop();
        }

        public void SetSessionState()
        {
            state = States.session;

            mainForm.appTickTimer.Start();
            mainForm.stopwatch.Start();
        }

        public void SetScoreState()
        {
            state = States.score;

            mainForm.appTickTimer.Stop();
            mainForm.stopwatch.Stop();
        }

        public void SetPauseState()
        {
            state = States.pause;

            mainForm.appTickTimer.Stop();
            mainForm.stopwatch.Stop();
        }
    }
}
