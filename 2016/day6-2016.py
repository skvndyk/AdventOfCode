if __name__ == "__main__":
    with open('day6-2016.txt', 'r') as f:
        allRows = []
        allCols = []
        for line in f:
            allRows.append(line.strip())
        for pos in range(len(allRows[0])):
            tempList = []
            for elem in allRows:
                tempList.append(elem[pos])
            allCols.append(tempList)

        message = ""
        for col in allCols:
            tempDict = {}
            for letter in col:
                tempDict[letter] = tempDict.get(letter, 0) + 1
            # change this according to part one (max) or part two (min)
            message += min(tempDict.keys(), key=(lambda k: tempDict[k]))

    print(message)