//This API Node is used when we need to inject additional attributes into a node for a visualization request.
// For example, a node class naturaly only has the name attribute, but a CLique node needs a name, and clique attribute, and a vertexcover node needs a name and
// cover attribute. Rather than build custom nodes for every graph object that have attributes that are only used in visualizing, we can build nodes that are
// in the correct json format opon serialization by having generic attributes.
//Author: Alex Diviney

namespace API.Interfaces.JSON_Objects.Graphs;

class API_Node_Programmable_Small{
    private string _name;
    private string _attribute1;
    private string _attribute2;
    private string _attribute3;

    public API_Node_Programmable_Small(){
        this._name = "APINODE";
        this._attribute1 = "";
        this._attribute2 = "";
        this._attribute3 = "";

    }

    public API_Node_Programmable_Small(string nm,string attr1="",string attr2="", string attr3=""){
        _name = nm;
        _attribute1 = attr1;
        _attribute2 = attr2;
        _attribute3 = attr3;
    }
    
    public string name{
        get{
            return _name;
        }
    }
    public string attribute1{
        get{
            return _attribute1;
        }
        set{
        _attribute1 = value;
        }
    }
    public string attribute2{
        get{
            return _attribute2;
        }
        set{
            _attribute2 = value;
        }
    }
    public string attribute3{
        get{
            return _attribute3;
        }
        set{
            _attribute3 = value;
        }
    }
    
}