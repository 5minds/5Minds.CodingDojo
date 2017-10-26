import math
from datetime import datetime
import time
from termcolor import colored


def main(current_time):

    dot = current_time.second % 2
    first_line = int(math.floor(current_time.hour / 5))
    second_line = current_time.hour - (first_line * 5)
    third_line = int(math.floor(current_time.minute / 5))
    fourth_line = current_time.minute - (third_line * 5)

    time.sleep(0.42)
    print(chr(27) + "[2J")

    print_formatted_seconds(dot)
    print_formatted_hours(first_line)
    print_formatted_hours(second_line)
    print_formatted_third_line(third_line)
    print_formatted_fourth_line(fourth_line)


def print_formatted_seconds(seconds):

    if seconds == 0:

        print(colored('#', 'yellow'))

    else:

        print('#')


def print_formatted_hours(line):

    white_spaces = '#' * (4 - line)

    print(colored('#' * line, 'red') + white_spaces)


def print_formatted_third_line(third_line):

    count = int(math.floor(third_line / 3))
    rest = third_line - (count * 3)

    full_three_bars = colored('##', 'yellow') + colored('#', 'red')
    full_fourth_bar_count = full_three_bars * count
    additional_yellow = colored(rest * '#', 'yellow')
    white_spaces = '#' * (11 - third_line)

    print(full_fourth_bar_count + additional_yellow + white_spaces)


def print_formatted_fourth_line(fourth_line):

    white_spaces = '#' * (4 - fourth_line)
    colored_spaces = colored('#' * fourth_line, 'red') + '#' * (4 - fourth_line)
    print(colored_spaces + white_spaces)


if __name__ == '__main__':

    while True:

        current_time = datetime.now()
        main(current_time)
