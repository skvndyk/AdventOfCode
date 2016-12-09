from hashlib import md5

password = "ckczppom"
foundNumber = bool(0)
x = 0

while not foundNumber:
    print(x)
    result = md5((password + str(x)).encode()).hexdigest()
    if len(result) >= 5:
        if result[0:6] == "000000":
            foundNumber = bool(1)
        else:
            x += 1

print('{0} is the smallest number'.format(x))




