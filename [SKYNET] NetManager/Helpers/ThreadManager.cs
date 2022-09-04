using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace SKYNET
{
    public class ThreadManager
    {
        public static List<Thread> ActiveThreads { get; set; }

        public static void RunThread(Action startThread)
        {
            Thread start = new Thread(new ThreadStart(startThread));
            start.IsBackground = true;
            start.Name = CreateName();
            start.Start();
            //NewThreadCore(start, false, false, true);
            ActiveThreads.Add(start);
        }
        private static void NewThreadCore(Thread t, bool inheritCulture, bool singleThreadedApartment, bool background)
        {
            t.Name = CreateName();
            if (inheritCulture)
            {
                t.CurrentCulture = CultureInfo.CurrentCulture;
                t.CurrentUICulture = CultureInfo.CurrentUICulture;
            }

            if (singleThreadedApartment)
                t.SetApartmentState(ApartmentState.STA);

            t.IsBackground = background;
        }
        public static void StopThreads()
        {
            for (int i = 0; i < ActiveThreads.Count; i++)
            {
                Thread thread = ActiveThreads[i];
                try
                {
                    if (thread != null)
                    {
                        thread.Join();
                    }
                }
                catch { }
            }
        }
        static ThreadManager()
        {
            ActiveThreads = new List<Thread>();
        }
        private static string CreateName()
        {
            string str1 = "";
            try
            {
                //Random Marcado por mi

                string str2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                short num1 = checked((short)str2.Length);
                StringBuilder stringBuilder = new StringBuilder();
                int num2 = 1;
                Random random = new Random();
                do
                {
                    int startIndex = random.Next(0, (int)num1);
                    stringBuilder.Append(str2.Substring(startIndex, 1));
                    checked { ++num2; }
                }
                while (num2 <= 6);
                stringBuilder.Append(DateAndTime.Now.ToString("HHmmss"));
                str1 = stringBuilder.ToString();
            }
            catch (Exception ex)
            {
            }
            return str1;
        }

    }
}