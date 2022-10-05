using System.Collections;

public class Tree{

    // Attributes
    private Node InitialNode;
    private Robot Agent;

    // Constructor
    public Tree(Robot Agent){

        this.Agent = Agent;

        this.InitialNode = new Node(1, 
                                    Constants.DONOTHING, 
                                    this.Agent.getPositionX(), 
                                    this.Agent.getPositionY(),
                                    this.Agent.getStates(), 
                                    null);
    }

    // Methods
    public Node? TreeSearchBFS(){

        Console.WriteLine("\nStarting Tree Search with Breadth First Search");

        Queue<Node> MyQueue = new Queue<Node>();
        Node CurrentNode;
        MyQueue.Enqueue(this.InitialNode);
        while(MyQueue.Count > 0){
            CurrentNode = MyQueue.Dequeue();
            if(CurrentNode.GoalTest()){
                return CurrentNode;
            }
            MyQueue = InsertAll(MyQueue, CurrentNode.Expand());
        }

        return null;
    }

    public Node? TreeSearchGreedy(){
        
        Console.WriteLine("\nStarting Tree Search with Greedy Search Algorithm");

        PriorityQueue<Node, int> MyQueue = new PriorityQueue<Node, int>();
        Node CurrentNode;
        MyQueue.Enqueue(this.InitialNode, this.InitialNode.CalculHeuristic());
        while(MyQueue.Count > 0){
            CurrentNode = MyQueue.Dequeue();
            if(CurrentNode.GoalTest()){
                return CurrentNode;
            }
            MyQueue = InsertAllGreedy(MyQueue, CurrentNode.Expand());
        }

        return null;
    }
    public Queue<Node> InsertAll(Queue<Node> MyQueue, Node[] NewNodes){

        for (int i = 0; i < 6; i++)
        {
            if(NewNodes[i] != null){
                MyQueue.Enqueue(NewNodes[i]);
            }
        }

        return MyQueue;
    }
    public PriorityQueue<Node, int> InsertAllGreedy(PriorityQueue<Node, int> MyQueue, Node[] NewNodes){

        for (int i = 0; i < 6; i++)
        {
            if(NewNodes[i] != null){
                int priority = NewNodes[i].CalculHeuristic();
                MyQueue.Enqueue(NewNodes[i], priority);
            }
        }

        return MyQueue;
    }
}