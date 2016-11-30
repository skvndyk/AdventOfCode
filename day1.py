floor = 0
with open('day1-2015.txt', 'r') as f:
    data = f.read()
for char in data:
    if char == '(':
        floor += 1
    else:
        floor -= 1

print(floor)

