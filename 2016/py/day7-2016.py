import re

def getParts(ip):
    hypernet = re.findall('(?<=\[)[a-z]+(?=\])', ip)
    supernets = re.findall('([a-z]+(?=\[))|((?<=\])[a-z]+)', ip)
    supernets = [x for y in supernets for x in y if x != '']
    return hypernet, supernets

def abaTest(to_test):
    candidate_abas = []
    for y in range(len(to_test)):
        x = 0
        string_length = len(to_test[y])
        while x < (string_length - 2):
            test_string = to_test[y][x:x + 3]
            if (test_string[0] == test_string[2]) and (test_string[0] != test_string[1]):
                candidate_abas.append(test_string)
            x += 1
    return candidate_abas

def babTest(candidate_abas, hypernets):
    candidate_babs = []
    babFound = 0
    for x in range(len(candidate_abas)):
        candidate_babs.append(candidate_abas[x][1] + candidate_abas[x][0] + candidate_abas[x][1])
    for y in range(len(hypernets)):
        z = 0
        string_length = len(hypernets[y])
        while (z < (string_length - 2)) and (babFound == 0):
            for i in range(len(candidate_babs)):
                if hypernets[y][z:z+3] == candidate_babs[i]:
                    babFound = 1
            z += 1
    return babFound

def abbaTest(to_test):
    abbaFormat = False
    x = 0
    string_length = len(to_test)
    while x < (string_length - 3):
        test_string = to_test[x:x+4]
        if (test_string[0] == test_string[3]) and (test_string[1] == test_string[2]) and (test_string[0] != test_string[1]):
            abbaFormat = True
            break
        x += 1
    return abbaFormat

if __name__ == "__main__":
    with open('day7-2016.txt', 'r') as f:
        valid_ips = 0
        valid_ips_ssl = 0
        for ip in f:
            hypernets, supernets = getParts(ip)

            num_supernets = len(supernets)
            num_hypernets = len(hypernets)

            valid_hypernets = 0
            valid_supernets = 0


            #hypernet should not be True, supernet should be True
            # for item in hypernets:
            #     if abbaTest(item) is False:
            #         valid_hypernets += 1
            #     else:
            #         break
            #
            # for item in supernets:
            #     if abbaTest(item) is True:
            #         valid_supernets += 1
            #         break
            #
            # if (valid_supernets > 0) and (valid_hypernets == num_hypernets):
            #     valid_ips += 1

            candidate_abas = abaTest(supernets)
            print(candidate_abas)
            if candidate_abas:
                valid_ips_ssl += babTest(candidate_abas, hypernets)

    print(valid_ips)
    print(valid_ips_ssl)



# **Explanation of list comprehension
# bloop = []
# for y in supernets:
#     for x in y:
#         if x != '':
#             bloop.append(x)