using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

class RouteDefinition {
    
    private string route;
    private HashSet<string> visited = new HashSet<string>();
    private List<string> fullWay = new List<string>();
    public RouteDefinition(string route) {
        this.route = route;
        this.parseHouses();
    }

    public HashSet<string> getVisited() {
        return this.visited;
    }
    public List<string> getFullWay() {
        return this.fullWay;
    }
    public string getAsJSON() {
        string collector = "{";
        collector += string.Format("  \"visitedCount\": {0},\n",this.fullWay.Count);
        collector += string.Format("  \"uniqueVisitedCount\": {0},\n",this.visited.Count);
        collector += string.Format("  \"completePath\": {0},\n",JsonConvert.SerializeObject(this.fullWay));
        collector += string.Format("  \"uniqueVisits\": {0}\n",JsonConvert.SerializeObject(this.visited));
        collector += "}";

        return collector;
    }

    public void parseHouses() {
        
        string[] steps = Regex.Split(this.route, string.Empty);
        int[] coords = new int[2]{0,0};

        this.visited.Add(string.Format("{0}:{1}",coords[0],coords[1]));
        this.fullWay.Add(string.Format("{0}:{1}",coords[0],coords[1]));
        foreach (var step in steps)
        {
            coords = this.newCoords(step, coords);
            this.visited.Add(string.Format("{0}:{1}",coords[0],coords[1]));
            this.fullWay.Add(string.Format("{0}:{1}",coords[0],coords[1]));
        }
        
    }
    
    private int[] newCoords(string movement, int[] currentCoords) {
        int[] newCoords = currentCoords;
        switch(movement) {
            case "^": 
                newCoords[1]+=1;
                return newCoords;
            case ">":
                newCoords[0]+=1;
                return newCoords;
            case "v":
                newCoords[1]-=1;
                return newCoords;
            case "<":
                newCoords[0]-=1;
                return newCoords;
            default:
                return currentCoords;

        }
    }
}