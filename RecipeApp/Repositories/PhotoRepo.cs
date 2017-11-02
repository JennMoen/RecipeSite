using RecipeApp.Data;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Repositories
{
    public class PhotoRepo
    {
        private ApplicationDbContext _db;

        public PhotoRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<Photo> GetPhotos()
        {
            return from p in _db.Photos
                   select p;
        }

        public IQueryable<Photo>GetPicById(int id)
        {
            return from p in _db.Photos
                   where p.Id == id
                   select p;
        }

        public void AddPhoto(Photo pic)
        {
            _db.Photos.Add(pic);
            _db.SaveChanges();
        }

        public void DeletePhoto(Photo pic)
        {
            _db.Photos.Remove(pic);
            _db.SaveChanges();
        }

    }
}
