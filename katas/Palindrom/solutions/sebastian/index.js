/* *
* Schreibe eine Funktion, die true zurückgibt, falls die übergebene Zeichenkette ein Palindron ist. Andernfalls false.  
* Irgendwie schreit das Problem nach Rekursion!
*  
* Beispiele:
* Abba  
* Lagerregal
* Reliefpfeiler
* Rentner
* Dienstmannamtsneid 
* */
class Palindrom {
  constructor() {
  }

  checkWord(word) {

    let handleWord = word.trim().toUpperCase();
    let wordLength = handleWord.length;

    if (wordLength <= 1) {
      console.log("no palindrom");
      return;
    }

    let firstWord = handleWord.slice(0,Math.floor(wordLength/2));
    let secondWord = handleWord.slice(Math.ceil(wordLength/2));
    let reverseSecondWord = secondWord.split("").reverse().join("");
  
    let result = false;
    if (firstWord === reverseSecondWord) {
      result = true;
    }
    console.log("Is palindrom " + word + "= " + result);
  }
}
const palindrom = new Palindrom();
palindrom.checkWord(" ABA  ");
palindrom.checkWord("Lagerregal");
palindrom.checkWord("Reliefpfeiler");
palindrom.checkWord("Rentner");
palindrom.checkWord("Dienstmannamtsneid");