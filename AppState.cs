using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastTouch
{
    public class AppState
    {
        StartForm mainForm;
        public enum States { menu, session, pause }
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

        public void SetSessionState()
        {
            state = States.session;
        }

        public void SetPauseState()
        {
            state = States.pause;
        }
    }
}
