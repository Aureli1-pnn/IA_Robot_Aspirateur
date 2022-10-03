public class Robot{

    // Attributs 
    private int Electricity;
    private int PositionX;
    private int PositionY;
    private List<Sensor> mySensors;
    private Environment myEnvironment;

    // Constructeur
    public Robot(Environment myEnvironment){

        Random rd = new Random();
        this.PositionX = rd.Next(0, Constants.DIMENSION);
        this.PositionY = rd.Next(0, Constants.DIMENSION);

        this.Electricity = 0;

        this.myEnvironment = myEnvironment;

        this.mySensors = new List<Sensor>();

        for (int i = 0; i < Constants.DIMENSION; i++)
        {
            for (int j = 0; j < Constants.DIMENSION; j++)
            {
                Sensor mySensor = new Sensor(i, j, this, myEnvironment);
                this.mySensors.Add(mySensor);
            }
        }
    }

    // Méthodes
    public void life(){
        while(true){
            this.observeEnvironmentWithAllMySensors();
        }
    }
    public void consumeElectricity(){
        this.Electricity++;
    }
    public void aspire(){
        this.myEnvironment.cleaningRoom(PositionX, PositionY);
        this.consumeElectricity();
    }
    public void catchJewel(){
        this.myEnvironment.catchJewel(PositionX, PositionY);
        this.consumeElectricity();
    }

    public void observeEnvironmentWithAllMySensors(){
        foreach (var s in this.mySensors){
            Console.WriteLine(s.returnMyState());
        }
        Console.WriteLine("\n");
    }
    // Méthodes de déplacement du robot
    public void goToTheLeft(){
        if(PositionX > 0){
            this.PositionX--;
            this.consumeElectricity();
        }
    }
    public void goToTheRight(){
        if(PositionX < Constants.DIMENSION-1){
            this.PositionX++;
            this.consumeElectricity();
        }
    }
    public void goUp(){
        if(PositionY > 0){
            this.PositionY--;
            this.consumeElectricity();
        }
    }
    public void goDown(){
        if(PositionY > Constants.DIMENSION-1){
            this.PositionY++;
            this.consumeElectricity();
        }
    }

    // Getters
    public int getElectricity(){ return this.Electricity;}

}