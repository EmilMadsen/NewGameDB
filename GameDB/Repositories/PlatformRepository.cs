using GameDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace GameDB.Repositories
{
    public class PlatformRepository : IRepository<Platform>
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public void Delete(int id)
        {
            db.Platforms.Remove(db.Platforms.Find(id));
        }

        public Platform Find(int id)
        {
            return db.Platforms.Find(id);
        }

        public List<Platform> GetAll()
        {
            return db.Platforms.ToList();
        }

        public List<Platform> GetAll(string search = "")
        {
            var selectedPlatforms = (from p in db.Platforms where p.name.Contains(search) select p).ToList();
            return selectedPlatforms;
        }

        public void InsertOrUpdate(Platform platform)
        {
            if (platform.PlatformID == 0)
            {
                db.Platforms.Add(platform);
            }
            else
            {
                db.Entry(platform).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
        }
    }
}