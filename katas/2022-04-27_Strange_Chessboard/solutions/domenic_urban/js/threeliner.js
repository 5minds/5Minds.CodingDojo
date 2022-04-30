#!/usr/bin/env node
const result = [0,0];
[3,1,2,7,1].forEach((c,i) => [1,8 ,4, 5, 2].forEach((r,j) => result[(i+j)%2] += c*r))
console.log(result)