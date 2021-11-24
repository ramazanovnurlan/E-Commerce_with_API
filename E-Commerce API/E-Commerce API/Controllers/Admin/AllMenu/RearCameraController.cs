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
    public class RearCameraController : ControllerBase
    {
        private readonly MyCommerceDbContext _context;
        public RearCameraController(MyCommerceDbContext context)
        {
            _context = context;
        }

        //List------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("getRearCamera")]
        public async Task<ActionResult<IEnumerable<RearCamera>>> GetAllRearCameras()
        {
            return await _context.RearCameras.ToListAsync();
        }

        //Create----------------------------------------------------------------------------------//

        [HttpPost]
        [Route("addRearCamera")]
        public async Task<IActionResult> AddRearCamera(RearCamera rearCamera)
        {
            try
            {
                await _context.RearCameras.AddAsync(rearCamera);
                await _context.SaveChangesAsync();
                return Created("", "Rear Camera added");
            }
            catch
            {
                return BadRequest("Rear Camera not added");
            }
        }

        //Edit------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("editRearCamera/{id}")]
        public ActionResult<RearCamera> EditRearCamera(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.RearCameras.Find(id);
            }
        }

        [HttpPost]
        [Route("editRearCamera/{id}")]
        public IActionResult EditRearCamera(int id, RearCamera rearCamera)
        {
            try
            {
                var find = _context.RearCameras.Find(id);

                find.Name = rearCamera.Name;

                _context.SaveChanges();

                return Ok("Rear Camera edited");
            }
            catch (Exception)
            {
                return BadRequest("Rear Camera not edited");
            }
        }

        //Delete----------------------------------------------------------------------------------//

        [HttpGet]
        [Route("deleteRearCamera/{id}")]
        public ActionResult<RearCamera> DeleteRearCamera(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.RearCameras.Find(id);
            }
        }


        [HttpPost]
        [Route("deleteRearCamera/{id}")]
        public IActionResult DeleteRearCamera(int id)
        {
            try
            {
                var find = _context.RearCameras.Find(id);

                _context.RearCameras.Remove(find);
                _context.SaveChanges();

                return Ok("Rear Camera deleted");
            }
            catch
            {
                return BadRequest("Rear Camera not deleted");
            }
        }
    }
}
