static class Constants{
    public const int DIMENSION = 5;
    public const int NBOFROOM = DIMENSION*DIMENSION;

    public static bool isASquare(){

        for (int i = 1; i <= (int)Math.Sqrt((double)NBOFROOM); i++){
            if(i*i == NBOFROOM){
                return true;
            }
        }
        return false;
    }
}

// Programmes
class Program{
    static void Main()
    {
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
}
