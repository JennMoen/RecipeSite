using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.Services;
using RecipeApp.Services.DTO;
using Microsoft.AspNetCore.Authorization;

namespace RecipeApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Recipes")]
    public class RecipesController : Controller
    {

        private RecipeService _rService;

        public RecipesController(RecipeService rs)
        {
            _rService = rs;
        }

        [HttpGet]
        [Authorize]
        public IList<RecipeDTO> Get()
        {
            return _rService.GetRecipesForUser(User.Identity.Name);
        }

        [HttpGet("recents")]
        public IList<RecipeDTO> GetTopSix(){
            return _rService.DisplayMostRecent();
        }

        [HttpPost]
        public IActionResult Add([FromBody] RecipeDTO recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _rService.AddRecipe(recipe, User.Identity.Name);
            return Ok();
        }

    }
}