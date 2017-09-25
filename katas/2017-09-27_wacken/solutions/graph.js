'use strict';

module.exports = class Graph {
  constructor(){
    this.nodes = [];
  }

  findNodeByValue(value){
    let foundNode = null;
    
    this.nodes.forEach((node) => {
      if(node.value == value){
        foundNode = node;
      }
    });
    return foundNode;
  }

  addEdge(firstNodeValue, secondNodeValue){
    let firstNode = this.findNodeByValue(firstNodeValue);
    let secondNode = this.findNodeByValue(secondNodeValue);

    if(firstNode === null){
      firstNode= new Node(firstNodeValue);
      this.nodes.push(firstNode);
    }
    if(secondNode === null){
      secondNode = new Node(secondNodeValue);
      this.nodes.push(secondNode);
    }

    this.nodes.sort((a, b) => {
      if(a.value >= b.value){
        return 1;
      }else{
        return -1;
      }
    });

    let edge = new Edge(firstNode, secondNode);
    firstNode.addEdge(edge);
    secondNode.addEdge(edge);
  }
}

class Node {
  constructor(value){
    this.edges = [];
    this.value = value;
  }

  addEdge(edge){
    this.edges.push(edge);
  }
}

class Edge{
  constructor(firstNode, secondNode){
    this.nodes = [firstNode, secondNode];
  }
}
