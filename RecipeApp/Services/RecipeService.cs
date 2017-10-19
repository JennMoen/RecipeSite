using RecipeApp.Models;
using RecipeApp.Repositories;
using RecipeApp.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Services
{
    public class RecipeService
    {

        private RecipeRepo _rRepo;
        private UserRepo _uRepo;

        public RecipeService(RecipeRepo rr, UserRepo ur)
        {
            _rRepo = rr;
            _uRepo = ur;
        }


        public IList<RecipeDTO> GetRecipesForUser(string user)
        {
            return (from r in _rRepo.GetUserRecipes(user)
                    select new RecipeDTO()
                    {
                        Id = r.Id,
                        Title = r.Title,
                        ImageUrl = r.ImageUrl,
                        TimeToMake = r.TimeToMake,
                        Notes = r.Notes,
                        DateCreated = r.DateCreated,
                        Ingredients = (from i in r.Ingredients
                                       select new IngredientDTO
                                       {
                                           Id = i.Id,
                                           Amount = i.Amount,
                                           Name = i.Name
                                       }).ToList(),
                        Steps = (from s in r.Steps
                                 select new StepDTO
                                 {
                                     Id = s.Id,
                                     Description = s.Description
                                 }).ToList()

                    }).ToList();

        }

        public IList<RecipeDTO> DisplayMostRecent()
        {

            return (from r in _rRepo.GetMostRecent()
                    select new RecipeDTO()
                    {
                        Id = r.Id,
                        Title = r.Title,
                        ImageUrl = r.ImageUrl,
                        TimeToMake = r.TimeToMake,
                        Notes = r.Notes,
                        DateCreated = r.DateCreated,
                        Ingredients = (from i in r.Ingredients
                                       select new IngredientDTO
                                       {
                                           Id = i.Id,
                                           Amount = i.Amount,
                                           Name = i.Name
                                       }).ToList(),
                        Steps = (from s in r.Steps
                                 select new StepDTO
                                 {
                                     Id = s.Id,
                                     Description = s.Description
                                 }).ToList()

                    }).ToList();

        }

        public void AddRecipe(RecipeDTO recipe, string currentUser)
        {
            Recipe dbRecipe = new Recipe()
            {
                Id = recipe.Id,
                Title = recipe.Title,
                ImageUrl = recipe.ImageUrl,
                DateCreated = DateTime.Now,
                Notes = recipe.Notes,
                UserId = _uRepo.getCurrentUser(currentUser).First().Id

            };
            _rRepo.Add(dbRecipe);
        }
    }
}
