import re

def analyze_marker(marker):
    stripped_marker = marker.split('x')
    num_chars = stripped_marker[0]
    num_repeats = stripped_marker[1]
    return num_chars, num_repeats

if __name__ == "__main__":
    with open('day9-2016.txt', 'r') as f:
        decompressed = ""
        marker = ""
        data = f.read()
        in_marker = False
        data = "A(1x5)BC"

        for char in data:
            if not in_marker:
                if char != "(":
                    decompressed += char
                else:
                    in_marker = True
            else:
                if char != ")":
                    marker += char
                else:
                    in_marker = False
                    chars, repeats = analyze_marker(marker)
                    x = 0



