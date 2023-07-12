using Locks.App;

Counter counter = new Counter();

Thread[] threads = new Thread[5];

for (int i = 0; i < threads.Length; i++)
{
    threads[i] = new Thread(() => Run(counter));
}

for (int i = 0; i < threads.Length; i++)
{
    threads[i].Start();
}

for (int i = 0; i < threads.Length; i++)
{
    threads[i].Join();
}

Console.WriteLine($"Counter:{counter.Value}");

static void Run(Counter counter)
{
    counter.IncrementUsingLock();
    counter.IncrementUsingMonitor();
}