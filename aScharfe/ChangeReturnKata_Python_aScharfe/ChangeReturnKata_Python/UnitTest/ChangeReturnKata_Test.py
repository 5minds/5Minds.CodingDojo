import unittest
from Helper.CheckInputValue import CheckInputValue
from Calculator.ChangeReturnCalculator import ChangeReturnCalculator
from Calculator.ChangeReturnCalculator import Change
from decimal import Decimal

class ChangeReturnKataTest(unittest.TestCase):
    def test_CheckInputValue(self):
        self.assertTrue(CheckInputValue.CheckValueIsValid("1","2"))
        self.assertFalse(CheckInputValue.CheckValueIsValid("2","1"))
        self.assertTrue(CheckInputValue.CheckValueIsValid("1.20","2.00"))
        self.assertFalse(CheckInputValue.CheckValueIsValid("2.00","1.20"))
        self.assertFalse(CheckInputValue.CheckValueIsValid("2,00", "2.00"))
        self.assertFalse(CheckInputValue.CheckValueIsValid("2.00", "2,00"))
        self.assertFalse(CheckInputValue.CheckValueIsValid("a", "1.20"))

    def test_Change(self):
        changeTest = Change(Decimal('.01'))
        self.assertEqual(1, changeTest.oneCent)
        changeTest = Change(Decimal('.02'))
        self.assertEqual(1, changeTest.twoCent)
        changeTest = Change(Decimal('.05'))
        self.assertEqual(1, changeTest.fiveCent)
        changeTest = Change(Decimal('.10'))
        self.assertEqual(1, changeTest.tenCent)
        changeTest = Change(Decimal('.20'))
        self.assertEqual(1, changeTest.twentyCent)
        changeTest = Change(Decimal('.50'))
        self.assertEqual(1, changeTest.fiftyCent)
        changeTest = Change(Decimal('5.00'))
        self.assertEqual(1, changeTest.fiveEuro)
        changeTest = Change(Decimal('10.00'))
        self.assertEqual(1, changeTest.tenEuro)
        changeTest = Change(Decimal('20.00'))
        self.assertEqual(1, changeTest.twentyEuro)
        changeTest = Change(Decimal('50.00'))
        self.assertEqual(1, changeTest.fiftyEuro)
        changeTest = Change(Decimal('100.00'))
        self.assertEqual(1, changeTest.hundredEuro)

        changeTest = Change(Decimal('111.11'))
        self.assertEqual(1, changeTest.oneCent)
        self.assertEqual(1, changeTest.tenCent)
        self.assertEqual(2, changeTest.fiftyCent)
        self.assertEqual(1, changeTest.tenEuro)
        self.assertEqual(1, changeTest.hundredEuro)
        self.assertEqual(0, changeTest.twoCent)
        self.assertEqual(0, changeTest.fiveCent)
        self.assertEqual(0, changeTest.twentyCent)
        self.assertEqual(0, changeTest.fiveEuro)
        self.assertEqual(0, changeTest.twentyEuro)
        self.assertEqual(0, changeTest.fiftyEuro)


if __name__ == '__main__':
    unittest.main()
        