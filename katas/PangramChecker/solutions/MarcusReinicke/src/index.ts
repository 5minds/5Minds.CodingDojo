import CPangramChecker from './CPangramChecker';

/**
 * For Console input
 */
const prompt = require("prompt-sync")();

let oPangramChecker:CPangramChecker = new CPangramChecker();

const input = prompt("String to Check?: ");

var nResult:any = oPangramChecker.fGetPangramType(input);

switch(nResult){
    
    case -1: console.log('"' + input + '" does not contain all alphabet letters at least once.'); break;
    case 0: console.log('"' + input + '" contains all alphabet letters exactly once.'); break;
    case 1: console.log('"' + input + '" contains all alphabet letters more than once.'); break;   
}