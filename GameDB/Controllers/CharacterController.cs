using GameDB.Models;
using GameDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameDB.Controllers
{
    public class CharacterController : Controller
    {
        CharacterRepository CharRepo = new CharacterRepository();
        GameRepository GameRepo = new GameRepository();

        public ActionResult Index()
        {
            return View(CharRepo.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Character());
        }

        [HttpPost]
        public ActionResult Create(Character character, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if(image != null)
                {
                    character.ImageMimeType = image.ContentType;
                    character.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(character.ImageData, 0, image.ContentLength);
                }
                character.ParentGameID = (int)Session["ParentID"];
                Session["Parent"] = null;
                CharRepo.InsertOrUpdate(character);
                return RedirectToAction("Details", "Game", new { id = character.ParentGameID });
            }
            return View();
        }
        [HttpGet]
        public ActionResult Details(int id)
        {

            return View(CharRepo.Find(id));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            int CharID = CharRepo.Find(id).ParentGameID;
            CharRepo.Delete(id);
            return RedirectToAction("Details", "Game", new { id = CharID });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(CharRepo.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Character character, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if(image != null)
                {
                    character.ImageMimeType = image.ContentType;
                    character.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(character.ImageData, 0, image.ContentLength);
                }
                CharRepo.InsertOrUpdate(character);
                return RedirectToAction("Details", "Game", new { id = character.ParentGameID});
            }
            return View(character);
           
        }
       
    }
}