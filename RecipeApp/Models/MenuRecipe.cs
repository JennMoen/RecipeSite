using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class MenuRecipe
    {
        public int RecipeId { get; set; }
        [ForeignKey("RecipeId")]
        public Recipe Recipe { get; set; }

        public int MenuId { get; set; }
        [ForeignKey("MenuId")]
        public Menu Menu { get; set; }


    }
}
