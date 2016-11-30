import unittest

def swap(number, first_pos, second_pos):

    number_list = list(number)

    temp = number_list[first_pos]
    number_list[first_pos] = number_list[second_pos]
    number_list[second_pos] = temp

    return ''.join(number_list)


def sort(number, from_pos, to_pos):

    start = number[:from_pos]
    end = number[to_pos:]

    sort_part = number[from_pos:to_pos]
    sorted_part = ''.join(sorted(sort_part, reverse=True))

    return start + sorted_part + end


def next_bigger(number):

    i = 0
    j = 0

    number_length = len(number)
    length_to_zero_range = range(number_length - 1, -1, -1)

    # From right to left, find first digit that ist smaller the the digit next to it
    for pos in length_to_zero_range:
        i = pos

        if number[i] > number[i - 1]:
            break

    # if i is zero, then number is in descending order, no higher number exists
    if i == 0:
        return -1

    x = number[i - 1]
    smallest = i

    for j in range(i + 1, len(number)):
        if x < number[j] < number[smallest]:
            smallest = j

    # Swap the above found smallest digit with number[i - 1]
    number = swap(number, smallest, i - 1)

    number = sort(number, i-1, len(number))

    return number


class TestMethods(unittest.TestCase):

    def tests(self):
        self.assertEqual(next_bigger('12'), '21')
        self.assertEqual(next_bigger('513'), '531')
        self.assertEqual(next_bigger('2017'), '2071')
        self.assertEqual(next_bigger('459853'), '483559')
        self.assertEqual(next_bigger('59884848459853'), '59884848483559')

unittest.main()

#user_number = raw_input("Please enter a number: ")
#next_bigger_number = next_bigger(user_number)

#print 'Next bigger number: ' + next_bigger_number
