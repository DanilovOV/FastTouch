using System;
using System.IO;
using System.Windows.Forms;

namespace FastTouch
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            TextBoxMinTime.Text = (Results.minTimeForStats / 1000).ToString();
        }

        private void SettingsFormKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape) || (e.KeyCode == Keys.F3))
            {
                if ((int.Parse(TextBoxMinTime.Text) * 1000) != Results.minTimeForStats)
                {
                    WriteFileSettings("minTimeForStats", (int.Parse(TextBoxMinTime.Text) * 1000).ToString());
                    Results.InitFileSettings();
                }
                Close();
            }
        }

        public void WriteFileSettings(string param, string value)
        {
            string[] contents = File.ReadAllLines(Results.settingsPath);
            int index = 0;
            while (true)
            {
                if (index < contents.Length)
                {
                    char[] separator = new char[] { ':' };
                    string[] strArray2 = contents[index].Split(separator);
                    if (strArray2[0] != param)
                    {
                        index++;
                        continue;
                    }
                    contents[index] = param + ":" + value;
                }
                File.WriteAllLines(Results.settingsPath, contents);
                return;
            }
        }
    }
}
