using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CommandLine;

namespace PhilosophersProblem
{
    public static class EntryPoint
    {
        public static void Main(string[] args)
        {
            Parser.Default
                .ParseArguments<Options>(args)
                .WithParsed(Run);
        }

        private static void Run(Options opts)
        {
            var forks = new Forks(opts.PhilosophersCount);
            var stats = new Stats(opts.PhilosophersCount);
            var philosophers = CreatePhilosophers(opts, forks, stats);
            var threads = CreateThreads(philosophers);

            foreach (var thread in threads)
                thread.Start();

            Console.ReadKey();

            foreach (var thread in threads)
            {
                thread.Abort();
                thread.Join();
            }

            stats.Print();
        }

        private static List<Thread> CreateThreads(IEnumerable<Philosopher> philosophers)
        {
            return philosophers.Select(philosopher => new Thread(philosopher.Run) {IsBackground = true}).ToList();
        }

        private static IEnumerable<Philosopher> CreatePhilosophers(Options opts, Forks forks, Stats stats)
        {
            var rand = new Random();
            return Enumerable.Range(0, opts.PhilosophersCount).Select(number => new Philosopher(number, forks, stats, opts.EmulateActivity? rand: null));
        }
    }
}
