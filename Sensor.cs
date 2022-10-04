public class Sensor
{

    private Robot Owner;
    private Environment Environment;
    private int PositionX;
    private int PositionY;

    // Constructeur
    public Sensor(int X, int Y, Robot owner, Environment Environment)
    {
        this.PositionX = X;
        this.PositionY = Y;
        this.Owner = owner;
        this.Environment = Environment;
    }
    public int returnMyState()
    {

        int stateOfRoom = 0;
        Room myRoom = this.Environment.getRoom(this.PositionX, this.PositionY);
        if (myRoom.AmIDirty())
        {
            stateOfRoom += 1;
        }
        if (myRoom.doIHaveAJewel())
        {
            stateOfRoom += 10;
        }

        return stateOfRoom;
    }

}