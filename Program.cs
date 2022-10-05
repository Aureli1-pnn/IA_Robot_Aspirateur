using CommandLine;

namespace Agent_aspirateur
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Determinate dimension of the house with the user entry
            if(!determinateDimension(args)){
                System.Environment.Exit(0);
            }

            // Initialisation of the variables
            Environment myEnvironment = new Environment();
            Robot myRobot = new Robot(myEnvironment);

            // Some print for user
            Console.Clear();
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("///////////////////////////////// Exploration Non Informée ///////////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////////////\n");
            Console.WriteLine("Vous avez choisi un manoir de dimension " + Constants.DIMENSION + "x" + Constants.DIMENSION + "\n\n");
            //Thread.Sleep(4000);

            // Creating Threads
            Thread t1 = new Thread(()=>myEnvironment.life()){
                Name = "Environment Thread"
            };
            Thread t2 = new Thread(()=>myRobot.life()){
                Name = "Robot Thread"
            };

            // Executing threads
            t1.Start();
            t2.Start();

            // Display performance measure
            Console.WriteLine("Performance measure : " + myEnvironment.CalculPerformanceMeasure(myRobot.getElectricity()));
        }

        // Use in the beginning of the program to determinate the dimension of the house 
        static bool determinateDimension(string[] args){
            bool isAllGood = false;
            Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(ops =>{
                if(ops.Dimension < 1){
                    Console.WriteLine("You need to indicate the number of rooms in width and length that is an integer higher than 0");
                }else{
                    //Console.WriteLine("Current value of Dimension : " + ops.Dimension);
                    Constants.DIMENSION = ops.Dimension;
                    isAllGood = true;
                }
            });
            return isAllGood;
        }
    }
}