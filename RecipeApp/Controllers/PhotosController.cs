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
    [Route("api/Photos")]
    public class PhotosController : Controller
    {
        private PhotoService _pService;

        public PhotosController(PhotoService ps)
        {
            _pService = ps;
        }

       [HttpGet]
       public IList<PhotoDTO> GetPhotos()
        {
            return _pService.GetPhotos();
        }

       [HttpGet("{id}")]
       public PhotoDTO GetById(int id)
        {
            return _pService.GetPicById(id);
        }

       [HttpPost]
       public IActionResult PostPic([FromBody]PhotoDTO pic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _pService.AddPhoto(pic);
            return Ok();
        }

       [HttpDelete("{id}")]
       public IActionResult DeletePic(PhotoDTO pic, int id)
        {
            id = pic.Id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _pService.DeletePhoto(pic);
            return Ok();
        }

    }
}