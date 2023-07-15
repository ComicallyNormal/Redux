using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using API.Interfaces.Graphs;
namespace API.Problems.NPComplete.NPC_CUT;

class CutGraph : UndirectedGraph
{

   /// <summary>
 /// Takes a String and creates a VertexCoverGraph from it
 /// NOTE: DEPRECATED format, ex: {{a,b,c} : {{a,b} &amp; {b,c}} : 1}
 /// </summary>
 /// <param name="cutInput"> string input</param>
  public CutGraph(string cutInput) : base (cutInput){
        
    }

    //Constructor for standard graph formatted string input.
     /// <summary>
     /// 
     /// </summary>
     /// <param name="cutInput"> Undirected Graph string input
     /// ex. {{1,2,3},{{1,2},{2,3}},0}
     /// </param>
     /// <param name="decoy"></param>
    public CutGraph(string cutInput, bool decoy) : base (cutInput, decoy){
    

    }

  /// <summary>
  /// This is an alternative constructor that would add native custom node support. This would mean that a cutgraph could have an arbitrary 
  /// amount of, and naming convention for, its nodes. 
  /// </summary>
  /// <param name="cutInput"></param>
  /// <param name="usingCutNodes"></param>
  public CutGraph(string cutInput, string usingCutNodes){
        string pattern;
        pattern = @"{{(([\w!]+)(,([\w!]+))*)+},{(\{([\w!]+),([\w!]+)\}(,\{([\w!]+),([\w!]+)\})*)*},\d+}"; //checks for undirected graph format
        Regex reg = new Regex(pattern);
        bool inputIsValid = reg.IsMatch(cutInput);
        if(inputIsValid){
            
            //nodes
            string nodePattern = @"{((([\w!]+))*(([\w!]+),)*)+}";
            MatchCollection nMatches =  Regex.Matches(cutInput,nodePattern);
            string nodeStr = nMatches[0].ToString();
            nodeStr = nodeStr.TrimStart('{');
            nodeStr = nodeStr.TrimEnd('}');
            string[] nodeStringList = nodeStr.Split(',');
            foreach(string nodeName in nodeStringList){
               _nodeList.Add(new CutNode(nodeName,String.Empty));
           }
           //Console.WriteLine(nMatches[0]);
            
            //edges
            string edgePattern = @"{(\{([\w!]+),([\w!]+)\}(,\{([\w!]+),([\w!]+)\})*)*}";
            MatchCollection eMatches = Regex.Matches(cutInput,edgePattern);
            string edgeStr = eMatches[0].ToString();
            //Console.WriteLine(edgeStr);
            string edgePatternInner = @"([\w!]+),([\w!]+)";
            MatchCollection eMatches2 = Regex.Matches(edgeStr,edgePatternInner);
            foreach(Match medge in eMatches2){
                string[] edgeSplit = medge.ToString().Split(',');
                Node n1 = new CutNode(edgeSplit[0],String.Empty);
                Node n2 = new CutNode(edgeSplit[1],String.Empty);
                _edgeList.Add(new Edge(n1,n2));
            }
            
            //end num
            string endNumPatternOuter = @"},\d+}"; //gets the end section of the graph string
            MatchCollection numMatches = Regex.Matches(cutInput,endNumPatternOuter);
            string outerString = numMatches[0].ToString();
            string endNumPatternInner = @"\d+"; //parses out number from end section.
            MatchCollection numMatches2 = Regex.Matches(outerString,endNumPatternInner);
            string innerString = numMatches2[0].ToString();

            int convNum = Int32.Parse(innerString);

            _K = convNum;
          

          foreach(Node n in _nodeList){
            _nodeStringList.Add(n.name);
        }
        foreach(Edge e in _edgeList){
                KeyValuePair<string, string> tempKVP = new KeyValuePair<string, string>(e.source.name, e.target.name);
                _edgesKVP.Add(tempKVP);
            }
 
        }
        else
        {
            Console.WriteLine("NOT VALID INPUT for Regex evaluation! INITIALIZATION FAILED");         
        }

    }


}