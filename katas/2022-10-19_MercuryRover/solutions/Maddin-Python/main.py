# This is a sample Python script.
from CommandInterpreter import CommandInterpreter
from MercuryRover import MappedMercuryRover


# Press ⌃R to execute it or replace it with your code.
# Press Double ⇧ to search everywhere for classes, files, tool windows, actions, and settings.


def print_hi(name):
    # Use a breakpoint in the code line below to debug your script.
    print(f'Hi, {name}')  # Press ⌘F8 to toggle the breakpoint.


# Press the green button in the gutter to run the script.
if __name__ == '__main__':
    with open("map_easy.txt") as f:
        loadedMap = f.read().splitlines()

    rover = MappedMercuryRover()
    rover.mercuryMap = loadedMap

    interpreter = CommandInterpreter(rover)

    commands = 'F2, R90, F18, L90, F2, R90, F22, R90, F1, L90, F16, L90, F1, R90'

    interpreter.interpret(commands)

    with open('my_way.txt', 'w') as f:
        for line in rover.mercuryMap:
            f.write(f"{line}\n")

# See PyCharm help at https://www.jetbrains.com/help/pycharm/
