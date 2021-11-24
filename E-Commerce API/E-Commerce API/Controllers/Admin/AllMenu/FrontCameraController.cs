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
    public class FrontCameraController : ControllerBase
    {
        private readonly MyCommerceDbContext _context;
        public FrontCameraController(MyCommerceDbContext context)
        {
            _context = context;
        }

        //List------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("getFrontCamera")]
        public async Task<ActionResult<IEnumerable<FrontCamera>>> GetAllFrontCameras()
        {
            return await _context.FrontCameras.ToListAsync();
        }

        //Create----------------------------------------------------------------------------------//

        [HttpPost]
        [Route("addFrontCamera")]
        public async Task<IActionResult> AddSubmenu(FrontCamera frontCamera)
        {
            try
            {
                await _context.FrontCameras.AddAsync(frontCamera);
                await _context.SaveChangesAsync();
                return Created("", "Front Camera added");
            }
            catch
            {
                return BadRequest("Front Camera not added");
            }
        }

        //Edit------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("editFrontCamera/{id}")]
        public ActionResult<FrontCamera> EditFrontCamera(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.FrontCameras.Find(id);
            }
        }

        [HttpPost]
        [Route("editFrontCamera/{id}")]
        public IActionResult EditFrontCamera(int id, FrontCamera frontCamera)
        {
            try
            {
                var find = _context.FrontCameras.Find(id);

                find.Name = frontCamera.Name;

                _context.SaveChanges();

                return Ok("Front Camera edited");
            }
            catch (Exception)
            {
                return BadRequest("Front Camera not edited");
            }
        }

        //Delete----------------------------------------------------------------------------------//

        [HttpGet]
        [Route("deleteFrontCamera/{id}")]
        public ActionResult<FrontCamera> DeleteFrontCamera(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.FrontCameras.Find(id);
            }
        }


        [HttpPost]
        [Route("deleteFrontCamera/{id}")]
        public IActionResult DeleteFrontCamera(int id)
        {
            try
            {
                var find = _context.FrontCameras.Find(id);

                _context.FrontCameras.Remove(find);
                _context.SaveChanges();

                return Ok("Front Camera deleted");
            }
            catch
            {
                return BadRequest("Front Camera not deleted");
            }
        }
    }
}
