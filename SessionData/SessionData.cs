using System;
using System.Text.RegularExpressions;

namespace FastTouch
{
    
    public class SessionData
    {
        public long timestamp;
        public string date;
        public string time;
        public int speed;
        public double mistakesProcent;
        public string duration;

        public SessionData(long timestamp, string date, string time, int speed, double mistakesProcent, string duration)
        {
            this.timestamp = timestamp;
            this.date = date;
            this.time = time;
            this.speed = speed;
            this.mistakesProcent = mistakesProcent;
            this.duration = duration;
        }

        public SessionData(string dataString)
        {
            string[] sessionProps = Regex.Replace(dataString, " +", " ").Split(Char.Parse(" "));
            
            if (sessionProps.Length == 5)
            {
                // Старый формат записи без таймстампа
                this.timestamp = 0;
                this.date = sessionProps[0];
                this.time = sessionProps[1];
                this.speed = int.Parse(sessionProps[2]);
                this.mistakesProcent = double.Parse(sessionProps[3]);
                this.duration = sessionProps[4];
            }
            else
            {
                this.timestamp = long.Parse(sessionProps[0]);
                this.date = sessionProps[1];
                this.time = sessionProps[2];
                this.speed = int.Parse(sessionProps[3]);
                this.mistakesProcent = double.Parse(sessionProps[4]);
                this.duration = sessionProps[5];
            }
        }
    }
}
