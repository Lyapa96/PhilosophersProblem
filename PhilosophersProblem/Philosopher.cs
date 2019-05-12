using System;
using System.Threading;

namespace PhilosophersProblem
{
    public class Philosopher
    {
        private readonly int _number;
        private readonly Forks _forks;
        private readonly Stats _stats;
        private readonly Random _rand;

        private readonly int _leftFork;
        private readonly int _rightFork;
        private bool _isHungry;

        public Philosopher(int number, Forks forks, Stats stats, Random rand = null)
        {
            _number = number;
            _forks = forks;
            _stats = stats;
            _rand = rand;
            _leftFork = number;
            _rightFork = number == forks.Count - 1 ? 0 : number + 1;
        }

        public void Run()
        {
            while (true)
            {
                if (!_isHungry)
                {
                    Console.WriteLine($"Философ №{_number} начал думать");
                    EmulateActivity();
                    Console.WriteLine($"Философ №{_number} закончил думать");
                    _isHungry = true;
                }
                else
                {
                    _forks.Get(_leftFork, _rightFork);
                    Console.WriteLine($"Философ №{_number} начал есть");
                    EmulateActivity();
                    _forks.Put(_leftFork, _rightFork);
                    Console.WriteLine($"Философ №{_number} поел");

                    _stats.AddDinner(_number);
                    _isHungry = false;
                }
            }
        }

        private void EmulateActivity()
        {
            if (_rand != null)
                Thread.Sleep(_rand.Next(50, 1000));
        }
    }
}