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
    public class GraphicsCardController : ControllerBase
    {
        private readonly MyCommerceDbContext _context;
        public GraphicsCardController(MyCommerceDbContext context)
        {
            _context = context;
        }

        //List------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("getGraphicsCard")]
        public async Task<ActionResult<IEnumerable<GraphicsCard>>> GetAllGraphicsCards()
        {
            return await _context.GraphicsCards.ToListAsync();
        }

        //Create----------------------------------------------------------------------------------//

        [HttpPost]
        [Route("addGraphicsCard")]
        public async Task<IActionResult> AddGraphicsCard(GraphicsCard graphicsCard)
        {
            try
            {
                await _context.GraphicsCards.AddAsync(graphicsCard);
                await _context.SaveChangesAsync();
                return Created("", "Graphics Card added");
            }
            catch
            {
                return BadRequest("Graphics Card not added");
            }
        }

        //Edit------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("editGraphicsCard/{id}")]
        public ActionResult<GraphicsCard> EditGraphicsCard(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.GraphicsCards.Find(id);
            }
        }

        [HttpPost]
        [Route("editGraphicsCard/{id}")]
        public IActionResult EditGraphicsCard(int id, GraphicsCard graphicsCard)
        {
            try
            {
                var find = _context.GraphicsCards.Find(id);

                find.Name = graphicsCard.Name;

                _context.SaveChanges();

                return Ok("Graphics Card edited");
            }
            catch (Exception)
            {
                return BadRequest("Graphics Card not edited");
            }
        }

        //Delete----------------------------------------------------------------------------------//

        [HttpGet]
        [Route("deleteGraphicsCard/{id}")]
        public ActionResult<GraphicsCard> DeleteGraphicsCard(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.GraphicsCards.Find(id);
            }
        }


        [HttpPost]
        [Route("deleteGraphicsCard/{id}")]
        public IActionResult DeleteGraphicsCard(int id)
        {
            try
            {
                var find = _context.GraphicsCards.Find(id);

                _context.GraphicsCards.Remove(find);
                _context.SaveChanges();

                return Ok("Graphics Card deleted");
            }
            catch
            {
                return BadRequest("Graphics Card not deleted");
            }
        }
    }
}
