'use strict';
module.exports = class Graph {
  constructor(){
    this.nodes = [];
    this.nodesAmount = 0;
  }

  findNodeByValue(value){
    this.nodes.forEach((node, index) => {
      if(node.value === value){
        return node;
      }
    });
    return null;
  }

  addEdge(firstNodeValue, secondNodeValue){
    let firstNode = this.findNodeByValue(firstNodeValue);
    let secondNode = this.findNodeByValue(secondNodeValue);
    if(firstNode === null){
      firstNode= new Node(this.nodesAmount, firstNodeValue);
      this.nodes.push(firstNode);
      this.nodesAmount++;
    }
    if(secondNode === null){
      secondNode = new Node(this.nodesAmount, secondNodeValue);
      this.nodes.push(secondNode);
      this.nodesAmount++;
    }

    let edge = new Edge(firstNode, secondNode);
    firstNode.addEdge(edge);
    secondNode.addEdge(edge);
  }
}

class Node {
  constructor(id, value){
    this.edges = [];
    this.edgesAmount = 0;
    this.id = id;
    this.value = value;
  }

  addEdge(edge){
    this.edges.push(edge);
    this.edgesAmount++;
  }
}

class Edge{
  constructor(firstNode, secondNode){
    this.nodes = [firstNode, secondNode];
  }
}