using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC2023.Day1
{
    class Day7_Program
    {
        static void Main(string[] args)
        {
            string filePath = $@"Day7\inputFileDay7-2023.txt";
            string exFilePath1 = $@"Day7\exInputFileDay7-2023_P1.txt";
            string exFilePath2 = $@"Day7\exInputFileDay7-2023_P2.txt";

            var exInputStrings1 = Common.Utilities.ReadFileToStrings(exFilePath1);
            var exInputStrings2 = Common.Utilities.ReadFileToStrings(exFilePath2);
            var inputStrings = Common.Utilities.ReadFileToStrings(filePath);

            //Console.WriteLine($"Part 1 example answer: {Part1(exInputStrings1)}");
            //Console.WriteLine($"Part 2 example answer: {Part2(exInputStrings2)}");

            Console.WriteLine($"Part 1 answer: {Part1(inputStrings)}");
            //Console.WriteLine($"Part 2 answer: {Part2(inputStrings)}");
        }

        private static int Part1(List<string> inputStrings)
        {
            var hands = ConvertInputToDataStructures(inputStrings);
            var rankedHands = RankHands(hands);
            rankedHands.Reverse();
            var sum = 0;
            for (int i = 0; i < rankedHands.Count; i++)
            {
                sum += rankedHands[i].Bid * (i + 1);
            }
            return sum;
        }

        private static int Part2(List<string> inputStrings)
        {
            return 0;
        }

        private static List<Hand> RankHands(List<Hand> hands)
        {
            var rankedHands = new List<Hand>();
            var dict = new Dictionary<HandType, List<Hand>>();
            foreach (var hand in hands)
            {
                var newKeyAdded = dict.TryAdd(hand.HandType, new List<Hand>() { hand });
                if (!newKeyAdded)
                {
                    dict[hand.HandType].Add(hand);
                }
            }

            var orderedDict = dict.OrderByDescending(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            var orderedHandsByType = new List<Hand>();
            var maxCard = new Card();
            foreach (var rec in orderedDict.Keys)
            {
                orderedHandsByType = new List<Hand>(orderedDict[rec]);
                //if there's no tie, just add to list
                if (orderedDict[rec].Count == 1)
                {
                    rankedHands.Add(orderedDict[rec][0]);
                }
                else
                {
                    //if there's a tie sort by highest card
                    //get max for each index
                    //for (int i = 0; i < 5 && orderedHandsByType.Count > 1; i++)
                    //{
                    //    maxCard = new Card();
                    //    var maxVal = 0;
                    //    for (int j = 0; j < orderedHandsByType.Count; j++)
                    //    {
                    //        if (orderedHandsByType[j].Cards[i].CardValue == maxVal)
                    //        {
                    //            maxCard = new Card();
                    //            maxVal = 0;
                    //            break;
                    //        }
                    //        else if (orderedHandsByType[j].Cards[i].CardValue > maxVal)
                    //        {
                    //            maxVal = orderedHandsByType[j].Cards[i].CardValue;
                    //            maxCard = orderedHandsByType[j].Cards[i];
                    //        }
                    //    }
                    //    if (maxVal != 0)
                    //    {
                    //        var toAddRemove = orderedHandsByType.First(h => h.Cards.Contains(maxCard));
                    //        rankedHands.Add(toAddRemove);
                    //        orderedHandsByType.Remove(toAddRemove);
                    //    }
                    //}
                    //orderedHandsByType.Sort((h1, h2) => int.Max(h1.Cards[0].CardValue, h2.Cards[1].CardValue));
                    //orderedHandsByType.OrderByDescending(h => h.Cards[0].CardValue);
                    //rankedHands.AddRange(orderedHandsByType);
                    //var i = 0;
                    //while (orderedHandsByType.Count > 1 && i < 10)
                    //{
                    //    var blah = orderedHandsByType.Max(h => h.Cards[i].CardValue);
                    //    var blahCards = orderedHandsByType.Where(h => h.Cards[i].CardValue == blah).ToList();

                    //    if (blahCards.Count == 1)
                    //    {
                    //        orderedHandsByType.Remove(blahCards[0]);
                    //        rankedHands.Add(blahCards[0]);
                    //    }

                    //    else { i++; }
                    //}
                    var i = 0;
                    var leftOverList = new List<Hand>();
                    while (orderedHandsByType.Count() > 1)
                    {
                        RecursiveThing(orderedHandsByType, rankedHands, i, leftOverList);
                    }
                }
            }

            return rankedHands;
        }

        private static void RecursiveThing(List<Hand> orderedHandsByType, List<Hand> rankedHands, int i, List<Hand> leftOverList)
        {
            if (orderedHandsByType.Count == 1)
            {
                rankedHands.Add(orderedHandsByType[0]);
                orderedHandsByType.Remove(orderedHandsByType[0]);
                if (leftOverList.Count > 0)
                {
                    RecursiveThing(leftOverList, rankedHands, i, leftOverList);
                }
                return;
            }
            var blah = orderedHandsByType.Max(h => h.Cards[i].CardValue);
            var blahCards = orderedHandsByType.Where(h => h.Cards[i].CardValue == blah).ToList();

            if (blahCards.Count == 1)
            {
                orderedHandsByType.Remove(blahCards[0]);
                rankedHands.Add(blahCards[0]);
                i++;
                RecursiveThing(orderedHandsByType, rankedHands, i, leftOverList);
            }
            else
            {
                var leftOverCards = orderedHandsByType.Except(blahCards).ToList();
                if (leftOverCards.Count() == 0)
                {
                    i++;
                }
                else
                {
                    leftOverList.AddRange(leftOverCards);
                    foreach (var item in leftOverList)
                    {
                        orderedHandsByType.Remove(item);
                    }
                }
                RecursiveThing(orderedHandsByType, rankedHands, i, leftOverList);

            }
        }

        private static List<Hand> ConvertInputToDataStructures(List<string> inputStrings)
        {
            var hands = new List<Hand>();
            foreach (var inputString in inputStrings) {
                var hand = new Hand();
                var cardsString = inputString[..5];
                for (int i = 1; i < cardsString.Length+1; i++) {
                    hand.Cards.Add(new Card(cardsString[i-1], i));
                }
                hand.Bid = int.Parse(inputString[6..]);
                hand.CalculateHandType();
                hands.Add(hand);

            }
            return hands;
        }

        #region lil classes
        public class Hand
        {
            public List<Card> Cards { get; set; }
            public int Bid { get; set; }
            public HandType HandType { get; set; }
            
            public Hand()
            {
                Cards = [];
                Bid = 0;
            }

            public override string ToString()
            {
                return string.Join("-", Cards.Select(c => c.GetCardType().ToString()));
                return string.Join("-", Cards.Select(c => c.CardValue.ToString()));
            }

            public void CalculateHandType()
            {
                var cardCounts = Cards.GroupBy(c => c.CardValue).Select(g => new {CardValue = g.Key, Count = g.Count()}).ToList();
                var ccDict = cardCounts.ToDictionary(c => c.CardValue, c => c.Count);
                if (ccDict.Count == 1)
                {
                    HandType = HandType.FiveOfAKind;
                }
                else if (ccDict.Count == 2)
                {
                    if (ccDict.ContainsValue(4))
                    {
                        HandType = HandType.FourOfAKind;
                    }
                    else
                    {
                        HandType = HandType.FullHouse;
                    }
                }
                else if (ccDict.Count == 3)
                {
                    if (ccDict.ContainsValue(3))
                    {
                        HandType = HandType.ThreeOfAKind;
                    }
                    else
                    {
                        HandType = HandType.TwoPair;
                    }
                }
                else if (ccDict.Count == 4)
                {
                    HandType = HandType.OnePair;
                }
                else
                {
                    HandType = HandType.HighCard;
                }
            }
        }

        public class Card
        {
            public int CardValue { get; set; }
            public int Index { get; set; }

            public Card()
            {

            }

            public Card(char cardType, int index)
            {
                var cardValue = cardType switch
                {
                    'T' => 10,
                    'J' => 11,
                    'Q' => 12,
                    'K' => 13,
                    'A' => 14,
                    _ => int.Parse(cardType.ToString()),
                };
                CardValue = cardValue;
                Index = index;
            }

            public override string ToString()
            {
                return $"Card: {CardValue} at index {Index}";
            }

            public char GetCardType()
            {
                return CardValue switch
                {
                    10 => 'T',
                    11 => 'J',
                    12 => 'Q',
                    13 => 'K',
                    14 => 'A',
                    _ => CardValue.ToString()[0],
                };
            }
        }

        public enum HandType
        {
            HighCard = 1,
            OnePair,
            TwoPair,
            ThreeOfAKind,
            FullHouse,
            FourOfAKind,
            FiveOfAKind
        }

       
        #endregion
    }
}
