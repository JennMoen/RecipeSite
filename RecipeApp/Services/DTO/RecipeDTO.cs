using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Services.DTO
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        //nifty feature of C# 6--you can initialize a property without having to make a constuctor
        public DateTime DateCreated { get; set; }

        public string UserId { get; set; }

        //fun new thing to try: image uploading
        public string ImageUrl { get; set; }

        public string Title { get; set; }
        public IList<IngredientDTO> Ingredients { get; set; }
        public IList<StepDTO> Steps { get; set; }

        public string TimeToMake { get; set; }

        public string Notes { get; set; }

        public int MenuId { get; set; }



    }
}
