import unittest

def next_bigger_number(number_array):
    length = len(number_array)
    # Doesn't work for single digit numbers
    if length == 1:
        return -1

    # Doesn't work for numbers consisting of one repeating digit
    if len(list(set(number_array))) == 1:
        return -1

    # Does not work if digits are in descending order
    descending = True
    for i in range(0, length - 1):
        if number_array[i] < number_array[i + 1]:
            descending = False
            break
    if descending:
        return -1

    # Special cases treated, now "usual" numbers
    # Find first pair of numbers where a greater number is to the right of a smaller number
    i = 0
    for i in range(length - 1, 0, -1):
        if number_array[i] > number_array[i - 1]:
            break

    # find the smallest number x to the right of the pair where x is still bigger than k, these have to be swapped
    k = number_array[i - 1]
    pos_smallest = i
    for j in range(i + 1, length):
        if k < number_array[j] < number_array[pos_smallest]:
            pos_smallest = j

    # swap numbers at i-1 and pos_smallest
    tmp = number_array[i - 1]
    number_array[i - 1] = number_array[pos_smallest]
    number_array[pos_smallest] = tmp

    # First i numbers are fixed, the last numbers have to be sorted ascending
    result = number_array[:i]
    for e in sorted(number_array[i:]):
        result.append(e)
    number_array = [str(digit) for digit in result]
    return int(''.join(number_array))


class TestNextBiggerNumber(unittest.TestCase):
    def testWorkingCases(self):
        numbers_to_test = [12, 513, 2017, 459853, 59884848459853]
        expected_results = [21, 531, 2071, 483559, 59884848483559]

        calculated_results = []
        for x in numbers_to_test:
            x = [int(char) for char in str(x)]
            next_num = next_bigger_number(x)
            calculated_results.append(next_num)
        self.assertTrue(expected_results == calculated_results)

    def testNotWorkingCases(self):
        numbers_to_test = [9, 111, 531]
        expected_results = [-1, -1, -1]

        calculated_results = []
        for x in numbers_to_test:
            x = [int(char) for char in str(x)]
            next_num = next_bigger_number(x)
            calculated_results.append(next_num)
        self.assertTrue(expected_results == calculated_results)


if __name__ == '__main__':
    unittest.main()