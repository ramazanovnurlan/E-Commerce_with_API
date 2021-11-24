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

    public class ColorController : Controller
    {
        RestClient client = new RestClient();

        //Index------------------------------------------------------------------------------------//

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Color>>> Index()
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/Color/getColor");
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getColor = JsonConvert.DeserializeObject<List<Color>>(context);

            return View(getColor);
        }

        //Create----------------------------------------------------------------------------------//

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Color color)
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = ("http://localhost:59964/api/Color/addColor");
                request.AddJsonBody(color);
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

        //Edit------------------------------------------------------------------------------------//

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = $"http://localhost:59964/api/Color/editColor/{id}";
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getColor = JsonConvert.DeserializeObject<Color>(context);

            return View(getColor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Color color)
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = $"http://localhost:59964/api/Color/editColor/{id}";
                request.AddJsonBody(color);
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

        //Delete----------------------------------------------------------------------------------//

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = $"http://localhost:59964/api/Color/deleteColor/{id}";
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getColor = JsonConvert.DeserializeObject<Color>(context);

            return View(getColor);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = $"http://localhost:59964/api/Color/deleteColor/{id}";
                var response = await client.ExecuteAsync(request, CancellationToken.None);
                var context = response.Content;
                var responseError = JsonConvert.DeserializeObject<string>(context);
                ModelState.AddModelError("", responseError);

                return RedirectToAction("Index", "Color", new { area = "Admin" });
            }
            else
            {
                return View();
            }
        }

        //=========================================================================================//

        //GetAllColors-----------------------------------------------------------------------------//

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
    }
}
