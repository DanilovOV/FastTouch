using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FastTouch
{
    public partial class StartForm : Form
    {
        double mistakesProcent = 0; // Процент ошибочно введенных символов
        double record = 0; // Значение рекордной скорости печати
        double score = 0; // Количество введенных символов для текущего сеанса печати
        double mistakesCount = 0; // Количество ошибок для текущего сеанса печати
        double sessionTime = 0; // Время текущего сеанса печати в мс
        double inputSpeed = 0; // Значение скорости печати для текущего сеанса печати
        int startPoint = 0; //
        int startFilePoint = 0;
        int animCount = 0; // Счетчик для анимации появления текста при старте сеанса
        int noMistakesCount = 0; // Количество напечатанных без ошибок символов подряд
        string textPath = @"Text\Text.txt"; // Путь к файлу с текстом для печати
        string startValuePath = @"Text\StartPoint.txt"; // Путь к файлу со значением стартовой точки для печати
        string recordPath = @"Properties\Record.txt"; // Путь к файлу со значением рекорда скорости печати
        string speedDataForProgressForm = @"Properties\Speed.txt"; // Путь к файлу со значением скорости печати для каждого сеанса
        string textData;
        string[] resultsLine; // Массив строк с данными о сеансах печати
        string[] speedLine; // Массив строк с данными о скорости печати для сеансов
        string inputSymbol; // Текущий символ, который нужно ввести
        char[] spaceArr;
        bool startInput = true;
        bool timerStoped = false;
        bool restartStopwatch = false;
        bool startAnim = true; // Определяет, нужно ли запускать анимацию появления текста
        bool startMode = true; // Показывает, находимся ли мы в главном меню, или нет
        bool workMode = false; // Показывает, идет ли сейчас сеанс печати, или нет
        DateTime dateForTimer;
        Timer timerUI = new Timer(); // Создаем таймер, который будет управлять лейблом с текущим временем сеанса печати
        Timer timerForAnim = new Timer();
        Stopwatch stopwatch = new Stopwatch(); // Создаем секундомер для подсчета скорости печати

        // Создаем объекты других форм
        ScoreForm scoreForm = new ScoreForm();
        ScoreFormChart scoreFromChart = new ScoreFormChart();
        SettingsForm settingsForm = new SettingsForm();
        ProgressForm progressForm = new ProgressForm();


        public StartForm()
        {
            InitializeComponent();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            LabelText.Parent = LabelSubText;
            LabelPastText.Parent = LabelSubPastText;
            startFilePoint = int.Parse(File.ReadAllText(startValuePath));
            startPoint = startFilePoint;
            TextBoxInput.Text = "";
            Results.InitFileSettings();
            Record();
            timerUI.Interval = 1000;
            timerUI.Tick += new EventHandler(Timer_Tick);
            timerForAnim.Interval = 25;
            timerForAnim.Tick += new EventHandler(SpawnTextAnim);
            using (StreamReader reader = new StreamReader(textPath))
            {
                textData = reader.ReadToEnd();
            }
            textData = Regex.Replace(textData, "[^a-z A-Z а-я А-Я 0-9 , . ! % * ( ) ? : - + =]", " ");
            textData = Regex.Replace(textData, @"\s+", " ");
            textData.Trim();
            inputSymbol = textData.Substring(startFilePoint, 1);
        }

        // Меняет символ, который нужно напечатать
        public void ChangeSymbol()
        {
            startPoint++;

            // Если не достигли конца файла с текстом
            if (startPoint < textData.Length)
            {
                inputSymbol = textData.Substring(startPoint, 1);
            }
            // Если достигли конца файла с текстом
            else
            {
                startPoint = 0;
                startFilePoint = 0;
            }
        }

        // Изменить строку невведенного текста
        public void changeTextLabel()
        {
            spaceArr = textData.Substring(startFilePoint + (int)(score), 28).ToCharArray();
            if (startAnim)
            {
                timerForAnim.Start();
                startAnim = false;
            }
            else
            {
                int index = 0;
                while (true)
                {
                    if (index >= spaceArr.Length)
                    {
                        break;
                    }
                    LabelText.Text = LabelText.Text + spaceArr[index].ToString();
                    if (spaceArr[index].ToString() == " ")
                    {
                        LabelText.Text = LabelText.Text + " ";
                    }
                    index++;
                }
            }
        }

        // Вычисляет и записывает данные о скорости и времени печати на диаграмму
        public void DataForSpeedScart()
        {
            sessionTime += stopwatch.ElapsedMilliseconds;
            inputSpeed = (score * 60000) / sessionTime;
            scoreFromChart.SpeedChart.Series[0].Points.AddXY(sessionTime / 1000, inputSpeed);
        }

        // Записывает данные о новом рекорде при выполнении определенных условий и выводит их в главное меню
        public void Record()
        {
            record = int.Parse(File.ReadAllText(recordPath));
            if (sessionTime >= Results.minTimeForStats && !Results.warmingUp && inputSpeed > record)
            {
                record = Math.Round(inputSpeed);
                File.WriteAllText(recordPath, record.ToString());
            }
            LabelPastText.Text = "Рекорд: ";
            LabelText.Text = " " + record.ToString() + " зн/мин";
        }

        // Заполняем диаграмму скорости 
        public void SetProgressChartData()
        {
            resultsLine = File.ReadAllLines(Results.statsPath);
            speedLine = File.ReadAllLines(speedDataForProgressForm);
            int index = resultsLine.Length - 1;
            while (true)
            {
                if (index < 0)
                {
                    Results.x = 1;
                    return;
                }
                progressForm.ProgressData.Text = progressForm.ProgressData.Text + resultsLine[index] + Environment.NewLine;
                progressForm.ProgressChart.Series[0].Points.AddXY(Results.x, int.Parse(speedLine[Results.x - 1]));
                Results.x++;
                index--;
            }
        }

        // Анимация появления текста при старте сеанса
        public void SpawnTextAnim(object sender, EventArgs e)
        {
            LabelText.Text = LabelText.Text + spaceArr[animCount].ToString();
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
            if ((e.KeyCode == Keys.Enter) && startMode)
            {
                TextBoxInput.Focus();
                startMode = false;
                workMode = true;
                LabelText.Text = "";
                LabelPastText.Text = "";
                changeTextLabel();
                dateForTimer = new DateTime(0, DateTimeKind.Unspecified);
            }
            // Если нажали F1 в главном меню, включаем режим разминки (статистика сеанса не записывается)
            if ((e.KeyCode == Keys.F1) && startMode)
            {
                Results.warmingUp = !Results.warmingUp;
            }
            // Если нажали F2 в главном меню, открываем форму со статистикой по всем сеансам печати
            if ((e.KeyCode == Keys.F2) && startMode)
            {
                Results.nowSymbols = startFilePoint + 1;
                Results.allSymbols = textData.Length;
                SetProgressChartData();
                progressForm.ShowDialog();
            }
            // Если нажали F2 в главном меню, открываем форму настроек
            if ((e.KeyCode == Keys.F3) && startMode)
            {
                settingsForm.ShowDialog();
            }
            
            if (e.KeyCode == Keys.Escape)
            {   
                // Если нажали Escape в главном меню, закрываем приложение
                if (startMode)
                {
                    Application.Exit();
                }
                // Если нажали Escape во время сеанса печати
                else
                {
                    workMode = false;
                    timerStoped = true;
                    stopwatch.Stop();
                    LabelText.BackColor = Color.LightGray;
                    LabelPastText.BackColor = Color.LightGray;
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
                        restartStopwatch = true;

                        inputSpeed = (score * 60000) / sessionTime;
                        Results.speed = $"Скорость: {Math.Round(inputSpeed)} зн/мин";
                    }

                    // Если сеанс длится от 5 секунд, при паузе выводим форму с графиком скорости печати
                    if (sessionTime >= 5000)
                    {
                        scoreFromChart.ShowDialog();
                    }
                    // Если нет, выводим форму без графика
                    else
                    {
                        scoreForm.ShowDialog();
                    }

                    // Если нажимаем Escape во время сеанса печати
                    if (!Results.startOrWork)
                    {
                        workMode = true;
                        restartStopwatch = true;
                        LabelText.BackColor = Color.GhostWhite;
                        LabelPastText.BackColor = Color.Lavender;
                    }
                    // Если нажимаем Escape во время паузы
                    else
                    {
                        startMode = true;
                        startAnim = true;
                        startInput = true;
                        restartStopwatch = true;
                        Record();
                        WriteStats();
                        Results.warmingUp = false;
                        LabelText.BackColor = Color.GhostWhite;
                        LabelPastText.BackColor = Color.Lavender;
                        startFilePoint += (int)(score);
                        File.WriteAllText(startValuePath, startFilePoint.ToString());
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

        // Событие ввода символа в текстбокс
        private void TextIsChanged(object sender, EventArgs e)
        {   
            // Если вводим символ во время сеанса печати
            if (workMode)
            {
                timerStoped = false;

                if (restartStopwatch)
                {
                    stopwatch.Start();
                    restartStopwatch = false;
                }

                // Запускает таймеры после первого введенного символа
                if (startInput)
                {
                    startInput = false;
                    dateForTimer = new DateTime();
                    stopwatch.Start();
                    timerUI.Start();
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
                        // Логика добавления символа в лейбл с напечатанным текстом
                        // Если нужно добавить пробел, добавляем два, т.к. с одним слишком маленькое расстояние между словами
                        if (inputSymbol == " ")
                        {
                            LabelPastText.Text += "  ";
                        }
                        else LabelPastText.Text += inputSymbol;

                        // Если строка с напечатанным текстом слишком длинная, обрезаем ее
                        if (LabelPastText.Text.Length > 45)
                        {
                            LabelPastText.Text = LabelPastText.Text.Remove(0, 15);
                        }

                        TextBoxInput.Text = "";
                        LabelText.Text = "";
                        score++;
                        noMistakesCount++;

                        // Если побили рекорд по количеству напечатанных без ошибок символов, перезаписываем его
                        if (Results.maxNoMistakesCount < noMistakesCount)
                        {
                            Results.maxNoMistakesCount = noMistakesCount;
                        }
                        changeTextLabel();
                        ChangeSymbol();
                    }
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!timerStoped)
            {
                dateForTimer = dateForTimer.AddSeconds(1);
                TimerLabel.Text = dateForTimer.ToString("m:ss");
                stopwatch.Stop();
                DataForSpeedScart();
                stopwatch.Restart();
            }
        }

        // Записывает статистику сеансов в файлы
        public void WriteStats()
        {
            if ((sessionTime >= Results.minTimeForStats) && !Results.warmingUp)
            {
                string str = DateTime.Now.ToString("dd:MM:yyyy HH:mm");
                using (StreamWriter writer = File.AppendText(Results.statsPath))
                {
                    string[] textArray1 = new string[] { str, "   ", Math.Round(inputSpeed).ToString(), "   ", Math.Round(mistakesProcent, 1).ToString(), "   ", TimerLabel.Text };
                    writer.WriteLine(string.Concat(textArray1));
                }
                using (StreamWriter writer2 = File.AppendText(speedDataForProgressForm))
                {
                    writer2.WriteLine(Math.Round(inputSpeed));
                }
            }
        }

        // Убирает звуковой сигнал текстбокса при нажатии Enter и Escape
        private void KeyCommandHandler(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape) e.Handled = true;
            if (e.KeyChar == (char)Keys.Enter) e.Handled = true;
        }
    }
}

