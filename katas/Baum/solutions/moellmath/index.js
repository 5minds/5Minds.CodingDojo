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
    let currentTree = this;
    let lastTree = null;
    let lastDirectionisLeft = false;

    while (currentTree) {
      lastTree = currentTree;
      if (value < currentTree.value) {
        currentTree = currentTree.left;
        lastDirectionisLeft = true;
      } else if (value > currentTree.value) {
        currentTree = currentTree.right;
        lastDirectionisLeft = false;
      } else {
        console.log(`${value} already exists`);
        return;
      }
    }
    
    if (lastDirectionisLeft) {
      lastTree.left = new Tree(value);
    } else {
      lastTree.right = new Tree(value);
    }
  }

  findValue(value) {
    let currentTree = this;
    let lastDirectionisLeft = false;
    const directions = [];

    while (currentTree) {
      if (value < currentTree.value) {
        currentTree = currentTree.left;
        directions.push('left');
      } else if (value > currentTree.value) {
        currentTree = currentTree.right;
        directions.push('right');
      } else {
        return directions;
      }
    }

    console.log(`${value} not found`);
  }
}

const tree = new Tree(30);
tree.addValues([15, 20, 7, 60, 11, 40, 79]);
const path = tree.findValue(11);
console.log(path);