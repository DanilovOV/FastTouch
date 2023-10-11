using System;
using static System.Net.Mime.MediaTypeNames;
using static System.Resources.ResXFileRef;

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
            string[] sessionProps = dataString.Split(Char.Parse(" "));

            this.timestamp = long.Parse(sessionProps[0]);
            this.date = sessionProps[1];
            this.time = sessionProps[2];
            this.speed = int.Parse(sessionProps[3]);
            this.mistakesProcent = double.Parse(sessionProps[4]);
            this.duration = sessionProps[5];
        }
    }
}
