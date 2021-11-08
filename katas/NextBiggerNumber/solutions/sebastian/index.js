Array.prototype.swap = function (x,y) {
  let b = this[x];
  this[x] = this[y];
  this[y] = b;
  return this;
}

class NextBiggerNumber {
  constructor() {
    this.properties = {
      getAllNumber: [],
      currentNumber:0,
      outputNoNumber: "-1"
    }
  }

  resetValues() {
    this.properties.getAllNumber = [];
    this.currentNumber = 0;
  }

  nextBigger(number) {
    this.resetValues();

    this.properties.getAllNumber.push(number);
    this.properties.currentNumber = number;
    this.digitSwitcher(number);
    //this.handleNumber(number);
    this.getNextBiggerNumber();
  }

  digitSwitcher(number) {
    
    let a = number.toString()[number.toString().length-1];
    let b = number.toString()[0];
    let newNumber = "" + a + b;
    this.properties.getAllNumber.push(parseInt(newNumber));
  }

  handleNumber(number) {
    let numberInString = number.toString();
    let numberCount = numberInString.length;
    let arrayNumbers = numberInString.split("");
    console.log("numberCount");
    console.log(numberCount);
    let testCount = 3;
    let testCount2 = 2;

    for (let i=0;i<testCount;i++) {
      let newString = i;
      console.log("arrayNumbers[i]");
      console.log("i= " + i);

      for (let j=0;j<testCount2;j++) {
        console.log("arrayNumbers[i]");
        console.log(" j= " + j);
       // console.log("i= " + i + " j= " + j);
      }
    }
 /*    
    console.log(numberInString.split(""));
    console.log(numberInString.split("").swap(2,1).join(""));

    let tempNumber = numberInString.split("").swap(2,1).join("");
    console.log(tempNumber.split("").swap(1,0).join(""));

    console.log(numberInString.split("").swap(0,1).join(""));
    console.log(numberInString.split("").swap(0,2).join(""));
    console.log(numberInString.split("").swap(0,3).join("")); */
   
    for (let i=(numberCount-1); i >=0;i--) {
    }
  }

  getNextBiggerNumber() {

    let allValues = this.properties.getAllNumber.sort();
    let getPositionOfNumber = allValues.indexOf(this.properties.currentNumber);

    if (getPositionOfNumber >= 0 && allValues[getPositionOfNumber+1] > 0) {
      console.log("Result= ");
      console.log(allValues[getPositionOfNumber+1]);
      return allValues[getPositionOfNumber+1];
    } else {
      console.log("Result= ");
      console.log(this.properties.outputNoNumber);
      return this.properties.outputNoNumber;
    }
  }
}
var nextBiggerNumber = new NextBiggerNumber();
nextBiggerNumber.nextBigger(12);
//nextBiggerNumber.nextBigger(513);