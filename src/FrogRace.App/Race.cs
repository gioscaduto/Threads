using System.Diagnostics;

namespace FrogRace
{
    public class Race
    {
        int maxDistance;
        Frog[] frogs;
        CountdownEvent countdown;
        List<Frog> ranking = new List<Frog>();
        Stopwatch stopwatch;

        public Race(int frogsQuantity, int maxDistance)
        {
            this.maxDistance = maxDistance;
            frogs = new Frog[frogsQuantity];
            countdown = new CountdownEvent(frogsQuantity);
            stopwatch = new Stopwatch();

            GenerateFrogs(frogsQuantity);
        }

        private void GenerateFrogs(int frogsQuantity)
        {
            for (int i = 0; i < frogsQuantity; i++)
            {
                frogs[i] = new Frog(i + 1, FrogArrived);
            }
        }

        void FrogArrived(Frog frog)
        {
            lock (ranking)
            {
                frog.SetTime(stopwatch.Elapsed);
                ranking.Add(frog);
            }
        }

        public void Start()
        {
            stopwatch.Start();

            for (int i = 0; i < frogs.Length; i++)
            {
                var j = i;
                new Thread(() => frogs[j].Jump(maxDistance, countdown)).Start();
            }
            
            countdown.Wait();
            stopwatch.Stop();
            Console.WriteLine("The race is over!");
            ShowRanking();
        }

        private void ShowRanking()
        {
            int place = 1;
            foreach (Frog frog in ranking)
            {
                Console.WriteLine($"{place}º place \t Frog {frog.Id:00} \t {frog.Time.Seconds:00}:{frog.Time.Microseconds:000}");
                place++;
            }
        }
    }
}
