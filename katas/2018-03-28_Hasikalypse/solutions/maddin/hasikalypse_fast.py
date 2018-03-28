import sys
import numpy

startMales = 1
startFemales = 1
maxPopulation = 1000

if len(sys.argv) > 1:
    startMales = int(sys.argv[1])
    startFemales = int(sys.argv[2])
    maxPopulation = int(sys.argv[3])

males = [0] * 96
females = [0] * 96

males[2] = startMales
females[2] = startFemales

age = 0


while(True):
    age = age + 1

    breeder = 0
    population = 0

    breeder = sum(females[4:96])

    for i in range(95, 0, -1):
        males[i] = males[i-1]
        females[i] = females[i-1]

    males[0] = breeder * 5
    females[0] = breeder * 9

    population = population + sum(males) + sum(females)

    print (str(age), ": ", population, "\t breeder: ", breeder, "\t new born:", breeder * 14)

    if population > maxPopulation:
        break

print()
print("Population of more than ", str(maxPopulation), " was reached after " + str(age) + " months.")
