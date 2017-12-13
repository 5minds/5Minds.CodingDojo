with open ("../../input/routen.txt", "r") as myfile:
    data=myfile.readlines()

for line in data:
    houses = [ [0,0] ]
    position = [0, 0]

    for char in line.replace('\n', ''):
        if char == '^':
            position[1] = position[1] + 1
        
        elif char == '<':
            position[0] = position[0] - 1

        elif char == 'v':
            position[1] = position[1] -1

        elif char == '>':
            position[0] = position[0] + 1

        if position not in houses:
            houses.append(list(position))

    print len(houses)