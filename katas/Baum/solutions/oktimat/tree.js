
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

  print(layer) {
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
    } else if (value > this.value && this.rightNode) {
      return 'right/' + this.rightNode.find(value);
    } else if (value < this.value && this.leftNode) {
      return 'left/' + this.leftNode.find(value);
    }
    return 'not found';
  }
}

const tree = new TreeNode(30);
tree.add(15)
  .add(60)
  .add(7)
  .add(20)
  .add(40)
  .add(79)
  .add(11);

tree.print(0);
console.log(tree.find(20));
console.log(tree.find(99));