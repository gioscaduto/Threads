using Semaphore.App;

Printers printers = new Printers();

for (int i = 1; i <= 10; i++)
{
    Thread thread = new Thread(() => Run(printers));
    thread.Name = $"Thread #{i}";
    thread.Start();
}

static void Run(Printers printers)
{
    while (true)
    {
        printers.Print(Thread.CurrentThread.Name);
        Thread.Sleep(500);
    }
}