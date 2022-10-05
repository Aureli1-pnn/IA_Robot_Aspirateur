public class Effector{

    private Environment MyEnvironment;
    private Robot Owner;

    // Constructeur
    public Effector(Environment e, Robot owner){
        this.MyEnvironment = e;
        this.Owner = owner;
    }

    // Methods 

    // Make the agent aspire and update environment in consequence
    public void aspire(){
        this.MyEnvironment.cleaningRoom(this.Owner.getPositionY(), this.Owner.getPositionX());
        this.Owner.consumeElectricity();
    }

    // Make the agent catch a jewel and update environment in consequence
    public void catchJewel(){
        this.MyEnvironment.catchJewel(this.Owner.getPositionY(), this.Owner.getPositionX());
        this.Owner.consumeElectricity();
    }

    // Move methods
    public void goToTheLeft(){
        if(this.Owner.getPositionX() > 0){
            this.Owner.setPositionX(this.Owner.getPositionX()-1);
            this.Owner.consumeElectricity();
        }
    }
    public void goToTheRight(){
        if(this.Owner.getPositionX() < Constants.DIMENSION-1){
            this.Owner.setPositionX(this.Owner.getPositionX()+1);
            this.Owner.consumeElectricity();
        }
    }
    public void goUp(){
        if(this.Owner.getPositionY() > 0){
            this.Owner.setPositionY(this.Owner.getPositionY()-1);
            this.Owner.consumeElectricity();
        }
    }
    public void goDown(){
        if(this.Owner.getPositionY() < Constants.DIMENSION-1){
            this.Owner.setPositionY(this.Owner.getPositionY()+1);
            this.Owner.consumeElectricity();
        }
    }
}