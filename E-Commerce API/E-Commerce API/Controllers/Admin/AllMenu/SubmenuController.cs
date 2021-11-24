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

namespace E_Commerce_API.Controllers.Admin.Menu
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmenuController : ControllerBase
    {
        private readonly MyCommerceDbContext _context;
        public SubmenuController(MyCommerceDbContext context)
        {
            _context = context;
        }

        //List------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("getSubmenu")]
        public async Task<ActionResult<IEnumerable<Submenu>>> GetAllSubmenus()
        {
            return await _context.Submenus.ToListAsync();
        }

        //Create----------------------------------------------------------------------------------//

        [HttpPost]
        [Route("addSubmenu")]
        public async Task<IActionResult> AddSubmenu(Submenu submenu)
        {
            try
            {
                await _context.Submenus.AddAsync(submenu);
                await _context.SaveChangesAsync();
                return Created("", "Submenu added");
            }
            catch
            {
                return BadRequest("Submenu not added");
            }
        }

        //Edit------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("editSubmenu/{id}")]
        public ActionResult<Submenu> EditSubmenu(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.Submenus.Find(id);
            }
        }

        [HttpPost]
        [Route("editSubmenu/{id}")]
        public IActionResult EditSubmenu(int id, Submenu submenu)
        {
            try
            {
                var find = _context.Submenus.Find(id);

                find.Name = submenu.Name;

                _context.SaveChanges();

                return Ok("Submenu edited");
            }
            catch (Exception)
            {
                return BadRequest("Submenu not edited");
            }
        }

        //[HttpPost]
        //[Route("editSubmenu/{id}")]
        //public IActionResult EditSubmenu(int id, Submenu submenu)
        //{
        //    var find = _context.Submenus.Find(id);

        //    find.Name = submenu.Name;

        //    _context.SaveChanges();

        //    return Ok("Menu edited");
        //}

        //Delete----------------------------------------------------------------------------------//

        [HttpGet]
        [Route("deleteSubmenu/{id}")]
        public ActionResult<Submenu> DeleteSubmenu(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.Submenus.Find(id);
            }
        }


        [HttpPost]
        [Route("deleteSubmenu/{id}")]
        public IActionResult DeleteSubmenu(int id)
        {
            try
            {
                var find = _context.Submenus.Find(id);

                _context.Submenus.Remove(find);
                _context.SaveChanges();

                return Ok("Submenu deleted");
            }
            catch 
            {
                return BadRequest("Submenu not deleted");
            }
        }
    }
}
