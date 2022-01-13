# -*- coding: utf-8 -*-
'''
@author Julian Lintz
@brief Testcases for solution to kata 'palindrom'
'''
import unittest
import random
import string
import re
from palindrom import isPalindrom


class PalindromTestCases(unittest.TestCase):

    def testFiveMindsExamples(self):
        # Test positive examples from 5minds presentation
        fiveMindsExamples = [
            "Abba",
            "Lagerregal",
            "Reliefpfeiler",
            "Rentner",
            "Dienstmannamtsneid",
            "Tarne nie deinen Rat!",
            "Eine güldne, gute Tugend: Lüge nie!",
            "Ein agiler Hit reizt sie. Geist?! Biertrunk nur treibt sie. Geist ziert ihre Liga nie!"
        ]

        for example in fiveMindsExamples:
            self.assertTrue(isPalindrom(example))

    def testRandomExample(self):
        # generate some random palindromes of random size on the fly
        # For the algorithm, these need not be grammatically correct (English etc.) sentences at all.
        # We also test case - insensitivity by forcing different capitalization in both half
        for randomTestNumber in range(100):
            halfLength = random.randint(0, 20)
            randomString = ''.join(random.choice(string.letters + string.punctuation + string.digits) for _ in range(halfLength))
            reversedString = ''.join(reversed(randomString))
            palindrom = randomString + reversedString.lower()
            self.assertTrue(isPalindrom(palindrom))

    def testRandomNegativeExample(self):
        # Generate some random strings which are not palindromes
        for randomTestNumber in range(100):
            halfLength = random.randint(1, 20)
            randomStringLh = ''.join(random.choice(string.letters + string.punctuation + string.digits) for _ in range(halfLength))
            randomStringRh = ''.join(random.choice(string.letters + string.punctuation + string.digits) for _ in range(halfLength))
            reversedStringLh = ''.join(reversed(randomStringLh))

            if re.sub('[^a-zA-Z0-9]', '', reversedStringLh.lower()) is re.sub('[^a-zA-Z0-9]', '', randomStringRh.lower()):
                # Theoretically, we could redo the generation here ...
                # ... or just the loop a few more times!
                # For the overall viability of the test it makes no difference,
                # unless every single one of 100 runs came up with this.
                # Next kata: calculate the chances of that! ;-)
                continue

            # Force at least two non-punctuation characters to be present, or this might be true
            randomLetter = ''.join(random.choice(string.letters))
            noPalindrom = randomStringLh + randomLetter + randomLetter + randomStringRh
            self.assertFalse(isPalindrom(noPalindrom))


if __name__ == '__main__':
    unittest.main()