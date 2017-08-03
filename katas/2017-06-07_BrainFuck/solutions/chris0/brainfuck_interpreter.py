#!/usr/bin/env python
# -*- coding: utf-8 -*-

data_container = []

global pointer_position
pointer_position = 0

global bracket_open_positon
bracket_open_positon = 0

global token_count
token_count = 0

global skip_mode
skip_mode = False

global bracket_mode
bracket_mode = False


def main(input_string):
    """Main of the Brainfuck Interpreter
    """
    if len(input_string) == 0:
        return

    parse(input_string[0])

    global token_count
    token_count += 1

    main(input_string[1:])


def current_value():
    if len(data_container) <= pointer_position:
        data_container.append(0)
        return

    return data_container[pointer_position]


def increment_value():
    if len(data_container) <= pointer_position:
        data_container.append(0)

    data_container[pointer_position] += 1


def decrement_value():
    if len(data_container) <= pointer_position:
        data_container.append(0)
        return

    if current_value() == 0:
        return

    data_container[pointer_position] -= 1


def parse(token):
    """Parses the current Token.

    :token: TODO
    :returns: TODO
    """
    global pointer_position
    global bracket_open_positon
    global skip_mode
    global bracket_mode

    if token is "[":
        bracket_open_positon = token_count
        print("bracket_open_positon {}".format(bracket_open_positon))

        bracket_mode = True
        print("entering bracket_mode")

        if current_value() is 0:
            skip_mode = True
            print("entering skip_mode")

        return

    if token is "]":
        if current_value() is 0:
            skip_mode = False
            bracket_mode = False
            print("leaving skip_mode")
            print("leaving bracket_mode")
            return

        else:
            pointer_position = bracket_open_positon
            return

    if skip_mode is True:
        return

    if token is "+":
        increment_value()

    if token is "-":
        decrement_value()

    if token is ">":
        pointer_position += 1

    if token is "<":
        pointer_position -= 1

    if token is ".":
        print("{:c}".format(current_value()))

    if token is ",":
        print("{}".format(pointer_position))

    return


if __name__ == "__main__":
    input_programm = "+[+++]" + 65 * "+" + "."
    # input_programm = 65*"+" + "."
    main(input_programm)
