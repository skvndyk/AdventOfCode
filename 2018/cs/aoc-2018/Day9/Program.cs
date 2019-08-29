using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            PlayGame(numPlayers, maxMarbleValue);
            Console.ReadLine();
        }

        public static void PlayGame(int numPlayers, int maxMarbleValue)
        {
            Game game = new Game(numPlayers, maxMarbleValue);
            //initial marble placement
            game.CurrentMarble = new LinkedListNode<Marble>(new Marble()
            {
                Value = 0
            });
            game.CurrentPlayer = game.Players.First;
            game.Circle.AddLast(game.CurrentMarble);
            PrintCircle(game);
                        
            while (game.CurrentMarble.Value.Value <= game.MaxMarbleValue)
            {
                PlaceNextMarble(game);
            }
        }

        public static void PrintCircle(Game game)
        {
            string toPrint = $"{game.CurrentPlayer.Value.Value}-- ";
            toPrint += string.Join(" ", game.Circle.Select(m => m.Value));
            Console.WriteLine(toPrint);
        }

        public static void PlaceNextMarble(Game game)
        {
            var nextMarble = new Marble()
            {
                Value = game.CurrentMarble.Value.Value + 1
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
                }
                //add that one to player's list
                game.CurrentPlayer.Value.Marbles.Add(marbleToRemove.Value);
                //now remove it and set the new marble
                game.CurrentMarble = marbleToRemove.GetNextCircular();
                game.Circle.Remove(marbleToRemove);
            }

            else
            {
                var addAfter = game.CurrentMarble.GetNextCircular();
                game.Circle.AddAfter(addAfter, nextMarble);
                game.CurrentMarble = game.Circle.Find(nextMarble);
            }
            
            //move to next player next turn
            game.CurrentPlayer = game.CurrentPlayer.GetNextCircular();
            PrintCircle(game);
        }
    }
}
