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
*
* Auch Palindromsätze sind möglich. 
* Handelt es sich um einen Satz, so sind Leer- und Satzzeichen zu vernachlässigen.
*  
* Beispiele:
* Tarne nie deinen Rat!
* Eine güldne, gute Tugend: Lüge nie! 
* Ein agiler Hit reizt sie. Geist?! Biertrunk nur treibt sie. Geist ziert ihre Liga nie!
* */
class Palindrom {
  constructor() {
  }

  check(word) {

    let handleWord = word.toUpperCase().replace(/[.,?\/#!$%\^&\*;:{}=\-_`~()\s]/g,"");
    console.log(handleWord);
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
palindrom.check(" ABA  ");
palindrom.check("Lagerregal");
palindrom.check("Reliefpfeiler");
palindrom.check("Rentner");
palindrom.check("Dienstmannamtsneid");
palindrom.check("Tarne nie deinen Rat!");
palindrom.check("Eine güldne, gute Tugend: Lüge nie!");
palindrom.check("Ein agiler Hit reizt sie. Geist?! Biertrunk nur treibt sie. Geist ziert ihre Liga nie!");