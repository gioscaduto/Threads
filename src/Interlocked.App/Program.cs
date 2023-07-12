using Interlocked.App;


Operation operation = new Operation();

Thread[] threads = new Thread[1000];

for (int i = 0; i < threads.Length; i++)
{
    threads[i] = new Thread(() => Run(operation));
}

for (int i = 0; i < threads.Length; i++)
{
    threads[i].Start();
}

for (int i = 0; i < threads.Length; i++)
{
    threads[i].Join();
}

Console.WriteLine($"Operation value:{operation.Value}");

static void Run(Operation operation)
{
    operation.Increment();
}