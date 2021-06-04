using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Diagnostics;
using System.Windows.Threading;
using System.IO;
using System.Windows.Documents;

namespace Timer2
{
    public class ViewModel : INotifyPropertyChanged
    {
        #region Objects
        public event PropertyChangedEventHandler PropertyChanged;
        public MainWindow MainWindow { get; set; }
        public Write write = new Write();
        public Init init = new Init();
        public MyTimer myTimer = new MyTimer();
        public DayTimer dayTimer = new DayTimer();
        public static DispatcherTimer clock = new DispatcherTimer();
        #endregion

        #region Properties
        #region Window start location
        public double TopValue
        {
            get
            {
                return Double.Parse(SettingsList[7]);
            }
            set
            {
                var list = new List<string>(File.ReadAllLines(write.dir + @"Settings\" + init.ListName));
                if (Double.Parse(SettingsList[7]) != value)
                {
                    list[7] = value.ToString();
                }
                File.WriteAllLines(write.dir + @"Settings\" + init.ListName, list);
                MainWindow.WindowLocationStart();
                OnPropertyChange(nameof(TopValue));
            }
        }
        public double LeftValue
        {
            get
            {
                return Double.Parse(SettingsList[8]);
            }
            set
            {
                var list = new List<string>(File.ReadAllLines(write.dir + @"Settings\" + init.ListName));
                if (Double.Parse(SettingsList[8]) != value)
                {
                    list[8] = value.ToString();
                }
                File.WriteAllLines(write.dir + @"Settings\" + init.ListName, list);
                MainWindow.WindowLocationStart();
                OnPropertyChange(nameof(LeftValue));
            }
        }
        #endregion
        #region Display
        public string HoursClock { get; set; } = "00";
        public string MinutesClock { get; set; } = "00";
        public string SecondsClock { get; set; } = "00";
        public string HoursTimer
        {
            get
            {
                return myTimer.HoursTimer;
            }
            set
            {
                if (myTimer.HoursTimer != value)
                {
                    myTimer.HoursTimer = value;
                }
                OnPropertyChange(nameof(HoursTimer));
            }
        }
        public string MinutesTimer
        {
            get
            {
                return myTimer.MinutesTimer;
            }
            set
            {
                if (myTimer.MinutesTimer != value)
                {
                    myTimer.MinutesTimer = value;
                }
                OnPropertyChange(nameof(MinutesTimer));
            }
        }
        public string SecondsTimer
        {
            get
            {
                return myTimer.SecondsTimer;
            }
            set
            {
                if (myTimer.SecondsTimer != value)
                {
                    myTimer.SecondsTimer = value;
                }
                OnPropertyChange(nameof(SecondsTimer));
            }
        }
        #endregion
        #region Clock
        public bool clock1 { get; set; } = true;
        public bool Clock
        {
            get
            {
                return clock1;
            }
            set
            {
                if (clock1 != value)
                {
                    clock1 = value;
                }
                myTimer.Clock = Clock;
                if (clock1 == false)
                {
                    Display(HoursTimer, MinutesTimer, SecondsTimer);
                }
                else if (clock1 == true)
                {
                    Display(HoursClock, MinutesClock, SecondsClock);
                }
                OnPropertyChange(nameof(Clock));
            }
        }
        public string date
        {
            get
            {
                return myTimer.date;
            }
            set
            {
                OnPropertyChange(nameof(date));
            }
        }
        #endregion
        #region Timer
        public string timerName { get; set; }
        public string TimerName
        {
            get
            {
                return timerName;
            }
            set
            {
                if (timerName != value)
                {
                    timerName = value;
                    myTimer.TimerName = timerName.ToLower();
                }
                OnPropertyChange(nameof(TimerName));
            }
        }
        public bool timer1 { get; set; }
        public bool Timer
        {
            get
            {
                return timer1;
            }
            set
            {
                if (timer1 != value)
                {
                    timer1 = value;
                }
                myTimer.Timer = Timer;

                if (timer1 == true)
                {
                    Clock = false;
                    Display(HoursTimer, MinutesTimer, SecondsTimer);
                }
                else if (timer1 == false)
                {
                    Clock = true;
                    Display(HoursClock, MinutesClock, SecondsClock);
                }
                OnPropertyChange(nameof(Timer));
            }
        }
        public double SetTime
        {
            get
            {
                return myTimer.SetTime;
            }
            set
            {
                if (myTimer.SetTime != value)
                {
                    myTimer.SetTime = value;
                }
                OnPropertyChange(nameof(SetTime));
            }
        }
        public double TotalSetTime
        {
            get
            {
                return myTimer.TotalSetTime;
            }
            set
            {
                if (myTimer.TotalSetTime != value)
                {
                    myTimer.TotalSetTime = value;
                }
                OnPropertyChange(nameof(TotalSetTime));
            }
        }
        public bool TimerIsRunning
        {
            get
            {
                return myTimer.TimerIsRunning;
            }
            set
            {
                if (myTimer.TimerIsRunning != value)
                {
                    myTimer.TimerIsRunning = value;
                }
                OnPropertyChange(nameof(TimerIsRunning));
            }
        }
        public bool StopWatchIsRunning
        {
            get
            {
                return myTimer.StopWatchIsRunning;
            }
            set
            {
                if (myTimer.StopWatchIsRunning != value)
                {
                    myTimer.StopWatchIsRunning = value;
                }
                OnPropertyChange(nameof(StopWatchIsRunning));
            }
        }
        public string TimeValues1
        {
            get
            {
                return myTimer.TimeValues1;
            }
            set
            {
                if (myTimer.TimeValues1 != value)
                {
                    myTimer.TimeValues1 = value;
                }
                OnPropertyChange(nameof(TimeValues1));
            }
        }
        public string TimeValues2
        {
            get
            {
                return myTimer.TimeValues2;
            }
            set
            {
                if (myTimer.TimeValues2 != value)
                {
                    myTimer.TimeValues2 = value;
                }
                OnPropertyChange(nameof(TimeValues2));
            }
        }
        public string TimeValues3
        {
            get
            {
                return myTimer.TimeValues3;
            }
            set
            {
                if (myTimer.TimeValues3 != value)
                {
                    myTimer.TimeValues3 = value;
                }
                OnPropertyChange(nameof(TimeValues3));
            }
        }
        public string TimerIndicator1
        {
            get
            {
                return myTimer.TimerIndicator1;
            }
            set
            {
                if (myTimer.TimerIndicator1 != value)
                {
                    myTimer.TimerIndicator1 = value;
                }
                OnPropertyChange(nameof(TimerIndicator1));
                //OnPropertyChange(nameof(TimerIsRunning));
                //OnPropertyChange(nameof(StopWatchIsRunning));
            }
        }
        public DateTime EndDateTime
        {
            get
            {
                return myTimer.EndDateTime;
            }

            set
            {
                if (myTimer.EndDateTime != value)
                {

                    myTimer.EndDateTime = value;
                }
            }
        }
        public int StartTimeCount { get; set; } = 0;
        public DateTime StopWatchStartDateTime
        {
            get
            {
                return myTimer.StopWatchStartDateTime;
            }

            set
            {
                if (myTimer.StopWatchStartDateTime != value)
                {

                    myTimer.StopWatchStartDateTime = value;
                }
            }
        }
        #endregion
        #region Day timer
        public string timerIndicator2 { get; set; }
        public string TimerIndicator2
        {
            get
            {
                return timerIndicator2;
            }
            set
            {
                if (timerIndicator2 != value)
                {
                    timerIndicator2 = value;
                }
                OnPropertyChange(nameof(TimerIndicator2));
            }
        }
        public string timerIndicator3 { get; set; }
        public string TimerIndicator3
        {
            get
            {
                return timerIndicator3;
            }
            set
            {
                if (timerIndicator3 != value)
                {
                    timerIndicator3 = value;
                }
                OnPropertyChange(nameof(TimerIndicator3));
            }
        }
        public string daysValues1 { get; set; } = "--";
        public string DaysValues1
        {
            get
            {
                return daysValues1;
            }
            set
            {
                var list = new List<string>(File.ReadAllLines(write.dir + @"Settings\" + init.ListName));
                if (daysValues1 != value)
                {
                    daysValues1 = value;
                    dayTimer.DaysValues1 = DaysValues1;
                    list[5] = dayTimer.ConvertValueToDate(value);
                    File.WriteAllLines(write.dir + @"Settings\" + init.ListName, list);
                }
                else if (DaysValues1 != dayTimer.DaysValues1)
                {
                    DaysValues1 = dayTimer.DaysValues1;
                }
                OnPropertyChange(nameof(DaysValues1));
                OnPropertyChange(nameof(dayTimer.DaysValues1));
            }
        }
        public string daysValues2 { get; set; } = "--";
        public string DaysValues2
        {
            get
            {
                return daysValues2;
            }
            set
            {
                var list = new List<string>(File.ReadAllLines(write.dir + @"Settings\" + init.ListName));
                if (daysValues2 != value)
                {
                    daysValues2 = value;
                    dayTimer.DaysValues2 = DaysValues2;
                    list[6] = dayTimer.ConvertValueToDate(value);
                    File.WriteAllLines(write.dir + @"Settings\" + init.ListName, list);
                }
                else if (DaysValues2 != dayTimer.DaysValues2)
                {
                    DaysValues2 = dayTimer.DaysValues2;
                }
                OnPropertyChange(nameof(DaysValues2));
                OnPropertyChange(nameof(dayTimer.DaysValues2));
            }
        }
        public bool DaysTimerIsRunning1
        {
            get
            {
                return dayTimer.DaysTimerIsRunning1;
            }
            set
            {
                if (dayTimer.DaysTimerIsRunning1 != value)
                {
                    dayTimer.DaysTimerIsRunning1 = value;
                }
                OnPropertyChange(nameof(DaysTimerIsRunning1));
            }
        }
        public bool DaysTimerIsRunning2
        {
            get
            {
                return dayTimer.DaysTimerIsRunning2;
            }
            set
            {
                if (dayTimer.DaysTimerIsRunning2 != value)
                {
                    dayTimer.DaysTimerIsRunning2 = value;
                }
                OnPropertyChange(nameof(DaysTimerIsRunning2));
            }
        }
        public bool DaysStopWatchIsRunning1
        {
            get
            {
                return dayTimer.DaysStopWatchIsRunning1;
            }
            set
            {
                if (dayTimer.DaysStopWatchIsRunning1 != value)
                {
                    dayTimer.DaysStopWatchIsRunning1 = value;
                }
                OnPropertyChange(nameof(DaysStopWatchIsRunning1));
            }
        }
        public bool DaysStopWatchIsRunning2
        {
            get
            {
                return dayTimer.DaysStopWatchIsRunning2;
            }
            set
            {
                if (dayTimer.DaysStopWatchIsRunning2 != value)
                {
                    dayTimer.DaysStopWatchIsRunning2 = value;
                }
                OnPropertyChange(nameof(DaysStopWatchIsRunning2));
            }
        }
        public string StartDateTime { get; set; } = DateTime.Now.ToString().Split(' ')[0];
        public int StartDateCount { get; set; } = 0;
        #endregion
        #region Alarm
        public string Alarm
        {
            get
            {
                return myTimer.Alarm;
            }
            set
            {
                if (myTimer.Alarm != value)
                {
                    myTimer.Alarm = value;
                }
                OnPropertyChange(nameof(Alarm));
            }
        }
        public string Item
        {
            get
            {
                return myTimer.Item;
            }
            set
            {
                if (myTimer.Item != value)
                {
                    myTimer.Item = value;
                }
                OnPropertyChange(nameof(Item));
            }
        }
        #endregion
        #region Background indicator
        public Brush BackgroundTimerIndicator1
        {
            get
            {
                return myTimer.BackgroundTimerIndicator1;
            }
            set
            {
                if (myTimer.BackgroundTimerIndicator1 != value)
                {
                    myTimer.BackgroundTimerIndicator1 = value;
                }
                OnPropertyChange(nameof(BackgroundTimerIndicator1));
            }
        }
        public Brush BackgroundTimerIndicator2
        {
            get
            {
                return myTimer.BackgroundTimerIndicator2;
            }
            set
            {
                if (myTimer.BackgroundTimerIndicator2 != value)
                {
                    myTimer.BackgroundTimerIndicator2 = value;
                }
                OnPropertyChange(nameof(BackgroundTimerIndicator2));
            }
        }
        public Brush BackgroundTimerIndicator3
        {
            get
            {
                return myTimer.BackgroundTimerIndicator3;
            }
            set
            {
                if (myTimer.BackgroundTimerIndicator3 != value)
                {
                    myTimer.BackgroundTimerIndicator3 = value;
                }
                OnPropertyChange(nameof(BackgroundTimerIndicator3));
            }
        }
        #endregion
        #region Lists
        public List<string> RingTones
        {
            get
            {
                return myTimer.RingTones;
            }
            set
            {
                OnPropertyChange(nameof(RingTones));
            }
        }
        public List<string> SettingsList
        {
            get
            {
                return myTimer.SettingsList;
            }
            set
            {
                if (myTimer.SettingsList != value)
                {
                    myTimer.SettingsList = value;
                }
                OnPropertyChange(nameof(SettingsList));
            }
        }
        #endregion
        #region TextRange
        public TextRange textrange { get; set; }
        public TextRange textRange
        {
            get
            {
                return textrange;
            }
            set
            {
                if (textrange != value)
                {
                    textrange = value;
                    OnPropertyChange(nameof(textRange));
                }
            }
        }
        #endregion
        #endregion

        #region Visibilities
        public Visibility settingsVis { get; set; } = Visibility.Hidden;
        public Visibility SettingsVis
        {
            get
            {
                return settingsVis;
            }
            set
            {
                if (settingsVis != value)
                {
                    settingsVis = value;
                    OnPropertyChange(nameof(SettingsVis));
                }
            }
        }
        public Visibility settingsListVis { get; set; } = Visibility.Hidden;
        public Visibility SettingsListVis
        {
            get
            {
                return settingsListVis;
            }
            set
            {
                if (settingsListVis != value)
                {
                    settingsListVis = value;
                    OnPropertyChange(nameof(SettingsListVis));
                }
            }
        }
        public Visibility MaximizeButton => Visible == MainWindowFunctions.Normalize ? Visibility.Visible : Visibility.Collapsed;
        public Visibility NormalizeButton => Visible == MainWindowFunctions.Maximize ? Visibility.Visible : Visibility.Collapsed;
        private MainWindowFunctions visible = MainWindowFunctions.Normalize;
        public MainWindowFunctions Visible
        {
            get { return this.visible; }
            set
            {
                this.visible = value;

                OnPropertyChange(nameof(Visible));
                OnPropertyChange(nameof(MaximizeButton));
                OnPropertyChange(nameof(NormalizeButton));
            }
        }
        #endregion

        #region Commands
        public ICommand ListOfSettings { get; set; }
        public ICommand StartTimer { get; set; }
        public ICommand SetTimeValue { get; set; }
        public ICommand ClearTimer { get; set; }
        public ICommand SetDays { get; set; }
        public ICommand StartStop { get; set; }
        public ICommand Delete { get; set; }
        public ICommand OpenSet { get; set; }
        public ICommand Exit { get; set; }
        public ICommand MaximizeIt { get; set; }
        public ICommand NormalizeIt { get; set; }
        public ICommand MinimizeIt { get; set; }
        public ICommand CloseIt { get; set; }
        #endregion

        public ViewModel(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
            SetTimeValue = new Command((param) => TimerControl(param), () => CanComm());
            StartTimer = new Command((param) => TimerControl(param), () => CanComm());
            SetDays = new Command((param) => DayTimerControl(param), () => CanComm());
            StartStop = new Command((param) => DayTimerControl(param), () => CanComm());
            Delete = new Command((param) => DayTimerControl(param), () => CanComm());
            OpenSet = new Command((param) => OpenSettings(), () => CanComm());
            ListOfSettings = new Command((param) => ShowListOfSettings(), () => CanComm());
            ClearTimer = new Command((param) => TimerControl(param), () => CanComm());
            Exit = new Command((param) => ExitApp(), () => CanComm());
        }
        public void DayTimerControl(object param)
        {
            string parameter1 = param.ToString().Substring(0, 1);
            string parameter2 = param.ToString().Substring(1);
            switch (parameter1)
            {
                case "m":
                    dayTimer.CheckDaysTimerRunning();
                    break;
                case "s":
                    dayTimer.Set_Days(parameter2);
                    break;
                case "b":
                    dayTimer.StartStopDaysTimer(parameter2);
                    break;
                case "d":
                    dayTimer.DeleteDaysTimer(parameter2);
                    break;
            }
            this.DaysValues1 = DaysValues1;
            this.DaysValues2 = DaysValues2;
        }
        public void TimerControl(object param)
        {
            string parameter = param.ToString().Split('_')[0];
            string parameter1 = param.ToString().Split('_')[1];
            if (Timer == true)
            {
                switch (parameter)
                {
                    case "H":
                        myTimer.SetTimer(parameter);
                        break;
                    case "M":
                        myTimer.SetTimer(parameter);
                        break;
                    case "S":
                        myTimer.SetTimer(parameter);
                        break;
                    case "St":
                        myTimer.StartTimerRun();
                        break;
                    case "C":
                        myTimer.Clear_Timer();
                        break;
                    case "Sb":
                        myTimer.SetTimerFromStandardBox(parameter1);
                        break;
                }
                Display(HoursTimer, MinutesTimer, SecondsTimer);
            }
        }
        public void Display(string Hours, string Minutes, string Seconds)
        {
            textRange.Text = Hours + ":" + Minutes + Seconds;
            textRange.ApplyPropertyValue(TextElement.FontSizeProperty, "76");
            textRange.ApplyPropertyValue(TextElement.FontFamilyProperty, "Arial");
            TextPointer startH = textRange.Start.GetPositionAtOffset(0, LogicalDirection.Forward);
            TextPointer endH = textRange.Start.GetPositionAtOffset(Hours.Length, LogicalDirection.Backward);
            var textRangeH = new TextRange(startH, endH);
            textRangeH.ApplyPropertyValue(TextElement.FontSizeProperty, "76");

            TextPointer startC = textRange.Start.GetPositionAtOffset(Hours.Length, LogicalDirection.Forward);
            TextPointer endC = textRange.Start.GetPositionAtOffset(Hours.Length + ":".Length, LogicalDirection.Backward);
            var textRangeC = new TextRange(startC, endC);
            textRangeC.ApplyPropertyValue(TextElement.FontSizeProperty, "76");

            TextPointer startM = textRange.Start.GetPositionAtOffset(Hours.Length + ":".Length, LogicalDirection.Forward);
            TextPointer endM = textRange.Start.GetPositionAtOffset(Hours.Length + ":".Length + Minutes.Length, LogicalDirection.Backward);
            var textRangeM = new TextRange(startM, endM);
            textRangeM.ApplyPropertyValue(TextElement.FontSizeProperty, "76");

            TextPointer startS = textRange.Start.GetPositionAtOffset(Hours.Length + ":".Length + Minutes.Length, LogicalDirection.Forward);
            TextPointer endS = textRange.Start.GetPositionAtOffset(Hours.Length + ":".Length + Minutes.Length + Seconds.Length, LogicalDirection.Backward);
            var textRangeS = new TextRange(startS, endS);
            textRangeS.ApplyPropertyValue(TextElement.FontSizeProperty, "56");
        }
        public void Clock_Tick(object sender, EventArgs e)
        {
            if (TimerIsRunning == true || StopWatchIsRunning == true)
            {
                SetTime -= 1 * myTimer.factor;
                StartTimeCount += 1;
            }
            if (TimerIsRunning == true)
            {
                if (StartTimeCount % 10 == 0)
                {
                    TimeSpan ts = EndDateTime - DateTime.Now;
                    double TimeDifference = ts.Days * 3600 * 24 + ts.Hours * 3600 + ts.Minutes * 60 + ts.Seconds;
                    if (TimeDifference < SetTime)
                    {
                        SetTime = TimeDifference;
                    }
                }
            }
            else if (StopWatchIsRunning == true)
            {
                if (StartTimeCount % 10 == 0)
                {
                    TimeSpan ts = DateTime.Now - StopWatchStartDateTime;
                    double TimeDifference = ts.Days * 3600 * 24 + ts.Hours * 3600 + ts.Minutes * 60 + ts.Seconds;
                    if (TimeDifference > SetTime)
                    {
                        SetTime = TimeDifference;
                    }
                }
            }
            MakeClock();
            myTimer.MakeTimer();
            StartDateCount += 1;
            if (StartDateCount % 1000 == 0)
            {
                int StartDay = Int32.Parse(StartDateTime.Split(' ')[0].Split('.')[0]);
                int StartMonth = Int32.Parse(StartDateTime.Split(' ')[0].Split('.')[1]);
                int DayNow = Int32.Parse(DateTime.Now.ToString().Split(' ')[0].Split('.')[0]);
                int MonthNow = Int32.Parse(DateTime.Now.ToString().Split(' ')[0].Split('.')[1]);
                if (DayNow > StartDay || (DayNow <= StartDay && MonthNow > StartMonth))
                {
                    if (DaysTimerIsRunning1 == true)
                    {
                        DaysValues1 = (Int32.Parse(DaysValues1) - 1).ToString();
                    }
                    else if (DaysStopWatchIsRunning1 == true)
                    {
                        DaysValues1 = (Int32.Parse(DaysValues1) + 1).ToString();
                    }
                    if (DaysTimerIsRunning2 == true)
                    {
                        DaysValues2 = (Int32.Parse(DaysValues1) - 1).ToString();
                    }
                    else if (DaysStopWatchIsRunning2 == true)
                    {
                        DaysValues2 = (Int32.Parse(DaysValues1) + 1).ToString();
                    }
                }
            }

            if (Timer == true)
            {
                if (TimerIsRunning == true)
                {
                    if (SetTime > 0)
                    {
                        myTimer.count = 0;
                    }
                    else if (SetTime == 0)
                    {
                        myTimer.PlayAlarm();
                    }
                    else if (SetTime <= 0)
                    {
                        if (myTimer.count < Int32.Parse(Alarm))
                        {
                            myTimer.count += 1;
                        }
                        else if (myTimer.count >= Int32.Parse(Alarm))
                        {
                            myTimer.mediaPlayer.Stop();
                        }
                    }
                    Display(HoursTimer, MinutesTimer, SecondsTimer);
                }
                else if (TimerIsRunning == false)
                {
                    if (StopWatchIsRunning == false)
                    {
                        if (SetTime <= 0)
                        {
                            myTimer.mediaPlayer.Stop();
                        }
                    }
                    else if (StopWatchIsRunning == true)
                    {
                        Display(HoursTimer, MinutesTimer, SecondsTimer);
                    }
                }
            }
            if (Timer == false)
            {
                Display(HoursClock, MinutesClock, SecondsClock);
            }
            ArrowFlash();
        }
        public async Task ArrowFlash()
        {
            //Timer run
            if (TimerIsRunning == true)
            {
                if (SetTime > 0)
                {
                    TimerIndicator1 = "↓";
                    BackgroundTimerIndicator1 = Brushes.White;
                }
                if (SetTime <= 0)
                {
                    TimerIndicator1 = " ";
                    BackgroundTimerIndicator1 = Brushes.Red;
                }
            }
            else if (StopWatchIsRunning == true)
            {
                TimerIndicator1 = "↑";
                BackgroundTimerIndicator1 = Brushes.White;
            }

            //Days timer1 run
            if (Int32.Parse(dayTimer.SubtractTime(SettingsList[5])) > 0 && DaysTimerIsRunning1 == true)
            {
                TimerIndicator2 = "↓";
                BackgroundTimerIndicator2 = Brushes.White;
            }
            else if (Int32.Parse(dayTimer.SubtractTime(SettingsList[5])) < 0 && DaysTimerIsRunning1 == true)
            {
                TimerIndicator2 = "↑";
                BackgroundTimerIndicator2 = Brushes.Red;
            }
            else if (Int32.Parse(dayTimer.SubtractTime(SettingsList[5])) <= 0 && DaysStopWatchIsRunning1 == true)
            {
                TimerIndicator2 = "↑";
                BackgroundTimerIndicator2 = Brushes.White;
            }
            else if ((DaysTimerIsRunning1 == false && DaysStopWatchIsRunning1 == false) || SettingsList[5] == "01.01.0001")
            {
                TimerIndicator2 = " ";
                BackgroundTimerIndicator2 = Brushes.White;
            }

            //Days timer2 run
            if (Int32.Parse(dayTimer.SubtractTime(SettingsList[6])) > 0 && DaysTimerIsRunning2 == true)
            {
                TimerIndicator3 = "↓";
                BackgroundTimerIndicator3 = Brushes.White;
            }
            else if (Int32.Parse(dayTimer.SubtractTime(SettingsList[6])) < 0 && DaysTimerIsRunning2 == true)
            {
                TimerIndicator3 = "↑";
                BackgroundTimerIndicator3 = Brushes.Red;
            }
            else if (Int32.Parse(dayTimer.SubtractTime(SettingsList[6])) <= 0 && DaysStopWatchIsRunning2 == true)
            {
                TimerIndicator3 = "↑";
                BackgroundTimerIndicator3 = Brushes.White;
            }
            else if ((DaysTimerIsRunning2 == false && DaysStopWatchIsRunning2 == false) || SettingsList[6] == "01.01.0001")
            {
                TimerIndicator3 = " ";
                BackgroundTimerIndicator3 = Brushes.White;
            }

            await Task.Delay(800);
            TimerIndicator1 = " ";
            TimerIndicator2 = " ";
            TimerIndicator3 = " ";
            BackgroundTimerIndicator1 = Brushes.White;
            BackgroundTimerIndicator2 = Brushes.White;
            BackgroundTimerIndicator3 = Brushes.White;
        }
        private void MakeClock()
        {
            HoursClock = DateTime.Now.Hour.ToString();
            if (Int32.Parse(HoursClock) < 10)
            {
                HoursClock = "0" + HoursClock;
            }
            MinutesClock = DateTime.Now.Minute.ToString();
            if (Int32.Parse(MinutesClock) < 10)
            {
                MinutesClock = "0" + MinutesClock;
            }
            SecondsClock = DateTime.Now.Second.ToString();
            if (Int32.Parse(SecondsClock) < 10)
            {
                SecondsClock = "0" + SecondsClock;
            }
        }
        public void StartC()
        {
            if (clock != null)
            {
                clock.Interval = TimeSpan.FromMilliseconds(1000);
                clock.Tick += Clock_Tick;
                clock.Start();
            }
        }
        private void OpenSettings()
        {
            if (SettingsVis == Visibility.Hidden)
            {
                SettingsVis = Visibility.Visible;
            }
            else
            {
                SettingsVis = Visibility.Hidden;
            }

            if (SettingsListVis == Visibility.Visible)
            {
                SettingsListVis = Visibility.Hidden;
            }
        }
        private void ShowListOfSettings()
        {
            if (SettingsListVis == Visibility.Hidden)
            {
                SettingsListVis = Visibility.Visible;
                MainWindow.SettingsList.Children.Clear();
                for (int i = 0; i < SettingsList.Count - 1; i++)
                {
                    MyLabel myLabel = new MyLabel();
                    myLabel.Content = SettingsList[i];
                    MainWindow.SettingsList.Children.Add(myLabel);
                }
                MyLabel myLabelE = new MyLabel();
                myLabelE.Content = SettingsList[SettingsList.Count - 1];
                myLabelE.Margin = new Thickness(5, 0, 0, 5);
                MainWindow.SettingsList.Children.Add(myLabelE);
            }
            else
            {
                SettingsListVis = Visibility.Hidden;
            }
        }
        public void AdditionalSettingsLists(int NProcesses)
        {
            init.ListName = init.ListName.Substring(0, "Settings".Length) + NProcesses.ToString() + ".ini";
            if (!File.Exists(write.dir + @"Settings\" + init.ListName))
            {
                File.Copy(write.dir + @"Settings\Settings.ini", write.dir + @"Settings\" + init.ListName);
            }
        }
        private void ExitApp()
        {
            Process[] processes = Process.GetProcessesByName("Timer2");
            int processesCount = processes.Length;
            string path = write.dir + @"Settings\";
            if (processesCount > 1)
            {
                File.Delete(path + init.ListName);
            }
            else if (processesCount == 1)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);

                List<FileInfo> files = dirInfo.GetFiles("*.ini").ToList();
                foreach (FileInfo element in files)
                {
                    if (element.ToString() != "Settings.ini")
                    {
                        File.Delete(path + element);
                    }
                }
            }
            Application.Current.Shutdown();
        }
        public bool CanComm()
        {
            return true;
        }
        private void OnPropertyChange(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}