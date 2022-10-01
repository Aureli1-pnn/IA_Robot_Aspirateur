public class Robot{

    // Attributs 
    private int Electricity;
    private int PositionX;
    private int PositionY;

    // Constructeur
    public Robot(){
        Random rd = new Random();
        Electricity = 0;
        PositionX = rd.Next(0, Constants.DIMENSION);
        PositionY = rd.Next(0, Constants.DIMENSION);
    }

    // Méthodes
    public void consumeElectricity(){
        Electricity++;
    }
    public void aspire(Environment myEnvironment){
        myEnvironment.cleaningRoom(PositionX, PositionY);
        consumeElectricity();
    }

    // Méthodes de déplacement du robot
    public void goToTheLeft(){
        if(PositionX > 0){
            PositionX--;
            consumeElectricity();
        }
    }
    public void goToTheRight(){
        if(PositionX < Constants.DIMENSION-1){
            PositionX++;
            consumeElectricity();
        }
    }
    public void goUp(){
        if(PositionY > 0){
            PositionY--;
            consumeElectricity();
        }
    }
    public void goDown(){
        if(PositionY > Constants.DIMENSION-1){
            PositionY++;
            consumeElectricity();
        }
    }

    // Getters
    public int getElectricity(){ return Electricity;}

}