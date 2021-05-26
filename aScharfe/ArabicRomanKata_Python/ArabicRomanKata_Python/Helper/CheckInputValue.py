import re

class CheckInputValue():
    
    def  CheckValueIsValid(inputValue):
        if CheckInputValue.RepresentsInt(inputValue):
            arabicNumber = int(inputValue)
            if (arabicNumber > 0) & (arabicNumber < 4000):
                return True
            else:
                print(inputValue + "    The Arabic numeral is outside the valid range. Valid are numbers from 1 - 3999.")
                return False
        elif CheckInputValue.RepresentsRomanNumber(inputValue):
            return True
        else:
            print(inputValue + " Is not a valid Roman numeral and not a valid Arabic numeral.")
            return False

    def GetConversionDirection(inputValue):
        if CheckInputValue.RepresentsRomanNumber(inputValue):
            return 1
        if CheckInputValue.RepresentsInt(inputValue):
            return 2

        return 0

    def RepresentsInt(stringValue):
        try:
            int(stringValue)
            return True
        except ValueError:
            return False

    def RepresentsRomanNumber(stringValue):
        if (len(stringValue) == 0):
            return False

        match = re.match("^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$",stringValue,re.IGNORECASE)
        if (match != None):
            return True
        else:
            return False
