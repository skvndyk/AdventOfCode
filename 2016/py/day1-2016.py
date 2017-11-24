def readSteps(fileName):
    with open(fileName, 'r') as f:
        data = f.read()
        steps = data.replace(',', '').split(" ")
    return steps

def rotate(rotateDir, facingDir):
    if rotateDir == 'L':
        facingDir -= 1
    else:
        facingDir += 1
    facingDir %= 4
    return facingDir

def main():

    # dirs are starting at n, going clockwise
    dirs = 'nesw'
    multipliers = [1, 1, -1, -1]

    facingDir = 0
    firstTwiceVisted = ()
    foundFTV = bool(0)

    x = 0
    y = 0
    coords = [(0, 0)]
    passedThrough = []

    steps = readSteps("day1-2016.txt")
    for step in steps:
        rotateDir = step[0]
        stepNum = int(step[1:])
        facingDir = rotate(rotateDir, facingDir)
        scalar = multipliers[facingDir]

        if foundFTV == bool(0):
            if dirs[facingDir] in "ns":
                for yAdd in range(1, stepNum + 1):
                    yCoord = y + (yAdd * scalar)
                    passedLocation = (x, yCoord)
                    if passedLocation in passedThrough:
                        firstTwiceVisted = passedLocation
                        foundFTV = bool(1)
                    else:
                        passedThrough.append(passedLocation)

            else:
                for xAdd in range(1, stepNum + 1):
                    xCoord = x + (xAdd * scalar)
                    passedLocation = (xCoord, y)
                    if passedLocation in passedThrough:
                        firstTwiceVisted = passedLocation
                        foundFTV = bool(1)
                    else:
                        passedThrough.append(passedLocation)

        if dirs[facingDir] in "ns":
            y += (stepNum*scalar)
        else:
            x += (stepNum*scalar)
        location = (x, y)

    firstDistance = abs(location[0]) + abs(location[1])
    secondDistance = abs(firstTwiceVisted[0]) + abs(firstTwiceVisted[1])
    print(firstDistance)
    print(secondDistance)

main()



