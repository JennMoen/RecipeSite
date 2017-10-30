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

        [HttpGet("{id}")]
        public RecipeDTO GetById(int id, string user)
        {
            return _rService.GetById(id, User.Identity.Name);
        }

        [Authorize]
        [HttpPost("{id}/steps")]
        public IActionResult AddStep([FromBody] StepDTO step, int id)
        {
            id = _rService.GetById(id, User.Identity.Name).Id;
               
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _rService.AddRecipeStep(step, id, User.Identity.Name);
            return Ok();
        }

        [HttpPost("{id}/ingredients")]
        public IActionResult AddIngredient([FromBody] IngredientDTO ingredient, int id)
        {
            id = _rService.GetById(id, User.Identity.Name).Id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _rService.AddIngredient(ingredient, id, User.Identity.Name);
            return Ok();
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
         [HttpDelete("{id}")]
         public IActionResult DeleteRecipe(RecipeDTO recipe, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            recipe.Id = id;
            _rService.DeleteRecipe(recipe, User.Identity.Name);

            return Ok();
        }
    }
}