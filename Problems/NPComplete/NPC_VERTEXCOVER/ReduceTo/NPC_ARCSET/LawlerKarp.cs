using API.Interfaces;
using API.Problems.NPComplete.NPC_ARCSET;
using API.Problems.NPComplete.NPC_VERTEXCOVER;
using System.Text.Json;
using System.Text.Json.Serialization;
using API.Interfaces.Graphs;

namespace API.Problems.NPComplete.NPC_VERTEXCOVER.ReduceTo.NPC_ARCSET;

class LawlerKarp : IReduction<VERTEXCOVER, ARCSET> {

  

    // --- Fields ---
    private string _reductionDefinition = @"This Reduction is an implementation of Lawler and Karp's reduction as laid out in Karp's 21 NP_Complete Problems. 
                                            It takes an instance of an undirected graph (specifically an instance of VERTEXCOVER) and returns an instance of ARCSET (ie. a Directed Graph)
                                            Specifically, a reduction follows the following algorithm: 
                                            For an undirected graph H: Where H is made up of <V,E>
                                            Convert the undirected edges in E to pairs of directed edges. So an undirected edge {{A,B}} turns into the directed pair of edges {(A,B),(B,A)} 
                                            Then turn every node into a pair of nodes denoted by 0 and 1. So a node 'A' turns into the two nodes '<A,0>' and '<A,1>'
                                            Now looks at the pairs of edges in E and maps from 1 to 0. So an edge (A,B) turns into (<A,1>, <B,0>) and edge (B,A) becomes (<B,1>,<A,0>)
                                            Then add directed edges from every 0 node 'u' to 1 node 'u'. ie. creates edges from <A,0> to <A,1>, <B,0> to <B,1> … <Z,0> to <Z,1>
                                            Now the algorithm has created an ARCSET instance (in other words, a Digraph). ";
    private string _source = "http://cgi.di.uoa.gr/~sgk/teaching/grad/handouts/karp.pdf"; //Alex NOTE: Change later to real citation.
    private string[] _contributers = { "Daniel Igbokwe"};
    private VERTEXCOVER _reductionFrom;
    private ARCSET _reductionTo;
    private Dictionary<Object,Object> _gadgetMap = new Dictionary<Object,Object>();


    // --- Properties ---
    public string reductionDefinition {
        get {
            return _reductionDefinition;
        }
    }
    public string source {
        get {
            return _source;
        }
    }
     public string[] contributers{
        get{
            return _contributers;
        }
    }
    public Dictionary<Object,Object> gadgetMap {
        get{
            return _gadgetMap;
        }
        set{
            _gadgetMap = value;
        }
    }
    public VERTEXCOVER reductionFrom {
        get {
            return _reductionFrom;
        }
        set {
            _reductionFrom = value;
        }
    }
    public ARCSET reductionTo {
        get {
            return _reductionTo;
        }
        set {
            _reductionTo = value;
        }
    }

    // --- Methods Including Constructors ---

    public LawlerKarp(){

        _reductionFrom = new VERTEXCOVER();
        _reductionTo = new ARCSET();
    }
    public LawlerKarp(VERTEXCOVER from) {
         _reductionFrom = from;
        _reductionTo = reduce();
        var options = new JsonSerializerOptions { WriteIndented = true };
        String jsonString = JsonSerializer.Serialize(reduce(),options);
        Console.Write(jsonString);
        
    }
    /// <summary>
    ///  Uses the VertexCover object's reduction utility to convert to a Arcset Graph and returns that equivalent object.
    /// </summary>
    /// <returns>
    /// An Arcset Object
    /// </returns>
    public ARCSET reduce() {
        VertexCoverGraph ug = new VertexCoverGraph(_reductionFrom.instance,true);
        string dgString = ug.reduction();
        //ArcsetGraph dg = new ArcsetGraph(dgString,true);
        ARCSET arcset = new ARCSET(dgString);
        
        return arcset;
    }
}
// return an instance of what you are reducing to