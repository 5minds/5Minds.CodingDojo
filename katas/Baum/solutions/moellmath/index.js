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
        return this.left = new Tree(value);
      } 
      
      return this.left.addValue(value);
    } 
    
    if (value > this.value) {
      if (!this.right) {
        return this.right = new Tree(value);
      }

      return this.right.addValue(value);
    }

    console.log(`${value} already exists`);
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

  print() {
    if (this.left) {
      this.left.print();
    }

    console.log(this.value);

    if (this.right) {
      this.right.print();
    }
  }
}

const tree = new Tree(30);
tree.addValues([15, 20, 11, 7, 60, 11, 40, 79]);
console.log(tree);
const path = tree.findValue(11);
console.log(path);
tree.print();