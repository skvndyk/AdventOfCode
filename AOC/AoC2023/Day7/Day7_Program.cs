using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            var groupedHands = hands.GroupBy(h => h.HandType).OrderBy(g => g.Key);

            foreach (var group in groupedHands)
            {
                var handList = group.Select(h => h).ToList();
                var orderedList = handList.OrderBy(h => h.CardInts[0]).ThenBy(h => h.CardInts[1]).ThenBy(h => h.CardInts[2]).ThenBy(h => h.CardInts[3]).ThenBy(h => h.CardInts[4]).ToList();
                rankedHands.AddRange(orderedList);
            }
            return rankedHands;
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
            public List<int> CardInts => Cards.Select(c => c.CardValue).ToList();
            public int Bid { get; set; }
            public HandType HandType { get; set; }
            //public int HandValue => Cards.Sum(c => c.IntegerValue);
            
            public Hand()
            {
                Cards = [];
                Bid = 0;
            }

            public override string ToString()
            {
                return string.Join("-", Cards.Select(c => c.GetCardType().ToString())) + $@"HandType: {HandType}";
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
            public int? Index { get; set; }
            //public int IntegerValue { get; set; }

            public Card()
            {
                //IntegerValue = 0;
                CardValue = 0;
                Index = null;
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
                var reverseIdx = 5 - (int)(Index - 1);
                var tenPower = (int)(Math.Pow(10, reverseIdx));
                //IntegerValue = tenPower * CardValue;
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
            FiveOfAKind,
        }

       
        #endregion
    }
}
