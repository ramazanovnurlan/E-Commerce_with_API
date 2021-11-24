using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_API.Data;
using E_Commerce_API.Models.Admin.AllMenu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Controllers.Admin.AllMenu
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly MyCommerceDbContext _context;
        public ColorController(MyCommerceDbContext context)
        {
            _context = context;
        }

        //List------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("getColor")]
        public async Task<ActionResult<IEnumerable<Color>>> GetAllColors()
        {
            return await _context.Colors.ToListAsync();
        }

        //Create----------------------------------------------------------------------------------//

        [HttpPost]
        [Route("addColor")]
        public async Task<IActionResult> AddColor(Color color)
        {
            try
            {
                await _context.Colors.AddAsync(color);
                await _context.SaveChangesAsync();
                return Created("", "Color added");
            }
            catch
            {
                return BadRequest("Color not added");
            }
        }

        //Edit------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("editColor/{id}")]
        public ActionResult<Color> EditColor(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.Colors.Find(id);
            }
        }

        [HttpPost]
        [Route("editColor/{id}")]
        public IActionResult EditColor(int id, Color color)
        {
            try
            {
                var find = _context.Colors.Find(id);

                find.Name = color.Name;

                _context.SaveChanges();

                return Ok("Color edited");
            }
            catch (Exception)
            {
                return BadRequest("Color not edited");
            }
        }

        //Delete----------------------------------------------------------------------------------//

        [HttpGet]
        [Route("deleteColor/{id}")]
        public ActionResult<Color> DeleteColor(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.Colors.Find(id);
            }
        }


        [HttpPost]
        [Route("deleteColor/{id}")]
        public IActionResult DeleteColor(int id)
        {
            try
            {
                var find = _context.Colors.Find(id);

                _context.Colors.Remove(find);
                _context.SaveChanges();

                return Ok("Color deleted");
            }
            catch
            {
                return BadRequest("Color not deleted");
            }
        }
    }
}
