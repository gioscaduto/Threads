namespace WaitPulse.App
{
    public class BufferExample
    {
        const int MAX = 10;
        readonly object sync = new object();
        Queue<int> list = new Queue<int>();
        Random random = new Random();

        readonly int qtdProducers;
        readonly int qtdConsumers;

        public BufferExample(int qtdProducers, int qtdConsumers)
        {
            this.qtdProducers = qtdProducers;
            this.qtdConsumers = qtdConsumers;
        }

        public void StartThreads()
        {
            StartThreadsProducers();
            StartThreadsConsumers();
        }

        private void StartThreadsProducers()
        {
            for (int i = 0; i < qtdProducers; i++)
            {
                new Thread(StartProducers).Start();
            }
        }

        private void StartThreadsConsumers()
        {
            for (int i = 0; i < qtdConsumers; i++)
            {
                new Thread(StartConsumers).Start();
            }
        }

        private void StartProducers()
        {
            while (true)
            {
                Produce(random.Next(10));
                Show();
                Thread.Sleep(2000);
            }
        }

        private void StartConsumers()
        {
            while (true)
            {
                Consume();
                Show();
                Thread.Sleep(2000);
            }
        }

        private void Produce(int n)
        {
            lock (sync)
            {
                while(list.Count == MAX)
                {
                    Monitor.Wait(sync);
                }

                list.Enqueue(n);
                Monitor.PulseAll(sync);
            }
        }

        private void Consume()
        {
            lock (sync)
            {
                while (!list.Any()) 
                {
                    Monitor.Wait(sync);
                }

                int i = list.Dequeue();
                Monitor.PulseAll(sync);
            }
        }

        private void Show()
        {
            lock (sync)
            {
                Console.Write("=> ");
                foreach (int i in list)
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine();
            }
        }
    }
}
