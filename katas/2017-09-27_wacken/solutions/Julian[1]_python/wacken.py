from random import choice
from copy import deepcopy


class Wacken(object):

    def __init__(self):

        self.wacken_map = {'1': ['5', '2', '3', '4'],
                           '2': ['1', '3', '4', '5'],
                           '3': ['1', '2', '4', '7'],
                           '4': ['1', '3', '2', '8'],
                           '5': ['1', '2', '6', '7'],
                           '6': ['5', '7'],
                           '7': ['5', '3', '6', '8'],
                           '8': ['7', '4']}

    def main(self):

        current_wacken = self.wacken_map

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

        only_one_stage = len(list(map.keys())) == 1
        only_one_path = len(list(map.keys())[0]) == 1

        if only_one_stage and only_one_path:

            return True

        map_not_empty = len(map) > 0

        if stage not in map and map_not_empty:

            return False

        next_stage = choice(map[stage])
        map[stage].remove(next_stage)

        stage_has_no_paths = len(map[stage]) == 0

        if stage_has_no_paths:

            map.pop(stage)

        if self.search(map, next_stage):

            return True


if __name__ == '__main__':

    Wacken = Wacken()
    Wacken.main()
