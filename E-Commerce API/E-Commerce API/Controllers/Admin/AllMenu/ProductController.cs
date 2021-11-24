using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_API.Data;
using E_Commerce_API.Models.Admin.AllMenu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyCommerceDbContext _context;
        public ProductController(MyCommerceDbContext context)
        {
            _context = context;
        }

        //List------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("getProduct")] //MVC-dən API-a sorğu gəlməsi üçün API-da mütləq Route atributu yazılmalı və adlandırılmalıdır. Route atributu vasitəsilə GetProducts() metodu işə düşür 
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            return await _context.Products.ToListAsync<Product>(); //E-Commerce Database'də olan Product cədvəlini API-da Product class'ına təyin edirəm(yəni Product cədvəlindəki məlumatları Servisə ötürürəm), yəni T-SQL-də olan məlumatlar ilə C#-da rahat işləmək olur 
        }

        //Create----------------------------------------------------------------------------------//

        [HttpPost]
        [Route("addProduct")]
        public async Task<IActionResult> CreateProducts(IncomingProduct incomingProduct)//Servis'ə Json formatında göndərilən informasiyanı .NET obyektinə çevirib(ProductCopy adında class yaradıb, servisə Json formatında göndərilən informasiyanı ProductCopy class'ındakı property'lərə təyin edirik) Database'ə göndərməliyik
        {
            try
            {
                Product product = new Product()
                {
                    Name = incomingProduct.Name,
                    Description = incomingProduct.Description,
                    Price = incomingProduct.Price,
                    ProductionYear = incomingProduct.ProductionYear,
                    MainImage = incomingProduct.MainImage,
                    Created = DateTime.Now,
                    /////////////////////////////////////////////////////
                    MenuID = incomingProduct.SubmenuID,
                    SubmenuID = incomingProduct.SubmenuID,
                    BrandID = incomingProduct.BrandID,
                    ColorID = incomingProduct.ColorID,
                    OpSystemID = incomingProduct.OpSystemID,
                    ProcessorID = incomingProduct.ProcessorID,
                    RAMID = incomingProduct.RAMID,
                    StorageID = incomingProduct.StorageID,
                    SSDID = incomingProduct.SSDID,
                    GraphicsCardID = incomingProduct.GraphicsCardID,
                    StyleJoinID = incomingProduct.StyleJoinID,
                    FrontCameraID = incomingProduct.FrontCameraID,
                    RearCameraID = incomingProduct.RearCameraID,
                    Battery = incomingProduct.Battery
                };

                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();

                foreach (var item in incomingProduct.Pictures)
                {
                    Picture picture = new Picture
                    {
                        ProductID = product.ID,
                        Name = item
                    };
                    await _context.Pictures.AddAsync(picture);
                    await _context.SaveChangesAsync();
                }

                return Created("", "Product added");
            }
            catch
            {
                return BadRequest("Product not added");
            }
        }

        //Edit------------------------------------------------------------------------------------//

        [HttpGet]
        [Route("editProduct/{id}")]
        public ActionResult<Product> EditProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.Products.Find(id);
            }
        }

        [HttpPost]
        [Route("editProduct/{id}")]
        public async Task<IActionResult> EditProduct(int id, IncomingProduct incomingProduct)
        {
            try
            {
                var find = _context.Products.Find(id);

                find.Name = incomingProduct.Name;
                find.Description = incomingProduct.Description;
                find.Price = incomingProduct.Price;
                //find.ProductionYear = incomingProduct.ProductionYear;
                //find.MainImage = incomingProduct.MainImage;
                //find.ColorID = incomingProduct.ColorID;
                //find.OpSystemID = incomingProduct.OpSystemID;
                //find.ProcessorID = incomingProduct.ProcessorID;
                //find.RAMID = incomingProduct.RAMID;
                //find.StorageID = incomingProduct.StorageID;
                //find.SSDID = incomingProduct.SSDID;
                //find.GraphicsCardID = incomingProduct.GraphicsCardID;
                //find.StyleJoinID = incomingProduct.StyleJoinID;
                //find.FrontCameraID = incomingProduct.FrontCameraID;
                //find.RearCameraID = incomingProduct.RearCameraID;
                //find.Battery = incomingProduct.Battery;

                //foreach (var item in incomingProduct.Pictures)
                //{
                //    Picture picture = new Picture
                //    {
                //        ProductID = id,
                //        Name = item
                //    };
                //    await _context.Pictures.AddAsync(picture);
                //    await _context.SaveChangesAsync();
                //}

                await _context.SaveChangesAsync();

                return Ok("Product edited");
            }
            catch (Exception)
            {
                return BadRequest("Product not edited");
            }
        }

        //Delete----------------------------------------------------------------------------------//

        [HttpGet]
        [Route("deleteProduct/{id}")]
        public ActionResult<Product> DeleteProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return _context.Products.Find(id);
            }
        }


        [HttpPost]
        [Route("deleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var find = _context.Products.Find(id);

                _context.Products.Remove(find);
                _context.SaveChanges();

                return Ok("Product deleted");
            }
            catch
            {
                return BadRequest("Product not deleted");
            }
        }

        //Filter----------------------------------------------------------------------------------//

        [HttpGet]
        [Route("getFilter")]
        public async Task<ActionResult<ProductFilter>> GetAllFilters()
        {
            ProductFilter filter = new ProductFilter
            {
                Menus = await _context.Menus.ToListAsync(),
                Submenus = await _context.Submenus.ToListAsync(),
                Brands = await _context.Brands.ToListAsync(),
                Colors = await _context.Colors.ToListAsync(),
                OpSystems = await _context.OpSystems.ToListAsync(),
                Processors = await _context.Processors.ToListAsync(),
                RAMs = await _context.RAMs.ToListAsync(),
                Storages = await _context.Storages.ToListAsync(),
                SSDs = await _context.SSDs.ToListAsync(),
                GraphicsCards = await _context.GraphicsCards.ToListAsync(),
                StyleJoins = await _context.StyleJoins.ToListAsync(),
                FrontCameras = await _context.FrontCameras.ToListAsync(),
                RearCameras = await _context.RearCameras.ToListAsync(),
            };
            return Ok(filter);
        }

        //Pcture----------------------------------------------------------------------------------//

        [HttpGet]
        [Route("getPicture")]
        public async Task<ActionResult<IEnumerable<Picture>>> GetAllPictures()
        {
            return await _context.Pictures.ToListAsync();
        }

        //Product---------------------------------------------------------------------------------//

        [HttpGet]
        [Route("product")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

    }
}
