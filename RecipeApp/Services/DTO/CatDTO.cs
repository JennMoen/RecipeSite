﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Services.DTO
{
    public class CatDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<RecipeDTO> Recipes { get; set; }
    }
}
