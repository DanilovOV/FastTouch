using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastTouch
{
    internal class SessionDataViews
    {
        readonly string delimeter = " ";
        readonly string mediumDelimeter = "  ";
        readonly string bigDelimeter = "   ";

        public string GetFileViewString(SessionData sessionData)
        {
            return string.Concat(sessionData.timestamp
                + delimeter + sessionData.date
                + delimeter + sessionData.time
                + delimeter + sessionData.speed
                + delimeter + sessionData.mistakesProcent
                + delimeter + sessionData.duration
            );
        }

        public string GetUserStatsViewString(SessionData sessionData)
        {
            return string.Concat(sessionData.date
                + mediumDelimeter + sessionData.time
                + bigDelimeter + sessionData.speed
                + bigDelimeter + sessionData.mistakesProcent
                + bigDelimeter + sessionData.duration
            );
        }
    }
}
