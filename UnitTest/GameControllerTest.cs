using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GameDB.Models;
using GameDB.Repositories;
using GameDB.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;

namespace UnitTest
{
    [TestClass]
    public class GameControllerTest
    {
        
        [TestMethod]
        public void GetAllGames()
        {
            // Arrange
            var MockGameRepo = new Mock<IRepository<Game>>();
            var MockCharRepo = new Mock<IRepository<Character>>();
            var Controller = new GameController(MockGameRepo.Object, MockCharRepo.Object);

            var Game1 = new Game
            {
                Name = "HOTS",
                Author = "Emil"
            };

            var Game2 = new Game
            {
                Name = "League of Legends",
                Author = "Peter"
            };

            var games = new List<Game>();
            games.Add(Game1);
            games.Add(Game2);

            MockGameRepo.Setup(x => x.GetAll("")).Returns(() => games);

            // Act
            var view = Controller.Index("") as ViewResult;

            // Assert
            Assert.AreEqual(games, view.Model);
            Assert.AreEqual("Index", view.ViewName);
        }

        [TestMethod]
        public void CreateNewGame()
        {
            // Arrange
            var MockGameRepo = new Mock<GameRepository>();
            var MockCharRepo = new Mock<CharacterRepository>();
            var Controller = new GameController(MockGameRepo.Object, MockCharRepo.Object);


            var Game1 = new Game
            {
                Name = "HOTS",
                Author = "Emil"
            };


            var games = new List<Game>();

            MockGameRepo.Setup(x => x.InsertOrUpdate(Game1));
            MockGameRepo.Setup(x => x.GetAll("")).Returns(games);

            // Act
            var view = Controller.Create(Game1, null) as ViewResult;

            // Assert
            //Assert.AreEqual(Game1, view.Model[0]);
            Assert.AreEqual("CreatedGame", view.ViewName);

        }

        [TestMethod]
        public void UpdateSpecificGame()
        {
            // Arrange
            var MockGameRepo = new Mock<GameRepository>();
            var MockCharRepo = new Mock<CharacterRepository>();
            var Controller = new GameController(MockGameRepo.Object, MockCharRepo.Object);

            var Game1 = new Game
            {
                GameID = 1,
                Name = "HOTS",
                Author = "Emil"
            };

            var Game2 = new Game
            {
                GameID = 2,
                Name = "League of Legends",
                Author = "Peter"
            };

            var games = new List<Game>();
            games.Add(Game1);
            games.Add(Game2);

            MockGameRepo.Setup(x => x.GetAll("")).Returns(games);
            MockGameRepo.Setup(x => x.InsertOrUpdate(Game2));

            Game2.Name = "NEW Name";

            // Act
            var view = Controller.Edit(Game2,null) as ViewResult;

            // Assert
            //Assert.AreEqual(Game2, view.Model[1]);
            Assert.AreEqual("Index", view.ViewName);
        }

        [TestMethod]
        public void DeleteSpecificGame()
        {
            // Arrange
            var MockGameRepo = new Mock<IRepository<Game>>();
            var MockCharRepo = new Mock<IRepository<Character>>();
            var Controller = new GameController(MockGameRepo.Object, MockCharRepo.Object);

            var Game1 = new Game
            {
                GameID = 1,
                Name = "HOTS",
                Author = "Emil"
            };

            var Game2 = new Game
            {
                GameID = 2,
                Name = "League of Legends",
                Author = "Peter"
            };

            var games = new List<Game>();
            games.Add(Game1);
            games.Add(Game2);

            MockGameRepo.Setup(x => x.Delete(Game1.GameID));

            // Act
            var view = Controller.Delete(Game1.GameID) as ViewResult;

            // Assert
            //Assert.AreNotEqual(games.Count, view.Model.Count);
            Assert.AreEqual("Index", view.ViewName);
        }
    }
}
