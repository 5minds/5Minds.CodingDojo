

def fizzbuzz():
    for x in range(1,101):
        print(str(x) + " -> " + str(convert_(convert(x))))

def convert(number):
    if number % 3 is 0 and number % 5 is 0:
        return "FizzBuzz"
    if number % 3 is 0:
        return "Fizz"
    if number % 5 is 0:
        return "Buzz"
    return number

def convert_(number):
    if "3" in str(number) and "5" in str(number):
        return "FizzBuzz"
    if "3" in str(number):
        return "Fizz"
    if "5" in str(number):
        return "Buzz"
    return number


import unittest

class TestFizzBuzz(unittest.TestCase):

    def test_fizz(self):
        self.assertEqual(convert(3), 'Fizz')
        self.assertEqual(convert(6), 'Fizz')
        self.assertEqual(convert_(13), 'Fizz')

    def test_buzz(self):
        self.assertEqual(convert(5), 'Buzz')
        self.assertEqual(convert_(54), 'Buzz')

    def test_fizzbuzz(self):
        self.assertEqual(convert(15), 'FizzBuzz')


    def test_numbers(self):
        self.assertEqual(convert(4), 4)
        self.assertEqual(convert_(convert(17)), 17)
