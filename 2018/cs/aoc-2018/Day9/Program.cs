using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Day9.Extensions;
using Day9.Models;

namespace Day9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int numPlayers = 410;
            int maxMarbleValue = 72059;

            Stopwatch _stopwatch = Stopwatch.StartNew();

            Game game = PlayGame(numPlayers, maxMarbleValue);

            _stopwatch.Stop();

            Console.WriteLine("\n\n");
            Console.WriteLine($"Elf {game.WinningPlayer.Value} won with a score of {game.WinningPlayer.TotalScore}!");
            Console.WriteLine($"Took {_stopwatch.ElapsedMilliseconds} ms to run.");
            Console.ReadLine();
        }

        public static Game PlayGame(int numPlayers, int maxMarbleValue)
        {

            Game game = new Game(numPlayers, maxMarbleValue);
            //initial marble placement
            game.CurrentMarble = new LinkedListNode<Marble>(new Marble()
            {
                Value = game.NextMarbleValueToPlace
            });
            game.CurrentPlayer = game.Players.First;
            game.Circle.AddLast(game.CurrentMarble);
            //PrintCircle(game);
                        
            while (game.CurrentMarble.Value.Value < game.MaxMarbleValue)
            {
                PlaceNextMarble(game);
            }

            return game;
        }

        public static void PrintCircle(Game game)
        {
            string toPrint = $"{game.CurrentPlayer.Value.Value}-- ";
            toPrint += string.Join(" ", game.Circle.Select(m => m.Value));
            Console.WriteLine(toPrint);
        }

        public static void PlaceNextMarble(Game game)
        {
            game.IncrementNextMarbleValue();
            var nextMarble = new Marble()
            {
                Value = game.NextMarbleValueToPlace
            };

            //check for 23 multiple in next marble
            if (nextMarble.Value % 23 == 0)
            {
                //add 23 marble to player's list
                game.CurrentPlayer.Value.Marbles.Add(nextMarble);
                var marbleToRemove = new LinkedListNode<Marble>(new Marble());
                //go 7 marbles counter-clockwise
                for (int i = 0; i < 7; i++)
                {
                    marbleToRemove = game.CurrentMarble.GetPreviousCircular();
                    game.CurrentMarble = marbleToRemove;
                }
                //add that one to player's list
                game.CurrentPlayer.Value.Marbles.Add(marbleToRemove.Value);
                //now remove it and set the new marble
                game.CurrentMarble = marbleToRemove.GetNextCircular();
                game.Circle.Remove(marbleToRemove);
                Console.WriteLine($"just removed marble {marbleToRemove.Value.Value}");
            }

            else
            {
                var addAfter = game.CurrentMarble.GetNextCircular();
                game.Circle.AddAfter(addAfter, nextMarble);
                game.CurrentMarble = game.Circle.Find(nextMarble);
            }
            
            //move to next player next turn
            game.CurrentPlayer = game.CurrentPlayer.GetNextCircular();
            //PrintCircle(game);
        }
    }
}
