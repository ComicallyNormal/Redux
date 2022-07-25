//Edge.cs
//This class is used for the creation of Edge objects that can then be used to create a graph. It is composed of two Nodes.


using System;
using System.Collections.Generic;
namespace API.Interfaces.Graphs;
class Edge{

//Fields
private Node _source;
private Node _target;

public Edge(){
_source = new Node();
_target = new Node();
}
public Edge(Node n1,Node n2){
    _source = n1;
    _target = n2;
}

public Node source{
    get{
        return _source;
    }
    set{
        _source = value;
    }
}

public Node target{
    get{
        return _target;
    }
    set{
        _target = value;
    }
}

public override string ToString(){
return source.name+","+_target.name;
}

public string undirectedString(){
    return "{"+source.name+","+_target.name+"}";
}
public string directedString(){
    return "("+source.name+","+_target.name+")";
}
public KeyValuePair<string,string> toKVP(){
    KeyValuePair<string,string> asKVP = new KeyValuePair<string, string>(source.name,target.name);
    return asKVP;
}

}