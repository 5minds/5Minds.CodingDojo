const { getValueFor, getValueSpecial } = require("./fizzbuzz");

test("get value for number", () => {
  expect(getValueFor(1)).toBe("1");
  expect(getValueFor(3)).toBe("Fizz");
  expect(getValueFor(5)).toBe("Buzz");
  expect(getValueFor(15)).toBe("FizzBuzz");
});

test("get values till 15", () => {
  const result = ["1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz"];
  let test = [];
  for (let i = 1; i <= 15; i++) {
    test.push(getValueFor(i));
  }
  
  expect(test).toEqual(result);
});

test("get value for number special ", () => {
  expect(getValueSpecial(1)).toBe("1");
  expect(getValueSpecial(3)).toBe("Fizz");
  expect(getValueSpecial(5)).toBe("Buzz");
  expect(getValueSpecial(15)).toBe("Buzz");
  expect(getValueSpecial(13)).toBe("Fizz");
  expect(getValueSpecial(25)).toBe("Buzz");
  expect(getValueSpecial(35)).toBe("FizzBuzz");
});
