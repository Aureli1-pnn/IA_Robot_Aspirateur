static class Constants{
    public const int NBOFROOM = 25;

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
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("\n\n\n");
            myEnvironment.life();
            myEnvironment.print();
        }
    }
}
