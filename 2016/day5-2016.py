from hashlib import md5


def partOne(doorID):
    i = 0
    x = 0
    password = ""
    while i < 8:
        foundResult = bool(0)
        while foundResult == bool(0):
            result = md5((doorID + str(x)).encode()).hexdigest()
            if len(result) >= 5:
                if result[0:5] == "00000":
                    password += result[5]
                    foundResult = bool(1)
                    x += 1
                    i += 1
                else:
                    x += 1
    return password

def partTwo(doorID):
    passwordDict = dict.fromkeys(range(0, 8))
    posFilled = 0
    x = 0
    while posFilled < 8:
        result = md5((doorID + str(x)).encode()).hexdigest()
        if len(result) >= 5:
            if result[0:5] == "00000":
                pos = result[5]
                if (ord(pos) in range(48, 58)) and (int(pos) < 8):
                    if passwordDict[int(pos)] is None:
                        passwordDict[int(pos)] = result[6]
                        posFilled += 1
            x += 1
    return passwordDict

if __name__ == "__main__":
    doorID = "abbhdwsy"
    password1 = partOne(doorID)
    print(password1)
    passwordDict = partTwo(doorID)
    password2 = ""
    for i in range(0, 8):
        password2 += passwordDict[i]
    print(password2)


