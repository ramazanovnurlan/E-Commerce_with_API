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
    public class RAMController : ControllerBase
    {
        private readonly MyCommerceDbContext _context;
        public RAMController(MyCommerceDbContext context)
        {
            _context = context;
        }

        //List------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("getRAM")]
        public async Task<ActionResult<IEnumerable<RAM>>> GetAllRAMs()
        {
            return await _context.RAMs.ToListAsync();
        }

        //Create----------------------------------------------------------------------------------//

        [HttpPost]
        [Route("addRAM")]
        public async Task<IActionResult> AddRAM(RAM ram)
        {
            try
            {
                await _context.RAMs.AddAsync(ram);
                await _context.SaveChangesAsync();
                return Created("", "RAM added");
            }
            catch
            {
                return BadRequest("RAM not added");
            }
        }

        //Edit------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("editRAM/{id}")]
        public ActionResult<RAM> EditRAM(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.RAMs.Find(id);
            }
        }

        [HttpPost]
        [Route("editRAM/{id}")]
        public IActionResult EditRAM(int id, RAM ram)
        {
            try
            {
                var find = _context.RAMs.Find(id);

                find.Name = ram.Name;

                _context.SaveChanges();

                return Ok("RAM edited");
            }
            catch (Exception)
            {
                return BadRequest("RAM not edited");
            }
        }

        //Delete----------------------------------------------------------------------------------//

        [HttpGet]
        [Route("deleteRAM/{id}")]
        public ActionResult<RAM> DeleteRAM(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.RAMs.Find(id);
            }
        }


        [HttpPost]
        [Route("deleteRAM/{id}")]
        public IActionResult DeleteRAM(int id)
        {
            try
            {
                var find = _context.RAMs.Find(id);

                _context.RAMs.Remove(find);
                _context.SaveChanges();

                return Ok("RAM deleted");
            }
            catch
            {
                return BadRequest("RAM not deleted");
            }
        }
    }
}
