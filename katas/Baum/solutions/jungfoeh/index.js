"use strict";

class Node {
  constructor(value, left, right) {
    this.value = value;
    this.left = left;
    this.right = right;
  }
}

const find = (tree, value, path) => {
  if( typeof path === "undefined" ) path = [];

  if( !tree ) {
    console.log(path.join('')+'???')
    console.log("Noooo, "+value+" nicht gefunden!")
    return null;
  }

  if( value == tree.value ) {
    console.log(path.join('')+tree.value+" (YEEEEES!)")
    return value;
  } else if( value < tree.value ) {
    path.push(tree.value+"  -(left)->  ")
    find(tree.left, value, path)
  } else if( value > tree.value ) {
    path.push(tree.value+"  -(right)->  ")
    find(tree.right, value, path)
  }
}

const collect_values = (tree, memo) => {
  if( typeof memo === "undefined" ) memo = [];

  if( tree ) {
    memo.push(tree.value);
    memo = collect_values(tree.left, memo);
    memo = collect_values(tree.right, memo);
  }

  return memo.sort((a, b) => a - b);
}

const build_tree = (list) => {
  if( list.length == 0 ) return null;

  let value = list.shift();
  let left_list = list.filter((a) => a < value);
  let right_list = list.filter((a) => a >= value);

  return new Node(value, build_tree(left_list), build_tree(right_list));
}

let tree = build_tree([20, 30, 40, 7, 11, 15, 60, 79]);

let tree2 =
  new Node(30,
    new Node(15,
      new Node(7,
        null,
        new Node(11, null, null)
      ),
      new Node(20, null, null)
    ),
    new Node(60,
      new Node(40, null, null),
      new Node(79, null, null)
    )
  );

let number = process.argv[2];
let number2 = process.argv[3];

find(tree, number);
console.log("\n");
find(tree, number2);

console.log("\n");
console.log("values:", collect_values(tree) );
