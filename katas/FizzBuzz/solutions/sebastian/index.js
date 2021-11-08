/* * 
* Für Vielfache von 3 gib "Fizz" zurück.  
* Für Vielfache von 5 gib "Buzz" zurück.  
* Für Vielfache von 3 und 5 gib "FizzBuzz" zurück.  
* Fizz“ soll auch zurückgegeben werden, wenn die Zahl eine 3 als Ziffer enthält, z.B. 13.  
* Buzz“ soll auch zurückgegeben werden, wenn die Zahl eine 5 als Ziffer enthält, z.B. 52.  
* FizzBuzz" soll auch zurückgegeben werden, wenn die Zahl eine 3 und eine 5 enthält, z.B. 35 oder 53. 
* */
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