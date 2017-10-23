using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class Menu
    {
        //have the items be of type Recipe so that I can link them up!
        public int Id { get; set; }
        public string Name { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public IList<Recipe> MenuItems { get; set; }





    }
}
