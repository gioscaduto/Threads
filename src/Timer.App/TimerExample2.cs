using System.Timers;

namespace Timer.App
{
    public static class TimerExample2
    {
        public static void Run()
        {
            var timer = new System.Timers.Timer();

            timer.Interval = 2000;
            timer.Elapsed += OnTimer;
            timer.Start();

            Console.ReadLine();

            timer.Dispose();
        }

        private static void OnTimer(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Example 2, timer started");
        }
    }
}