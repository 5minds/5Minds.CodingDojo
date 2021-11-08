class FizzBuzz {
  constructor() {
    this.limit = 100;
    this.allNumber = [];
  }
  start () {

    for(let i=1;i<=this.limit;i++) {

      let result = i;

      if (i%3 == 0 || i.toString().match(3)) {
        result = "Fizz";
      }
      if (i%5 == 0 || i.toString().match(5)) {
        result = "Buzz";
      }
      if (i%3 == 0 && i%5 == 0 || i.toString().match(3) && i.toString().match(5)) {
        result = "FizzBuzz";
      }
      this.allNumber.push(result);
      
    }
    console.log(this.allNumber);
  }
}
const fizzBuzz = new FizzBuzz();
fizzBuzz.start();