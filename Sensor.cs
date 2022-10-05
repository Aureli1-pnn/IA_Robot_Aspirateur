public class Sensor{

    // Attributes
    private Robot Owner;
    private Environment Environment;
    private int PositionX;
    private int PositionY;

    // Constructor
    public Sensor(int X, int Y, Robot owner, Environment Environment){
        this.PositionX = X;
        this.PositionY = Y;
        this.Owner = owner;
        this.Environment = Environment;
    }

    // Return the state of the room 
    // 0 -> no jewel and clean
    // 10 -> no hewel and dirty
    // 110 -> have a jewel and is dirty
    public int returnMyState(){
        
        int stateOfRoom = 0;
        Room myRoom = this.Environment.getRoom(this.GetPositionX(), this.GetPositionY());
        if(myRoom.AmIDirty()){
            stateOfRoom += 10;
        }
        if(myRoom.doIHaveAJewel()){
            stateOfRoom += 100;
        }

        return stateOfRoom;
    }

    // Getters 
    public int GetPositionX(){ return this.PositionX;}
    public int GetPositionY(){ return this.PositionY;}
}