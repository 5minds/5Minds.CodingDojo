using NUnit.Framework;

namespace FizzBuzzTest;
using FizzBuzz;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void FizzTest()
    {
        Assert.AreEqual("Fizz", FizzBuzz.isFizzBuzz(13));
        Assert.AreEqual("Fizz", FizzBuzz.isFizzBuzz(9));
        Assert.AreEqual("Fizz", FizzBuzz.isFizzBuzz(12));
    }

    [Test]
    public void BuzzTest()
    {
        Assert.AreEqual("Buzz", FizzBuzz.isFizzBuzz(10));
        Assert.AreEqual("Buzz", FizzBuzz.isFizzBuzz(52));
        Assert.AreEqual("Buzz", FizzBuzz.isFizzBuzz(59));
    }

    [Test]
    public void FizzBuzzTest()
    {
        Assert.AreEqual("FizzBuzz", FizzBuzz.isFizzBuzz(15));
        Assert.AreEqual("FizzBuzz", FizzBuzz.isFizzBuzz(53));
        Assert.AreEqual("FizzBuzz", FizzBuzz.isFizzBuzz(30));
    }
}