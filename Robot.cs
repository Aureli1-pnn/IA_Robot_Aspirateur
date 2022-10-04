public class Robot
{

    // Attributs 
    private int Electricity;
    private int PositionX;
    private int PositionY;
    private List<Sensor> mySensors;
    private Environment myEnvironment;
    private Effector myEffector;
    private string[] actions;

    // Constructeur
    public Robot(Environment myEnvironment)
    {

        Random rd = new Random();

        this.PositionX = rd.Next(0, Constants.DIMENSION);
        this.PositionY = rd.Next(0, Constants.DIMENSION);
        this.Electricity = 0;

        this.myEnvironment = myEnvironment;
        this.myEffector = new Effector(myEnvironment, this);
        this.mySensors = new List<Sensor>();

        this.actions = new string[Constants.NBOFACTION];
        for (int i = 0; i < Constants.NBOFACTION; i++)
        {
            this.actions[i] = Constants.DONOTHING;
        }

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
    public void life()
    {
        while (true)
        {
            this.ObserveEnvironmentWithAllMySensors();
        }
    }

    public void ObserveEnvironmentWithAllMySensors()
    {
        foreach (var s in this.mySensors)
        {
            Console.WriteLine(s.returnMyState());
        }
        Console.WriteLine("\n");
    }

    public void UpdateMyState()
    {

    }
    public void ChooseAnAction()
    {

    }
    public void justDoIt()
    {

    }
    // Getters
    public int getElectricity() { return this.Electricity; }
    public int getPositionX() { return this.PositionX; }
    public int getPositionY() { return this.PositionY; }

    // Setters
    public void setPositionX(int newPosition)
    {
        this.PositionX = newPosition;
    }
    public void setPositionY(int newPosition)
    {
        this.PositionY = newPosition;
    }
    public void consumeElectricity()
    {
        this.Electricity++;
    }
}