namespace Semaphore.App
{
    public class Printers
    {
        private const int COUNT = 3;
        private bool[] usedPrinters = new bool[COUNT];
        private Random random = new Random();
        private SemaphoreSlim semaphore = new SemaphoreSlim(COUNT);

        public void Print(string name)
        {
            semaphore.Wait();

            try
            {
                int printerIndex = GetPrinterIndex();
                
                Console.WriteLine($"Printer {printerIndex + 1} starting print to thread {name}");
                Thread.Sleep(random.Next(5000));
                Console.WriteLine($"Printer {printerIndex + 1} has finished print to thread {name}");
               
                SetPrinterFree(printerIndex);
            }
            finally
            {
                semaphore.Release();
            }
        }

        private int GetPrinterIndex()
        {
            for (int i = 0; i < usedPrinters.Length; i++) 
            {
                if (!usedPrinters[i])
                {
                    usedPrinters[i] = true;
                    return i;
                }
            }

            throw new InvalidOperationException("All printers are busy");
        }

        private void SetPrinterFree(int printerIndex)
        {
            usedPrinters[printerIndex] = false;
        }
    }
}
