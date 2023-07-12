Mutex mutex = new Mutex(false, "MutexApp");
bool acquired = false;

try
{
    acquired = mutex.WaitOne(1000);

    if (!acquired)
    {
        Console.WriteLine("The application has been running");
        return;
    }

    Console.WriteLine("The application started to running");
    Console.ReadLine();
}
finally
{
    if (acquired)
    {
        mutex.ReleaseMutex();
    }
}