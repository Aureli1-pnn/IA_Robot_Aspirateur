static class Constants{
    public const int DIMENSION = 5;
    public const int NBOFROOM = DIMENSION*DIMENSION;
     // = ops.DImension au carré

    
}



namespace Agent_aspirateur
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed<Options>(ops =>
                   {

                       if (ops.Dimension == null || ops.Dimension < 1)
                       {
                           Console.WriteLine("You need to indicate the number of rooms in width and lenght that is and integer higher than 0");
                       }
                       else
                       {
                           perform_actions(ops);
                       }


                   });
        }

    // To do 

    // Test
    Environment myEnvironment = new Environment();
    Robot myRobot = new Robot();
    /*
    myEnvironment.life();
    Console.WriteLine(myRobot.getElectricity());
    myRobot.aspire(myEnvironment);
    Console.WriteLine(myRobot.getElectricity());
    */
    /*
    for (int i = 0; i < 100; i++)
    {
        Console.WriteLine("\n\n\n");
        myEnvironment.life();
        myEnvironment.print();
    }
    */
    

}
