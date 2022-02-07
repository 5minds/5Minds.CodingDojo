
const { describe, it,expect } = require("@jest/globals");
const {fizzBuzz,fizzBuzzVariation}=require("./fizzbuzz");



describe('fizzBuzz', () => {

    it('should return {1,2}', () => {
        const result=[1,2];
        expect(result).toEqual(fizzBuzz(2));
    });

    it('should return {1,2,Fizz,4,Buzz}', () => {
        const result=[1,2,"Fizz",4,"Buzz"];
        expect(result).toEqual(fizzBuzz(5));
    });

    it('should return {1,2,Fizz,4,Buzz,Fizz,7,8,Fizz,Buzz,11,Fizz,13,14,FizzBuzz}', () => {
        const result=[1,2,"Fizz",4,"Buzz","Fizz",7,8,"Fizz","Buzz",11,"Fizz",13,14,"FizzBuzz"];
        expect(result).toEqual(fizzBuzz(15));
    });
});

describe('fizzBuzzVariation', () => {
    it('should return {1,2,Fizz,4,Buzz,Fizz,7,8,Fizz,Buzz,11,Fizz,13,14,FizzBuzz}', () => {
        const result=[1,2,"Fizz",4,"Buzz","Fizz",7,8,"Fizz","Buzz",11,"Fizz","Fizz",14,"FizzBuzz"];
        expect(result).toEqual(fizzBuzzVariation(15));
    });
});