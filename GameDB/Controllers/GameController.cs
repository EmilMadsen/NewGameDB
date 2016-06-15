using GameDB.Models;
using GameDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameDB.Controllers
{
    public class GameController : Controller
    {
        GameRepository GameRepo = new GameRepository();
        CharacterRepository CharRepo = new CharacterRepository();

        public ActionResult Index(string search = "")
        {
            return View(GameRepo.GetAll(search));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Game game, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    game.ImageMimeType = image.ContentType;
                    game.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(game.ImageData, 0, image.ContentLength);
                }
                GameRepo.InsertOrUpdate(game);
                return View("CreatedGame", game);

            }
            return View();
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(GameRepo.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Game game, HttpPostedFileBase image)
        {
            if(ModelState.IsValid)
            {
                if(image != null)
                {
                    game.ImageMimeType = image.ContentType;
                    game.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(game.ImageData, 0, image.ContentLength);
                }
                GameRepo.InsertOrUpdate(game);
                return RedirectToAction("Index");
            }
            return View(game);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            GameRepo.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Session["ParentID"] = id;
            GameWithChars GameAndChars = new GameWithChars();
            GameAndChars.Game = GameRepo.Find(id);
            GameAndChars.Characters = CharRepo.GetAll(); // 
            return View(GameAndChars);
        }

        public FileContentResult GetImage(int gameId)
        {
            Game game = GameRepo.Find(gameId);
           
            if (game != null)
            {
                return File(game.ImageData, game.ImageMimeType);
            }
            else
            {
                return null;
            }
          
        }
    }
}