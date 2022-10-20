import unittest

from CommandInterpreter import CommandInterpreter
from MercuryRover import MercuryRover


class TestCommandInterpreter(unittest.TestCase):
    def test_first(self):
        with open("instructions.txt") as f:
            lines = f.read().splitlines()

        for line in lines:
            rover = MercuryRover()
            interpreter = CommandInterpreter(rover)

            splitted = line.split(' -> ')
            commands = splitted[0]
            expectedPart = splitted[1]

            expectedNumbers = expectedPart.split(', ')
            expected = (int(expectedNumbers[0]), int(expectedNumbers[1]))

            interpreter.interpret(commands)

            self.assertEqual(expected, rover.position)
