using NUnit.Framework;

namespace FizzBuzzTest;
using FizzBuzz;

public class Tests
{
    private FizzBuzz fizzBuzz;
    [SetUp]
    public void Setup()
    {
        fizzBuzz = new FizzBuzz();
    }

    [Test]
    public void FizzTest()
    {
        Assert.AreEqual("Fizz", fizzBuzz.IsFizzBuzz(13));
        Assert.AreEqual("Fizz", fizzBuzz.IsFizzBuzz(9));
        Assert.AreEqual("Fizz", fizzBuzz.IsFizzBuzz(12));
    }

    [Test]
    public void BuzzTest()
    {
        Assert.AreEqual("Buzz", fizzBuzz.IsFizzBuzz(10));
        Assert.AreEqual("Buzz", fizzBuzz.IsFizzBuzz(52));
        Assert.AreEqual("Buzz", fizzBuzz.IsFizzBuzz(59));
    }

    [Test]
    public void FizzBuzzTest()
    {
        Assert.AreEqual("FizzBuzz", fizzBuzz.IsFizzBuzz(15));
        Assert.AreEqual("FizzBuzz", fizzBuzz.IsFizzBuzz(53));
        Assert.AreEqual("FizzBuzz", fizzBuzz.IsFizzBuzz(30));
    }
}