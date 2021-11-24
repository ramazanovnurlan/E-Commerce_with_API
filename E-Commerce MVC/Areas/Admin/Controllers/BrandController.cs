using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using E_Commerce_MVC.Areas.Admin.Models.AllMenu;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace E_Commerce_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class BrandController : Controller
    {
        RestClient client = new RestClient();

        //List-------------------------------------------------------------------------------------//

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> Index()
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/Brand/getBrand");
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getBrand = JsonConvert.DeserializeObject<List<Brand>>(context);

            return View(getBrand);
        }


        //Create----------------------------------------------------------------------------------//

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = ("http://localhost:59964/api/Brand/addBrand");
                request.AddJsonBody(brand);
                var response = await client.ExecuteAsync(request, CancellationToken.None);
                var context = response.Content;
                var responseError = JsonConvert.DeserializeObject<string>(context);
                ModelState.AddModelError("", responseError);

                return View();
                //return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }
            else
            {
                return View();
            }
        }

        //Edit------------------------------------------------------------------------------------//

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = $"http://localhost:59964/api/Brand/editBrand/{id}";
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getBrand = JsonConvert.DeserializeObject<Brand>(context);

            return View(getBrand);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Brand brand)
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = $"http://localhost:59964/api/Brand/editBrand/{id}";
                request.AddJsonBody(brand);
                var response = await client.ExecuteAsync(request, CancellationToken.None);
                var context = response.Content;
                var responseError = JsonConvert.DeserializeObject<string>(context);
                ModelState.AddModelError("", responseError);

                return View();
                //return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }
            else
            {
                return View();
            }
        }

        //Delete----------------------------------------------------------------------------------//

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = $"http://localhost:59964/api/Brand/deleteBrand/{id}";
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getBrand = JsonConvert.DeserializeObject<Brand>(context);

            return View(getBrand);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = $"http://localhost:59964/api/Brand/deleteBrand/{id}";
                var response = await client.ExecuteAsync(request, CancellationToken.None);
                var context = response.Content;
                var responseError = JsonConvert.DeserializeObject<string>(context);
                ModelState.AddModelError("", responseError);

                return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }
            else
            {
                return View();
            }
        }

        //============================================================================================//

        //GetAllBrands(Json)--------------------------------------------------------------------------//

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/Brand/getBrand");
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            string context = response.Content;
            var getBrand = JsonConvert.DeserializeObject<List<Brand>>(context);

            return Json(getBrand);
        }
    }
}
