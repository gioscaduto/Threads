namespace Timer.App
{
    public static class TimerExample1
    {
        public static void Run()
        {
            var timer = new System.Threading.Timer(OnTimer, null, TimeSpan.FromSeconds(3), TimeSpan.FromSeconds(2));
            Console.ReadLine();

            timer.Dispose();
        }

        private static void OnTimer(object param)
        {
            Console.WriteLine("Example 1, timer started");
        }
    }
}
