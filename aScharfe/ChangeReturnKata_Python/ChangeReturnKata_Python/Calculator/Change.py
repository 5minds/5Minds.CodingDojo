from decimal import Decimal

class Change(object):
    def __init__(self,changeReturn):
        self.hundredEuro = int(changeReturn / 100)
        changeReturn %= 100        
        
        self.fiftyEuro = int(changeReturn / 50)
        changeReturn %= 50
        
        self.twentyEuro = int(changeReturn / 20)
        changeReturn %= 20
        
        self.tenEuro = int(changeReturn / 10)
        changeReturn %= 10
        
        self.fiveEuro = int(changeReturn / 5)
        changeReturn %= 5        
        
        self.fiftyCent = int(changeReturn / Decimal('0.5'))        
        changeReturn %= Decimal('0.5')

        self.twentyCent = int(changeReturn / Decimal('0.2'))        
        changeReturn %= Decimal('0.2')

        self.tenCent = int(changeReturn / Decimal('0.1'))        
        changeReturn %= Decimal('0.1')

        self.fiveCent = int(changeReturn / Decimal('0.05'))        
        changeReturn %= Decimal('0.05')

        self.twoCent = int(changeReturn / Decimal('0.02'))        
        changeReturn %= Decimal('0.02')

        self.oneCent = int(changeReturn / Decimal('0.01'))

   


