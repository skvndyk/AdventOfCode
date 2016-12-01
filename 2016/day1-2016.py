# dirs are starting at n, going clockwise
dirs = ['n', 'e', 's', 'w']
facingDir = 0
firstTwiceVisted = ()
foundFTV = bool(0)

x = 0
y = 0
coords = [(0, 0)]
timesVisited = {}

with open('day1-2016.txt', 'r') as f:
    data = f.read()
    steps = data.replace(',', '').split(" ")

for step in steps:
    rotateDir = step[0]
    stepNum = int(step[1:])
    if rotateDir == 'L':
        facingDir -= 1
    else:
        facingDir += 1
    facingDir %= 4
    if dirs[facingDir] == 'n':
        y += stepNum
    elif dirs[facingDir] == 's':
        y -= stepNum
    elif dirs[facingDir] == 'w':
        x -= stepNum
    elif dirs[facingDir] == 'e':
        x += stepNum
    location = (x, y)
    coords.append(location)

firstDistance = abs(location[0]) + abs(location[1])
print(firstDistance)





