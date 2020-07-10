using HighPrecisionTimer;
using System;

namespace MultimediaTimer
{
    class Program
    {
        static readonly HPTimer timer = new HPTimer();

        static void Main()
        {
            // 每秒执行一次
            timer.Interval = 2;
            timer.Ticked += Timer_Ticked;
            timer.Start();

            Console.ReadKey();
            timer.Stop();
        }

        private static void Timer_Ticked()
        {
            Console.WriteLine(DateTime.Now.Millisecond);
        }
    }
}
