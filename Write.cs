using System;
using System.IO;

namespace Timer2
{
    public class Write
    {
        public string dir
        {
            get
            {
                string dir = System.IO.Path.GetPathRoot(System.Reflection.Assembly.GetEntryAssembly().Location);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                if (Directory.Exists(dir + "Home" + @"\"))
                {
                    dir += @"Home\" + @"_TimerX\";
                }
                else
                {
                    dir += @"_TimerX\";
                }
                return dir;
            }
        }
    }
}
