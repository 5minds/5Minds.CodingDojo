
class TreeNode {

  constructor(value) {
    this._leftNode = null;
    this._rightNode = null;

    this._value = value;
  }

  get leftNode() {
    return this._leftNode;
  }

  get rightNode() {
    return this._rightNode;
  }

  get value() {
    return this._value;
  }

  static fromList(list) {
    if (list.length == 0) return null;
    let [x, ...xs] = list;
    let tree = new TreeNode(x);
    xs.forEach(value => tree.add(value));

    return tree;
  }

  add(value) {
    if (value > this.value) {
      if (this.rightNode) {
        this._rightNode.add(value);
      } else {
        this._rightNode = new TreeNode(value);
      }
    } else if (value < this.value) {
      if (this.leftNode) {
        this._leftNode.add(value);
      } else {
        this._leftNode = new TreeNode(value);
      }
    } else {
      throw new Error('value already exists');
    }

    return this;
  }

  print(layer = 0) {
    console.log('  '.repeat(layer * 2) + this.value);
    if (this.leftNode) {
      console.log('  '.repeat(layer * 2) + '↙');
      this.leftNode.print(layer + 1);
    }
    if (this.rightNode) {
      console.log('  '.repeat(layer * 2) + '↘');
      this.rightNode.print(layer + 1);
    }
  }

  find(value) {
    if (value === this.value) {
      return value;
    }
    if (value > this.value && this.rightNode) {
      return 'right/' + this.rightNode.find(value);
    }
    if (value < this.value && this.leftNode) {
      return 'left/' + this.leftNode.find(value);
    }
    return 'not found';
  }

  infix() {
    if (this.leftNode) {
      this.leftNode.infix();
    }
    console.log(this.value);
    if (this.rightNode) {
      this.rightNode.infix();
    }
  }

  depth() {
    if (this.leftNode && this.rightNode) {
      return 1 + Math.max(this.leftNode.depth(), this.rightNode.depth());
    }
    if (this.leftNode) {
      return 1 + this.leftNode.depth();
    }
    if (this.rightNode) {
      return 1 + this.rightNode.depth();
    }
    return 1;
  }
}


let tree = new TreeNode(30);
tree.add(15)
  .add(60)
  .add(7)
  .add(20)
  .add(40)
  .add(79)
  .add(11);

tree.print();

tree = TreeNode.fromList([30, 15, 60, 7, 20, 40, 79, 11]);

tree.print();

console.log('\ninfix');
tree.infix();

console.log('\nfind 20');
console.log(tree.find(20));
console.log('\nfind 99');
console.log(tree.find(99));

console.log('\ndepth');
console.log(tree.depth());