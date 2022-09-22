public class Environment{

    // Attributs
    public Room[] Map = new Room[Constants.NBOFROOM];

    // Constructeur
    public Environment(){

        // Dimension, Column and Line will be use to give a localisation to a room
        int column = 1;
        int line = 1;
        int dimension = (int)Math.Sqrt((double)Constants.NBOFROOM);

        if(!Constants.isASquare()){
            dimension++;
        }

        // Create rooms
        for (int i = 0; i < Constants.NBOFROOM; i++)
        {
            string localisation = line + "_" + column;
            Map[i] = new Room(localisation);
            if((i+1) % dimension == 0){
                line++;
                column = 1;
            }
            else{
                column++;
            }
        }
    }

    // Methods 
    public void print(){
        for (int i = 0; i < Constants.NBOFROOM; i++)
        {
            Map[i].print();
        }
    }

    public void life(){
        Random rd = new Random();

        // Maybe a new dirty room (probability 1/10)
        int chance = rd.Next(1, 11);
        if(chance == 7){
            int randomRoom = rd.Next(0, Constants.NBOFROOM);
            Map[randomRoom].dirty();
        }
        // Maybe a jewel somewhere (probability 1/1000)
        chance = rd.Next(1, 1001);
        if(chance == 69){           // Aller l'OL
            int randomRoom = rd.Next(0, Constants.NBOFROOM);
            Map[randomRoom].setHaveJewel(true); 
        }
    }
}