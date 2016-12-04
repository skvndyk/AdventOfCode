def sideTest(sides):
    x = 1
    for idx in range(0, 3):
        thirdSide = sides[idx]
        # otherSideIdxs = [i for i in range(0, 3) if i != idx]
        smallerSides = [sides[i] for i in [z for z in range(0, 3) if z != idx]]
        if sum(smallerSides) <= thirdSide:
            x = 0
            break
    return x

if __name__ == "__main__":
    numPossibleRow = 0
    numPossibleCol = 0

    allRows = []
    allColumns = []

    with open('day3-2016.txt', 'r') as f:
        for line in f:
            sides = line.strip().split("  ")
            sides = [s for s in sides if len(s) > 0]
            sides = [int(s.strip()) for s in sides]
            allRows.append(sides)
            numPossibleRow += sideTest(sides)

    allColumns = list(zip(*allRows))
    for col in allColumns:
        idx = 0
        while (idx + 3) <= len(col):
            sides = col[idx:idx+3]
            numPossibleCol += sideTest(sides)
            idx += 3

    print("Part 1: {}".format(numPossibleRow))
    print("Part 2: {}".format(numPossibleCol))