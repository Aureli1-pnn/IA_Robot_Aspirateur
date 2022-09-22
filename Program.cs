static class Constants{
    public const int NBOFROOM = 26;

    public static bool isASquare(){

        for (int i = 1; i <= (int)Math.Sqrt((double)NBOFROOM); i++){
            if(i*i == NBOFROOM){
                return true;
            }
        }
        return false;
    }
}

// Programme
class Program{
    static void Main()
    {
        // To do 

        // Test
        Random rd = new Random();

        // Maybe a new dirty room (probability 1/10)
        /*for (int i = 1; i <= 100; i++)
        {
            int chance = rd.Next(1, 11);    
            Console.WriteLine(i + ": " + chance);
        }*/
    }
}
