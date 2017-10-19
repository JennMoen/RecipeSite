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
        //nifty feature of C# 6--you can initialize a property without having to make a constuctor if you need to
        public DateTime DateCreated { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        //fun new thing to try: image uploading
        public string ImageUrl { get; set; }

        public string Title { get; set; }
        public IList<Ingredient> Ingredients { get; set; }
        public IList<Step> Steps { get; set; }

        public string TimeToMake { get; set; }

        public string Notes { get; set; }


    }
}
