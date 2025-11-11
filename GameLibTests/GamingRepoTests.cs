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
    public class GamingRepoTests
    {
        private const bool useDatabase = true;
        private IGaming<Game> _repo = new GamingRepo();

        [TestInitialize()]
        public void Setup()
        {
            _repo.Add(new Game("The Legend of Zelda", "Adventure", 1986));
            _repo.Add(new Game("Super Mario Bros.", "Platformer", 1985));
            _repo.Add(new Game("Minecraft", "Sandbox", 2011));
        }

        [TestMethod()]
        public void AddTest()
        {
            Game newGame = new Game("Halo: Combat Evolved", "Shooter", 2001);
            Game addedGame = _repo.Add(newGame);
            Assert.IsNotNull(addedGame);
            Assert.AreEqual(4, addedGame.Id);
            Assert.AreEqual("Halo: Combat Evolved", addedGame.Title);
            Assert.AreEqual("Shooter", addedGame.Genre);
            Assert.AreEqual(2001, addedGame.ReleaseYear);

        }

        [TestMethod()]
        public void GetTest()
        {
            IEnumerable<Game> games = _repo.Get();
            Assert.IsNotNull(games);
            Assert.AreEqual(3, games.Count());
            Assert.AreNotEqual(2, games.Count());
            Assert.AreNotEqual(4, games.Count());
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            // success case
            Game? game = _repo.Get(2);
            Assert.IsNotNull(game);
            Assert.AreEqual(2, game.Id);
            Assert.AreEqual("Super Mario Bros.", game.Title);
            Assert.AreEqual("Platformer", game.Genre);
            Assert.AreEqual(1985, game.ReleaseYear);

            // failure case
            Game? missingGame = _repo.Get(0);
            Assert.IsNull(missingGame);
            Game? missingGame1 = _repo.Get(4);
            Assert.IsNull(missingGame1);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // failure case
            Game? missingGame = _repo.Delete(0);
            Assert.IsNull(missingGame);
            Game? missingGame1 = _repo.Delete(4);
            Assert.IsNull(missingGame1);

            // success case
            Game? deletedGame = _repo.Delete(1);
            Assert.IsNotNull(deletedGame);
            Assert.AreEqual(1, deletedGame.Id);
            Assert.AreEqual("The Legend of Zelda", deletedGame.Title);
            Assert.AreEqual("Adventure", deletedGame.Genre);
            Assert.AreEqual(1986, deletedGame.ReleaseYear);
            Assert.AreEqual(2, _repo.Get().Count());
        }

        [TestMethod()]
        public void UpdateTest()
        {
            // failure case
            Game updatedGameInfo = new Game("Updated Title", "Updated Genre", 2000);
            Game? missingGame = _repo.Update(0, updatedGameInfo);
            Assert.IsNull(missingGame);
            Game? missingGame1 = _repo.Update(4, updatedGameInfo);
            Assert.IsNull(missingGame1);

            // success case
            Game? updatedGame = _repo.Update(2, updatedGameInfo);
            Assert.IsNotNull(updatedGame);
            Assert.AreEqual(2, updatedGame.Id);
            Assert.AreEqual("Updated Title", updatedGame.Title);
            Assert.AreEqual("Updated Genre", updatedGame.Genre);
            Assert.AreEqual(2000, updatedGame.ReleaseYear);
        }
    }
}