with open('day1-2015.txt', 'r') as f:
    data = f.read()

floor = 0
idx = 1
firstBasementChar = ""
basementReached = bool(0)

for char in data:
    if char == '(':
        floor += 1
    else:
        floor -= 1
    if basementReached == bool(0):
        if floor == -1:
            firstBasementChar = idx
            basementReached = bool(1)
    idx += 1

print(floor)
print(firstBasementChar)


