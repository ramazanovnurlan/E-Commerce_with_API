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
    public class BrandController : ControllerBase
    {
        private readonly MyCommerceDbContext _context;
        public BrandController(MyCommerceDbContext context)
        {
            _context = context;
        }

        //List-------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("getBrand")]
        public async Task<ActionResult<IEnumerable<Brand>>> GetAllBrands()
        {
            return await _context.Brands.ToListAsync();
        }

        //Create----------------------------------------------------------------------------------//

        [HttpPost]
        [Route("addBrand")]
        public async Task<IActionResult> AddBrand(Brand brand)
        {
            try
            {
                await _context.Brands.AddAsync(brand);
                await _context.SaveChangesAsync();
                return Created("", "Brand added");
            }
            catch
            {
                return BadRequest("Brand not added");
            }
        }

        //Edit------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("editBrand/{id}")]
        public ActionResult<Brand> EditBrand(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.Brands.Find(id);
            }
        }

        [HttpPost]
        [Route("editBrand/{id}")]
        public IActionResult EditBrand(int id, Brand brand)
        {
            try
            {
                var find = _context.Brands.Find(id);

                find.Name = brand.Name;

                _context.SaveChanges();

                return Ok("Brand edited");
            }
            catch (Exception)
            {
                return BadRequest("Brand not edited");
            }
        }

        //Delete----------------------------------------------------------------------------------//

        [HttpGet]
        [Route("deleteBrand/{id}")]
        public ActionResult<Brand> DeleteBrand(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.Brands.Find(id);
            }
        }

        [HttpPost]
        [Route("deleteBrand/{id}")]
        public IActionResult DeleteBrand(int id)
        {
            try
            {
                var find = _context.Brands.Find(id);

                _context.Brands.Remove(find);
                _context.SaveChanges();

                return Ok("Brand deleted");
            }
            catch
            {
                return BadRequest("Brand not deleted");
            }
        }
    }
}
