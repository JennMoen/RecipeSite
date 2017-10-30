using RecipeApp.Repositories;
using RecipeApp.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Services
{
    public class MenuService
    {
        private MenuRepo _mRepo;
        private UserRepo _uRepo;

        public MenuService(MenuRepo mr, UserRepo ur)
        {
            _mRepo = mr;
            _uRepo = ur;
        }

        public IList<MenuDTO> GetyMenus(string user)
        {
            return (from m in _mRepo.GetMyMenus(user)
                    select new MenuDTO()
                    {
                        Id = m.Id,
                        Name = m.Name,
                        User = user,
                        Recipes = (from r in m.MenuItems select new RecipeDTO()
                        {
                            Id= r.Id,
                            DateCreated = r.DateCreated,
                            ImageUrl = r.ImageUrl,
                            Notes = r.Notes,
                            TimeToMake = r.TimeToMake,
                            Title = r.Title,

                        }).ToList()
                    }).ToList();
        }

        public MenuDTO GetMenusById(int id)
        {
            return (from m in _mRepo.GetMenuById(id)
                    select new MenuDTO()
                    {
                        Id = m.Id,
                        Name = m.Name,
                        User = m.User.UserName,
                        Recipes = (from r in m.MenuItems
                                   select new RecipeDTO()
                                   {
                                       Id = r.Id,
                                       DateCreated = r.DateCreated,
                                       ImageUrl = r.ImageUrl,
                                       Notes = r.Notes,
                                       TimeToMake = r.TimeToMake,
                                       Title = r.Title,

                                   }).ToList()
                    }).FirstOrDefault();
        }




    }
}
