using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.Services.DTO;
using RecipeApp.Services;

namespace RecipeApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Notes")]
    public class NotesController : Controller
    {
        private NoteService _nService;

        public NotesController(NoteService ns)
        {
            _nService = ns;
        }

        [HttpGet]
        public IEnumerable<NoteDTO> GetMyNotes()
        {
            return _nService.GetMyNotes(User.Identity.Name);
        }

        [HttpGet("{id}")]
        public NoteDTO GetById(int id)
        {
            return _nService.GetById(id);
        }


        [HttpPost]
        public IActionResult Addnote([FromBody]NoteDTO note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _nService.AddNote(note, User.Identity.Name);
            return Ok();
        }

    }
}