x = 0
y = 0
coords = [(0,0)]

with open('day3-2015.txt', 'r') as f:
    data = f.read()
    for char in data:
        if char == "^":
            y += 1
        elif char == "v":
            y -= 1
        elif char == ">":
            x += 1
        elif char == "<":
            x -= 1
        coords.append((x,y))

print(len(set(coords)))
