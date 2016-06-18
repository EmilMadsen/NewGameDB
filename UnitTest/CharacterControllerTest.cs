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

            // Act
            var view = Controller.Index() as ViewResult;

            // Arrange
            Assert.AreEqual(chars, view.Model);
            Assert.AreEqual("Index", view.ViewName);

        }

        [TestMethod]
        public void CreateNewCharacter()
        {

        }

        [TestMethod]
        public void UpdateSpecificCharacter()
        {

        }

        [TestMethod]
        public void DeleteSpecificCharacter()
        {

        }
    }
}
