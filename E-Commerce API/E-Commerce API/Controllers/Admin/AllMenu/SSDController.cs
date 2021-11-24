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
    public class SSDController : ControllerBase
    {
        private readonly MyCommerceDbContext _context;
        public SSDController(MyCommerceDbContext context)
        {
            _context = context;
        }

        //List------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("getSSD")]
        public async Task<ActionResult<IEnumerable<SSD>>> GetAllSSDs()
        {
            return await _context.SSDs.ToListAsync();
        }

        //Create----------------------------------------------------------------------------------//

        [HttpPost]
        [Route("addSSD")]
        public async Task<IActionResult> AddSSD(SSD ssd)
        {
            try
            {
                await _context.SSDs.AddAsync(ssd);
                await _context.SaveChangesAsync();
                return Created("", "SSD added");
            }
            catch
            {
                return BadRequest("SSD not added");
            }
        }

        //Edit------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("editSSD/{id}")]
        public ActionResult<SSD> EditSSD(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.SSDs.Find(id);
            }
        }

        [HttpPost]
        [Route("editSSD/{id}")]
        public IActionResult EditSSD(int id, SSD ssd)
        {
            try
            {
                var find = _context.SSDs.Find(id);

                find.Name = ssd.Name;

                _context.SaveChanges();

                return Ok("SSD edited");
            }
            catch (Exception)
            {
                return BadRequest("SSD not edited");
            }
        }

        //Delete----------------------------------------------------------------------------------//

        [HttpGet]
        [Route("deleteSSD/{id}")]
        public ActionResult<SSD> DeleteSSD(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.SSDs.Find(id);
            }
        }


        [HttpPost]
        [Route("deleteSSD/{id}")]
        public IActionResult DeleteSSD(int id)
        {
            try
            {
                var find = _context.SSDs.Find(id);

                _context.SSDs.Remove(find);
                _context.SaveChanges();

                return Ok("SSD deleted");
            }
            catch
            {
                return BadRequest("SSD not deleted");
            }
        }
    }
}
