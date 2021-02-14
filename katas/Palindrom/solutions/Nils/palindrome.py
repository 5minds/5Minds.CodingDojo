#!/usr/bin/env python3

import sys

def usage() -> str:
    return f'''
Usage: {sys.argv[0]} <text>

'''


def is_palindrome(text:str) -> bool:
    text = text.lower()
    text = text.replace(' ', '')
    text = text.replace('.', '')
    text = text.replace(',', '')
    text = text.replace(':', '')
    text = text.replace(';', '')
    text = text.replace('!', '')
    text = text.replace('?', '')
    text = text.replace('\n', '')
    text = text.replace('\r', '')

    last_idx = len(text)-1
    for i in range(0, last_idx):
        if text[i] != text[last_idx-i]:
            return False

    return True


if __name__ == '__main__':
    if len(sys.argv) < 2:
        print(usage())
        exit(1)

    text = sys.argv[1]
    if is_palindrome(text):
        print('Yep! A palindrome!')
    else:
        print('Nope! Try again!')
