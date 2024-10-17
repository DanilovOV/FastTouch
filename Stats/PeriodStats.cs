using System;
using System.Collections.Generic;
using System.Linq;

namespace FastTouch
{
    internal class PeriodStats
    {
        private List<SessionData> sessions;
        private readonly long dayToSec = 86400;
        private readonly long weekToSec = 604800;
        private readonly long monthToSec = 2592000;
        private readonly long yearToSec = 31536000;
        private readonly long currentTimestamp;

        public PeriodStats(List<SessionData> sessions)
        {
            this.sessions = sessions;
            currentTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        public int GetCommonAverageSpeed()
        {
            if (sessions.Count == 0)
            {
                return 0;
            }

            return (int)sessions.Average(data => data.speed);
        }

        private int GetPeriodAverageSpeed(long periodInSeconds)
        {
            var periodSessions = sessions
                .Where(data => data.timestamp >= currentTimestamp - periodInSeconds)
                .Select(data => data.speed)
                .ToList();

            if (periodSessions.Count == 0)
            {
                return 0;
            }

            return (int)periodSessions.Average();
        }

        public int GetDayAverageSpeed()
        {
            return GetPeriodAverageSpeed(dayToSec);
        }

        public int GetWeekAverageSpeed()
        {
            return GetPeriodAverageSpeed(weekToSec);
        }

        public int GetMonthAverageSpeed()
        {
            return GetPeriodAverageSpeed(monthToSec);
        }

        public int GetYearAverageSpeed()
        {
            return GetPeriodAverageSpeed(yearToSec);
        }
    }
}