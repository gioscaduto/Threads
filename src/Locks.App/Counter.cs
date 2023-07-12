namespace Locks.App
{
    public class Counter
    {
        private readonly object sync = new object();
        public int Value { get; private set; }

        public void IncrementUsingLock()
        {
            lock (sync)
            {
                Value++;
            }
        }

        //This same Increment With Lock
        public void IncrementUsingMonitor()
        {
            bool lockTaken = false;
            
            try
            {
                Monitor.Enter(sync, ref lockTaken);
                Value++;
            }
            finally
            {
                if (lockTaken)
                {
                    Monitor.Exit(sync);
                }
            }
        }
    }
}
