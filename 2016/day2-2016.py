SQUARE_GRID = [(1, 2, 3), (4, 5, 6), (7, 8, 9)]

DIAMOND_GRID = [('*', '*', '1', '*', '*'),
                ('*', '2', '3', '4', '*'),
                ('5', '6', '7', '8', '9'),
                ('*', 'A', 'B', 'C', '*'),
                ('*', '*', 'D', '*', '*')]

DIRECTIONS = {
    "U": [-1, 0],
    "D": [1, 0],
    "L": [0, -1],
    "R": [0, 1]
}


def main():
    lines = open('day2-2016.txt').read().splitlines()

    # print(squareCode(lines))
    print(diamondCode(lines))

def squareCode(lines):
    loc = [1, 1]
    code = ""

    for line in lines:
        for step in line:
            direction = DIRECTIONS[step]
            loc = [x + y for x, y in zip(direction, loc)]
            if loc[0] > 2:
                loc[0] = 2
            if loc[0] < 0:
                loc[0] = 0
            if loc[1] > 2:
                loc[1] = 2
            if loc[1] < 0:
                loc[1] = 0
        num = str(SQUARE_GRID[loc[0]][loc[1]])
        code += num
    return code

def goBack(loc, direction):
    return [x + y for x, y in zip([-x for x in direction], loc)]

def diamondCode(lines):
    loc = [2, 0]
    code = ""

    for line in lines:
        for step in line:
            direction = DIRECTIONS[step]
            loc = [x + y for x, y in zip(direction, loc)]
            while (loc[0] > 4) or (loc[0] < 0) or (loc[1] > 4) or (loc[1] < 0) or DIAMOND_GRID[loc[0]][loc[1]] == '*':
                loc = goBack(loc, direction)
        num = str(DIAMOND_GRID[loc[0]][loc[1]])
        code += num
    return code


main()
