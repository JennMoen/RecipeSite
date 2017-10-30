using RecipeApp.Repositories;
using RecipeApp.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Services
{
    public class CatService
    {
        private CategoryRepo _cRepo;
        private RecipeRepo _rRepo;
        private UserRepo _uRepo;

        public CatService(CategoryRepo cr, RecipeRepo rr, UserRepo ur)
        {
            _cRepo = cr;
            _rRepo = rr;
            _uRepo = ur;
        }

        public IList<CatDTO> GetCategories()
        {
            return (from c in _cRepo.GetAllCategories()
                    select new CatDTO()
                    {
                        Id = c.Id,
                        Name = c.Name
                        //Recipes = (from r in c.Recipes select new RecipeDTO()
                        //{
                        //    Id = r.Id,
                        //    DateCreated = r.DateCreated,
                        //    ImageUrl = r.ImageUrl,
                        //    Notes = r.Notes,
                        //    TimeToMake = r.TimeToMake,
                        //    Title = r.Title,
                        //    MenuId = r.MenuReference.Id                             
                        //}).ToList()
                    }).ToList();
        }

        public IList<CatDTO> GetRecipesByCategory()
        {
            return (from c in _cRepo.GetAllCategories()
                    select new CatDTO()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Recipes = (from r in c.Recipes
                                   select new RecipeDTO()
                                   {
                                       Id = r.Id,
                                       DateCreated = r.DateCreated,
                                       ImageUrl = r.ImageUrl,
                                       CatId = r.CatReference.Id,
                                       CatName = r.CatReference.Name,
                                       Notes = r.Notes,
                                       TimeToMake = r.TimeToMake,
                                       Title = r.Title,
                                       //MenuId = r.MenuId.HasValue ? r.MenuReference.Id: 0,
                                       MenuId= r.MenuId.GetValueOrDefault(),
                                       UserId = r.User.UserName

                                   }).ToList()
                    }).ToList();
        }



    }
}
