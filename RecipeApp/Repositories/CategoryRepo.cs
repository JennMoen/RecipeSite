using RecipeApp.Data;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Repositories
{
    public class CategoryRepo
    {
        private ApplicationDbContext _db;

        public CategoryRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<Category> GetCatByName(string name)
        {
            return from c in _db.Categories
                   where c.Name == name
                   select c;
        }

        public IQueryable<Category> GetAllCategories()
        {
            return from c in _db.Categories
                   select c;
        }

    }
}
