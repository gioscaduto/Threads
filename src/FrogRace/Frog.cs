namespace FrogRace
{
    internal class Frog
    {
        static Random random = new Random();

        public Frog(int id, Action<Frog> arrived)
        {
            Id = id;
            Arrived = arrived;
        }

        public int Id { get; private set; }
        public int Distance { get; private set; }
        public TimeSpan Time { get; private set; }
        private Action<Frog> Arrived;

        public void Jump(int maxDistance, CountdownEvent countdown)
        {
            while (true)
            {
                Distance += random.Next(60);

                Console.WriteLine($"Frog {Id:00} achieved {Distance:000} cm");

                if (Distance >= maxDistance)
                {
                    if(Arrived != null)
                    {
                        Arrived(this);
                    }
                    
                    break;
                }

                Thread.Sleep(500);
            }

            countdown.Signal();
        }

        public void SetTime(TimeSpan time) =>
            Time = time;
    }
}
