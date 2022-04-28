using API.Interfaces;

namespace API.Problems.NPComplete.NPC_KNAPSACK.Solvers;
class GarrettKnapsackSolver : ISolver {

    // --- Fields ---
    private string _solverName = "Generic Solver";
    private string _solverDefinition = "This solver is for the 0-1 Knapsack problem";
    private string _source = "This person ____";

    private string _complexity = "complexity of this problem depends on size of input values. When inputs are binary it's complexity is exponential.";

    // --- Properties ---
    public string solverName {
        get {
            return _solverName;
        }
    }
    public string solverDefinition {
        get {
            return _solverDefinition;
        }
    }
    public string source {
        get {
            return _source;
        }
    }
    public string complexity {
        get {
            return _complexity;
        }
    }
    // --- Methods Including Constructors ---
    //solver for 0-1 knapsack problem
    public int solve(KNAPSACK knapsack) {
        // returns the maximum value achievable given the the weight constraints on the given knapsack.
        
        List<KeyValuePair<String, String>> allitems = knapsack.items; 
        int Capacity = knapsack.W;



        int[,] matrix = new int[allitems.Count +1 , Capacity + 1];
        //iterate through each item
        for (int i=0; i < allitems.Count + 1; i++){
            //iterate through each of the different weight values starting at 0 until W
            for(int j=0; j<Capacity +1; j++){
                //initializing all matrix[0,j] and matrix[i,0] to 0
                if(i==0 || j==0){
                    matrix[i,j] = 0;
                    //break to the next iteration
                    continue;
                }
                var currentItem = allitems[i-1];

                if (Int32.Parse(currentItem.Key) > j){
                    matrix[i,j] = matrix[i-1,j];
                }
                else {
                    matrix[i,j] = Math.Max(Int32.Parse(currentItem.Value) + matrix[i-1,j- Int32.Parse(currentItem.Key)], matrix[i-1,j]);

                }
            }
        }
        return  matrix[allitems.Count, Capacity];
    }

}