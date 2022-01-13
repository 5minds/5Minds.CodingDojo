from sys import argv
from Calculator.ChangeReturnCalculator import ChangeReturnCalculator
from Helper.CheckInputValue import CheckInputValue

if (len(argv) >= 3):
   if (CheckInputValue.CheckValueIsValid(argv[1], argv[2])):
        print("Total Costs:\t" + argv[1])
        print("Total Paid:\t" + argv[2])
        print("\n")
        ChangeReturnCalculator.GetChangeReturn(argv[1],argv[2])
else: 
    print('At least two parameters must be specified. Parameter one contains the purchase amount and parameter two contains the given money in decimal format.')