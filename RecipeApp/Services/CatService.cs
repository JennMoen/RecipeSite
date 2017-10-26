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

        public CatService(CategoryRepo cr, RecipeRepo rr)
        {
            _cRepo = cr;
            _rRepo = rr;
        }

        public IList<CatDTO> GetCategories()
        {
            return (from c in _cRepo.GetAllCategories()
                    select new CatDTO()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Recipes = (from r in c.Recipes select new RecipeDTO()
                        {
                            Id = r.Id,
                            DateCreated = r.DateCreated,
                            ImageUrl = r.ImageUrl,
                            Notes = r.Notes,
                            TimeToMake = r.TimeToMake,
                            Title = r.Title,
                            MenuId = r.MenuReference.Id                             
                        }).ToList()
                    }).ToList();
        }



    }
}
