class Tree {
  constructor(value) {
    this.value = value;
    this.left = null;
    this.right = null;
  }

  addLeft(value) {
    this.left = new Tree(value);
    return this.left;
  }

  addRight(value) {
    this.right = new Tree(value);
    return this.right;
  }
}

const tree = new Tree(30)
tree.addLeft(15).addLeft(7);
console.log(tree);