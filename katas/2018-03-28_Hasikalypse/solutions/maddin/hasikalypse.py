import sys
import numpy

# 8 Jahre
# 14 Nachkommen 5m 9w
# ab 4 Monate

class Rabbit:
    def __init__(self, isFemale):
        self.isFemale = isFemale
        self.ageInMonths = 0

class Population:
    def __init__(self, males, females):
    
        self.population = []
        self.age = 0

        for males in range(0, startMales):
            self.add_rabbit(False)

        for females in range(0, startFemales):
            self.add_rabbit(True)

        for rabbit in self.population:
            rabbit.ageInMonths = 2

    def add_rabbit(self, isFemale):
        rabbit = Rabbit(isFemale)
        self.population.append(rabbit)

    def kill(self, rabbit):
        self.population.remove(rabbit)

    def breed(self, rabbit):
        
        newBorn = []

        for i in range(0, 5):
            rabbit = Rabbit(False)
            newBorn.append(rabbit)

        for i in range(0, 9):
            rabbit = Rabbit(True)
            newBorn.append(rabbit)
        
        return newBorn

    def next_month(self):
        self.age = self.age + 1
        breeder = 0

        newBorn = []
        dead = []
                
        for rabbit in self.population:

            if rabbit.ageInMonths > 8 * 12:
                dead.append(rabbit)
                continue

            if rabbit.ageInMonths >= 4 and rabbit.isFemale:
                newBorn.extend(self.breed(rabbit))
                breeder = breeder + 1 

            rabbit.ageInMonths = rabbit.ageInMonths + 1
        print (str(self.age), ": ", len(self.population), "\t breeder: ", breeder, "\t new born:", len(newBorn))
        
        for rabbit in dead:
            self.kill(rabbit)

        self.population.extend(newBorn)



startMales = 1
startFemales = 1
maxPopulation = 1000

if len(sys.argv) > 1:
    startMales = int(sys.argv[1])
    startFemales = int(sys.argv[2])
    maxPopulation = int(sys.argv[3])

population = Population(startMales, startFemales)

while(True):
    population.next_month()

    if len (population.population) > maxPopulation:
        break

print(population.age)
