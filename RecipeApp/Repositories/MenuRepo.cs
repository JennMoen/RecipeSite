using RecipeApp.Data;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Repositories
{
    public class MenuRepo
    {
        private ApplicationDbContext _db;


        public MenuRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<Menu> GetMyMenus(string user)
        {
            return from m in _db.Menus
                   where m.User.UserName == user
                   select m;
        }

        public IQueryable<Menu> GetMenuById(int id)
        {
            return from m in _db.Menus
                   where m.Id == id
                   select m;
        }

        public void AddMenu(Menu menu)
        {
            _db.Menus.Add(menu);
            _db.SaveChanges();
        }

    }
}
