
using System;
using System.Collections.Generic;
namespace API.Problems.NPComplete.NPC_VERTEXCOVER;

class Node:ICloneable{

//Fields
private string _name;
private int _preVisit;
private int _postVisit;

private bool _visited;

//Constructors
public Node(){
_name = "DEFAULT";
_preVisit = 0;
_postVisit = 0;
_visited = false;


}
public Node(string nm){
    _name = nm;
    _preVisit = 0;
    _postVisit = 0;
    _visited = false;
   
}

//getters and setters
public string name {
        get {
            return _name;
        }
        set {
            _name = value;
        }
    }
public int preVisit {
    get{
        return _preVisit;
    }
    set{
        _preVisit = value;
    }
}
public int postVisit {
    get{
        return _postVisit;
    }
    set{
        _postVisit = value;
    }
}
public bool visited {
    get{
        return _visited;
    }
    set{
        _visited = value;
    }
}


//May want to change to include visit values.
public override string ToString(){

return _name + " " + _preVisit + " " + _postVisit;
}

public object Clone(){
    Node clonedNode = new Node(this._name);
    clonedNode._preVisit = this._preVisit;
    clonedNode._postVisit = this._postVisit;
    clonedNode._visited = this._visited;
    return clonedNode;
}

}