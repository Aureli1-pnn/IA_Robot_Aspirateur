public class Environment{

    // Attributs
    private Room[][] Map = new Room[Constants.DIMENSION][];
    private int performance_measure;

    // Constructeur
    public Environment(){
        this.performance_measure = 0;
        for (int i = 0; i < Constants.DIMENSION; i++)
        {
            this.Map[i] = new Room[Constants.DIMENSION];
            for (int j = 0; j < Constants.DIMENSION; j++)
            {
                string localisation = (i+1) + "-" + (j+1);
                this.Map[i][j] = new Room(localisation);
            }
        }
    }

    // Getters
    public Room getRoom(int X, int Y){ return Map[X][Y];}
    public Room[][] getMap(){ return this.Map;}

    // Methods 
    // Interface
    public void print(int PositionRobotX, int PositionRobotY){

        //Console.WriteLine("Code [D,J,R] -- D = X la pièce est sale -- J il y a un joyeau -- R le robot est présent sinon il y a un espace\n");
        /*for (int i = 0; i < Constants.DIMENSION; i++)
        {
            Console.Write("[D,J,R]");
        }*/
        //Console.WriteLine();
        for (int i = 0; i < Constants.DIMENSION; i++)
        {
            for (int j = 0; j < Constants.DIMENSION; j++)
            {
                if(this.Map[i][j].AmIDirty()){
                    Console.Write("[Dirty,");
                }else{
                    Console.Write("[     ,");
                }
                if(this.Map[i][j].doIHaveAJewel()){
                    Console.Write("Jewel,");
                }else{
                    Console.Write("     ,");
                }
                if(j == PositionRobotX && i == PositionRobotY){
                    Console.Write("Robot]");
                }else{
                    Console.Write("     ]");
                }
            }
            Console.WriteLine();
        }
    }

    public bool shouldThereBeANewDirtySpace(){
        // Maybe a new dirty room (probability 1/30 for non informed 1/20 for informed)
        Random rd = new Random();
        //int chance = rd.Next(1, 31);
        int chance = rd.Next(1, 21);
        if(chance == 7){
            return true;
        }
        return false;
    }

    public bool shouldThereBeANewLostJewel(){
        // Maybe a jewel somewhere (probability 1/150 for no-informed 1/100 informed)
        Random rd = new Random();
        //int chance = rd.Next(1, 151);
        int chance = rd.Next(1, 101);
        if(chance == 69){               // Aller l'OL
            return true;
        }
        return false;
    }

    public void generateDirt(){
        Random rd = new Random();
        int randomLine = rd.Next(0, Constants.DIMENSION);
        int randomColumn = rd.Next(0, Constants.DIMENSION);
        Map[randomLine][randomColumn].dirty();
    }

    public void cleaningRoom(int X, int Y){
        if(X>=0 && X<Constants.DIMENSION && Y>=0 && Y<Constants.DIMENSION){
            if(this.Map[X][Y].AmIDirty()){
                changePerformanceMeasure(10);
            }
            else{
                changePerformanceMeasure(-5);
            }
            if(this.Map[X][Y].doIHaveAJewel()){
                changePerformanceMeasure(-1000);
            }
            this.Map[X][Y].cleaned();
        }
    }

    public void catchJewel(int X, int Y){
        if(X>=0 && X<Constants.DIMENSION && Y>=0 && Y<Constants.DIMENSION){
            if(this.Map[X][Y].doIHaveAJewel()){
                changePerformanceMeasure(100);
            }
            else{
                changePerformanceMeasure(-5);
            }
            this.Map[X][Y].setHaveJewel(false);
        }
    }

    public void loseJewel(){
        Random rd = new Random();
        int randomLine = rd.Next(0, Constants.DIMENSION);
        int randomColumn = rd.Next(0, Constants.DIMENSION);
        this.Map[randomLine][randomColumn].setHaveJewel(true); 
    }

    public int returnPerformanceMeasure(int electricity_consumption){
        return this.performance_measure+electricity_consumption;
    }

    public void life(){
        while(true){
            if(shouldThereBeANewDirtySpace()){
                generateDirt();
            }
            if(shouldThereBeANewLostJewel()){
                loseJewel();
            }
            Thread.Sleep(200);
        }
    }

    // Setters
    public void changePerformanceMeasure(int change){ performance_measure+=change;}
}