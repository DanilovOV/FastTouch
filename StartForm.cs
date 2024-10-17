using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FastTouch
{
    public partial class StartForm : Form
    {
        App app = new App();
        AppState appState;

        double score = 0; // Количество введенных символов для текущего сеанса печати
        double inputSpeed = 0; // Значение скорости печати для текущего сеанса печати
        int noMistakesCount = 0; // Количество напечатанных без ошибок символов подряд
        double mistakesCount = 0; // Количество ошибок для текущего сеанса печати
        double mistakesProcent = 0; // Процент ошибочно введенных символов

        int startFilePoint = 0; // Хранит значение, определяющее с какого по счету символа будет браться текст для печати в файле
        int animCount = 0; // Счетчик для анимации появления текста при старте сеанса
        string textData; // Хранит обработанный текст из файла с текстом для печати
        string inputSymbol; // Текущий символ, который нужно ввести
        char[] spaceArr; // В него помещается текст, который потом модифицируется для красивого отображения в лейблы

        bool isStartAnimation = true; // Определяет, нужно ли запускать анимацию появления текста  

        DateTime dateForTimer;
        public Timer appTickTimer = new Timer();
        public Stopwatch stopwatch = new Stopwatch(); // Секундомер для подсчета скорости печати
        Timer startSessionAnimTimer = new Timer(); // Таймер для анимации появления текста

        ScoreForm scoreForm;
        ScoreFormChart scoreFromChart;
        SettingsForm settingsForm = new SettingsForm();
        ProgressForm progressForm = new ProgressForm();

        public int inputSpeedRecord
        {
            get
            {
                string recordValue = File.ReadAllText(app.recordPath);
                return recordValue == "" 
                    ? 0 
                    : int.Parse(recordValue);
            }

            set
            {
                File.WriteAllText(app.recordPath, value.ToString());
            }
        }

        public StartForm()
        {
            InitializeComponent();
            appState = new AppState(this);
            scoreForm = new ScoreForm(appState);
            scoreFromChart = new ScoreFormChart(appState);
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            LabelText.Parent = LabelSubText;
            LabelPastText.Parent = LabelSubPastText;

            TextBoxInput.Text = "";
            Results.InitFileSettings();
            appState.SetMenuState();

            appTickTimer.Interval = 10;
            appTickTimer.Tick += new EventHandler(AppTick);
            startSessionAnimTimer.Interval = 25;
            startSessionAnimTimer.Tick += new EventHandler(StartAnimation);

            using (StreamReader reader = new StreamReader(app.textPath))
            {
                textData = FormatRawTextFromFile(reader.ReadToEnd());
            }

            startFilePoint = int.Parse(File.ReadAllText(app.startValuePath));
        }

        public string FormatRawTextFromFile(string text)
        {
            text = Regex.Replace(text, "[^a-zA-Zа-яА-Я0-9,!.%*()?\\-+:=\\s]", "");
            text = Regex.Replace(text, @"[\r\n]+", " ");
            text = Regex.Replace(text, @"\s+", " ");

            return text;
        }

        // Обработка горячих клавиш
        private void StartForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (appState.state == AppState.States.menu)
            {
                // Инициализация сеанса печати
                if (e.KeyCode == Keys.Enter)
                {
                    if (startFilePoint >= textData.Length - 1)
                    {
                        startFilePoint = 0;
                    }

                    inputSymbol = textData.Substring(startFilePoint, 1);

                    TextBoxInput.Focus();
                    appState.SetWaitInputState();
                    LabelText.Text = "";
                    LabelPastText.Text = "";

                    if (isStartAnimation)
                    {
                        spaceArr = GetRawUntypedSubstring().ToCharArray();
                        startSessionAnimTimer.Start();
                        isStartAnimation = false;
                    }
                    else
                    {
                        ShiftUntypedText();
                    }
                    
                    dateForTimer = new DateTime(0, DateTimeKind.Unspecified);
                }

                else if (e.KeyCode == Keys.F1)
                {
                    Results.warmingUp = !Results.warmingUp;
                }

                else if (e.KeyCode == Keys.F2)
                {
                    Results.nowSymbols = startFilePoint;
                    Results.allSymbols = textData.Length;
                    progressForm.ShowDialog();
                }

                else if (e.KeyCode == Keys.F3)
                {
                    settingsForm.ShowDialog();
                }

                else if (e.KeyCode == Keys.Escape)
                {
                    Application.Exit();
                }
            }

            else if (appState.state == AppState.States.session || appState.state == AppState.States.waitInput)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    appState.SetScoreState();
                    SetTextlabelsColor("inactive");
                    Results.time = $"Время: {dateForTimer:m:ss}";
                    Results.score = $"Напечатано: {score}";

                    // Логика определения и записи процента ошибок
                    if (mistakesCount == 0)
                    {
                        Results.mistakes = "Ошибок: 0%";
                    }
                    else
                    {
                        mistakesProcent = (mistakesCount / (score + mistakesCount)) * 100;
                        Results.mistakes = $"Ошибок: {Math.Round(mistakesProcent, 1)}% ({mistakesCount})";
                    }

                    // Логика определения и записи скорости печати
                    if (stopwatch.ElapsedMilliseconds == 0 && stopwatch.ElapsedMilliseconds == 0)
                    {
                        Results.speed = "Скорость: 0 зн/мин";
                    }
                    else
                    {
                        inputSpeed = (score * 60000) / stopwatch.ElapsedMilliseconds;
                        Results.speed = $"Скорость: {Math.Round(inputSpeed)} зн/мин";
                    }

                    if (stopwatch.ElapsedMilliseconds >= 5000)
                    {
                        scoreFromChart.ShowDialog();
                    }
                    else
                    {
                        scoreForm.ShowDialog();
                    }

                    // Действия после выхода из окна результатов
                    SetTextlabelsColor("active");

                    if (appState.state == AppState.States.menu)
                    {
                        if (stopwatch.ElapsedMilliseconds >= Results.minTimeForStats && inputSpeed > inputSpeedRecord)
                        {
                            inputSpeedRecord = (int)Math.Round(inputSpeed);
                        }

                        appState.SetMenuState();
                        isStartAnimation = true;

                        if ((stopwatch.ElapsedMilliseconds >= Results.minTimeForStats) && !Results.warmingUp)
                        {
                            WriteStats();
                        }

                        Results.warmingUp = false;
                        File.WriteAllText(app.startValuePath, startFilePoint.ToString());
                        mistakesCount = 0;
                        score = 0;
                        stopwatch.Reset();
                        TimerLabel.Text = "0:00";
                        scoreFromChart.SpeedChart.Series[0].Points.Clear();
                    }
                }
            }
        }

        private void SetTextlabelsColor(string colorMode)
        {
            if (colorMode == "active")
            {
                LabelText.BackColor = Color.GhostWhite;
                LabelPastText.BackColor = Color.Lavender;
            }

            if (colorMode == "inactive")
            {
                LabelText.BackColor = Color.LightGray;
                LabelPastText.BackColor = Color.LightGray;
            }
        }

        public void StartAnimation(object sender, EventArgs e)
        {
            if (appState.state != AppState.States.waitInput) return;

            LabelText.Text += spaceArr[animCount].ToString();
            if (spaceArr[animCount].ToString() == " ")
            {
                LabelText.Text += " ";
            }

            animCount++;

            if (animCount == spaceArr.Length)
            {
                startSessionAnimTimer.Stop();
                animCount = 0;
            }
        }

        public void ShiftUntypedText()
        {
            LabelText.Text = GetCustomizedText(GetRawUntypedSubstring());
        }

        public string GetRawUntypedSubstring()
        {
            int substringLength = 28;
            int restTextLength = textData.Length - startFilePoint;

            if (substringLength >= restTextLength)
            {
                substringLength = restTextLength - 1;
            }

            return textData.Substring(startFilePoint, substringLength);
        }

        public string GetCustomizedText(string text)
        {
            StringBuilder customizedText = new StringBuilder();

            foreach (char letter in text)
            {
                customizedText.Append(GetCustomizedLetter(letter));
            }

            return customizedText.ToString();
        }

        public string GetCustomizedLetter(char letter)
        {
            if (letter == ' ') return "  ";
            else return letter.ToString();
        }

        private void MainTextboxChanged(object sender, EventArgs e)
        {
            if (appState.state == AppState.States.waitInput)
            {
                appState.SetSessionState();
            }

            if (appState.state == AppState.States.session || appState.state == AppState.States.waitInput)
            {
                HandleEnteredLetter();
            }
        }

        private void HandleEnteredLetter()
        {
            // Убираем срабатывание функции на очистку текстбокса от введенного символа
            if (TextBoxInput.Text != "")
            {
                // Если ввели неправильный символ
                if (TextBoxInput.Text != inputSymbol)
                {
                    TextBoxInput.Text = "";
                    mistakesCount++;
                    noMistakesCount = 0;
                }
                // Если ввели правильный символ
                else
                {

                    TextBoxInput.Text = "";
                    LabelText.Text = "";
                    score++;
                    noMistakesCount++;

                    LabelPastText.Text += GetCustomizedLetter(char.Parse(inputSymbol));

                    // Ограничивает длину строки напечатанного текста
                    if (LabelPastText.Text.Length > 45)
                    {
                        LabelPastText.Text = LabelPastText.Text.Remove(0, 15);
                    }

                    if (Results.maxNoMistakesCount < noMistakesCount)
                    {
                        Results.maxNoMistakesCount = noMistakesCount;
                    }

                    if (startFilePoint < textData.Length)
                    {
                        startFilePoint++;
                    }
                    else
                    {
                        startFilePoint = 0;
                    }
                    inputSymbol = textData.Substring(startFilePoint, 1);

                    ShiftUntypedText();
                }
            }
        }

        string prevTimeString;
        private void AppTick(object sender, EventArgs e)
        {
            if (appState.state != AppState.States.session) return;

            dateForTimer = new DateTime(TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds).Ticks);
            string uiTimeString = dateForTimer.ToString("m:ss");
            TimerLabel.Text = uiTimeString;

            if (prevTimeString != uiTimeString && prevTimeString != null)
            {
                inputSpeed = (score * 60000) / stopwatch.ElapsedMilliseconds;
                scoreFromChart.SpeedChart.Series[0].Points.AddXY(stopwatch.ElapsedMilliseconds / 1000, inputSpeed);
            }

            prevTimeString = uiTimeString;
        }

        private void WriteStats()
        {
            CommonStatsWriter statsWriter = new CommonStatsWriter(Results.statsPath);

            long currentTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            string currentDate = DateTime.Now.ToString("dd:MM:yyyy");
            string currentTime = DateTime.Now.ToString("HH:mm");
            int roundedInputSpeed = (int)Math.Round(inputSpeed);
            double roundedMistakesProcent = Math.Round(mistakesProcent, 1);
            string sessionDuration = TimerLabel.Text;

            SessionData sessionData = new SessionData(currentTimestamp, currentDate, currentTime, roundedInputSpeed, roundedMistakesProcent, sessionDuration);
            SessionDataViews sessionDataViews = new SessionDataViews();
            string sessionDataString = sessionDataViews.GetFileViewString(sessionData);

            statsWriter.write(sessionDataString);
        }

        // Убирает звуковой сигнал текстбокса при нажатии Enter и Escape
        private void KeySoundBlock(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Enter) e.Handled = true;
        }

        private void StartForm_Deactivate(object sender, EventArgs e)
        {
            if (appState.state == AppState.States.session)
            {
                appState.SetWaitInputState();
            }
        }
    }
}
