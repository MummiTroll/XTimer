using System.Collections.Generic;

namespace Timer2
{
    public class Init
    {
        public List<string> SettingsListTmp = new List<string>() { 
            "10", 
            "20", 
            "30", 
            "20", 
            "Alarm1.mp3", 
            "01.01.0001", 
            "01.01.0001", 
            "250", 
            "17" 
        };
        public string ListName { get; set; } = "Settings.ini";
        public const string DefaultTimerIntervalWin1 = "10";
        public const string DefaultTimerIntervalWin2 = "20";
        public const string DefaultTimerIntervalWin3 = "30";
        public const string DefaultAlarmInterval = "20";
        public const string DefaultAlarmFile = "Alarm1.mp3";
    }
}

