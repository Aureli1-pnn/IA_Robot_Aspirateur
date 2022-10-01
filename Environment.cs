public class Environment{

    // Attributs
    private Room[][] Map = new Room[Constants.DIMENSION][];
    private int performance_measure;

    // Constructeur
    public Environment(){
        performance_measure = 0;
        for (int i = 0; i < Constants.DIMENSION; i++)
        {
            Map[i] = new Room[Constants.DIMENSION];
            for (int j = 0; j < Constants.DIMENSION; j++)
            {
                string localisation = (i+1) + "-" + (j+1);
                Map[i][j] = new Room(localisation);
            }
        }
    }

    // Methods 
    public void print(){
        for (int i = 0; i < Constants.DIMENSION; i++)
        {
            for (int j = 0; j < Constants.DIMENSION; j++)
            {
                Map[i][j].print();
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
            if(Map[X][Y].AmIDirty()){
                performance_measure++;
            }
            Map[X][Y].cleaned();
        }
    }

    public void loseJewel(){
        Random rd = new Random();
        int randomLine = rd.Next(0, Constants.DIMENSION);
        int randomColumn = rd.Next(0, Constants.DIMENSION);
        Map[randomLine][randomColumn].setHaveJewel(true); 
    }
    public void life(){
       if(shouldThereBeANewDirtySpace()){
            generateDirt();
       }
       if(shouldThereBeANewLostJewel()){
            loseJewel();
       }
    }
}