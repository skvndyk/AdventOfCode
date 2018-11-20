def twice_in_a_row(line):
    found_tiar = False
    for idx, char in enumerate(line):
        if idx < (len(line) - 1):
            if char == line[idx + 1]:
                found_tiar = True
                break
    return found_tiar

def bad_strings(line):
    string_is_bad = True
    bad_strings = ['ab', 'cd', 'pq', 'xy']
    line_len = len(line)
    x = 0

    while x < (line_len - 1):
        test_string = line[x:x+2]
        if test_string in bad_strings:
            string_is_bad = False
            break
        x += 1
    return string_is_bad

def three_plus_vowels(line):
    has_tpv = False
    vowels = 'aeiou'
    num_vowels = 0
    for char in line:
        if char in vowels:
            num_vowels += 1
            if num_vowels == 3:
                has_tpv = True
                break
    return has_tpv


if __name__ == "__main__":
    nice_string_num = 0
    with open('day5-2015.txt', 'r') as f:
        for line in f:
            if twice_in_a_row(line) and bad_strings(line) and three_plus_vowels(line):
                nice_string_num += 1
    print(nice_string_num)
