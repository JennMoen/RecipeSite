using RecipeApp.Data;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Repositories
{
    public class RecipeRepo
    {

        private ApplicationDbContext _db;

        
        public RecipeRepo( ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<Recipe> GetUserRecipes(string user)
        {
            return from r in _db.Recipes
                   where r.User.UserName == user
                   select r;
        }

        public IQueryable<Recipe> GetMostRecent()
        {
            var recipes = (from r in _db.Recipes
                   orderby r.DateCreated
                   select r).Take(6);
            return recipes;
                   
        }

        public void Add(Recipe recipe)
        {
            _db.Recipes.Add(recipe);
            _db.SaveChanges();
        }

    }
}
