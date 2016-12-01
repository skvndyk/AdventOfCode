# dirs are starting at n, going clockwise
dirs = ['n', 'e', 's', 'w']
facingDir = 0

x = 0
y = 0
coords = [(0, 0)]


with open('day1-2016.txt', 'r') as f:
    data = f.read()
    steps = data.replace(',', '').split(" ")

for step in steps:
    rotateDir = step[0]
    stepNum = int(step[1])
    if rotateDir == 'L':
        facingDir -= 1
        while facingDir < 0:
            facingDir += 4
    else:
        facingDir += 1
        while facingDir > 3:
            facingDir -= 4
    if facingDir == 0:
        y += stepNum
    elif facingDir == 1:
        x += stepNum
    elif facingDir == 2:
        y -= stepNum
    elif facingDir == 3:
        x -= stepNum
    coords.append((x, y))

lenCoords = len(coords)
endPos = coords[lenCoords - 1]
distance = abs(endPos[0]) + abs(endPos[1])
print(distance)



