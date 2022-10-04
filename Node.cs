public class Node{

    // Attributes
    private int Depth;
    private bool IsLeaf;
    private string Action;
    private int RobotPositionX;
    private int RobotPositionY;
    private int[][] State;
    private Node? Father; 
    private Node[]? Children;
    private List<Tuple<int, int>> AlreadyVisitRoom;

    // Constructors
    // Initial node constructor
    public Node(int Depth, string Action, int X, int Y, int[][] MyState, Node? Father){

        this.Depth = Depth;
        this.Action = Action;
        this.State = new int[Constants.DIMENSION][];
        this.Father = Father;
        this.IsLeaf = true;
        this.RobotPositionX = X;
        this.RobotPositionY = Y;
    
        for (int i = 0; i < Constants.DIMENSION; i++)
        {
            this.State[i] = new int[Constants.DIMENSION];
            for (int j = 0; j < Constants.DIMENSION; j++)
            {
                this.State[i][j] = MyState[i][j];
            }
        }

        this.AlreadyVisitRoom = new List<Tuple<int, int>>();

        Tuple<int,int> localisation = new Tuple<int, int>(X, Y);
        this.AlreadyVisitRoom.Add(localisation);
    }

    // Others nodes constructor
    public Node(int Depth, string Action, int X, int Y, int[][] MyState, Node? Father, List<Tuple<int, int>> visited, bool Imoved){

        this.Depth = Depth;
        this.Action = Action;
        this.State = new int[Constants.DIMENSION][];
        this.Father = Father;
        this.IsLeaf = true;
        this.RobotPositionX = X;
        this.RobotPositionY = Y;
    
        for (int i = 0; i < Constants.DIMENSION; i++)
        {
            this.State[i] = new int[Constants.DIMENSION];
            for (int j = 0; j < Constants.DIMENSION; j++)
            {
                this.State[i][j] = MyState[i][j];
            }
        }

        this.AlreadyVisitRoom = new List<Tuple<int, int>>();
        foreach (var tuple in visited)
        {
            this.AlreadyVisitRoom.Add(tuple);
        }
        if(Imoved){
            Tuple<int, int> localisation = new Tuple<int, int>(Father.getPositionX(), Father.getPositionY());
            this.AlreadyVisitRoom.Add(localisation);
        }
    }

    // Methods
    public Node[] Expand(){

        this.Children = new Node[6];

        // Child with action aspire
        if(this.State[this.RobotPositionX][this.RobotPositionY]-1 >= 0){
            int[][] newState = new int[Constants.DIMENSION][];
            for (int i = 0; i < Constants.DIMENSION; i++)
            {
                newState[i] = new int[Constants.DIMENSION];
                for (int j = 0; j < Constants.DIMENSION; j++)
                {
                    newState[i][j] = this.State[i][j];
                }
            }
            newState[this.RobotPositionX][this.RobotPositionY] -= 1;

            this.IsLeaf = false;
            this.Children[0] = new Node(this.Depth+1, 
                                        Constants.ASPIRE, 
                                        this.RobotPositionX, 
                                        this.RobotPositionY, 
                                        newState, 
                                        this, 
                                        this.AlreadyVisitRoom, 
                                        false);
        }

        // Child with action catchjewel
        if(this.State[this.RobotPositionX][this.RobotPositionY]-10 >= 0){
            int[][] newState = new int[Constants.DIMENSION][];
            for (int i = 0; i < Constants.DIMENSION; i++)
            {
                newState[i] = new int[Constants.DIMENSION];
                for (int j = 0; j < Constants.DIMENSION; j++)
                {
                    newState[i][j] = this.State[i][j];
                }
            }
            newState[this.RobotPositionX][this.RobotPositionY] -= 10;

            this.IsLeaf = false;
            this.Children[1] = new Node(this.Depth+1, 
                                        Constants.CATCHJEWEL, 
                                        this.RobotPositionX, 
                                        this.RobotPositionY, 
                                        newState, 
                                        this, 
                                        this.AlreadyVisitRoom, 
                                        false);
        }

        // Child with action GoUp
        if(!doIHaveVisitedThisRoom(this.getPositionX(), this.getPositionY()-1) && roomExist(this.getPositionX(), this.getPositionY()-1)){
            this.IsLeaf = false;
            this.Children[2] = new Node(this.Depth+1, 
                                        Constants.GOUP, 
                                        this.RobotPositionX, 
                                        this.RobotPositionY - 1, 
                                        this.State, 
                                        this,
                                        this.AlreadyVisitRoom, 
                                        true);
        }

        // Child with action GoDown
        if(!doIHaveVisitedThisRoom(this.getPositionX(), this.getPositionY()+1) && roomExist(this.getPositionX(), this.getPositionY()+1)){
            this.IsLeaf = false;
            this.Children[3] = new Node(this.Depth+1, 
                                        Constants.GODOWN, 
                                        this.RobotPositionX, 
                                        this.RobotPositionY + 1, 
                                        this.State, 
                                        this,
                                        this.AlreadyVisitRoom, 
                                        true);
        }

        // Child with action GoRight
        if(!doIHaveVisitedThisRoom(this.getPositionX()+1, this.getPositionY()) && roomExist(this.getPositionX()+1, this.getPositionY())){
            this.IsLeaf = false;
            this.Children[4] = new Node(this.Depth+1, 
                                        Constants.GORIGHT, 
                                        this.RobotPositionX + 1, 
                                        this.RobotPositionY, 
                                        this.State, 
                                        this,
                                        this.AlreadyVisitRoom, 
                                        true);
        }

        // Child with action GoLeft
        if(!doIHaveVisitedThisRoom(this.getPositionX()-1, this.getPositionY()) && roomExist(this.getPositionX()-1, this.getPositionY())){
            this.IsLeaf = false;
            this.Children[5] = new Node(this.Depth+1, 
                                        Constants.GOLEFT, 
                                        this.RobotPositionX - 1, 
                                        this.RobotPositionY, 
                                        this.State, 
                                        this,
                                        this.AlreadyVisitRoom, 
                                        true);
        }

        return this.Children;
    }

    // Goal is obtain a clean state
    public bool GoalTest(){
        for (int i = 0; i < Constants.DIMENSION; i++)
        {
            for (int j = 0; j < Constants.DIMENSION; j++)
            {
                if(this.State[i][j] != 0){
                    return false;
                }
            }
        }
        return true;
    }

    public bool doIHaveVisitedThisRoom(int X, int Y){
        foreach (var tuple in this.AlreadyVisitRoom)
        {
            if(tuple.Item1 == X && tuple.Item2 == Y){
                return true;
            }
        }
        return false;
    }

    public bool roomExist(int X, int Y){
        //Console.WriteLine("X:" + X +"  Y :" + Y);
        if(X >= 0 && X < Constants.DIMENSION && Y >= 0 && Y < Constants.DIMENSION){
            return true;
        }
        else{
            return false;
        }
    }

    // Return sequence
    public Stack<string> GenerateSequence(){

        Stack<string> Sequence = new Stack<string>();
        
        Node? CurrentNode = this;
        while(CurrentNode.getDepth() > 1){
            Sequence.Push(CurrentNode.GetAction());
            CurrentNode = CurrentNode.getFather();
        }
        printSequence(Sequence);

        return Sequence;

    }

    // Print sequence
    public void printSequence(Stack<string> Sequence){
        int i = 1;
        foreach (var item in Sequence)
        {
            Console.WriteLine(i + " : " + item);
            i++;
        }
        Console.WriteLine();
    }

    // Getters 
    public string GetAction(){
        return this.Action;
    }
    public Node? getFather(){
        return this.Father;
    }
    public bool AmIALeaf(){
        return this.IsLeaf;
    }
    public int getPositionX(){
        return this.RobotPositionX;
    }
    public int getPositionY(){
        return this.RobotPositionY;
    }
    public int getDepth(){
        return this.Depth;
    }
}