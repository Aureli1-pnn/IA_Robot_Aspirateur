public class Robot{

    // Attributes 
    private int Electricity;
    private int PositionX;
    private int PositionY;
    private Stack<string> Intentions;
    private int[][] states;
    private List<Sensor> mySensors;
    private Environment myEnvironment;
    private Effector myEffector;

    // Constructor
    public Robot(Environment myEnvironment){

        // Random position
        Random rd = new Random();
        this.PositionX = rd.Next(0, Constants.DIMENSION);
        this.PositionY = rd.Next(0, Constants.DIMENSION);

        // In the beginning there is no consumption of electricity
        this.Electricity = 0;

        // Agent must have an environment 
        this.myEnvironment = myEnvironment;

        // Initialisation of his effector and sensors(one per room of environment)
        this.myEffector = new Effector(myEnvironment, this);
        this.mySensors = new List<Sensor>();
        for (int i = 0; i < Constants.DIMENSION; i++)
        {
            for (int j = 0; j < Constants.DIMENSION; j++)
            {
                Sensor mySensor = new Sensor(j, i, this, myEnvironment);
                this.mySensors.Add(mySensor);
            }
        }

        // Stack of his Intentions
        this.Intentions = new Stack<string>();

        // Initialisation of his Believe of environment
        this.states = new int[Constants.DIMENSION][];
        for (int i = 0; i < Constants.DIMENSION; i++)
        {
            this.states[i] = new int[Constants.DIMENSION];
            for (int j = 0; j < Constants.DIMENSION; j++)
            {
                this.states[i][j] = 0;
            }
        }
    }

    // Méthodes
    public void life(){
        while(true){
            this.ObserveEnvironmentWithAllMySensors();
            Console.WriteLine("\n///////////////////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("///////////////////////Etat de l'environnement enregistré par le robot/////////////////////////");
            this.myEnvironment.print(this.PositionX, this.PositionY);   // Print the environment at the beginning of the sequence
            this.ChooseSequenceOfAction();
            this.JustDoIt();
            Console.WriteLine("Performance measure : " + myEnvironment.CalculPerformanceMeasure(this.getElectricity()));
            Thread.Sleep(1000);
        }   
    }

    // Update agent's perception of his environment using his sensors
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

    // Determinate next sequence of intention
    public void ChooseSequenceOfAction(){

        // Non Informé
        BreadthFirstSearch();

        // Informé
        //GreedySearch();
        
    }
    
    // Execute sequence 
    public void JustDoIt(){
        int i = 1;
        while(this.Intentions.Count > 0){
            string CurrentAction = this.getNextAction();
            Console.WriteLine("Action n°" + i + " : " + CurrentAction);
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
            i++;
            this.myEnvironment.print(this.PositionX, this.PositionY);
            Console.WriteLine();
            Thread.Sleep(1000);
        }
    }

    // Agent using BFS for searching a optimal solution
    public void BreadthFirstSearch(){
        Tree MyTree = new Tree(this);
        Node? Solution = MyTree.TreeSearchBFS();    
        if(Solution != null){ 
            setActions(Solution.GenerateSequence());
        }else{
            Console.WriteLine("No solution finded");
        }
    }

    // Agent using Greedy Search for searching a solution
    public void GreedySearch(){
        Tree MyTree = new Tree(this);
        Node? Solution = MyTree.TreeSearchGreedy();
        if(Solution != null){
            setActions(Solution.GenerateSequence());
        }else{
            Console.WriteLine("No solution finded");
        }
    }

    // Getters
    public int getElectricity(){ return this.Electricity; }
    public int getPositionX(){ return this.PositionX; }
    public int getPositionY(){ return this.PositionY; }
    public int[][] getStates(){ return this.states; }
    public string getNextAction() { return this.Intentions.Pop(); }

    // Setters
    public void setPositionX(int newPosition){ this.PositionX = newPosition;}
    public void setPositionY(int newPosition){ this.PositionY = newPosition;}
    public void consumeElectricity(){ this.Electricity++;}
    public void setActions(Stack<string> sequenceOfActions){ 
        if(Constants.NBOFACTION == null){
            this.Intentions = sequenceOfActions;
        }else{
            Stack<string> revIntentions = new Stack<string>();
            Stack<string> newIntentions = new Stack<string>();
            int i=1;
            while(i <= Constants.NBOFACTION && sequenceOfActions.Count >= 1){
                revIntentions.Push(sequenceOfActions.Pop());
                i++;
            }
            i=1;
            while(i <= Constants.NBOFACTION && revIntentions.Count >= 1){
                newIntentions.Push(revIntentions.Pop());
                i++;
            }
            this.Intentions = newIntentions;
        }
    }
}
