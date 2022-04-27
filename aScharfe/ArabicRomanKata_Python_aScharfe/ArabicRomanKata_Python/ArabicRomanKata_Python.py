from sys import argv
from Converter.ArabicRomanConverter import ArabicRomanConverter
from Helper.CheckInputValue import CheckInputValue

if (len(argv) == 2):
    if (CheckInputValue.CheckValueIsValid(argv[1])):
        print(ArabicRomanConverter.Convert(argv[1]))
else: 
    print('An error occurred during processing. Please specify exact one parameter and valid Arabic or Roman numerals.')