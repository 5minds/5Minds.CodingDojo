var Graph = require("./graph.js");

var graph = new Graph();

function createGraph(){
  graph.addEdge(1, 2);
  graph.addEdge(1, 4);
  graph.addEdge(4, 3);
  graph.addEdge(4, 5);
  graph.addEdge(5, 8);
  graph.addEdge(8, 6);
  graph.addEdge(6, 7);
  graph.addEdge(7, 3);
  logGraph();
}

function logGraph(){
  graph.nodes.forEach((node) => {
    console.log(node.value);
    node.edges.forEach((edge) => {
      edge.nodes.forEach((edgeNode) => {
        if(edgeNode.value !== node.value){
          console.log(`-> ${edgeNode.value}`)
        }
      })
    });
  });
}

createGraph();
