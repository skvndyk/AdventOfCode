﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day9;
using Day9.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class Day9_Tests
    {

        [TestMethod]
        public void P0()
        {
            int numPlayers = 9;
            int lastMarbleValue = 25;
            int expectedHighScore = 32;
            Game game = Program.PlayGame(numPlayers, lastMarbleValue);
            Assert.AreEqual(expectedHighScore, game.WinningPlayer.TotalScore);

        }

        [TestMethod]
        public void P1()
        {
            int numPlayers = 10;
            int lastMarbleValue = 1618;
            int expectedHighScore = 8317;
            Game game = Program.PlayGame(numPlayers, lastMarbleValue);
            Assert.AreEqual(expectedHighScore, game.WinningPlayer.TotalScore);
        }

        [TestMethod]
        public void P2()
        {
            int numPlayers = 13;
            int lastMarbleValue = 7999;
            int expectedHighScore = 146373;
            Game game = Program.PlayGame(numPlayers, lastMarbleValue);
            Assert.AreEqual(expectedHighScore, game.WinningPlayer.TotalScore);
        }

        [TestMethod]
        public void P3()
        {
            int numPlayers = 17;
            int lastMarbleValue = 1104;
            int expectedHighScore = 2764;
            Game game = Program.PlayGame(numPlayers, lastMarbleValue);
            Assert.AreEqual(expectedHighScore, game.WinningPlayer.TotalScore);
        }

        [TestMethod]
        public void P4()
        {
            int numPlayers = 21;
            int lastMarbleValue = 6111;
            int expectedHighScore = 54718;
            Game game = Program.PlayGame(numPlayers, lastMarbleValue);
            Assert.AreEqual(expectedHighScore, game.WinningPlayer.TotalScore);
        }

        [TestMethod]
        public void P5()
        {
            int numPlayers = 30;
            int lastMarbleValue = 5807;
            int expectedHighScore = 37305;
            Game game = Program.PlayGame(numPlayers, lastMarbleValue);
            Assert.AreEqual(expectedHighScore, game.WinningPlayer.TotalScore);
        }
    }
}
