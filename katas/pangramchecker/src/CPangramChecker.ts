export default class CPangramChecker {

  constructor(){

  }

  public fInitLetters(p_oObject:any): void{

    /**
     * Ascii between 65 and 90 = A to Z
     */
    const nStart:number = 65, nEnd:number = 90;
    for(let i:number = nStart; i <= nEnd; i++){

      p_oObject[String.fromCharCode(i)] = 0;
    }
  }

  public fCheckIfPangram(p_sStringToCheck: string): any{

    let oEnglishLetters:any = {};
    this.fInitLetters(oEnglishLetters);
    let lStringToCheckUpperCase = p_sStringToCheck.toUpperCase();
    let bSpecialCharacter:boolean = false;
    for(var sChar of lStringToCheckUpperCase){ 

      if(oEnglishLetters[sChar] !== undefined){

        oEnglishLetters[sChar]++;
      } else {

        if(sChar !== " "){

          bSpecialCharacter = true;
        }
      }
    }
    // console.log(oEnglishLetters);
    return oEnglishLetters;
  }

  public fGetPangramType(p_sStringToCheck: string): number{

    var oResult:any = this.fCheckIfPangram(p_sStringToCheck);
    let bMissing:boolean = false;
    let bMultiple:boolean = false;

    Object.keys(oResult).forEach(function(p_sKey) {
        if (oResult[p_sKey] === 0) {

            bMissing = true;
        } else if (oResult[p_sKey] > 1) {

            bMultiple = true;
        }
    });

    if(bMissing){
        return -1;
    } else if(bMultiple){
        return 1;
    } else {
        return 0;
    }
  }
}