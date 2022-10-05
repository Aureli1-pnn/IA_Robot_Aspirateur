using CommandLine;

namespace Agent_aspirateur
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Determinate dimension of the house with the user entry
            /*if(!determinateDimension(args)){
                System.Environment.Exit(0);
            }*/

            // Initialisation of the variables
            Environment myEnvironment = new Environment();
            Robot myRobot = new Robot(myEnvironment);

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
            //Console.WriteLine("Performance measure : " + myEnvironment.returnPerformanceMeasure(myRobot.getElectricity()));

            // Test

        }

        static bool determinateDimension(string[] args){
            bool isAllGood = false;
            Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(ops =>{
                if(ops.Dimension < 1){
                    Console.WriteLine("You need to indicate the number of rooms in width and length that is an integer higher than 0");
                }else{
                    Console.WriteLine("Current value of Dimension : " + ops.Dimension);
                    Constants.DIMENSION = ops.Dimension;
                    Constants.NBOFROOM = ops.Dimension*ops.Dimension;
                    isAllGood = true;
                }
            });
            return isAllGood;
        }
    }
}