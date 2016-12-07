import re

def getParts(ip):
    hypernet = re.findall('(?<=\[)[a-z]+(?=\])', ip)
    outside_brackets = re.findall('([a-z]+(?=\[))|((?<=\])[a-z]+)', ip)
    outside_brackets = [x for y in outside_brackets for x in y if x != '']
    return hypernet, outside_brackets

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
        for ip in f:
            hypernet, outside_brackets = getParts(ip)

            num_outside_brackets = len(outside_brackets)
            num_hypernets = len(hypernet)

            valid_hypernets = 0
            valid_outside_brackets = 0

            #hypernet should not be True, outside_brackets should be True
            for item in hypernet:
                if abbaTest(item) is False:
                    valid_hypernets += 1
                else:
                    break

            for item in outside_brackets:
                if abbaTest(item) is True:
                    valid_outside_brackets += 1
                    break

            if (valid_outside_brackets > 0) and (valid_hypernets == num_hypernets):
                valid_ips += 1


    print(valid_ips)



# **Explanation of list comprehension
# bloop = []
# for y in outside_brackets:
#     for x in y:
#         if x != '':
#             bloop.append(x)