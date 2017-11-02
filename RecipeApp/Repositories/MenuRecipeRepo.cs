using RecipeApp.Data;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Repositories
{
    public class MenuRecipeRepo
    {
        private ApplicationDbContext _db;

        public MenuRecipeRepo(ApplicationDbContext db)
        {
            _db = db;
        }


        public void AddMenuItem(MenuRecipe item)
        {
            if((from mr in _db.MenuRecipes
                where mr.MenuId == item.MenuId
                && mr.RecipeId == item.RecipeId
                select mr).FirstOrDefault() == null)
            {
                _db.MenuRecipes.Add(item);
                _db.SaveChanges();
            }
        }



    }
}
