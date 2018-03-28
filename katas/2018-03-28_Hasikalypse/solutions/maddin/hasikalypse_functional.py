import sys
import numpy

startMales = 1
startFemales = 1
maxPopulation = 1000

if len(sys.argv) > 1:
    startMales = int(sys.argv[1])
    startFemales = int(sys.argv[2])
    maxPopulation = int(sys.argv[3])

males = [2] * startMales 
females = [2] * startFemales

age = 0

while(True):
    age = age + 1

    males = list(filter(lambda m: m < (8*12), males)) #males[lambda m:m < (8*12)])
    females = list(filter(lambda f: f < (8*12), females)) #females[lambda f:f < (8*12)])

    breeder = len(list(filter(lambda f:f >= 4, females)))

    males = [m+1 for m in males]
    females = [f+1 for f in females]

    males.extend([0] * (breeder * 5))
    females.extend([0] * (breeder * 9))

    population = len(males) + len(females)

    print (str(age), ": ", population, "\t breeder: ", breeder, "\t new born:", breeder * 14)

    if population > maxPopulation:
        break

print()
print("Population of more than ", str(maxPopulation), " was reached after " + str(age) + " months.")
