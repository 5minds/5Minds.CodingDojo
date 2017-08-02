filenames = ['situation_1.txt', 'situation_2.txt', 'situation_3.txt', 'situation_4.txt', 'situation_5.txt']


def read_file(filename):
    with open('../examples/' + filename, 'r') as f:
        content = f.readlines()

    return content


def analyzer(def_player_counter):
    exit_loop = False
    atk_coordinates = []
    for y_pos in range(61, 0, -1):
        for x_pos in range(len(lineslist)):
            if lineslist[x_pos][y_pos] == 'x':
                if 0 < y_pos < 60:
                    if 0 < x_pos < 45:
                        if not (lineslist[x_pos-1][y_pos+1] is 'x' or lineslist[x_pos][y_pos+1] is 'x' or lineslist[x_pos-1][y_pos+1] is 'x'):
                            def_player_counter += 1

                else:
                    def_player_counter += 1

            elif lineslist[x_pos][y_pos] is '+':
                exit_loop = True
                atk_coordinates.append(x_pos)

            elif lineslist[x_pos][y_pos] is '@':
                ball_pos.append([y_pos, x_pos])

        if exit_loop:
            if def_player_counter < 2:
                for x in lineslist:
                    for y, z in enumerate(x):
                        if y < atk_coordinates[0]-2:
                            print('Abseits in ' + names)
                            return

            else:
                print('Kein Abseits in ' + names)
                return


if __name__ == '__main__':
    for names in filenames:
        lineslist = read_file(names)
        counter = 0
        ball_pos = []
        def_player_counter = 0
        for lines in lineslist:
            for field in lines:
                if field is 'x' or field is '+':
                    counter += 1

        if counter is 0:
            print('Leeres Feld in ' + names)
        else:
            analyzer(def_player_counter)
