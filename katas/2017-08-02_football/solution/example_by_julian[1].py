import os.path
import sys

situation = open(os.path.join('../utils', "situation_1.txt"), "r").readlines()

for item in situation:
    item = list(item)
    if item[0] == '|':
        item[0] = 'o'
        item[-1] = 'o'
vector = ''.join(situation[-1])
vector = vector.split('|')
vector = vector[0].split('(')
vector = int(vector[1])
if vector <= 0:
    sys.exit('Der Spieler schießt in die falsche Richtung')

