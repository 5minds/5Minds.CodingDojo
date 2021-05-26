from Calculator.Change import Change
from decimal import Decimal

class ChangeReturnCalculator():
    def __init__(self):
        self.ChangeOutputMapping = {
            "hundredEuro": "Hundred Euro:\t",
            "fiftyEuro": "Fifty Euro:\t",
            "twentyEuro": "Twenty Euro:\t", 
            "tenEuro": "Ten Euro:\t",
            "fiveEuro": "Five Euro:\t", 
            "fiftyCent": "Fifty Cent:\t", 
            "twentyCent": "Twenty Cent:\t",
            "tenCent": "Ten Cent:\t", 
            "fiveCent": "Five Cent:\t",
            "twoCent": "Two Cent:\t",
            "oneCent": "One Cent:\t"
        }
    
    def PrintChangeResult(change):
        calculator = ChangeReturnCalculator()       
        for attr, value in change.__dict__.items():
           if (value > 0 ):
               print(calculator.ChangeOutputMapping[attr], value)

    def GetChangeReturn(costs, paid):
       changeValue = Decimal(paid) - Decimal(costs)
       change = Change(changeValue)
       ChangeReturnCalculator.PrintChangeResult(change)


    
        