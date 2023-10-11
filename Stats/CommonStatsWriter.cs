using System;
using System.IO;
using System.Linq;

namespace FastTouch
{
    internal class CommonStatsWriter
    {
        private StreamWriter writer;

        internal CommonStatsWriter(string statsFilePath)
        {
            writer = File.AppendText(statsFilePath);
        }

        internal void write(string stats)
        {
            using (writer)
            {
                writer.WriteLine(stats);
            }
        }
    }
}
