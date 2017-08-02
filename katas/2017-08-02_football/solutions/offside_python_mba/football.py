
def main():
    lines = readFile('examples\situation_4.txt')

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

def scanLineForOffside(lines, scanline):
    defenseCount = 0
    offenseCount = 0
    for position in range(0, 45):
        if lines[position][scanline] == 'x':
            defenseCount = defenseCount + 1
        elif lines[position][scanline] == '+':
            offenseCount = offenseCount + 1

    if (offenseCount >= defenseCount) and (offenseCount > 0):
        return True

    return False

def scanFieldForOffside(lines):
    offside = False
    scanline = 60

    while (not offside) and scanline > 30:
        offside = scanLineForOffside(lines, scanline)
        scanline = scanline - 1

    return offside

def scanFieldForPlayer(lines):
    hasPlayer = False
    for line in lines:        
        hasPlayer = hasPlayer or ('+' in line) or ('x' in line)

    return hasPlayer

if __name__ == '__main__':
    main()