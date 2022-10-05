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

    // Search in the tree Using BFS Algorithm
    public Node? TreeSearchBFS(){

        Console.WriteLine("\nStarting Tree Search with Breadth First Search");

        Queue<Node> MyQueue = new Queue<Node>();    // initialize an empty queue
        Node CurrentNode;
        MyQueue.Enqueue(this.GetInitialNode());     // put the initial Node of the tree in the queue
        while(MyQueue.Count > 0){                   // while the queue is not empty
            CurrentNode = MyQueue.Dequeue();        // dequeu it 
            if(CurrentNode.GoalTest()){             // if dequeued node is a solution return it
                return CurrentNode;
            }
            MyQueue = InsertAll(MyQueue, CurrentNode.Expand());     // Then Expand it and put new nodes in the tree
        }

        return null;    // only if no solution is finded (error case)
    }

    public Node? TreeSearchGreedy(){
        
        Console.WriteLine("\nStarting Tree Search with Greedy Search Algorithm");

        PriorityQueue<Node, int> MyQueue = new PriorityQueue<Node, int>();          // initialize an empty priority queue
        Node CurrentNode;
        MyQueue.Enqueue(this.GetInitialNode(), this.InitialNode.CalculHeuristic()); // put the initial Node of the tree in the queue
        while(MyQueue.Count > 0){                // while the queue is not empty
            CurrentNode = MyQueue.Dequeue();     // dequeu it and take the node with the better priority
            if(CurrentNode.GoalTest()){          // if dequeued node is a solution return it
                return CurrentNode;
            }
            MyQueue = InsertAllGreedy(MyQueue, CurrentNode.Expand());   // Then Expand it and put new nodes in the tree
        }

        return null;    // only if no solution is finded (error case)
    }

    // Insert all the (non null) nodes created during an expand
    public Queue<Node> InsertAll(Queue<Node> MyQueue, Node[] NewNodes){

        for (int i = 0; i < 6; i++)
        {
            if(NewNodes[i] != null){
                MyQueue.Enqueue(NewNodes[i]);
            }
        }

        return MyQueue;
    }

    // Same but with a priority queue
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

    // Getter
    public Node GetInitialNode(){ return this.InitialNode;}
}