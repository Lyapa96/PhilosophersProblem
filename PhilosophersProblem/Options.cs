using CommandLine;

namespace PhilosophersProblem
{
    public class Options
    {
        [Option('p', "philosophers", Required = false, Default = 5, HelpText = "Count of philosophers")]
        public int PhilosophersCount { get; set; }
        [Option('e', "emulate", Required = false, HelpText = "Emulate activity of philosophers")]
        public bool EmulateActivity { get; set; }
    }
}