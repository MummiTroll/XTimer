using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Timer2
{
    public class DayTimer
    {
        #region Objects
        public Write write = new Write();
        public Init init = new Init();
        #endregion

        #region Properties
        public bool DaysTimerIsRunning1 { get; set; } = false;
        public bool DaysTimerIsRunning2 { get; set; } = false;
        public bool DaysStopWatchIsRunning1 { get; set; } = false;
        public bool DaysStopWatchIsRunning2 { get; set; } = false;
        public string DaysValues1 { get; set; } = "--";
        public string DaysValues2 { get; set; } = "--";
        public string[] unwanted = new[] { "-", "", "  " };
        #endregion
        public void StartStopDaysTimer(object param)
        {
            string timeParameter = param.ToString();
            var SettingsList = new List<string>(File.ReadAllLines(write.dir + @"Settings\"+init.ListName));
            switch (timeParameter)
            {
                case "1":
                    if (DaysTimerIsRunning1 == true)
                    {
                        DaysTimerIsRunning1 = false;
                    }
                    else if (DaysStopWatchIsRunning1 == true)
                    {
                        DaysStopWatchIsRunning1 = false;
                    }
                    else if (DaysTimerIsRunning1 == false && DaysStopWatchIsRunning1 == false)
                    {
                        if (SettingsList[5] == "01.01.0001")
                        {
                            SettingsList[5] = DateTime.Now.ToString().Split(' ')[0];
                            DaysStopWatchIsRunning1 = true;
                            DaysValues1 = "00";
                        }
                        else if (SettingsList[5] != "01.01.0001")
                        {
                            if (Int32.Parse(SubtractTime(SettingsList[5])) > 0)
                            {
                                MakeDayTimerScreenValue(SubtractTime(SettingsList[5]), 1);
                                DaysTimerIsRunning1 = true;
                            }
                            else if (Int32.Parse(SubtractTime(SettingsList[5])) == 0)
                            {
                                DaysStopWatchIsRunning1 = true;
                                DaysValues1 = "00";
                            }
                            else if (Int32.Parse(SubtractTime(SettingsList[5])) < 0)
                            {
                                MakeDayTimerScreenValue(SubtractTime(SettingsList[5]).Substring(1), 1);
                                DaysStopWatchIsRunning1 = true;
                            }
                        }
                    }
                    break;
                case "2":
                    if (DaysTimerIsRunning2 == true)
                    {
                        DaysTimerIsRunning2 = false;
                    }
                    else if (DaysStopWatchIsRunning2 == true)
                    {
                        DaysStopWatchIsRunning2 = false;
                    }
                    else if (DaysTimerIsRunning2 == false && DaysStopWatchIsRunning2 == false)
                    {
                        if (SettingsList[6] == "01.01.0001")
                        {
                            SettingsList[6] = DateTime.Now.ToString().Split(' ')[0];
                            DaysStopWatchIsRunning2 = true;
                            DaysValues2 = "00";
                        }
                        else if (SettingsList[6] != "01.01.0001")
                        {
                            if (Int32.Parse(SubtractTime(SettingsList[6])) > 0)
                            {
                                MakeDayTimerScreenValue(SubtractTime(SettingsList[6]), 2);
                                DaysTimerIsRunning2 = true;
                            }
                            else if (Int32.Parse(SubtractTime(SettingsList[6])) == 0)
                            {
                                DaysStopWatchIsRunning2 = true;
                                DaysValues2 = "00";
                            }
                            else if (Int32.Parse(SubtractTime(SettingsList[6])) < 0)
                            {
                                MakeDayTimerScreenValue(SubtractTime(SettingsList[6]).Substring(1), 2);
                                DaysStopWatchIsRunning2 = true;
                            }
                        }
                    }
                    break;
            }
            File.WriteAllLines(write.dir + @"Settings\" + init.ListName, SettingsList);
        }
        public void Set_Days(object param)
        {
            string timeParameter = param.ToString();
            var SettingsList = new List<string>(File.ReadAllLines(write.dir + @"Settings\" + init.ListName));
            switch (timeParameter)
            {
                case "1":
                    if (DaysTimerIsRunning1 == false && DaysStopWatchIsRunning1 == false)
                    {
                        if (DaysValues1 == "--")
                        {
                            DaysValues1 = "01";
                        }
                        else if (DaysValues1 != "--" && Int32.Parse(DaysValues1) + 1 <= 99)
                        {
                            DaysValues1 = (Int32.Parse(DaysValues1) + 1).ToString();
                            if (DaysValues1.Length == 1)
                            {
                                DaysValues1 = "0" + DaysValues1;
                            }
                        }
                        SettingsList[5] = ConvertValueToDate(DaysValues1);
                    }
                    break;
                case "2":
                    if (DaysTimerIsRunning2 == false && DaysStopWatchIsRunning2 == false)
                    {
                        if (DaysValues2 == "--")
                        {
                            DaysValues2 = "01";
                        }
                        else if (DaysValues2 != "--" && Int32.Parse(DaysValues2) + 1 <= 99)
                        {
                            DaysValues2 = (Int32.Parse(DaysValues2) + 1).ToString();
                            if (DaysValues2.Length == 1)
                            {
                                DaysValues2 = "0" + DaysValues2;
                            }
                        }
                        SettingsList[6] = ConvertValueToDate(DaysValues2);
                    }
                    break;
            }
            File.WriteAllLines(write.dir + @"Settings\" + init.ListName, SettingsList);
        }
        public void DeleteDaysTimer(object param)
        {
            string number = param.ToString();
            var SettingsList = new List<string>(File.ReadAllLines(write.dir + @"Settings\" + init.ListName));
            switch (number)
            {
                case "1":
                    if (DaysTimerIsRunning1 == false && DaysStopWatchIsRunning1 == false)
                    {
                        SettingsList[5] = "01.01.0001";
                        DaysValues1 = "--";
                    }
                    break;
                case "2":

                    if (DaysTimerIsRunning2 == false && DaysStopWatchIsRunning2 == false)
                    {
                        SettingsList[6] = "01.01.0001";
                        DaysValues2 = "--";
                    }
                    break;
            }
            File.WriteAllLines(write.dir + @"Settings\" + init.ListName, SettingsList);
        }
        public string ConvertValueToDate(string val)
        {
            string finalDate = string.Empty;
            if (!String.IsNullOrEmpty(val) && val != "-")
            {
                if (val == "--")
                {
                    finalDate = "01.01.0001";
                }
                else
                {
                    finalDate = (DateTime.Now + new TimeSpan(Int32.Parse(val), 0, 0, 0, 0)).ToString().Split(' ')[0];
                    //        int days = Int32.Parse(val);
                    //        int[] LongMonth = new[] { 1, 3, 5, 7, 8, 10, 12 };
                    //        int[] ShortMonth = new[] { 4, 6, 9, 11 };
                    //        string[] leapYear = new[] { "2000", "2004", "2008", "2012", "2016", "2020", "2024", "2028", "2032", "2036", "2040", "2044", "2048", "2052", "2056", "2060", "2064", "2068", "2072", "2076", "2080", "2084", "2088", "2092", "2096", "2100" };
                    //        int DateDay = Int32.Parse(DateTime.Now.ToString().Split(' ')[0].Split('.')[0]);
                    //        int DateMonth = Int32.Parse(DateTime.Now.ToString().Split(' ')[0].Split('.')[1]);
                    //        int DateYear = Int32.Parse(DateTime.Now.ToString().Split(' ')[0].Split('.')[2]);
                    //        while (days > 0)
                    //        {
                    //            if (LongMonth.Any(DateMonth.Equals))
                    //            {
                    //                if (days - (31 - DateDay) > 0)
                    //                {
                    //                    days -= (31 - DateDay);
                    //                    DateDay = 0;
                    //                    DateMonth += 1;
                    //                }
                    //                else if (days - (31 - DateDay) == 0)
                    //                {
                    //                    days -= (31 - DateDay);
                    //                    DateDay = 31;
                    //                }
                    //                else if (days - (31 - DateDay) < 0)
                    //                {
                    //                    DateDay += days;
                    //                    days = 0;
                    //                }
                    //            }
                    //            else if (ShortMonth.Any(DateMonth.Equals))
                    //            {
                    //                if (days - (30 - DateDay) > 0)
                    //                {
                    //                    days -= (30 - DateDay);
                    //                    DateDay = 0;
                    //                    DateMonth += 1;
                    //                }
                    //                else if (days - (30 - DateDay) == 0)
                    //                {
                    //                    days -= (30 - DateDay);
                    //                    DateDay = 30;
                    //                }
                    //                else if (days - (30 - DateDay) < 0)
                    //                {
                    //                    DateDay += days;
                    //                    days = 0;
                    //                }
                    //            }
                    //            else if (DateMonth == 2)
                    //            {
                    //                if (leapYear.Any(DateYear.Equals))
                    //                {
                    //                    if (days - (29 - DateDay) > 0)
                    //                    {
                    //                        days -= (29 - DateDay);
                    //                        DateDay = 0;
                    //                        DateMonth += 1;
                    //                    }
                    //                    else if (days - (29 - DateDay) == 0)
                    //                    {
                    //                        days -= (29 - DateDay);
                    //                        DateDay = 29;
                    //                    }
                    //                    else if (days - (29 - DateDay) < 0)
                    //                    {
                    //                        DateDay += days;
                    //                        days = 0;
                    //                    }
                    //                }
                    //                else
                    //                {
                    //                    if (days - (28 - DateDay) > 0)
                    //                    {
                    //                        days -= (28 - DateDay);
                    //                        DateDay = 0;
                    //                        DateMonth += 1;
                    //                    }
                    //                    else if (days - (28 - DateDay) == 0)
                    //                    {
                    //                        days -= (20 - DateDay);
                    //                        DateDay = 28;
                    //                    }
                    //                    else if (days - (28 - DateDay) < 0)
                    //                    {
                    //                        DateDay += days;
                    //                        days = 0;
                    //                    }
                    //                }
                    //            }
                    //            if (DateMonth > 12)
                    //            {
                    //                DateMonth = DateMonth - DateMonth;
                    //            }
                    //            if (DateMonth < DateMonth)
                    //            {
                    //                DateYear += 1;
                    //            }
                    //        }
                    //        if (DateDay < 10)
                    //        {
                    //            finalDate += "0" + DateDay.ToString() + ".";
                    //        }
                    //        else
                    //        {
                    //            finalDate += DateDay.ToString() + ".";
                    //        }
                    //        if (DateMonth < 10)
                    //        {
                    //            finalDate += "0" + DateMonth.ToString() + ".";
                    //        }
                    //        else
                    //        {
                    //            finalDate += DateMonth.ToString() + ".";
                    //        }
                    //        finalDate += DateYear.ToString();
                    //    }
                    //}
                    //else
                    //{
                    //    finalDate = "01.01.0001";
                    //}
                }
            }
            return finalDate;
        }
        public void CheckDaysTimerRunning()
        {
            var SettingsList = new List<string>(File.ReadAllLines(write.dir + @"Settings\" + init.ListName));
            {
                if (SettingsList[5] != "01.01.0001")
                {
                    string timeDifference = SubtractTime(SettingsList[5]);
                    if (Int32.Parse(timeDifference) > 0)
                    {
                        MakeDayTimerScreenValue(timeDifference, 1);
                        DaysTimerIsRunning1 = true;
                    }
                    else if (Int32.Parse(timeDifference) == 0)
                    {
                        DaysTimerIsRunning1 = false;
                        DaysStopWatchIsRunning1 = true;
                    }
                    else if (Int32.Parse(timeDifference) < 0)
                    {
                        timeDifference = timeDifference.Substring(1);
                        MakeDayTimerScreenValue(timeDifference, 1);
                        DaysTimerIsRunning1 = false;
                        DaysStopWatchIsRunning1 = true;
                    }
                }
                else if (SettingsList[5] == "01.01.0001")
                {
                    DaysTimerIsRunning1 = false;
                    DaysStopWatchIsRunning1 = false;
                }
                if (SettingsList[6] != "01.01.0001")
                {
                    string timeDifference = SubtractTime(SettingsList[6]);
                    if (Int32.Parse(timeDifference) > 0)
                    {
                        MakeDayTimerScreenValue(timeDifference, 2);
                        DaysTimerIsRunning2 = true;
                    }
                    else if (Int32.Parse(timeDifference) == 0)
                    {
                        DaysTimerIsRunning2 = false;
                        DaysStopWatchIsRunning2 = true;
                    }
                    else if (Int32.Parse(timeDifference) < 0)
                    {
                        timeDifference = timeDifference.Substring(1);
                        MakeDayTimerScreenValue(timeDifference, 2);
                        DaysTimerIsRunning2 = false;
                        DaysStopWatchIsRunning2 = true;
                    }
                }
                else
                {
                    DaysTimerIsRunning2 = false;
                    DaysStopWatchIsRunning2 = false;
                }
            }
            File.WriteAllLines(write.dir + @"Settings\" + init.ListName, SettingsList);
        }
        private void MakeDayTimerScreenValue(string timeDifference, int param)
        {
            switch (param)
            {
                case 1:
                    if (timeDifference.Length == 1)
                    {
                        DaysValues1 = "0" + timeDifference;
                    }
                    else if (timeDifference.Length == 2)
                    {
                        DaysValues1 = timeDifference;
                    }
                    else if (timeDifference.Length > 2)
                    {
                        DaysValues1 = "00";
                    }
                    break;
                case 2:
                    if (timeDifference.Length == 1)
                    {
                        DaysValues2 = "0" + timeDifference;
                    }
                    else if (timeDifference.Length == 2)
                    {
                        DaysValues2 = timeDifference;
                    }
                    else if (timeDifference.Length > 2)
                    {
                        DaysValues2 = "00";
                    }
                    break;
            }
        }
        public string SubtractTime(string savedTime)
        {
            string days = string.Empty;
            TimeSpan span = new TimeSpan(0, 0, 0, 0);
            DateTime SavedTime = new DateTime(
                Int32.Parse(savedTime.Split('.')[2]),
                Int32.Parse(savedTime.Split('.')[1]),
                Int32.Parse(savedTime.Split('.')[0]), 0, 0, 0);
            DateTime TimeNow = new DateTime(
                Int32.Parse(DateTime.Now.ToString().Split(' ')[0].Split('.')[2]),
                Int32.Parse(DateTime.Now.ToString().Split(' ')[0].Split('.')[1]),
                Int32.Parse(DateTime.Now.ToString().Split(' ')[0].Split('.')[0]), 0, 0, 0);
            span = SavedTime - TimeNow;
            if (span.ToString().Contains("."))
            {
                days = span.ToString().Split('.')[0];
            }
            else
            {
                days = "0";
            }
            return days;
        }
    }
}
