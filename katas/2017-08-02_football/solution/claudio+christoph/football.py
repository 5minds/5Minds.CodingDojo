#!/usr/bin/env python
# -*- coding: utf-8 -*-

import sys

field = []

def main():

    x_pos = 0
    y_pos = 0

    attacker_positions = []
    defender_positions = []
    ball_position = None

    defender = {
            "token": "x",
            "replacement": "a"
        }

    attacker = {
            "token": "+",
            "replacement": "b"
        }

    ball = '@'

    for row in field:
        x_pos = 0
        for space in row:
            if space is defender["token"]:
                defender_positions.append(
                        detect_player_position(x_pos, y_pos, defender)
                    )

            elif space is attacker["token"]:
                attacker_positions.append(
                        detect_player_position(x_pos, y_pos, attacker)
                    )

            elif space is ball:
                ball_position = x_pos

            else:
                pass

            x_pos = x_pos + 1
        y_pos = y_pos + 1

    print("attacker: {}".format(attacker_positions))
    print("defender: {}".format(defender_positions))
    print("ball is at: {}".format(ball_position))

    try:
        relevant_attacker = sorted(attacker_positions)[-1:]
        relevant_defender = sorted(defender_positions)[-2:-1]

        print("relevant_attacker: {}".format(relevant_attacker))
        print("relevant_defender: {}".format(relevant_defender))

        is_suspected_to_be_offside = (relevant_attacker > relevant_defender)
        ball_is_not_closer_to_goal = ball_position <= attacker_positions
        is_offside = is_suspected_to_be_offside and ball_is_not_closer_to_goal

        if is_offside:
            print("Schiri pfeift. Abseits!")
        else:
            print("Kein Abseits")

    except:
        print("Nicht zu entscheiden.")

    return True


def detect_player_position(x_offset, y_offset, token_and_replacement):

    position = x_offset

    for x in range(-2,3):
        for y in range(-2,3):
            try:
                x_pos = x_offset + x
                y_pos = y_offset + y

                field_value = field[y_pos][x_pos]

                if field_value is token_and_replacement["token"]:
                    position = x_pos
                    field[y_pos][x_pos] = token_and_replacement["replacement"]

            except:
                pass

    return position


if __name__ == "__main__":

    files = sys.argv[1:]

    situation_counter = 0
    for file in files:

        with open(file) as f:
            field = f.readlines()

        field = [x.strip() for x in field]
        field = [list(x) for x in field]

        situation_counter = situation_counter + 1
        print("\nLoading Situation {}".format(situation_counter))
        main()
