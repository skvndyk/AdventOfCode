from hashlib import md5

password = "ckczppom".encode('utf-8')
foundNumber = bool(0)
x = 0

while not foundNumber:
    print(x)
    result = md5((password + str(x)).encode()).hexdigest()
    if len(result) >= 5:
        if str(result[0:6]) == "00000":
            foundNumber = bool(1)
        else:
            x += 1

print('{0} is the smallest number'.format(x))
# print(type(passHash.digest()))



