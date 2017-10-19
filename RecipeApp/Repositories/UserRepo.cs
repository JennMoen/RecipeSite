using RecipeApp.Data;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Repositories
{
    public class UserRepo
    {
        private ApplicationDbContext _db;


        public UserRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<ApplicationUser> getCurrentUser(string userName)
        {
            return from u in _db.Users
                   where u.UserName == userName
                   select u;
        }


    }
}
