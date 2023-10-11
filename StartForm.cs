using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FastTouch
{
    public partial class StartForm : Form
    {
        App app = new App();
        AppState appStates;

        double mistakesProcent = 0; // Процент ошибочно введенных символов
        double score = 0; // Количество введенных символов для текущего сеанса печати
        double mistakesCount = 0; // Количество ошибок для текущего сеанса печати
        double sessionTime = 0; // Время текущего сеанса печати в мс
        double inputSpeed = 0; // Значение скорости печати для текущего сеанса печати

        int startFilePoint = 0; // Хранит значение, определяющее с какого по счету символа будет браться текст для печати в файле
        int animCount = 0; // Счетчик для анимации появления текста при старте сеанса
        int noMistakesCount = 0; // Количество напечатанных без ошибок символов подряд
        string textData; // Хранит обработанный текст из файла с текстом для печати
        string inputSymbol; // Текущий символ, который нужно ввести
        char[] spaceArr; // В него помещается текст, который потом модифицируется для красивого отображения в лейблы

        bool isFirstInputedSymbol = true; // Является ли символ первым введенным символом
        bool timerStoped = false; // Показывает таймеру, нужно ли обновлять время в лейбле со временем сеанса
        bool isShouldStartStopwatch = false; // Указывает, следует ли запустить таймер
        bool isStartAnimation = true; // Определяет, нужно ли запускать анимацию появления текста  
        bool isStartMode = true; // Показывает, находимся ли мы в главном меню, или нет

        DateTime dateForTimer;
        Timer timerUI = new Timer(); // Таймер для лейбла продолжительности сеанса
        Timer timerForAnim = new Timer(); // Таймер для анимации появления текста
        Stopwatch stopwatch = new Stopwatch(); // Создаем секундомер для подсчета скорости печати

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
            appStates = new AppState(this);
            scoreForm = new ScoreForm(appStates);
            scoreFromChart = new ScoreFormChart(appStates);
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            LabelText.Parent = LabelSubText;
            LabelPastText.Parent = LabelSubPastText;

            startFilePoint = int.Parse(File.ReadAllText(app.startValuePath));

            TextBoxInput.Text = "";
            Results.InitFileSettings();
            appStates.SetMenuState();

            timerUI.Interval = 1000;
            timerUI.Tick += new EventHandler(TimerTick);
            timerForAnim.Interval = 25;
            timerForAnim.Tick += new EventHandler(StartAnimation);

            using (StreamReader reader = new StreamReader(app.textPath))
            {
                textData = reader.ReadToEnd();
            }

            textData = Regex.Replace(textData, "[^a-z A-Z а-я А-Я 0-9 , . ! % * ( ) ? : - + =]", "");
            textData = Regex.Replace(textData, @"\s+", " ");
            
            inputSymbol = textData.Substring(startFilePoint, 1);
        }

        // Изменить строку невведенного текста
        public void ChangeTextLabel()
        {
            spaceArr = textData.Substring(startFilePoint, 28).ToCharArray();

            if (isStartAnimation)
            {
                timerForAnim.Start();
                isStartAnimation = false;
            }
            else
            {
                for (int i = 0; i < spaceArr.Length; i++)
                {
                    LabelText.Text += spaceArr[i].ToString();
                    if (spaceArr[i].ToString() == " ") LabelText.Text += " ";
                }
            }
        }

        // Анимация появления текста при старте сеанса
        public void StartAnimation(object sender, EventArgs e)
        {
            if (appStates.state != AppState.States.session) return;
            
            LabelText.Text += spaceArr[animCount].ToString();
            if (spaceArr[animCount].ToString() == " ")
            {
                LabelText.Text += " ";
            }

            animCount++;

            if (animCount == spaceArr.Length)
            {
                timerForAnim.Stop();
                animCount = 0;
            }
        }

        // Обработка горячих клавиш
        private void StartForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Если нажали Enter в главном меню, начинаем сеанс печати
            if ((e.KeyCode == Keys.Enter) && isStartMode)
            {
                TextBoxInput.Focus();
                isStartMode = false;
                appStates.SetSessionState();
                LabelText.Text = "";
                LabelPastText.Text = "";
                ChangeTextLabel();
                dateForTimer = new DateTime(0, DateTimeKind.Unspecified);
            }

            if ((e.KeyCode == Keys.F1) && isStartMode)
            {
                Results.warmingUp = !Results.warmingUp;
            }

            if ((e.KeyCode == Keys.F2) && isStartMode)
            {
                Results.nowSymbols = startFilePoint;
                Results.allSymbols = textData.Length;
                progressForm.ShowDialog();
            }

            if ((e.KeyCode == Keys.F3) && isStartMode)
            {
                settingsForm.ShowDialog();
            }
            
            if (e.KeyCode == Keys.Escape)
            {   
                // Если нажали Escape в главном меню, закрываем приложение
                if (isStartMode)
                {
                    Application.Exit();
                }

                // Если нажали Escape во время сеанса печати
                else
                {
                    timerStoped = true;
                    stopwatch.Stop();
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
                    if (sessionTime == 0 && stopwatch.ElapsedMilliseconds == 0)
                    {
                        Results.speed = "Скорость: 0 зн/мин";
                    }
                    else
                    {
                        sessionTime += stopwatch.ElapsedMilliseconds;
                        stopwatch.Reset();

                        inputSpeed = (score * 60000) / sessionTime;
                        Results.speed = $"Скорость: {Math.Round(inputSpeed)} зн/мин";
                    }

                    if (sessionTime >= 5000)
                    {
                        scoreFromChart.ShowDialog();
                    }
                    else
                    {
                        scoreForm.ShowDialog();
                    }

                    // Далее логика действий после выхода из окна результатов
                    SetTextlabelsColor("active");
                    isShouldStartStopwatch = true;

                    if (appStates.state == AppState.States.menu)
                    {
                        if (sessionTime >= Results.minTimeForStats && inputSpeed > inputSpeedRecord)
                        {
                            inputSpeedRecord = (int)Math.Round(inputSpeed);
                        }

                        appStates.SetMenuState();
                        isStartMode = true;
                        isStartAnimation = true;
                        isFirstInputedSymbol = true;

                        if ((sessionTime >= Results.minTimeForStats) && !Results.warmingUp)
                        {
                            WriteStats();
                        }

                        Results.warmingUp = false;
                        File.WriteAllText(app.startValuePath, startFilePoint.ToString());
                        mistakesCount = 0;
                        score = 0;
                        sessionTime = 0;
                        timerUI.Stop();
                        TimerLabel.Text = "0:00";
                        scoreFromChart.SpeedChart.Series[0].Points.Clear();
                    }
                }
            }
        }

        private void MainTextboxChanged(object sender, EventArgs e)
        {
            if (appStates.state != AppState.States.session) return;

            HandleEnteredLetter();
        }

        private void HandleEnteredLetter()
        {
            // Запускает таймеры после первого введенного символа
            if (isFirstInputedSymbol)
            {
                timerStoped = false;
                isFirstInputedSymbol = false;
                dateForTimer = new DateTime();
                stopwatch.Start();
                timerUI.Start();
            }

            if (isShouldStartStopwatch)
            {
                timerStoped = false;
                stopwatch.Start();
                isShouldStartStopwatch = false;
            }

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

                    if (inputSymbol == " ")
                    {
                        // Вместо одного пробела в видимый лейбл добавляется два, для лучшего визуала
                        LabelPastText.Text += "  ";
                    }
                    else LabelPastText.Text += inputSymbol;

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

                    ChangeTextLabel();
                }
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (timerStoped) return;

            dateForTimer = dateForTimer.AddSeconds(1);
            TimerLabel.Text = dateForTimer.ToString("m:ss");
            stopwatch.Stop();
            sessionTime += stopwatch.ElapsedMilliseconds;
            stopwatch.Restart();
            inputSpeed = (score * 60000) / sessionTime;
            AddSpeedChartData();
        }

        public void AddSpeedChartData()
        {
            scoreFromChart.SpeedChart.Series[0].Points.AddXY(sessionTime / 1000, inputSpeed);
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
            HandleSessionLostFocus();
        }

        private void HandleSessionLostFocus()
        {
            if (appStates.state == AppState.States.session)
            {

            }
        }
    }
}
