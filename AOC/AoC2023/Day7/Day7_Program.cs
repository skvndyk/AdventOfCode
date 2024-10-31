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
            //var exInputStrings2 = Common.Utilities.ReadFileToStrings(exFilePath2);
            //var inputStrings = Common.Utilities.ReadFileToStrings(filePath);

            Console.WriteLine($"Part 1 example answer: {Part1(exInputStrings1)}");
            //Console.WriteLine($"Part 2 example answer: {Part2(exInputStrings2)}");

            //Console.WriteLine($"Part 1 answer: {Part1(inputStrings)}");
            //Console.WriteLine($"Part 2 answer: {Part2(inputStrings)}");
        }

        private static int Part1(List<string> inputStrings)
        {
            var hands = ConvertInputToDataStructures(inputStrings);
            return 0;
        }

        private static int Part2(List<string> inputStrings)
        {
            return 0;
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
                hand.Bid = int.Parse(inputString[7..]);
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

            public void CalculateHandType()
            {
                var cardCounts = Cards.GroupBy(c => c.CardValue).Select(g => new {CardValue = g.Key, Count = g.Count()}).ToList();
                var ccDict = cardCounts.ToDictionary(c => c.CardValue, c => c.Count);
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
