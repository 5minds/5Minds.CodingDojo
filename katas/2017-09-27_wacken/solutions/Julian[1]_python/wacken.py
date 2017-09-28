from random import choice
from copy import deepcopy


class Knots(object):

    def __init__(self):

        self.wacken_one = {'1': ['5', '2', '3', '4'],
                           '2': ['1', '3', '4', '5'],
                           '3': ['1', '2', '4', '7'],
                           '4': ['1', '3', '2', '8'],
                           '5': ['1', '2', '6', '7'],
                           '6': ['5', '7'],
                           '7': ['5', '3', '6', '8'],
                           '8': ['7', '4']}

    def main(self):

        current_wacken = self.wacken_one

        while True:

            instance_of_wacken = deepcopy(current_wacken)

            if self.enter(instance_of_wacken):

                print('Possible')
                break

            else:

                print('Another try')

    def enter(self, map):

        random_stage = choice(list(map.keys()))

        if self.search(map, random_stage):

            return True

        return False

    def search(self, map, stage):

        print(map)

        if len(list(map.keys())) == 1 and len(list(map.keys())[0]) == 1:

            return True

        map_not_empty = len(map) > 0

        if stage not in map and map_not_empty:

            return False

        next_stage = choice(map[stage])
        map[stage].remove(next_stage)

        if len(map[stage]) == 0:

            map.pop(stage)

        if self.search(map, next_stage):

            return True


if __name__ == '__main__':

    just_do_it = Knots()
    just_do_it.main()
