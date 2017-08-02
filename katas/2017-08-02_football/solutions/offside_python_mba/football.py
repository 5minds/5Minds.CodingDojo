
offSidePossible = True
defenders = 0

def main():
    lines = readFile('solutions/offside_python_mba/examples/situation_5.txt')

    hasPlayer = scanFieldForPlayer(lines)
    if hasPlayer:        
        result = scanFieldForOffside(lines)

        if result:
            print('Es ist eine Abseitsposition vorhanden')
        else:
            print('Kein Abseits!')
    else:
        print('Ist leider ein falsches Bild.')

def readFile(filename):
    lines = open(filename).readlines()
    return lines

def scanLineForOffside(field, scanline):
    defenseCount = 0
    offenseCount = 0
    lastDefensePosition = 0
    global offSidePossible
    global defenders
    for position in range(0, 45):
        #print field[position]
        #print position, scanline
        if field[position][scanline] == 'x':
            if lastDefensePosition == 0:
                lastDefensePosition = position
                if field[position][scanline-1] != 'x':
                    defenseCount = defenseCount + 1
            elif lastDefensePosition + 2 < position:
                defenseCount = defenseCount + 1
                lastDefensePosition = lastDefensePosition + 1
        elif field[position][scanline] == '+':
            offenseCount = 1

    if defenseCount > 0:
        defenders = defenders + 1

    if defenseCount > 1 or defenders > 1:
        offSidePossible = False

    if (offenseCount >= defenseCount) and (offenseCount > 0):
        return True

    return False

def scanFieldForOffside(field):
    offside = False
    scanline = 60

    while offSidePossible and (not offside) and scanline > 30:
        offside = scanLineForOffside(field, scanline)
        scanline = scanline - 1

    return offside and offSidePossible

def scanFieldForPlayer(lines):
    hasPlayer = False
    for line in lines:        
        hasPlayer = hasPlayer or ('+' in line) or ('x' in line)

    return hasPlayer

if __name__ == '__main__':
    main()