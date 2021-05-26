import decimal

class CheckInputValue():
    
    def  CheckValueIsValid(firstArgument, secondArgument):        
        if CheckInputValue.RepresentsDecimal(firstArgument):
            firstArgument = decimal.Decimal(firstArgument)
        else:
            print(firstArgument + "\tThe first argument is not a valid Decimal number.")
            return False
        if CheckInputValue.RepresentsDecimal(secondArgument):
            secondArgument = decimal.Decimal(secondArgument)
            if (firstArgument < secondArgument):
                return True
            else:
                print("The purchase amount must not be greater than the given amount.\n")
                return False
        else:
            print(secondArgument + "\tThe second argument is not a valid Decimal number.")
            return False

    def RepresentsDecimal(stringValue):
        try:
            decimal.Decimal(stringValue)
            return True
        except decimal.InvalidOperation:
            return False
