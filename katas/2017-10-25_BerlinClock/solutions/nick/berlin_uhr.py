import sys
import math
import time
from datetime import datetime
from termcolor import cprint

def divMod(x,y):
    div = int(math.floor(x / y))
    mod = int(x - (div * y))

    return div, mod

def newLine():
    print('\n')

def separator():
   cprint('|', 'cyan', end = '') 

def minutesBigLight():
   cprint('########', 'yellow', end = '') 
   
def hourBigLight():
   cprint('########', 'red', end = '') 

def offBigLight():
   print('        ', end = '') 

def minutesSmallRedLight():
   cprint('##', 'red', end = '') 
   
def minutesSmallYellowLight():
   cprint('##', 'yellow', end = '') 

def minutesSmallOffLight():
   print('  ', end = '') 

def clearScreen():   
    print(chr(27) + '[2J')

def writeSecondBit(bit):
    if bit == 0:
        cprint('@', 'yellow', end = '') 
    else:
        print(' ', end = '') 

    newLine()

def writeHourBigLights(count):
    separator()

    for x in range(0, count):
        hourBigLight()
        separator()

    for x in range(0, 4 - count):
        offBigLight() 
        separator()

    newLine()

def writeMinutesBigLights(count):
    separator()

    for x in range(0, count):
        minutesBigLight()
        separator()

    for x in range(0, 4 - count):
        offBigLight() 
        separator()

    newLine()

def writeSmallLights(count):
    separator()
  
    for x in range(0, count):
        if (x + 1) % 3 == 0:
            minutesSmallRedLight() 
        else:
            minutesSmallYellowLight()
        separator()

    for x in range(0, 11 - count):
        minutesSmallOffLight()
        separator()

    newLine()

def calculateClockSegments():  
    now = time.localtime()

    hours = now.tm_hour
    minutes = now.tm_min
    
    sec_bit = now.tm_sec % 2

    hour_fives, hour_ones = divMod(hours, 5)
    min_fives, min_ones = divMod(minutes, 5)
 
    return [sec_bit, hour_fives, hour_ones, min_fives, min_ones]   

def showClock(segments):
    clearScreen()
    
    print(datetime.now().strftime("%H:%M"))

    writeSecondBit(segments[0])
    writeHourBigLights(segments[1])
    writeHourBigLights(segments[2])
    writeSmallLights(segments[3])
    writeMinutesBigLights(segments[4])

if __name__ == '__main__':
    while (True):
        showClock(calculateClockSegments())
        time.sleep(1)