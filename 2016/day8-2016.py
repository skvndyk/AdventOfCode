# dim: 50 wide x 6 tall
from collections import OrderedDict

def makerectangle(dimensions, grid):
    stripped_dimensions = dimensions.split('x')
    width = int(stripped_dimensions[0])
    height = int(stripped_dimensions[1])
    for w in range(width):
        for h in range(height):
            grid[(w, h)] = '#'
    return grid


def shiftpixels(parameters, grid, width, height):
    group_type = parameters[0]
    axis_num = int(parameters[1].split("=")[1])
    num_to_shift = int(parameters[3])
    new_grid = grid.copy()
    if group_type == 'row':
        for x in range(width):
            move_x_pos = (x + num_to_shift) % width
            new_grid[(move_x_pos, axis_num)] = grid[(x, axis_num)]
    else:
        for y in range(height):
            move_y_pos = (y + num_to_shift) % height
            new_grid[(axis_num, move_y_pos)] = grid[(axis_num, y)]
    return new_grid


def makegrid(width, height):
    return OrderedDict.fromkeys([(x, y) for x in range(0, width) for y in range(0, height)], '.')


def printgrid(grid, width, height):
    for h in range(height):
        print("\n")
        for w in range(width):
            print(grid[w, h], end='')
    print("\n")

def printgrid5(grid, width, height):
    for w1 in range(0, width, 5):
        for h in range(height):
            print("\n")
            for w2 in range(w1, w1+5):
                print(grid[w2, h], end='')
        print("\n")
    print("\n")

if __name__ == "__main__":
    lit_pixels = 0
    with open('day8-2016.txt', 'r') as f:
        width = 50
        height = 6
        grid = makegrid(width, height)
        for line in f:
            instructions = line.rstrip().split(" ")
            if instructions[0] == 'rect':
                grid = makerectangle(instructions[1], grid)
            else:
                grid = shiftpixels(instructions[1:5], grid, width, height)
    for value in grid.items():
        if value[1] == '#':
            lit_pixels += 1
    printgrid5(grid, width, height)
    print(lit_pixels)