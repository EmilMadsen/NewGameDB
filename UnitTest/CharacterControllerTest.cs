using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameDB.Repositories;
using Moq;
using GameDB.Models;
using GameDB.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;

namespace UnitTest
{
    [TestClass]
    public class CharacterControllerTest
    {
        [TestMethod]
        public void GetAllCharacters()
        {
            // Arrange
            var MockCharRepo = new Mock<IRepository<Character>>();
            var MockGameRepo = new Mock<IRepository<Game>>();
            var Controller = new CharacterController(MockCharRepo.Object, MockGameRepo.Object);

            var Game1 = new Game
            {
                GameID = 1,
                Name = "HOTS",
                Author = "Emil"
            };

            var Char1 = new Character
            {
                ParentGameID = 1,
                CharacterID = 1,
                Name = "Muradin"
            };

            var Char2 = new Character
            {
                ParentGameID = 1,
                CharacterID = 2,
                Name = "Tracer"
            };

            var chars = new List<Character>();
            chars.Add(Char1);
            chars.Add(Char2);

            MockCharRepo.Setup(x => x.GetAll("")).Returns(chars);

            // Act
            var view = Controller.Index() as ViewResult;

            // Arrange
            Assert.AreEqual(chars, view.Model);
            Assert.AreEqual("Index", view.ViewName);

        }

        [TestMethod]
        public void CreateNewCharacter()
        {
            // Arrange
            var MockCharRepo = new Mock<IRepository<Character>>();
            var MockGameRepo = new Mock<IRepository<Game>>();
            var Controller = new CharacterController(MockCharRepo.Object, MockGameRepo.Object);

            var Game1 = new Game
            {
                GameID = 1,
                Name = "HOTS",
                Author = "Emil"
            };

            var Char1 = new Character
            {
                ParentGameID = 1,
                CharacterID = 1,
                Name = "Muradin"
            };

            var chars = new List<Character>();
            chars.Add(Char1);

            var games = new List<Game>();
            games.Add(Game1);

            MockCharRepo.Setup(x => x.GetAll("")).Returns(chars);
            MockCharRepo.Setup(x => x.InsertOrUpdate(Char1));

            // Act
            var view = Controller.Create(Char1,null) as ViewResult;

            // Assert
            //Assert.AreEqual(Char1, view.Model.Characters[0]);
            Assert.AreEqual("Details", view.ViewName);
        }

        [TestMethod]
        public void UpdateSpecificCharacter()
        {
            // Arrange
            var MockCharRepo = new Mock<IRepository<Character>>();
            var MockGameRepo = new Mock<IRepository<Game>>();
            var Controller = new CharacterController(MockCharRepo.Object, MockGameRepo.Object);

            var Game1 = new Game
            {
                GameID = 1,
                Name = "HOTS",
                Author = "Emil"
            };

            var Char1 = new Character
            {
                ParentGameID = 1,
                CharacterID = 1,
                Name = "Muradin"
            };

            var Char2 = new Character
            {
                ParentGameID = 1,
                CharacterID = 2,
                Name = "Tracer"
            };

            var chars = new List<Character>();
            chars.Add(Char1);
            chars.Add(Char2);

            var games = new List<Game>();
            games.Add(Game1);

            MockCharRepo.Setup(x => x.GetAll("")).Returns(chars);
            MockCharRepo.Setup(x => x.InsertOrUpdate(Char2));

            Char2.Name = "NEW Name";

            // Act
            var view = Controller.Edit(Char2, null) as ViewResult;

            // Assert
            //Assert.AreEqual(Char2, view.Model.Characters[0]);
            Assert.AreEqual("Details", view.ViewName);
        }

        [TestMethod]
        public void DeleteSpecificCharacter()
        {
            // Arrange
            var MockCharRepo = new Mock<IRepository<Character>>();
            var MockGameRepo = new Mock<IRepository<Game>>();
            var Controller = new CharacterController(MockCharRepo.Object, MockGameRepo.Object);

            var Game1 = new Game
            {
                GameID = 1,
                Name = "HOTS",
                Author = "Emil"
            };

            var Char1 = new Character
            {
                ParentGameID = 1,
                CharacterID = 1,
                Name = "Muradin"
            };

            var chars = new List<Character>();
            chars.Add(Char1);

            var games = new List<Game>();
            games.Add(Game1);

            MockCharRepo.Setup(x => x.GetAll("")).Returns(chars);
            MockCharRepo.Setup(x => x.Delete(Char1.CharacterID));

            // Act
            var view = Controller.Delete(Char1.CharacterID) as ViewResult;

            // Assert
            //Assert.AreNotEqual(chars.Count, view.Model.Count);
            Assert.AreEqual("Details", view.ViewName);

        }
    }
}
