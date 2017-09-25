'use strict';

const Graph = require("./graph.js");
const Situation = require("./situation.js")

function createGraphSituation1(){
  let graph = new Graph();
  graph.addEdge(1, 4);
  graph.addEdge(1, 2);
  graph.addEdge(2, 3);
  graph.addEdge(2, 4);
  graph.addEdge(2, 8);
  graph.addEdge(3, 4);
  graph.addEdge(3, 8);
  graph.addEdge(4, 8);
  graph.addEdge(4, 5);
  graph.addEdge(5, 6);
  graph.addEdge(5, 7);
  graph.addEdge(6, 7);
  graph.addEdge(6, 8);
  graph.addEdge(7, 8);
  return graph;
}
function createGraphSituation2(){
  let graph = new Graph();
  graph.addEdge(1, 2);
  graph.addEdge(1, 4);
  graph.addEdge(2, 3);
  graph.addEdge(4, 5);
  graph.addEdge(5, 8);
  graph.addEdge(5, 6);
  graph.addEdge(6, 7);
  graph.addEdge(5, 8);
  graph.addEdge(7, 3);
  graph.addEdge(7, 8);
  return graph;
}
function createGraphSituation3(){
  let graph = new Graph();
  graph.addEdge(1, 2);
  graph.addEdge(1, 4);
  graph.addEdge(2, 3);
  graph.addEdge(2, 4);
  graph.addEdge(3, 4);
  graph.addEdge(4, 5);
  graph.addEdge(5, 6);
  graph.addEdge(5, 7);
  graph.addEdge(6, 7);
  graph.addEdge(6, 8);
  graph.addEdge(7, 8);
  return graph;
}
function createGraphSituation4(){
  let graph = new Graph();
  graph.addEdge(1, 2);
  graph.addEdge(1, 4);
  graph.addEdge(2, 3);
  graph.addEdge(2, 4);
  graph.addEdge(2, 8);
  graph.addEdge(3, 4);
  graph.addEdge(4, 8);
  graph.addEdge(5, 6);
  graph.addEdge(5, 7);
  graph.addEdge(7, 8);
  graph.addEdge(8, 6);
  return graph;
}
function createGraphSituation5(){
  let graph = new Graph();
  graph.addEdge(1, 2);
  graph.addEdge(1, 4);
  graph.addEdge(2, 3);
  graph.addEdge(2, 4);
  graph.addEdge(2, 6);
  graph.addEdge(3, 7);
  graph.addEdge(4, 5);
  graph.addEdge(4, 8);
  graph.addEdge(5, 6);
  graph.addEdge(5, 7);
  graph.addEdge(5, 8);
  graph.addEdge(6, 7);
  graph.addEdge(6, 8);
  graph.addEdge(7, 8);
  return graph;
}

function checkAllSituations(){
  let situations = [];
  situations.push(new Situation(createGraphSituation1()));
  situations.push(new Situation(createGraphSituation2()));
  situations.push(new Situation(createGraphSituation3()));
  situations.push(new Situation(createGraphSituation4()));
  situations.push(new Situation(createGraphSituation5()));

  situations.forEach((situation, index) => {
    if(situation.result){
      console.log(`Situation ${index + 1} is working\n`)
    }else{
      console.log(`Situation ${index + 1} is not working!\nThe nodes ${situation.reason}make it impossible.\n`)
    }
  });
}

checkAllSituations();