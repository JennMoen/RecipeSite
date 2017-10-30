using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.Services;
using Microsoft.AspNetCore.Authorization;
using RecipeApp.Services.DTO;

namespace RecipeApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Menus")]
    public class MenusController : Controller
    {

        private MenuService _mService;

        public MenusController(MenuService ms)
        {
            _mService = ms;
        }

        [HttpGet]
        [Authorize]
        public IList<MenuDTO> Get()
        {
            return _mService.GetyMenus(User.Identity.Name);
        }

        [HttpGet("{id}")]
        public MenuDTO GetById(int id)
        {
            return _mService.GetMenusById(id);
        }


    }
}