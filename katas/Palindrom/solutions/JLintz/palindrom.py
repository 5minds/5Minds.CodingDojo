# -*- coding: utf-8 -*-
'''
@author Julian Lintz
@brief Solution to 'palindrom' kata
'''
import re


def isPalindromRecursive(inputString):
    '''
    Recursive function to test for a palindrom on the input.
    This function requires the input to consist of only alpha-numeric characters.
    :param input: A String of purely alpha-numeric characters.
    :return: True, if the input is a string representing a palindrom
    '''

    if len(inputString) < 2:
        return True

    if inputString.endswith(inputString[0]):
        return isPalindromRecursive(inputString[1:-1])
    else:
        return False


def isPalindrom(inputString):
    '''
    Function to test whether an input string represents a palindrom.
    The string will be evaluated case insensitive and also ignore all punctuation,
    only alpha-numeric characters will be considered (a-z, A-Z, 0-9).
    :param input: A string of arbitrary length
    :return: True, if the input is a string representing a palindrom
    '''

    # Clean the input of any non-alphabet characters and make it case-insensitive, then call recursion
    return isPalindromRecursive(re.sub('[^a-zA-Z0-9]', '', inputString.lower()))

