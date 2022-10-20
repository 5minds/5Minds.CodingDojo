from enum import IntEnum


class Direction(IntEnum):
    North = 0,
    East = 90,
    South = 180,
    West = 270


class MercuryRover:
    def __init__(self):
        self.direction = Direction.East
        self.position = (0, 0)

    def forward(self, steps):

        pos = list(self.position)

        if self.direction == Direction.North:
            pos[1] = pos[1] - steps
        if self.direction == Direction.South:
            pos[1] = pos[1] + steps
        if self.direction == Direction.East:
            pos[0] = pos[0] + steps
        if self.direction == Direction.West:
            pos[0] = pos[0] - steps

        self.position = tuple(pos)

    def backward(self, steps):
        self.forward(steps * -1)

    def right(self, degree):
        updatedDegree = int(self.direction) + degree

        if updatedDegree >= 360:
            updatedDegree = updatedDegree - 360

        self.direction = Direction(updatedDegree)

    def left(self, degree):
        updatedDegree = int(self.direction) - degree

        if updatedDegree <= 0:
            updatedDegree = updatedDegree + 360

        if updatedDegree == 360:
            updatedDegree = 0

        self.direction = Direction(updatedDegree)


class MappedMercuryRover(MercuryRover):

    mercuryMap = []

    def forward(self, steps):

        orientation = 1 if steps > 0 else -1

        for step in range(0, steps * orientation):
            pos = list(self.position)

            if self.direction == Direction.North:
                pos[1] = pos[1] - orientation
            if self.direction == Direction.South:
                pos[1] = pos[1] + orientation
            if self.direction == Direction.East:
                pos[0] = pos[0] + orientation
            if self.direction == Direction.West:
                pos[0] = pos[0] - orientation

            if self.mercuryMap[pos[1]][pos[0]] == 'O' or self.mercuryMap[pos[1]][pos[0]] == '#':
                raise ValueError(f"I cannot do this at position ({pos[0]}, {pos[1]})")

            self.position = tuple(pos)

            currentLine = self.mercuryMap[pos[1]]
            currentLine = currentLine[:pos[0]] + 'X' + currentLine[pos[0]+1:]
            self.mercuryMap[pos[1]] = currentLine
