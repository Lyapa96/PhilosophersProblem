using System;
using System.Collections.Generic;
using System.Linq;

namespace PhilosophersProblem
{
    public class Stats
    {
        private readonly Dictionary<int, int> _philosopherNumberToDinnerCount;

        public Stats(int philosophersCount)
        {
            _philosopherNumberToDinnerCount = Enumerable.Range(0, philosophersCount).ToDictionary(x => x, x => 0);
        }

        public void AddDinner(int philosopherNumber)
        {
            _philosopherNumberToDinnerCount[philosopherNumber]++;
        }

        public void Print()
        {
            Console.WriteLine();
            Console.WriteLine("================================");

            foreach (var stat in _philosopherNumberToDinnerCount)
                Console.WriteLine($"Философ №{stat.Key}: {stat.Value}");

            Console.WriteLine("================================");
        }
    }
}