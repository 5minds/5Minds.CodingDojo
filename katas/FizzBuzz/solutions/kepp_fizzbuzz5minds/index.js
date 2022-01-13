const { getValueSpecial } = require("./js/fizzbuzz");

const target = 100;
for (let i = 1; i <= target; i++) {
  console.log(getValueSpecial(i));
}
