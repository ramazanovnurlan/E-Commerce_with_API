using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_API.Data;
using E_Commerce_API.Models.Admin.AllMenu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly MyCommerceDbContext _context;
        public MenuController(MyCommerceDbContext context)
        {
            _context = context;
        }

        //List------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("getMenu")]
        public async Task<ActionResult<IEnumerable<Menu>>> GetAllMenus()
        {
            return await _context.Menus.ToListAsync();
        }

        //Create----------------------------------------------------------------------------------//

        [HttpPost]
        [Route("addMenu")]
        public async Task<IActionResult> AddMenu(Menu menu)
        {
            try
            {
                await _context.Menus.AddAsync(menu);
                await _context.SaveChangesAsync();
                return Created("", "Menu added");
            }
            catch
            {
                return BadRequest("Menu not added");
            }
        }

        //Edit------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("editMenu/{id}")]
        public ActionResult<Menu> EditMenu(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.Menus.Find(id);
            }
        }

        [HttpPost]
        [Route("editMenu/{id}")]
        public IActionResult EditMenu(int id, Menu menu)
        {
            try
            {
                var find = _context.Menus.Find(id);

                find.Name = menu.Name;

                _context.SaveChanges();

                return Ok("Menu edited");
            }
            catch
            {
                return BadRequest("Menu not edited");
            }
        }

        //Delete----------------------------------------------------------------------------------//

        [HttpGet]
        [Route("deleteMenu/{id}")]
        public ActionResult<Menu> DeleteMenu(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.Menus.Find(id);
            }
        }

        [HttpPost]
        [Route("deleteMenu/{id}")]
        public IActionResult DeleteMenu(int id)
        {
            try
            {
                var find = _context.Menus.Find(id);

                _context.Menus.Remove(find);
                _context.SaveChanges();

                return Ok("Menu deleted");
            }
            catch
            {
                return BadRequest("Menu not deleted");
            }
        }
    }
}
