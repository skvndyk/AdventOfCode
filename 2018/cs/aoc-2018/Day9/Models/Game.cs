using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9.Models
{
    public class Game
    {
        public LinkedList<Player> Players { get; set; }
        public LinkedList<Marble> Circle { get; set; }
        public LinkedListNode<Marble> CurrentMarble { get; set; }
        public LinkedListNode<Player> CurrentPlayer { get; set; }
        public int MaxMarbleValue { get; set; }
        
        public Game(int numPlayers, int maxMarbleValue)
        {
            Players = new LinkedList<Player>();
            for (int i = 0; i < numPlayers; i++)
            {
                Players.AddLast(new Player() { Value = i + 1});
            }
            Circle = new LinkedList<Marble>();
            MaxMarbleValue = maxMarbleValue;
        }
    }
}
