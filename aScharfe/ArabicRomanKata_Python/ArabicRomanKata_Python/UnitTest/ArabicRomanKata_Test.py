import unittest
from Helper.CheckInputValue import CheckInputValue
from Converter.ArabicRomanConverter import ArabicRomanConverter


class ArabicRomanKataTest(unittest.TestCase):
    def test_CheckInputValue(self):
        self.assertTrue(CheckInputValue.CheckValueIsValid("1"),)
        self.assertTrue(CheckInputValue.CheckValueIsValid("12"))
        self.assertTrue(CheckInputValue.CheckValueIsValid("123"))
        self.assertTrue(CheckInputValue.CheckValueIsValid("1234"))
        self.assertTrue(CheckInputValue.CheckValueIsValid("I"))
        self.assertTrue(CheckInputValue.CheckValueIsValid("XII"))
        self.assertTrue(CheckInputValue.CheckValueIsValid("CXXIII"))
        self.assertTrue(CheckInputValue.CheckValueIsValid("MCCXXXIV"))
        self.assertTrue(CheckInputValue.CheckValueIsValid("MMMCMXCIX"))
        
        self.assertFalse(CheckInputValue.CheckValueIsValid(""))
        self.assertFalse(CheckInputValue.CheckValueIsValid("0"))
        self.assertFalse(CheckInputValue.CheckValueIsValid("4000"))
        self.assertFalse(CheckInputValue.CheckValueIsValid("12345"))
        self.assertFalse(CheckInputValue.CheckValueIsValid("123d"))
        self.assertFalse(CheckInputValue.CheckValueIsValid("d123"))

        self.assertFalse(CheckInputValue.CheckValueIsValid("MMMMMM"))
        self.assertFalse(CheckInputValue.CheckValueIsValid("P"))

    def test_ArabicRomanConverter(self):
        self.assertEqual(ArabicRomanConverter.Convert(""),"   Cannot be converted.","Convert empty string")
        self.assertEqual(ArabicRomanConverter.Convert("0"),"","Convert 0")

        self.assertEqual(ArabicRomanConverter.Convert("1"),"I","Convert 1")
        self.assertEqual(ArabicRomanConverter.Convert("1974"),"MCMLXXIV","Convert 1974")
        self.assertEqual(ArabicRomanConverter.Convert("3999"),"MMMCMXCIX", "Convert 3999")
        
        
        self.assertEqual(ArabicRomanConverter.Convert("I"),1,"Convert I")
        self.assertEqual(ArabicRomanConverter.Convert("MMMCMXCIX"),3999,"Convert MMMCMXCIX")
        self.assertEqual(ArabicRomanConverter.Convert("MCMLXXIV"),1974,"Convert MCMLXXIV")
        self.assertEqual(ArabicRomanConverter.Convert("mcmlxxiv"),1974,"Convert MCMLXXIV")



if __name__ == '__main__':
    unittest.main()
        