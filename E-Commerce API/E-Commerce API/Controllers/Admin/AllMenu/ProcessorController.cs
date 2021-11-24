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
    public class ProcessorController : ControllerBase
    {
        private readonly MyCommerceDbContext _context;
        public ProcessorController(MyCommerceDbContext context)
        {
            _context = context;
        }

        //List------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("getProcessor")]
        public async Task<ActionResult<IEnumerable<Processor>>> GetAllProcessors()
        {
            return await _context.Processors.ToListAsync();
        }

        //Create----------------------------------------------------------------------------------//

        [HttpPost]
        [Route("addProcessor")]
        public async Task<IActionResult> AddProcessor(Processor processor)
        {
            try
            {
                await _context.Processors.AddAsync(processor);
                await _context.SaveChangesAsync();
                return Created("", "Processor added");
            }
            catch
            {
                return BadRequest("Processor not added");
            }
        }

        //Edit------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("editProcessor/{id}")]
        public ActionResult<Processor> EditProcessor(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.Processors.Find(id);
            }
        }

        [HttpPost]
        [Route("editProcessor/{id}")]
        public IActionResult EditProcessor(int id, Processor processor)
        {
            try
            {
                var find = _context.Processors.Find(id);

                find.Name = processor.Name;

                _context.SaveChanges();

                return Ok("Processor edited");
            }
            catch (Exception)
            {
                return BadRequest("Processor not edited");
            }
        }

        //Delete----------------------------------------------------------------------------------//

        [HttpGet]
        [Route("deleteProcessor/{id}")]
        public ActionResult<Processor> DeleteProcessor(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.Processors.Find(id);
            }
        }


        [HttpPost]
        [Route("deleteProcessor/{id}")]
        public IActionResult DeleteProcessor(int id)
        {
            try
            {
                var find = _context.Processors.Find(id);

                _context.Processors.Remove(find);
                _context.SaveChanges();

                return Ok("Processor deleted");
            }
            catch
            {
                return BadRequest("Processor not deleted");
            }
        }
    }
}
