def dumbWay(sides):
    x = 0
    if ((sides[0] + sides[1]) > sides[2]) and ((sides[0] + sides[2]) > sides[1]) and ((sides[1] + sides[2]) > sides[0]):
        x = 1
    return x

def betterWay(sides):
    x = 1
    for idx in range(0, 3):
        thirdSide = sides[idx]
        smallerSides = [s for s in sides if s != thirdSide]
        if sum(smallerSides) < thirdSide:
            x = 0
            break
    return x

if __name__ == "__main__":
    numPossibleDumb = 0
    numPossibleBetter = 0

    with open('day3-2016.txt', 'r') as f:
        for line in f:

            sides = line.strip().split("  ")
            sides = [s for s in sides if len(s) > 0]
            sides = [int(s.strip()) for s in sides]
            numPossibleDumb += dumbWay(sides)
            numPossibleBetter += betterWay(sides)

    print("Dumb way is {}".format(numPossibleDumb))
    print("Better way is {}".format(numPossibleBetter))