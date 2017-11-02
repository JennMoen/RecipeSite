using RecipeApp.Models;
using RecipeApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Services
{
    public class MenuRecipeService
    {
        private MenuRecipeRepo _mrRepo;
        private MenuRepo _mRepo;
        private RecipeRepo _rRepo;

        public MenuRecipeService(MenuRecipeRepo mrr, MenuRepo mr, RecipeRepo rr)
        {
            _mrRepo = mrr;
            _mRepo = mr;
            _rRepo = rr;
        }

        public void AddMenuItem(int menuId, int recipeId, string user)
        {
            MenuRecipe dbMRecipe = new MenuRecipe()
            {
                MenuId = _mRepo.GetMenuById(menuId).First().Id,
                RecipeId = _rRepo.GetById(recipeId, user).First().Id
            };

            _mrRepo.AddMenuItem(dbMRecipe);
        }
    }
}
