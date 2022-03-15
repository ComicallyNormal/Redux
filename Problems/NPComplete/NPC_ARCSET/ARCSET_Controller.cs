using Microsoft.AspNetCore.Mvc;
using API.Problems.NPComplete.NPC_ARCSET;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using API.Problems.NPComplete.NPC_ARCSET.Verifiers;
using API.Problems.NPComplete.NPC_ARCSET.Solvers;

namespace API.Problems.NPComplete.NPC_ARCSET;

[ApiController]
[Route("[controller]")]
public class ARCSETGenericController : ControllerBase {

    [HttpGet]
    public String getDefault() {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(new ARCSET(), options);
        return jsonString;
    }

    [HttpGet("{instance}")]
    public String getInstance() {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(new ARCSET(), options);
        return jsonString;
    }
}

[ApiController]
[Route("[controller]")]
public class ArcsetVerifierController : ControllerBase {

      [HttpGet]
    public String getInstance([FromQuery]string certificate, [FromQuery]string problemInstance) {
        var options = new JsonSerializerOptions { WriteIndented = true };
        ARCSET ARCSETProblem = new ARCSET(problemInstance);
        AlexArcsetVerifier verifier = new AlexArcsetVerifier();
        Boolean response = verifier.verify(ARCSETProblem,certificate);
        // Send back to API user
        string jsonString = JsonSerializer.Serialize(response.ToString(), options);
        return jsonString;
    }

}

[ApiController]
[Route("[controller]")]
public class ArcsetSolverController : ControllerBase {

      [HttpGet]
    public String getInstance([FromQuery]string problemInstance) {
        var options = new JsonSerializerOptions { WriteIndented = true };
        ARCSET ARCSETProblem = new ARCSET(problemInstance);
        AlexNaiveSolver solver = new AlexNaiveSolver();
        string graphSolvedInstance = solver.solve(ARCSETProblem);
        string prettySolvedInstance = solver.prettySolve(ARCSETProblem);
        string[] totalSolvedInstance  = new string[2];
        totalSolvedInstance[0] = graphSolvedInstance;
        totalSolvedInstance[1] =  prettySolvedInstance;
        //Boolean response = verifier.verify(ARCSETProblem,certificate);
        // Send back to API user
        string jsonString = JsonSerializer.Serialize(totalSolvedInstance, options);
        return jsonString;
    }

}

[ApiController]
[Route("[controller]")]
public class ArcsetReductionController : ControllerBase {

      [HttpGet]
    public String getInstance([FromQuery]string problemInstance) {
 
        var options = new JsonSerializerOptions { WriteIndented = true };

    
        UndirectedGraph UG = new UndirectedGraph(problemInstance);
        string reduction = UG.reduction();
        //Boolean response = verifier.verify(ARCSETProblem,certificate);
        // Send back to API user
        string jsonString = JsonSerializer.Serialize(reduction, options);
        return jsonString;
    }
}


