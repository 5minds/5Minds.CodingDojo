import unittest
import re

def Palindrom(word):
    if len(word) == 0 or len(word) == 1:
        return True

    word = word.lower()
    word = re.sub('[^a-z]', '', word)

    firstchar = word[0]
    lastchar = word[len(word)-1]

    if firstchar == lastchar:
        word = word[1:-1]
        return Palindrom(word)
    else:
        return False

class TestMethods(unittest.TestCase):

    def tests(self):
        self.assertEqual(Palindrom('Abba'), True)
        self.assertEqual(Palindrom('Lagerregal'), True)
        self.assertEqual(Palindrom('Reliefpfeiler'), True)
        self.assertEqual(Palindrom('Rentner'), True)
        self.assertEqual(Palindrom('Dienstmannamtsneid'), True)

        self.assertEqual(Palindrom('Adam, ritt Irma da?'), True)
        self.assertEqual(Palindrom('Eins nutzt uns: Amore. Die Rederei da, die Rederei der Omas, nutzt uns nie.'), True)

        self.assertEqual(Palindrom('Test'), False)
        self.assertEqual(Palindrom('Beispiel'), False)
        self.assertEqual(Palindrom('PythonRocks'), False)
        self.assertEqual(Palindrom('Regular Expressions sind doof!!!'), False)

unittest.main()
