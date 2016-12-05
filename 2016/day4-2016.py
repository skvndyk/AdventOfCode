import re
from itertools import groupby

if __name__ == "__main__":
    sectorSum = 0
    with open('day4-2016.txt', 'r') as f:
        for origLine in f:
            letterCount = {}
            sectorID = int(re.findall('\d+', origLine)[0])
            checkSum = re.search('(?<=\[)[a-z]*(?=\])', origLine).group(0)
            line = origLine.replace('-', '')
            regName = re.match('[a-z]*', line)
            name = line[regName.start():regName.end()]
            for char in name:
                letterCount[char] = letterCount.get(char, 0) + 1
            sortedLC = sorted(letterCount.items(), key=lambda x: x[1], reverse=True)
            newList = []
            for key, group in groupby(sortedLC, lambda x: x[1]):
                toSort = list(group)
                if len(toSort) > 1:
                    toSort = sorted(toSort, key=lambda x: x[0])
                for i in toSort:
                    newList.append(i)
            potentialCS = ''.join([x[0] for x in newList[:5]])
            if potentialCS == checkSum:
                sectorSum += sectorID
    print(sectorSum)