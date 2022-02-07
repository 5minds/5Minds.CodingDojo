
const convertToFizzBuzz = (n) => {
    let output = "";
    if (n % 3 == 0) { output = "Fizz"; }
    if (n % 5 == 0) { output += "Buzz"; }
    return output == "" ? n : output;
}

const converterVariationToFizzBuzz  = (n) => {
    let output = "";
    if (n % 3 == 0 || Math.floor(n/10)==3 || n%10==3) { output = "Fizz"; }
    if (n % 5 == 0 || Math.floor(n/10)==5 || n%10==5) { output += "Buzz"; }
    return output == "" ? n : output;
}

const fizzBuzz = (n) => {
    if (n <= 0) {
        throw new Error("Invalid argument");
    }
    const results = Array(n)
        .fill()
        .map((_, i) => convertToFizzBuzz(i + 1));

    return results;
}



const fizzBuzzVariation = (n) => {
    if (n <= 0) {
        throw new Error("Invalid argument");
    }
    const results = Array(n)
        .fill()
        .map((_, i) => converterVariationToFizzBuzz(i + 1));

    return results;
}

module.exports = {
    fizzBuzz,
    fizzBuzzVariation
}