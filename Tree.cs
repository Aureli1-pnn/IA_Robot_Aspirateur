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
    public Node? TreeSearch(){

        Console.WriteLine("\nStarting tree Search");

        Queue<Node> MyQueue = new Queue<Node>();
        Node CurrentNode;
        MyQueue.Enqueue(this.InitialNode);

        while(MyQueue.Count > 0){
            //Console.WriteLine("MyStack count : " + MyStack.Count);
            CurrentNode = MyQueue.Dequeue();
            if(CurrentNode.GoalTest()){
                return CurrentNode;
            }
            else{
                MyQueue = InsertAll(MyQueue, CurrentNode.Expand());
            }
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
}