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

    // Methods 
    public void print(){
        for (int i = 0; i < Constants.DIMENSION; i++)
        {
            for (int j = 0; j < Constants.DIMENSION; j++)
            {
                this.Map[i][j].print();
            }
        }
    }

    public bool shouldThereBeANewDirtySpace(){
        // Maybe a new dirty room (probability 1/10)
        Random rd = new Random();
        int chance = rd.Next(1, 11);
        if(chance == 7){
            return true;
        }
        return false;
    }

    public bool shouldThereBeANewLostJewel(){
        // Maybe a jewel somewhere (probability 1/1000)
        Random rd = new Random();
        int chance = rd.Next(1, 1001);
        if(chance == 69){           // Aller l'OL
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
                changePerformanceMeasure(1);
            }
            else{
                changePerformanceMeasure(-1);
            }
            if(this.Map[X][Y].doIHaveAJewel()){
                changePerformanceMeasure(-10);
            }
            this.Map[X][Y].cleaned();
        }
    }

    public void catchJewel(int X, int Y){
        if(X>=0 && X<Constants.DIMENSION && Y>=0 && Y<Constants.DIMENSION){
            if(this.Map[X][Y].doIHaveAJewel()){
                changePerformanceMeasure(5);
            }
            else{
                changePerformanceMeasure(-1);
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
        }
    }

    // Setters
    public void changePerformanceMeasure(int change){ performance_measure+=change;}
}