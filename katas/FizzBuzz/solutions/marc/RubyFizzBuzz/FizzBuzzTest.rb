require_relative "FizzBuzz"
require "test/unit"

class FizzBuzzCalculatorTest < Test::Unit::TestCase
    def test_1
        sut = FizzBuzzCalculator.new
        expected = "1"
        actual = sut.naivImplementation(1)
    
        assert_equal(expected, actual)
    end

    def test_2
        sut = FizzBuzzCalculator.new
        expected = "2"
        actual = sut.naivImplementation(2)

        assert_equal(expected, actual)
    end

    def test_3
        sut = FizzBuzzCalculator.new
        expected = "Fizz"
        actual = sut.naivImplementation(3)

        assert_equal(expected, actual)
    end

    def test_5
        sut = FizzBuzzCalculator.new
        expected = "Buzz"
        actual = sut.naivImplementation(5)

        assert_equal(expected, actual)
    end

    def test_90
        sut = FizzBuzzCalculator.new
        expected = "FizzBuzz"
        actual = sut.naivImplementation(90)

        assert_equal(expected, actual)
    end

    def test_simple_1
        sut = FizzBuzzCalculator.new
        expected = "1"
        actual = sut.simpleImplementation(1)
    
        assert_equal(expected, actual)
    end

    def test_simple_2
        sut = FizzBuzzCalculator.new
        expected = "2"
        actual = sut.simpleImplementation(2)

        assert_equal(expected, actual)
    end

    def test_simple_3
        sut = FizzBuzzCalculator.new
        expected = "Fizz"
        actual = sut.simpleImplementation(3)

        assert_equal(expected, actual)
    end

    def test_simple_5
        sut = FizzBuzzCalculator.new
        expected = "Buzz"
        actual = sut.simpleImplementation(5)

        assert_equal(expected, actual)
    end

    def test_simple_90
        sut = FizzBuzzCalculator.new
        expected = "FizzBuzz"
        actual = sut.simpleImplementation(90)

        assert_equal(expected, actual)
    end
end