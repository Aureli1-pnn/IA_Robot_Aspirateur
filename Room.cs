public class Room{

    // Attributs
    private string Localisation { get; set; }
    private bool HaveJewel;
    private bool IsDirty;

    // Constructeur
    public Room(string localisation){
        Localisation = localisation;
        HaveJewel = false;
        IsDirty = false;
    }

    // Getters
    public string getLocalisation(){ return Localisation;}
    public bool doIHaveAJawel(){ return HaveJewel;}
    public bool AmIDirty(){ return IsDirty;}

    // Methods
    public void print(){
        Console.WriteLine("My Localisation : " + Localisation);
    }

    // Setters
    public void setHaveJewel(bool newValue){ HaveJewel=newValue;}
    public void dirty(){ IsDirty=true;}
    public void cleaned(){ IsDirty=false;}
}