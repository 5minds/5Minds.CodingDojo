import sys
import math
import time
from datetime import datetime
from termcolor import cprint
import select

# calculates the division and module of two numbers
def divMod(x,y):
    div = int(math.floor(x / y))
    mod = int(x - (div * y))

    return div, mod

# clears the screent to show the current time
def clearScreen():   
    print(chr(27) + '[2J')

# moves the cursor to the new line
def newLine():
    print('\n')

# places a separator
def separator():
   cprint('|', 'cyan', end = '') 

# places a big light for minutes
def minutesBigLight():
   cprint('########', 'yellow', end = '') 
   
# places a big light for hour
def hourBigLight():
   cprint('########', 'red', end = '') 

# places an off big light
def offBigLight():
   print('        ', end = '') 

# places a red small light
def smallRedLight():
   cprint('##', 'red', end = '') 
   
# places a yellow small light
def smallYellowLight():
   cprint('##', 'yellow', end = '') 

# places an off small light
def smallOffLight():
   print('  ', end = '') 

# turns on a flashing light every second
def writeSecondBit(bit):
    if bit == 0:
        cprint('@', 'yellow', end = '') 
    else:
        print(' ', end = '') 

    newLine()

# turns on some (parameter: count, up to 4) big lights
#    with the given color (red for hour or yellow for minutes)
def writeHourBigLights(count):
    separator()

    for x in range(0, count):
        hourBigLight()
        separator()

    for x in range(0, 4 - count):
        offBigLight() 
        separator()

    newLine()

# turns on some (parameter: count, up to 4) big lights
#    with the given color (red for hour or yellow for minutes)
def writeMinutesBigLights(count):
    separator()

    for x in range(0, count):
        minutesBigLight()
        separator()

    for x in range(0, 4 - count):
        offBigLight() 
        separator()

    newLine()

# turns on some (parameter: count, up to 11) small lights
def writeSmallLights(count):
    separator()
  
    for x in range(0, count):
        if (x + 1) % 3 == 0:
            smallRedLight() 
        else:
            smallYellowLight()
        separator()

    for x in range(0, 11 - count):
        smallOffLight()
        separator()

    newLine()

# gets the current time and calculates the number of
#    turned on lights in each row
def calculateClockSegments():  
    now = time.localtime()

    hours = now.tm_hour
    minutes = now.tm_min
    
    sec_bit = now.tm_sec % 2

    hour_fives, hour_ones = divMod(hours, 5)
    min_fives, min_ones = divMod(minutes, 5)
 
    return [sec_bit, hour_fives, hour_ones, min_fives, min_ones]   

# sccepts the number of turned on lights in each row
#    and draws the clock accordingly
def showClock(segments):
    # to test the functionality
    print(datetime.now().strftime("%H:%M"))

    writeSecondBit(segments[0])
    writeHourBigLights(segments[1])
    writeHourBigLights(segments[2])
    writeSmallLights(segments[3])
    writeMinutesBigLights(segments[4])


# main
if __name__ == '__main__':
    while (True):
        clearScreen()
        showClock(calculateClockSegments())
        time.sleep(1)