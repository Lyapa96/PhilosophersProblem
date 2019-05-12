using System.Threading;

namespace PhilosophersProblem
{
    public class Forks
    {
        private readonly object lockObject = new object();
        private readonly bool[] forks;
        public readonly int Count;

        public Forks(int forksCount)
        {
            forks = new bool[forksCount];
            Count = forksCount;
        }

        public void Get(int left, int right)
        {
            lock (lockObject)
            {
                while (forks[left] || forks[right]) Monitor.Wait(lockObject);

                forks[left] = true;
                forks[right] = true;
            }
        }

        public void Put(int left, int right)
        {
            lock (lockObject)
            {
                forks[left] = false;
                forks[right] = false;
                Monitor.PulseAll(lockObject);
            }
        }
    }
}