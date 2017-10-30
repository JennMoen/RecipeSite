using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.Services;
using RecipeApp.Services.DTO;

namespace RecipeApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        private CatService _cService;

        public CategoriesController(CatService cs)
        {
            _cService = cs;
        }

        [HttpGet]
        public IEnumerable<CatDTO> GetCategories()
        {
            return _cService.GetCategories();
        }

        [HttpGet("recipes")]
        public IEnumerable<CatDTO> GetRecipesByCategory()
        {
            return _cService.GetRecipesByCategory();
        }

    }
}