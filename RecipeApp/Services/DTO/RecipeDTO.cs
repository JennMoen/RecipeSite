using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Services.DTO
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int MenuId { get; set; }
        //public MenuDTO Menu { get; set; }
        public int CatId { get; set; }
        //public CatDTO Catetory { get; set; }
        public string CatName { get; set; }

        public DateTime DateCreated { get; set; }       
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string TimeToMake { get; set; }
        public string Notes { get; set; }


        public IList<IngredientDTO> Ingredients { get; set; }
        public IList<StepDTO> Steps { get; set; }

       

        



    }
}
