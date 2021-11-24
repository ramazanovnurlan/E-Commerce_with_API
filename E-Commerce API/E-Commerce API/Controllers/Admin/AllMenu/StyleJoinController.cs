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
    public class StyleJoinController : ControllerBase
    {
        private readonly MyCommerceDbContext _context;
        public StyleJoinController(MyCommerceDbContext context)
        {
            _context = context;
        }

        //List------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("getStyleJoin")]
        public async Task<ActionResult<IEnumerable<StyleJoin>>> GetAllStyleJoins()
        {
            return await _context.StyleJoins.ToListAsync();
        }

        //Create----------------------------------------------------------------------------------//

        [HttpPost]
        [Route("addStyleJoin")]
        public async Task<IActionResult> AddStyleJoin(StyleJoin styleJoin)
        {
            try
            {
                await _context.StyleJoins.AddAsync(styleJoin);
                await _context.SaveChangesAsync();
                return Created("", "Style Join added");
            }
            catch
            {
                return BadRequest("Style Join not added");
            }
        }

        //Edit------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("editStyleJoin/{id}")]
        public ActionResult<StyleJoin> EditStyleJoin(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.StyleJoins.Find(id);
            }
        }

        [HttpPost]
        [Route("editStyleJoin/{id}")]
        public IActionResult EditStyleJoin(int id, StyleJoin styleJoin)
        {
            try
            {
                var find = _context.StyleJoins.Find(id);

                find.Name = styleJoin.Name;

                _context.SaveChanges();

                return Ok("Style Join edited");
            }
            catch (Exception)
            {
                return BadRequest("Style Join not edited");
            }
        }

        //Delete----------------------------------------------------------------------------------//

        [HttpGet]
        [Route("deleteStyleJoin/{id}")]
        public ActionResult<StyleJoin> DeleteStyleJoin(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.StyleJoins.Find(id);
            }
        }


        [HttpPost]
        [Route("deleteStyleJoin/{id}")]
        public IActionResult DeleteStyleJoin(int id)
        {
            try
            {
                var find = _context.StyleJoins.Find(id);

                _context.StyleJoins.Remove(find);
                _context.SaveChanges();

                return Ok("Style Join deleted");
            }
            catch
            {
                return BadRequest("Style Join not deleted");
            }
        }
    }
}
