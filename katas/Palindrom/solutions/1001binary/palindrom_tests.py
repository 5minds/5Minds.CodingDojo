import unittest
import palindrom
from parameterized import parameterized

class TestPalindrom(unittest.TestCase):
    @parameterized.expand([
        ["abba"],
        ["rentner"],
        ["Lagerregal"],
        ["Dienstmannamtsneid"],
        ["Eine güldne, gute Tugend: Lüge nie!"],
        ["Tarne nie deinen Rat!"],
        ["Ein agiler Hit reizt sie. Geist?! Biertrunk nur treibt sie. Geist ziert ihre Liga nie!"]
    ])
    def testpalindrom_text_returnstrue(self, text):
        self.assertEqual(True, palindrom(text))

    @parameterized.expand([
        [None],
        [""],
        ["   "]
    ])
    def testpalindrom_text_returnsfalse(self, text):
        self.assertEqual(False, palindrom(text))

if __name__ == '__main__':
    unittest.main()