using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Services.DTO
{
    public class StepDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int RecipeId { get; set; }

    }
}
