using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        //I want to be able to enter a recipe without a menu ID because not every recipe may be associated with a menu so I experimented with making it nullable here
        public int? MenuId { get; set; }
        [ForeignKey("MenuId")]
        public Menu MenuReference { get; set; }

        public DateTime DateCreated { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string TimeToMake { get; set; }
        public string Notes { get; set; }

        public IList<Ingredient> Ingredients { get; set; }
        public IList<Step> Steps { get; set; }

        



    }
}
