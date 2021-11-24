using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using E_Commerce_MVC.Areas.Admin.Models.AllMenu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace E_Commerce_MVC.Areas.Admin.Controllers.AllMenu
{
    [Area("Admin")]

    public class ProductController : Controller
    {
        RestClient client = new RestClient();

        private readonly IHostingEnvironment hostingEnvironment;
        public ProductController(IHostingEnvironment hostingEnviroment)
        {
            this.hostingEnvironment = hostingEnviroment;
        }


        //Get----------------------------------------------------------------------------------------//

        //ASP.NET Core MVC'də Api ilə proyekt yaradanda üç şeyi bilmək lazımdır. Model, View, Controller. Bu elə MVC sözünün açılışıdır. İlk öncə Controller yaradılır. Controller MVC-nin backend hissəsi sayılır. Controller'də metodlar yaradılır ki, hansı ki bu metodlar vasitəsilə View'lar(yaradılan View'ların adı metodun adına uyğun olur) yaradılır. Əgər Proyekti Servis ilə yazacıqsa, onda MVC-nin Controller'in də ancaq Servisə sorğu göndərəcik. Yox əgər Proyekti Servis ilə yazmayacıqsa, onda Database'i qurmaq, Database'ə sorğu göndərmək və ya sorğu çəkmək, Database'dən məlumatları silmək və ya məlumatları yeniləmək kimi əməliyyatları MVC Controller'də yazacıq.

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Index() //Bu metod vasitəsilə Servis'dən məlumatlar asinxron olaraq sadalanma üsulu ilə (IEnumerable) Product tipində nəticə qayıdır
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/Product/getProduct"); //API'a sorğu göndərir 
            var response = await client.ExecuteAsync(request, CancellationToken.None); //Sorğu təsdiqlənir və API sorğu gedir.
            var context = response.Content;
            var getProduct = JsonConvert.DeserializeObject<List<Product>>(context); //Deserializasiya texnoloji vahiddə(xml,json,binary və.s) saxlanılan informasiyanı .NET obyektinə çevrilməsi prosesidir. Servisdə informasiya Json formatında olur. Servisdən MVC-ə (Controller'ə) Json formatında gələn informasiyanı .NET obyektinə çevirmək üçün Servisdən gələn məlumatı Product class'ına təyin edirik və bu class'a model deyilir. Product cədvəlinin sütununlardan gələn informasiya servisə yazmışam. API-dən (Servisdən) MVC-ə gələn informasiyanı Product class'ının (model'inin)  property'sinə təyin edirəm. Daha aydın izah etsək, View'a yəni HTML səhifəsinə məlumatlar əlavə olunur.

            return View(getProduct);
        }

        //Create--------------------------------------------------------------------------------------//

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product, IFormFile photo, IFormFile[] photos) //Product View'sunda (yəni HTML səhifəsində) input'da daxil etdiyimiz Product məlumatlarını Product modelinə ötürürür.
        {
            if (ModelState.IsValid)
            {
                if (photo == null || photo.Length == 0)
                {
                    return Content("File not selected");
                }
                else
                {
                    string uniqueFileName = null;
                    product.Pictures = new List<string>();

                    string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    product.MainImage = uniqueFileName;


                    foreach (IFormFile item in photos)
                    {
                        string uniqueFileName2 = null;
                        string uploadFolder2 = Path.Combine(hostingEnvironment.WebRootPath, "images");
                        uniqueFileName2 = Guid.NewGuid().ToString() + "_" + item.FileName;
                        string filePath2 = Path.Combine(uploadFolder2, uniqueFileName2);
                        item.CopyTo(new FileStream(filePath2, FileMode.Create));
                        product.Pictures.Add(uniqueFileName2);
                    }
                }

                RestRequest request = new RestRequest(Method.POST);
                request.Resource = ("http://localhost:59964/api/Product/addProduct");
                request.AddJsonBody(product);
                var response = await client.ExecuteAsync(request, CancellationToken.None);
                var context = response.Content;
                var responseError = JsonConvert.DeserializeObject<string>(context); //Servisdən Json formatında qayıdan Error'ları string tipinə çevirib, Product View'suna (yəni HTML səhifəsinə) ötürürəm
                ModelState.AddModelError("", responseError);

                return View();
            }
            else
            {
                return View();
            }            
        }

        //Edit----------------------------------------------------------------------------------------//

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = $"http://localhost:59964/api/Product/editProduct/{id}";
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getProduct = JsonConvert.DeserializeObject<Product>(context);

            return View(getProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product product)
        {            
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = $"http://localhost:59964/api/Product/editProduct/{id}";
                request.AddJsonBody(product);
                var response = await client.ExecuteAsync(request, CancellationToken.None);
                var context = response.Content;
                var responseError = JsonConvert.DeserializeObject<string>(context);
                ModelState.AddModelError("", responseError);

                return View();
            }
            else
            {
                return View();
            }
        }

        //Delete--------------------------------------------------------------------------------------//

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = $"http://localhost:59964/api/Product/deleteProduct/{id}";
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getProduct = JsonConvert.DeserializeObject<Product>(context);

            return View(getProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = $"http://localhost:59964/api/Product/deleteProduct/{id}";
                var response = await client.ExecuteAsync(request, CancellationToken.None);
                var context = response.Content;
                var responseError = JsonConvert.DeserializeObject<string>(context);
                ModelState.AddModelError("", responseError);

                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            else
            {
                return View();
            }
        }

        //ManualSearchedProduct-----------------------------------------------------------------------//

        //[HttpPost]
        //public async Task<ActionResult<IEnumerable<Product>>> SearchedProduct(string search)
        //{
        //    RestRequest request = new RestRequest(Method.GET);
        //    request.Resource = ("http://localhost:59964/api/Product/getProduct");
        //    var response = await client.ExecuteAsync(request, CancellationToken.None);
        //    var context = response.Content;
        //    var getProduct = JsonConvert.DeserializeObject<List<Product>>(context);

        //    List<Product> searchedProducts = new List<Product>();

        //    if (!String.IsNullOrEmpty(search))
        //    {
        //        searchedProducts = getProduct.Where(x => x.Name.ToLower().Contains(search)).OrderByDescending(x => x.Created).ToList();

        //        if (searchedProducts.Count() == 0)
        //        {
        //            searchedProducts = getProduct.OrderByDescending(x => x.Created).ToList();
        //        }
        //    }
        //    if (String.IsNullOrEmpty(search))
        //    {
        //        searchedProducts = getProduct.OrderByDescending(x => x.Created).ToList();
        //    }

        //    return Json(searchedProducts);
        //}

        //============================================================================================//

        //GetAllMenus---------------------------------------------------------------------------------//

        [HttpGet]
        public async Task<IActionResult> GetAllMenus()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/Menu/getMenu");
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            string context = response.Content;
            var getMenu = JsonConvert.DeserializeObject<List<Menu>>(context);

            return Json(getMenu);
        }

        //GetAllSubmenus------------------------------------------------------------------------------//

        [HttpPost]
        public async Task<IActionResult> GetAllSubmenus(int id)
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/Submenu/getSubmenu");
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            string context = response.Content;
            var getSubmenu = JsonConvert.DeserializeObject<List<Submenu>>(context);
            var result = getSubmenu.Where(x => x.MenuID == id).Select(x => new { x.ID, x.Name }).ToList();

            return Json(result);
        }

        //GetAllBrands-------------------------------------------------------------------------------//

        [HttpPost]
        public async Task<IActionResult> GetAllBrands(int id)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/Brand/getBrand");
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            string context = response.Content;
            var getBrand = JsonConvert.DeserializeObject<List<Brand>>(context);
            var result = getBrand.Where(x => x.SubmenuID == id).Select(x => new { x.ID, x.Name }).ToList();
            
            return Json(result);
        }

        //GetAllColors-------------------------------------------------------------------------------//

        [HttpGet]
        public async Task<IActionResult> GetAllColors()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/Color/getColor");
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            string context = response.Content;
            var getColor = JsonConvert.DeserializeObject<List<Color>>(context);

            return Json(getColor);
        }

        //GetAllOperatingSystems---------------------------------------------------------------------//

        [HttpGet]
        public async Task<IActionResult> GetAllOperatingSystems()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/OperatingSystem/getOpSystem");
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            string context = response.Content;
            var getOperatingSystem = JsonConvert.DeserializeObject<List<OpSystem>>(context);

            return Json(getOperatingSystem);
        }

        //GetAllProcessors---------------------------------------------------------------------------//

        [HttpGet]
        public async Task<IActionResult> GetAllProcessors()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/Processor/getProcessor");
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            string context = response.Content;
            var getProcessor = JsonConvert.DeserializeObject<List<Processor>>(context);

            return Json(getProcessor);
        }

        //GetAllRAMs---------------------------------------------------------------------------------//

        [HttpGet]
        public async Task<IActionResult> GetAllRAMs()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/RAM/getRAM");
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            string context = response.Content;
            var getRAM = JsonConvert.DeserializeObject<List<RAM>>(context);

            return Json(getRAM);
        }

        //GetAllStorages-----------------------------------------------------------------------------//

        [HttpGet]
        public async Task<IActionResult> GetAllStorages()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/Storage/getStorage");
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            string context = response.Content;
            var getStorage = JsonConvert.DeserializeObject<List<Storage>>(context);

            return Json(getStorage);
        }

        //GetAllSSDs---------------------------------------------------------------------------------//

        [HttpGet]
        public async Task<IActionResult> GetAllSSDs()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/SSD/getSSD");
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            string context = response.Content;
            var getSSD = JsonConvert.DeserializeObject<List<SSD>>(context);

            return Json(getSSD);
        }

        //GetAllGraphicsCards------------------------------------------------------------------------//

        [HttpGet]
        public async Task<IActionResult> GetAllGraphicsCards()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/GraphicsCard/getGraphicsCard");
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            string context = response.Content;
            var getGraphicsCard = JsonConvert.DeserializeObject<List<GraphicsCard>>(context);

            return Json(getGraphicsCard);
        }

        //GetAllStyleJoins----------------------------------------------------------------------------//

        [HttpGet]
        public async Task<IActionResult> GetAllStyleJoins()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/StyleJoin/getStyleJoin");
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            string context = response.Content;
            var getStyleJoin = JsonConvert.DeserializeObject<List<StyleJoin>>(context);

            return Json(getStyleJoin);
        }

        //GetAllFrontCameras--------------------------------------------------------------------------//

        [HttpGet]
        public async Task<IActionResult> GetAllFrontCameras()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/FrontCamera/getFrontCamera");
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            string context = response.Content;
            var getFrontCamera = JsonConvert.DeserializeObject<List<FrontCamera>>(context);

            return Json(getFrontCamera);
        }

        
        //GetAllRearCameras---------------------------------------------------------------------------//

        [HttpGet]
        public async Task<IActionResult> GetAllRearCameras()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/RearCamera/getRearCamera");
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            string context = response.Content;
            var getRearCamera = JsonConvert.DeserializeObject<List<RearCamera>>(context);

            return Json(getRearCamera);
        }
    }
}
