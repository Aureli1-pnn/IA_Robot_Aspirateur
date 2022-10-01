using CommandLine;

namespace Agent_aspirateur
{
    public class Options
    {
        [Option('D', "dimension", Required = true, HelpText = "Specify the dimension of rooms")]
        public int Dimension { get; set; }

    }
}