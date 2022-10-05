public class Room{

    // Attributes
    private string Localisation { get; set; }   // just use for testing
    private bool HaveJewel;
    private bool IsDirty;

    // Constructor
    public Room(string localisation){
        Localisation = localisation;
        HaveJewel = false;
        IsDirty = false;
    }

    // Getters
    public string getLocalisation(){ return Localisation;}
    public bool doIHaveAJewel(){ return HaveJewel;}
    public bool AmIDirty(){ return IsDirty;}

    // Methods
    
    // just use for testing
    public void print(){
        string message = "My Localisation : " + getLocalisation();
        if(AmIDirty()){
            message += " dirty place";
        }
        if(doIHaveAJewel()){
            message += " with a jewel";
        }
        Console.WriteLine(message);
    }

    // Setters
    public void setHaveJewel(bool newValue){ HaveJewel=newValue;}
    public void dirty(){ IsDirty=true;}
    public void cleaned(){ 
        IsDirty=false;
        HaveJewel=false;}
}