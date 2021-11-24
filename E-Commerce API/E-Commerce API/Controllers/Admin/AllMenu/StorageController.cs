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
    public class StorageController : ControllerBase
    {
        private readonly MyCommerceDbContext _context;
        public StorageController(MyCommerceDbContext context)
        {
            _context = context;
        }

        //List------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("getStorage")]
        public async Task<ActionResult<IEnumerable<Storage>>> GetAllStorages()
        {
            return await _context.Storages.ToListAsync();
        }

        //Create----------------------------------------------------------------------------------//

        [HttpPost]
        [Route("addStorage")]
        public async Task<IActionResult> AddStorage(Storage storage)
        {
            try
            {
                await _context.Storages.AddAsync(storage);
                await _context.SaveChangesAsync();
                return Created("", "Storage added");
            }
            catch
            {
                return BadRequest("Storage not added");
            }
        }

        //Edit------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("editStorage/{id}")]
        public ActionResult<Storage> EditStorage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.Storages.Find(id);
            }
        }

        [HttpPost]
        [Route("editStorage/{id}")]
        public IActionResult EditStorage(int id, Storage storage)
        {
            try
            {
                var find = _context.Storages.Find(id);

                find.Name = storage.Name;

                _context.SaveChanges();

                return Ok("Storage edited");
            }
            catch (Exception)
            {
                return BadRequest("Storage not edited");
            }
        }

        //Delete----------------------------------------------------------------------------------//

        [HttpGet]
        [Route("deleteStorage/{id}")]
        public ActionResult<Storage> DeleteStorage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.Storages.Find(id);
            }
        }


        [HttpPost]
        [Route("deleteStorage/{id}")]
        public IActionResult DeleteStorage(int id)
        {
            try
            {
                var find = _context.Storages.Find(id);

                _context.Storages.Remove(find);
                _context.SaveChanges();

                return Ok("Storage deleted");
            }
            catch
            {
                return BadRequest("Storage not deleted");
            }
        }
    }
}
