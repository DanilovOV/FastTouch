using System;
using System.Linq;
using System.Collections.Generic;

namespace FastTouch
{
    internal class PeriodStats
    {
        List<SessionData> sessions;
        protected long dayToSec = 86400;
        long timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        public PeriodStats(List<SessionData> sessions) 
        { 
            this.sessions = sessions;
        }

        public int GetAwerageSpeed()
        {
            return (int)sessions.Average(data => data.speed);
        }

        public int GetDayAwerageSpeed()
        {
            List<int> periodSessions = new List<int>();

            for (int i = sessions.Count - 1; i >= 0; i--)
            {
                if (sessions[i].timestamp >= timestamp - dayToSec)
                {
                    periodSessions.Add(sessions[i].speed);
                }
                else
                {
                    break;
                }

            }

            if (periodSessions.Count == 0)
            {
                return 0;
            }

            return (int)periodSessions.Average();
        }

        public int GetWeekAwerageSpeed()
        {
            return 1;
        }

        public int GetMonthAwerageSpeed()
        {
            return 1;
        }

        public int GetYearAwerageSpeed()
        {
            return 1;
        }
    }
}
