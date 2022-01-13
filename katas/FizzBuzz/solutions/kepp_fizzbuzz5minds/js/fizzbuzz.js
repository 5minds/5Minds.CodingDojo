exports.getValueFor = (number) => {
  if (number % (3 * 5) === 0) return "FizzBuzz";
  if (number % 3 === 0) return "Fizz";
  if (number % 5 === 0) return "Buzz";
  return number.toString();
}

exports.getValueSpecial = (number) => {
  const result = number.toString();
  if (result.includes("5") && result.includes("3")) return "FizzBuzz";
  if (result.includes("3")) return "Fizz";
  if (result.includes("5")) return "Buzz";
  return this.getValueFor(parseInt(result));
}
