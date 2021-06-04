using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Media;
using System.Speech.Synthesis;
using System.Threading;

namespace Timer2
{
    public class MyTimer
    {
        #region Objects
        public MediaPlayer mediaPlayer = new MediaPlayer();
        public Write write = new Write();
        public Init init = new Init();
        Random rnd = new Random();
        TextToSpeech textToSpeech = new TextToSpeech();
        #endregion

        #region Properties
        #region Timer
        public bool Timer { get; set; }
        public bool Clock { get; set; } = true;
        public double SetTime { get; set; } = 0;
        public double TotalSetTime { get; set; } = 0;
        public bool TimerIsRunning { get; set; } = false;
        public bool StopWatchIsRunning { get; set; } = false;
        public string TimeValues1
        {
            get
            {
                if (String.IsNullOrEmpty(SettingsList[0]))
                {
                    SettingsList[0] = "10";
                }
                return SettingsList[0];
            }
            set
            {
                var list = new List<string>(File.ReadAllLines(write.dir + @"Settings\" + init.ListName));

                if (list[0] != value)
                {
                    list[0] = value;
                }
                File.WriteAllLines(write.dir + @"Settings\" + init.ListName, list);
            }
        }
        public string TimeValues2
        {
            get
            {
                if (String.IsNullOrEmpty(SettingsList[1]))
                {
                    SettingsList[1] = "20";
                }
                return SettingsList[1];
            }
            set
            {
                var list = new List<string>(File.ReadAllLines(write.dir + @"Settings\" + init.ListName));

                if (list[1] != value)
                {
                    list[1] = value;
                }
                File.WriteAllLines(write.dir + @"Settings\" + init.ListName, list);
            }
        }
        public string TimeValues3
        {
            get
            {
                if (String.IsNullOrEmpty(SettingsList[2]))
                {
                    SettingsList[2] = "30";
                }
                return SettingsList[2];
            }
            set
            {
                var list = new List<string>(File.ReadAllLines(write.dir + @"Settings\" + init.ListName));

                if (list[2] != value)
                {
                    list[2] = value;
                }
                File.WriteAllLines(write.dir + @"Settings\" + init.ListName, list);
            }
        }
        public DateTime EndDateTime { get; set; }
        public DateTime StopWatchStartDateTime { get; set; }
        public string TimerIndicator1 { get; set; }
        public int count { get; set; } = 0;
        public int factor { get; set; } = 1;
        public string date
        {
            get
            {
                return DateTime.Now.Day.ToString() + " " + DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture) + " " + DateTime.Now.Year.ToString();
            }
        }
        public string[] unwanted = new[] { "-", " ", "" };
        public string TimerName { get; set; }
        #endregion

        #region Display
        public string HoursTimer { get; set; } = "00";
        public string MinutesTimer { get; set; } = "00";
        public string SecondsTimer { get; set; } = "00";
        #endregion

        #region Background indicator
        public Brush BackgroundTimerIndicator1 { get; set; } = Brushes.White;
        public Brush BackgroundTimerIndicator2 { get; set; } = Brushes.White;
        public Brush BackgroundTimerIndicator3 { get; set; } = Brushes.White;
        #endregion

        #region Alarm
        public string Alarm
        {
            get
            {
                if (String.IsNullOrEmpty(SettingsList[3]))
                {
                    SettingsList[3] = Init.DefaultAlarmInterval;
                }
                return SettingsList[3];
            }
            set
            {
                var list = new List<string>(File.ReadAllLines(write.dir + @"Settings\" + init.ListName));

                if (list[3] != value)
                {
                    list[3] = value;
                }
                File.WriteAllLines(write.dir + @"Settings\" + init.ListName, list);
            }
        }
        public string Item
        {
            get
            {
                if (String.IsNullOrEmpty(SettingsList[4]))
                {
                    SettingsList[4] = Init.DefaultAlarmFile;
                }
                return SettingsList[4];
            }
            set
            {
                var list = new List<string>(File.ReadAllLines(write.dir + @"Settings\" + init.ListName));

                if (list[4] != value)
                {
                    list[4] = value;
                }
                File.WriteAllLines(write.dir + @"Settings\" + init.ListName, list);
            }
        }
        #endregion

        #region Lists
        public List<string> RingTones
        {
            get
            {
                List<string> Tones = new List<string>();
                string path = write.dir + @"Alarm\";
                string[] extensions = new string[] { ".mp3", ".wav" };
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                List<FileInfo> files = dirInfo.GetFiles().Where(f => extensions.Any(f.Extension.Equals)).ToList();
                foreach (FileInfo element in files)
                {
                    if (!Tones.Contains(element.ToString()))
                    {
                        Tones.Add(element.ToString());
                    }
                }
                return Tones;
            }
        }
        public List<string> SettingsList
        {
            get
            {
                List<string> list = new List<string>();
                if (!Directory.Exists(write.dir + @"Settings\")) { Directory.CreateDirectory(write.dir + @"Settings\"); }
                if (File.Exists(write.dir + @"Settings\" + init.ListName))
                {
                    list = new List<string>(File.ReadAllLines(write.dir + @"Settings\" + init.ListName));
                    if (list.Count < 9)
                    {
                        list = new List<string>(init.SettingsListTmp);
                    }
                }
                else if (!File.Exists(write.dir + @"Settings\" + init.ListName))
                {
                    list = new List<string>(init.SettingsListTmp);
                }
                File.WriteAllLines(write.dir + @"Settings\" + init.ListName, list);
                return list;
            }
            set
            {
                if (SettingsList != value)
                {
                    SettingsList = value;
                }
                List<string> list = new List<string>(SettingsList);

                if (!Directory.Exists(write.dir + @"Settings\")) { Directory.CreateDirectory(write.dir + @"Settings\"); }
                File.WriteAllLines(write.dir + @"Settings\" + init.ListName, list);
            }
        }
        #endregion
        #endregion
        public void MakeTimer()
        {
            if (SetTime > 0)
            {
                SecsToTime(SetTime);
            }
            else if (SetTime == 0)
            {
                HoursTimer = "00";
                MinutesTimer = "00";
                SecondsTimer = "00";
            }
            else if (SetTime < 0)
            {
                SecsToTime(-SetTime);
            }
        }
        public void StartTimerRun()
        {
            if (Clock == false)
            {
                if (TimerIsRunning == false && StopWatchIsRunning == false)
                {
                    if (TotalSetTime > 0)
                    {
                        TimerIsRunning = true;
                        StopWatchIsRunning = false;

                        TimerIndicator1 = "↓";
                        factor = 1;
                        if (SetTime == 0)
                        {
                            SetTime = TotalSetTime;
                        }
                        MakeTimer();
                        EndDateTime = DateTime.Now + new TimeSpan(0, 0, 0, Convert.ToInt32(TotalSetTime), 0);
                    }
                    else if (TotalSetTime <= 0)
                    {
                        StopWatchIsRunning = true;
                        TimerIsRunning = false;
                        TimerIndicator1 = "↑";
                        factor = -1;
                        StopWatchStartDateTime = DateTime.Now;
                    }
                }
                else if (TimerIsRunning == true)
                {
                    TimerIsRunning = false;
                    mediaPlayer.Stop();

                    try
                    {
                        textToSpeech.synth.SpeakAsyncCancelAll();
                    }
                    catch (ObjectDisposedException) { }
                    //textToSpeech.synth.Dispose();
                }
                else if (StopWatchIsRunning == true)
                {
                    StopWatchIsRunning = false;
                    try
                    {
                        textToSpeech.synth.SpeakAsyncCancelAll();
                    }
                    catch (ObjectDisposedException) { }
                    //textToSpeech.synth.Dispose();
                }
            }
        }
        public void SetTimerFromStandardBox(string TextBoxText)
        {
            if (Timer == true)
            {
                if (StopWatchIsRunning == false && TimerIsRunning == false)
                {
                    if (String.IsNullOrEmpty(TextBoxText))
                    {
                        TextBoxText = "0";
                    }
                    HoursTimer = "00";
                    MinutesTimer = TextBoxText;
                    SecondsTimer = "00";
                    TotalSetTime = Int32.Parse(TextBoxText) * 60;
                    SetTime = TotalSetTime;
                }
            }
        }
        public void SetTimer(string param)
        {
            if (Timer == true)
            {
                switch (param)
                {
                    case "H":
                        HoursTimer = SetValue1(HoursTimer);
                        break;
                    case "M":
                        MinutesTimer = SetValue(MinutesTimer);
                        break;
                    case "S":
                        SecondsTimer = SetValue(SecondsTimer);
                        break;
                }
                SetTime = Int32.Parse(HoursTimer) * 3600 + Int32.Parse(MinutesTimer) * 60 + Int32.Parse(SecondsTimer);
                TotalSetTime = SetTime;
            }
        }
        public string SetValue(string val)
        {
            int v = Int32.Parse(val);
            if (v < 59)
            {
                v += 1;
                if (v < 10)
                {
                    val = "0" + v.ToString();
                }
                else
                {
                    val = v.ToString();
                }
            }
            else if (v == 59)
            {
                val = "00";
            }
            return val;
        }
        public string SetValue1(string val)
        {
            int v = Int32.Parse(val);
            if (v < 99)
            {
                v += 1;
                if (v < 10)
                {
                    val = "0" + v.ToString();
                }
                else
                {
                    val = v.ToString();
                }
            }
            else if (v == 99)
            {
                val = "00";
            }
            return val;
        }
        public void SecsToTime(double val)
        {
            if (Math.Floor(val / 3600) < 10)
            {
                HoursTimer = "0" + Math.Floor(val / 3600).ToString();
            }
            else
            {
                HoursTimer = Math.Floor(val / 3600).ToString();
            }
            val = val - Math.Floor(val / 3600) * 3600;
            if (Math.Floor(val / 60) < 10)
            {
                MinutesTimer = "0" + Math.Floor(val / 60).ToString();
            }
            else
            {
                MinutesTimer = Math.Floor(val / 60).ToString();
            }
            val = val - Math.Floor(val / 60) * 60;
            if (val < 10)
            {

                SecondsTimer = "0" + val.ToString();
            }
            else
            {
                SecondsTimer = val.ToString();
            }
        }
        public void PlayAlarm()
        {
            string Speech = string.Empty;
            string[] Phrases = new[] { "Think about", "What about", "Are you thinking about", "Time to deal with" };
            if (!String.IsNullOrEmpty(TimerName))
            {
                   PromptBuilder builder = new PromptBuilder(new System.Globalization.CultureInfo("en-US"));
                for (int i = 0; i < 10; i++)
                {
                    builder.AppendText(Phrases[rnd.Next(0, Phrases.Length)]);
                    builder.AppendText(TimerName + "?");
                    builder.AppendBreak();
                }
                textToSpeech.synth.SetOutputToDefaultAudioDevice();
                textToSpeech.synth.SpeakAsync(builder);
            }
            else
            {
                mediaPlayer.Open(new Uri(write.dir + @"Alarm\" + Item));
                mediaPlayer.Play();
            }
            //switch (TimerName.ToLower())
            //{
            //    case "breakfast":
            //        Item = "Breakfast.mp3";
            //        break;
            //    case "lunch":
            //        Item = "Lunch.mp3";
            //        break;
            //    case "dinner":
            //        Item = "Dinner.mp3";
            //        break;
            //}
            //mediaPlayer.Open(new Uri(write.dir + @"Alarm\" + Item));
            //mediaPlayer.Play();
        }
        public void Clear_Timer()
        {
            if (TimerIsRunning == false)
            {
                HoursTimer = "00";
                MinutesTimer = "00";
                SecondsTimer = "00";
                SetTime = 0;
                TotalSetTime = 0;
                StopWatchStartDateTime = DateTime.Now;
            }
        }
    }
}