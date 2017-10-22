using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class Menu
    {
        //have the items be of type Recipe so that I can link them up!
        public int Id { get; set; }

        public IList<Recipe> MenuItems { get; set; }





    }
}
