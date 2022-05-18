#!/usr/bin/env node
console.log([3,1,2,7,1].flatMap((c,i) => [1,8 ,4, 5, 2].map((r,j) => ({i:i, j:j, c:c, r:r}))).reduce((acc, x) =>(acc[(x.i+x.j)%2]+=x.c*x.r, acc), [0,0]))