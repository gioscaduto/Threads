Thread.CurrentThread.Name = "Main()";

Thread t1 = new Thread(Run);
t1.Name = "Run () 1";
t1.Start("p1");

Thread t2 = new Thread(Run);
t2.Name = "Run () 2";
t2.Start("p2");

// Wait t1 and t2 finalize
t1.Join();
t2.Join();

for (int i = 0; i < 100; i++)
{
    Console.WriteLine($"{i} => {Thread.CurrentThread.Name}");
}

static void Run(object param)
{
    string p = param as string;

    for (int i = 0; i < 100; i++)
    {
        Console.WriteLine($"{i} => {Thread.CurrentThread.Name} => {p}");
    }
}