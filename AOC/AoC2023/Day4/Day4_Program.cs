using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC2023.Day1
{
    class Day4_Program
    {
        static void Main(string[] args)
        {
            string filePath = $@"Day4\inputFileDay4-2023.txt";
            string exFilePath1 = $@"Day4\exInputFileDay4-2023_P1.txt";
            string exFilePath2 = $@"Day4\exInputFileDay4-2023_P2.txt";

            var exInputStrings1 = Common.Utilities.ReadFileToStrings(exFilePath1);
            var exInputStrings2 = Common.Utilities.ReadFileToStrings(exFilePath2);
            var inputStrings = Common.Utilities.ReadFileToStrings(filePath);

            Console.WriteLine($"Part 1 example answer: {Part1(exInputStrings1)}");
            Console.WriteLine($"Part 2 example answer: {Part2(exInputStrings2)}");

            Console.WriteLine($"Part 1 answer: {Part1(inputStrings)}");
            Console.WriteLine($"Part 2 answer: {Part2(inputStrings)}");
        }

        private static int Part1(List<string> inputStrings)
        {
            var game = InputStringsToGame(inputStrings);
            return game.Cards.Sum(c => c.PointValue);
        }

        private static int Part2(List<string> inputStrings)
        {
            var game = InputStringsToGame(inputStrings);
            while (game.UnprocessedCardQueue.Count > 0)
            {
                var currCard = game.UnprocessedCardQueue.Dequeue();
                for (int i = 1; i <= currCard.WinningPlayerNumbersCount; i++)
                {
                    var newId = currCard.Id + i;
                    var cardToCopy = game.FindCardById(newId);
                    game.UnprocessedCardQueue.Enqueue(
                        new Card (
                            newId,
                            cardToCopy.WinningNumbers,
                            cardToCopy.PlayerNumbers
                        )
                    );
                }
                game.ProcessedCardQueue.Enqueue(currCard);
            }
            return game.ProcessedCardQueue.Count;
        }

        private static Game InputStringsToGame(List<string> inputStrings)
        {
            var game = new Game();

            string pattern = $@"(Card *(\d+):)(.*)";
            Regex regex = new Regex(pattern);

            foreach (var str in inputStrings)
            {
                var matches = regex.Matches(str);
                var cardContents = matches[0].Groups[3].Value;
                var cardId = int.Parse(matches[0].Groups[2].Value);

                var cardList = cardContents.Split('|');
                var winningNumbers = cardList[0].Split(' ').Where(x => x != string.Empty).ToList();
                var playerNumbers = cardList[1].Split(' ').Where(x => x != string.Empty).ToList();

                game.Cards.Add(new Card(cardId, winningNumbers, playerNumbers));

            }
            //initialize game queue
            game.Cards.ForEach(c => game.UnprocessedCardQueue.Enqueue(c));
            return game;
        }

        public class Game
        {
            public List<Card> Cards { get; set; } = new List<Card>();
            public Queue<Card> UnprocessedCardQueue { get; set; } = new Queue<Card>();
            public Queue<Card> ProcessedCardQueue { get; set;} = new Queue<Card>();
            public Card FindCardById(int id) => Cards.FirstOrDefault(c => c.Id == id);
        }
        public class Card
        {
            public int Id { get; set; }
            public List<int> WinningNumbers { get; set; } = new List<int>();
            public List<int> PlayerNumbers { get; set; } = new List<int>();

            public List<int> WinningPlayerNumbers => WinningNumbers.Intersect(PlayerNumbers).ToList();
            public int WinningPlayerNumbersCount => WinningPlayerNumbers.Count;

            public Card(int id, List<int> winningNumbers, List<int> playerNumbers)
            {
                Id = id;
                WinningNumbers = winningNumbers;
                PlayerNumbers = playerNumbers;
            }

            public Card(int id, List<string> winningNumbers, List<string> playerNumbers)
            {
                Id = id;
                WinningNumbers = winningNumbers.Select(int.Parse).ToList();
                PlayerNumbers = playerNumbers.Select(int.Parse).ToList();
            }

            public int PointValue => (int)Math.Pow(2, WinningPlayerNumbers.Count - 1); 

            public Card CopyCard()
            {
                return new Card(Id, WinningNumbers, PlayerNumbers);
            }
        }


    }
}
