public class Robot{

    // Attributs 
    private int Electricity;
    private int PositionX;
    private int PositionY;
    private Stack<string> actions;
    private int[][] states;
    private List<Sensor> mySensors;
    private Environment myEnvironment;
    private Effector myEffector;

    // Constructeur
    public Robot(Environment myEnvironment){

        Random rd = new Random();

        this.PositionX = rd.Next(0, Constants.DIMENSION);
        this.PositionY = rd.Next(0, Constants.DIMENSION);
        this.Electricity = 0;

        this.myEnvironment = myEnvironment;
        this.myEffector = new Effector(myEnvironment, this);
        this.mySensors = new List<Sensor>();

        this.actions = new Stack<string>();

        this.states = new int[Constants.DIMENSION][];
        for (int i = 0; i < Constants.DIMENSION; i++)
        {
            this.states[i] = new int[Constants.DIMENSION];
            for (int j = 0; j < Constants.DIMENSION; j++)
            {
                this.states[i][j] = 0;
            }
        }
        for (int i = 0; i < Constants.DIMENSION; i++)
        {
            for (int j = 0; j < Constants.DIMENSION; j++)
            {
                Sensor mySensor = new Sensor(j, i, this, myEnvironment);
                this.mySensors.Add(mySensor);
            }
        }
    }

    // Méthodes
    public void life(){
        while(true){
            this.ObserveEnvironmentWithAllMySensors();
            Console.WriteLine("\n\nRobot position :" + (this.PositionX+1) + " " + (this.PositionY+1)+"\n");
            this.myEnvironment.print();
            //this.PrintStates();
            this.ChooseSequenceOfAction();
            this.JustDoIt();
            Thread.Sleep(2000);
        }
    }

    public void ObserveEnvironmentWithAllMySensors(){
        int i = 0;
        int j = 0;
        foreach (var s in this.mySensors){
            this.states[i][j] = s.returnMyState();
            if(j == Constants.DIMENSION-1){
                j=0;
                i++;
            }else{
                j++;
            }
        }
    }

    public void ChooseSequenceOfAction(){

        // Non Informé
        Tree MyTree = new Tree(this);
        Node? Solution = MyTree.TreeSearch();    
        if(Solution != null){
            setActions(Solution.GenerateSequence());
        }else{
            Console.WriteLine("No solution finded");
        }
        // Informé
        
    }
    public void JustDoIt(){
        while(this.actions.Count > 0){
            string CurrentAction = this.getNextAction();
            if(CurrentAction == Constants.GOUP){
                this.myEffector.goUp();
            }
            else if(CurrentAction == Constants.GODOWN){
                this.myEffector.goDown();
            }
            else if(CurrentAction == Constants.GORIGHT){
                this.myEffector.goToTheRight();
            }
            else if(CurrentAction == Constants.GOLEFT){
                this.myEffector.goToTheLeft();
            }
            else if(CurrentAction == Constants.ASPIRE){
                this.myEffector.aspire();
            }
            else if(CurrentAction == Constants.CATCHJEWEL){
                this.myEffector.catchJewel();
            }
        }
    }

    public void PrintStates(){
        Console.WriteLine();
        for (int i = 0; i < Constants.DIMENSION; i++)
        {
            for(int j = 0; j < Constants.DIMENSION; j++){
                Console.WriteLine(this.states[i][j]);
            }
        }
    }
    // Getters
    public int getElectricity(){ return this.Electricity; }
    public int getPositionX(){ return this.PositionX; }
    public int getPositionY(){ return this.PositionY; }
    public int[][] getStates(){ return this.states; }
    public string getNextAction() { return this.actions.Pop(); }

    // Setters
    public void setPositionX(int newPosition){
        this.PositionX = newPosition;
    }
    public void setPositionY(int newPosition){
        this.PositionY = newPosition;
    }
    public void consumeElectricity(){
        this.Electricity++;
    }
    public void setActions(Stack<string> sequenceOfActions){
        this.actions = sequenceOfActions;
    }
}
