using GameDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace GameDB.Repositories
{
    public class CharacterRepository : IRepository<Character>
    {

        ApplicationDbContext db = new ApplicationDbContext();

        public void Delete(int id)
        {
            db.Characters.Remove(db.Characters.Find(id));
            db.SaveChanges();
        }

        public Character Find(int id)
        {
            return db.Characters.Find(id);
        }

        public List<Character> GetAll()
        {
            return db.Characters.ToList();
        }

        public List<Character> GetAll(string search = "")
        {
            var selectedCharacters = (from c in db.Characters where c.Name.Contains(search) select c).ToList();
            return selectedCharacters;
        }

        public void InsertOrUpdate(Character character)
        {
            if (character.CharacterID == 0)
            {
                db.Characters.Add(character);
            }
            else
            {
                db.Entry(character).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
        }
    }
}