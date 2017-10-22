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

        public IQueryable<Recipe> GetById(int id, string user)
        {
            return from r in _db.Recipes
                   where r.Id == id && r.User.UserName == user
                   select r;
        }

        public void Add(Recipe recipe)
        {
            _db.Recipes.Add(recipe);
            _db.SaveChanges();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            _db.Ingredients.Add(ingredient);
            _db.SaveChanges();
        }

        public void AddStep(Step step, int id, string user)
        {
           
            _db.Steps.Add(step);
            
            _db.SaveChanges();
        }

    }
}
