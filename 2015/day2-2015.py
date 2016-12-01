# 2*l*w + 2*w*h + 2*h*l + (area of smallest side)
import itertools

def getPaperFootage(line, combos):

    minArea = 9999999999999999999999
    boxFeet = 0

    charElems = line.rstrip().split('x')
    intElems = [int(e) for e in charElems]
    elemDict = {"l": intElems[0], "w": intElems[1], "h": intElems[2]}

    for comb in combos:
        area = elemDict[comb[0]] * elemDict[comb[1]]
        if area < minArea:
            minArea = area

    boxFeet = 2 * (elemDict["l"] * elemDict["w"] + elemDict["w"] * elemDict["h"] + elemDict["h"] * elemDict["l"]) + \
              minArea

    return boxFeet
#
# def getRibbonFootage(line, combos):


def main():
    totalPaperFootage = 0

    with open('day2-2015.txt', 'r') as f:

        measures = ['l', 'w', 'h']
        combos = list(itertools.combinations(measures, 2))

        for line in f:
            if line == "\n":
                break
            else:
                totalPaperFootage += getPaperFootage(line, combos)


    print(totalPaperFootage)


main()


