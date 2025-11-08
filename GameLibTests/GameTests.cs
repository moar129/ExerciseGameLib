using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Tests
{
    [TestClass()]
    public class GameTests
    {
        [TestMethod()]
        public void GameSuccessTest()
        {
            Game game = new Game("The Legend of Zelda", "Adventure", 1986);
            Assert.AreEqual("The Legend of Zelda", game.Title);
            Assert.AreEqual("Adventure", game.Genre);
            Assert.AreEqual(1986, game.ReleaseYear);
        }
        [TestMethod()]
        public void GameFailureTest() 
        {
            Game game = new Game("Valid Title", "Valid Genre", 2000);
            Assert.ThrowsException<ArgumentNullException>(() => game.Title = null);
            Assert.ThrowsException<ArgumentException>(() => game.Title = "a");
            Assert.ThrowsException<ArgumentNullException>(() => game.Genre = null);
            Assert.ThrowsException<ArgumentException>(() => game.Genre = "a");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => game.ReleaseYear = 1940);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => game.ReleaseYear = DateTime.Now.Year + 1);
        }

        [TestMethod()]
        public void GameDefaultConstructorTest()
        {
            Game game = new Game();
            game.Genre = "Action";
            game.Title = "Super Mario Bros";
            game.ReleaseYear = 1985;
            Assert.AreEqual("Super Mario Bros", game.Title);
            Assert.AreEqual("Action", game.Genre);
            Assert.AreEqual(1985, game.ReleaseYear);

        }
    }
}