'use strict';

module.exports = class Situation {
  constructor(graph){
    this.graph = graph;
    this.reason = "";
    this.result = this.searchPath();
  }

  searchPath(){
    let pathFound = true;
  
    this.graph.nodes.forEach((node) => {
      if(node.edges.length % 2 !== 0){
        this.reason += `${node.value} `;
        pathFound = false;
      }
    });
    return pathFound;
  }
}