﻿using RecipeApp.Models;
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
                        CatId = r.CatId,
                        CatName = r.CatReference.Name,
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

        public RecipeDTO GetById(int id, string user)
        {
            return (from r in _rRepo.GetById(id, user)
                    select new RecipeDTO()
                    {
                        Id=id,
                        Title = r.Title,
                        ImageUrl = r.ImageUrl,
                        TimeToMake = r.TimeToMake,
                        Notes = r.Notes,
                        CatId = r.CatId,
                        CatName = r.CatReference.Name,
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
                                 }).ToList(),
                        UserId = _uRepo.getCurrentUser(user).First().Id
                    }).First();
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
                        UserName = r.User.UserName,
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
                CatId = recipe.CatId,
                //CatReference = (Category)recipe.Catetory,
                //MenuId = recipe.Menu.Id,
                UserId = _uRepo.getCurrentUser(currentUser).First().Id

            };
            _rRepo.Add(dbRecipe);
        }

        public void AddRecipeStep(StepDTO step, int id, string user)
        {
           
            Step dbStep = new Step()
            {
                Id = step.Id,
                Description = step.Description,
                RecipeId = _rRepo.GetById(id, user).First().Id
                
            };
            
            
            _rRepo.AddStep(dbStep);

        }

        public void AddIngredient(IngredientDTO ingredient, int id, string user)
        {

            Ingredient dbIngredient = new Ingredient()
            {
                Id = ingredient.Id,                
                Amount= ingredient.Amount,
                Name=ingredient.Name,
                RecipeId = _rRepo.GetById(id, user).First().Id

            };

            _rRepo.AddIngredient(dbIngredient);

        }

        public void DeleteRecipe(RecipeDTO recipe, string user)
        {
            _rRepo.DeleteRecipe(_rRepo.GetById(recipe.Id, user).First());
        }

    }
}
