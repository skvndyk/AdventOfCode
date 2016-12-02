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

    print("Code to square grid: {}".format(squareCode(lines)))
    print("Code to square grid: {}".format(diamondCode(lines)))

def squareCode(lines):
    boundary = len(SQUARE_GRID)

    loc = [1, 1]
    code = ""

    for line in lines:
        for step in line:
            direction = DIRECTIONS[step]
            loc = [x + y for x, y in zip(direction, loc)]
            while not(all(pt in range(0, boundary) for pt in loc)):
                loc = goBack(loc, direction)
        num = str(SQUARE_GRID[loc[0]][loc[1]])
        code += num
    return code

def goBack(loc, direction):
    return [x + y for x, y in zip([-x for x in direction], loc)]

def diamondCode(lines):
    boundary = len(DIAMOND_GRID)
    loc = [2, 0]
    code = ""

    for line in lines:
        for step in line:
            direction = DIRECTIONS[step]
            loc = [x + y for x, y in zip(direction, loc)]
            while not(all(pt in range(0, boundary) for pt in loc)) or DIAMOND_GRID[loc[0]][loc[1]] == '*':
                loc = goBack(loc, direction)
        num = str(DIAMOND_GRID[loc[0]][loc[1]])
        code += num
    return code


main()
