import hashlib

password = "ckczppom".encode('utf-8')

passHash = hashlib.md5()
passHash.update(password)

foundNumber = bool(0)
print(foundNumber)
x = 0

while not foundNumber:
    startHash = passHash
    encodedX = str(x).encode('utf-8')
    startHash.update(encodedX)

    result = passHash.hexdigest()
    print(x)
    if len(result) >= 5:
        if str(result[0:6]) == "00000":
            foundNumber = bool(1)
        else:
            x += 1

print('{0} is the smallest number'.format(x))
# print(type(passHash.digest()))



