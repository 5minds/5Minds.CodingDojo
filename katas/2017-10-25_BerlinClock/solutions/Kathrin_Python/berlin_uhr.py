
import time
import colorama
from colorama import Fore, init
import sys
import select

init()

def printline():   
    print '-----------------------'

def print4Segment(countLitSegments):
    if (countLitSegments == 0):
        print "|    |     |     |    |"
    elif (countLitSegments == 1):
        print "|XXXX|     |     |    |"
    elif (countLitSegments == 2):
        print "|XXXX|XXXXX|     |    |"
    elif (countLitSegments == 3):
        print "|XXXX|XXXXX|XXXXX|    |"
    else:
        print "|XXXX|XXXXX|XXXXX|XXXX|"

def print11Segment(countLitSegments):
    line = "|"
    counter = 0
    while counter < 11:
        if (counter < countLitSegments):
            if (counter%3 == 2):
                line = line + Fore.RED+"X"+ Fore.RESET
            else:
                line = line + "X"
        else:
            line = line + " "
        line = line + "|"
        counter = counter + 1
    print (line)

def calcSegmentInfo(current_time):    
    hour_dec = current_time.tm_hour
    min_dec = current_time.tm_min

 #   print "current_time " + str(current_time)
 #   print "hour_dec " + str(hour_dec)
 #   print "min_dec " + str(min_dec)

    hour_fives = hour_dec // 5
    hour_ones = hour_dec % 5

 #   print "hour_fives " + str(hour_fives)
 #   print "hour_ones " + str(hour_ones)

    min_fives = min_dec // 5
    min_ones = min_dec % 5
 #   print "min_fives " + str(min_fives)
 #   print "min_ones " + str(min_ones)
    return {"hour_fives":hour_fives, "hour_ones":hour_ones, "min_fives":min_fives, "min_ones":min_ones}


def printSegmentClock(segmentInfo):
    print(chr(27) + "[2J")
    printline()
    print4Segment(segmentInfo["hour_fives"])
    printline()
    print4Segment(segmentInfo["hour_ones"])
    printline()
    print11Segment(segmentInfo["min_fives"])
    printline()
    print4Segment(segmentInfo["min_ones"])
    printline()

while (True):
    segmentInfo = calcSegmentInfo(time.localtime())
    printSegmentClock(segmentInfo)
    time.sleep(60)

