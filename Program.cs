using CommandLine;

namespace Agent_aspirateur;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    /*static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }*/

    static void Main(string[] args)
    {
        
        // Determinate dimension of the house with the user entry
        if (!determinateDimension(args))
        {
            System.Environment.Exit(0);
        }

        // Initialisation of the variables
        Environment myEnvironment = new Environment();
        Robot myRobot = new Robot(myEnvironment);

        // Creating Threads
        Thread t1 = new Thread(() => myEnvironment.life())
        {
            Name = "Environment Thread"
        };
        Thread t2 = new Thread(() => myRobot.life())
        {
            Name = "Robot Thread"
        };

        // Executing threads
        t1.Start();
        t2.Start();

        // Display performance measure
        Console.WriteLine("Performance measure : " + myEnvironment.returnPerformanceMeasure(myRobot.getElectricity()));

        // Test
        ApplicationConfiguration.Initialize();
        Application.Run(new Graphic_interface.Form1());

    }

    static bool determinateDimension(string[] args)
    {
        bool isAllGood = false;
        Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(ops => {
            if (ops.Dimension < 1)
            {
                Console.WriteLine("You need to indicate the number of rooms in width and length that is an integer higher than 0");
            }
            else
            {
                Console.WriteLine("Current value of ops.Dimension : " + ops.Dimension);
                Constants.DIMENSION = ops.Dimension;
                Constants.NBOFROOM = ops.Dimension * ops.Dimension;
                isAllGood = true;
            }
        });
        return isAllGood;
    }
}