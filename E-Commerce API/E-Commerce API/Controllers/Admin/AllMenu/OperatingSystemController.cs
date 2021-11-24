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
    public class OperatingSystemController : ControllerBase
    {
        private readonly MyCommerceDbContext _context;
        public OperatingSystemController(MyCommerceDbContext context)
        {
            _context = context;
        }

        //List------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("getOpSystem")]
        public async Task<ActionResult<IEnumerable<OpSystem>>> GetAllOperatingSystems()
        {
            return await _context.OpSystems.ToListAsync();
        }

        //Create----------------------------------------------------------------------------------//

        [HttpPost]
        [Route("addOpSystem")]
        public async Task<IActionResult> AddOperatingSystem(OpSystem opSystem)
        {
            try
            {
                await _context.OpSystems.AddAsync(opSystem);
                await _context.SaveChangesAsync();
                return Created("", "Operating System added");
            }
            catch
            {
                return BadRequest("Operating System not added");
            }
        }

        //Edit------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("editOpSystem/{id}")]
        public ActionResult<OpSystem> EditOperatingSystem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.OpSystems.Find(id);
            }
        }

        [HttpPost]
        [Route("editOpSystem/{id}")]
        public IActionResult EditOperatingSystem(int id, OpSystem opSystem)
        {
            try
            {
                var find = _context.OpSystems.Find(id);

                find.Name = opSystem.Name;

                _context.SaveChanges();

                return Ok("Operating System edited");
            }
            catch (Exception)
            {
                return BadRequest("Operating System not edited");
            }
        }

        //Delete----------------------------------------------------------------------------------//

        [HttpGet]
        [Route("deleteOpSystem/{id}")]
        public ActionResult<OpSystem> DeleteOperatingSystem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.OpSystems.Find(id);
            }
        }


        [HttpPost]
        [Route("deleteOpSystem/{id}")]
        public IActionResult DeleteOperatingSystem(int id)
        {
            try
            {
                var find = _context.OpSystems.Find(id);

                _context.OpSystems.Remove(find);
                _context.SaveChanges();

                return Ok("Operating System deleted");
            }
            catch
            {
                return BadRequest("Operating System not deleted");
            }
        }
    }
}
