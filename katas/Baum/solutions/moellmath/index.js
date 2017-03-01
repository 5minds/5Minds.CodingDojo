class Tree {
  constructor(value) {
    this.value = value;
    this.left = null;
    this.right = null;
  }

  addValues(values) {
    for (let value of values) {
      this.addValue(value);
    }
  }

  addValue(value) {
    if (value < this.value) {
      if (!this.left) {
        this.left = new Tree(value);
      } else {
        this.left.addValue(value);
      }
    } else if (value > this.value) {
      if (!this.right) {
        this.right = new Tree(value);
      } else {
        this.right.addValue(value);
      }
    } else {
      console.log(`${value} already exists`);
    }
  }

  findValue(value) {
    if (value < this.value) {
      if (!this.left) {
        return ['value not found'];
      }
      
      return ['left'].concat(this.left.findValue(value));
    }
    
    if (value > this.value) {
      if (!this.right) {
        return ['value not found'];
      }

      return ['right'].concat(this.right.findValue(value));
    }

    return [];
  }
}

const tree = new Tree(30);
tree.addValues([15, 20, 7, 60, 11, 40, 79]);
console.log(tree);
const path = tree.findValue(40);
console.log(path);