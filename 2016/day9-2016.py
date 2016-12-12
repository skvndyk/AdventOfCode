def analyze_marker(marker):
    stripped_marker = marker.split('x')
    num_chars = int(stripped_marker[0])
    num_repeats = int(stripped_marker[1])
    return num_chars, num_repeats

if __name__ == "__main__":
    with open('day9-2016.txt', 'r') as f:
        decompressed = ""
        marker = ""
        data = f.read()
        in_marker = False
        marker_exists = False
        data = "A(2x2)BCD(2x2)EFG"
        len_data = len(data)
        x = 0
        while x < (len_data):
            if not marker_exists:
                curr_char = data[x]
                if not in_marker:
                    if curr_char != "(":
                        decompressed += curr_char
                    else:
                        in_marker = True
                else:
                    if curr_char != ")":
                        marker += curr_char
                    else:
                        in_marker = False
                        marker_exists = True
                        chars, repeats = analyze_marker(marker)
                x += 1
            else:
                to_repeat = ""
                for y in range(chars):
                    pos = x + y
                    to_repeat += data[pos]
                for z in range(repeats):
                    decompressed += to_repeat
                marker = ""
                marker_exists = False
                x = (pos + 1)
    print(decompressed)

