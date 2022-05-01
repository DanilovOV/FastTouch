﻿using System;
using System.IO;

namespace FastTouch
{
    public static class Results
    {
        public static string time;
        public static string score;
        public static string speed;
        public static string mistakes;
        public static string appMode = "Main menu";
        public static bool warmingUp = false;
        public static string statsPath = @"Properties\Stats.txt";
        public static string mistakesPath = @"Properties\MaxNoMistakes.txt";
        public static double allSymbols = 0;
        public static double nowSymbols = 0;
        public static int x = 1;
        public static int maxNoMistakesCount = int.Parse(File.ReadAllText(mistakesPath));
        public static string settingsPath = @"Properties\Settings.txt";
        public static int minTimeForStats;
        public static string backgroundMode;
        public static string imgPath;
        public static string backColor;
        public static string[] settingLine;

        // Применяет настройки из файла. Еще не готова
        public static void InitFileSettings()
        {
            string[] strArray = File.ReadAllLines(settingsPath);
            for (int i = 0; i < strArray.Length; i++)
            {
                char[] separator = new char[] { ':' };
                string[] strArray2 = strArray[i].Split(separator);
                if (strArray2.Length > 1)
                {
                    if (strArray2[0] == "minTimeForStats")
                    {
                        minTimeForStats = (int.Parse(strArray2[1]) < 120000) ? 120000 : int.Parse(strArray2[1]);
                    }
                    if (strArray2[0] == "backgroundMode")
                    {
                        backgroundMode = strArray2[1];
                    }
                    if (strArray2[0] == "imgPath")
                    {
                        imgPath = strArray2[1];
                    }
                    if (strArray2[0] == "backColor")
                    {
                        backColor = strArray2[1];
                    }
                }
            }
        }
    }
}

