from Helper.CheckInputValue import CheckInputValue

class ArabicRomanConverter():
    def __init__(self):
        self.ArabicRomanMapping = {
            1000: "M",
            900: "CM",
            500: "D", 
            400: "CD",
            100: "C", 
            90: "XC", 
            50: "L",
            40: "XL", 
            10: "X",
            9: "IX",
            5: "V",
            4: "IV",
            1: "I" 
        }

        self.RomanArabicMapping = {
             'I': 1,
             'V': 5,
             'X': 10,
             'L': 50,
             'C': 100,
             'D': 500,
             'M': 1000
        }


    def Convert(valueToBeConvert):        
        if (CheckInputValue.GetConversionDirection(valueToBeConvert) == 1):
            return ArabicRomanConverter.__ConvertRomanToArabic(valueToBeConvert)
        elif (CheckInputValue.GetConversionDirection(valueToBeConvert) == 2):
            return ArabicRomanConverter.__ConvertArabicToRoman(valueToBeConvert)
        else:
            return valueToBeConvert + "   Cannot be converted."

    def __ConvertArabicToRoman(numberToBeConvert):
        numberToBeConvert = int(numberToBeConvert)           
        converter = ArabicRomanConverter()
        
        romanNumber = ""
        for key in converter.ArabicRomanMapping:
            #This works only with the defined sorted ArabicRomanMapping.
            while numberToBeConvert >= key:            
                romanNumber += converter.ArabicRomanMapping[key]
                numberToBeConvert -= key
        return romanNumber

    def __ConvertRomanToArabic(romanNumber):
        converter = ArabicRomanConverter()
        arabicResult = 0
        previousRoman = 0
        romanNumber = romanNumber.upper()

        for currentRoman in romanNumber:
            if previousRoman == 0:
                previousValue = previousRoman
            else:
                previousValue = converter.RomanArabicMapping[previousRoman]
            currentValue = converter.RomanArabicMapping[currentRoman]

            # Consideration of the subtraction rules
            if (previousValue != 0) & (currentValue > previousValue):
                # Subtraction rule
                arabicResult = arabicResult - (2 * previousValue) + currentValue
            else:                
                arabicResult += currentValue
            previousRoman = currentRoman
            
        return arabicResult


    
    