from typing import Dict, Any


class CommandInterpreter:
    def __init__(self, rover):
        self.rover = rover

        self.instructionSelector = {
            'F': self.rover.forward,
            'B': self.rover.backward,
            'R': self.rover.right,
            'L': self.rover.left
        }

    def interpret(self, commands):
        commandList = commands.split(', ')

        for command in commandList:
            instruction = command[0]
            value = int(command[1:])

            self.instructionSelector[instruction](value)
