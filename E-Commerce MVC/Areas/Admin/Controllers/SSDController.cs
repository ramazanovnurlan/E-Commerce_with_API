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

    public class SSDController : Controller
    {
        RestClient client = new RestClient();

        //Index------------------------------------------------------------------------------------//

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SSD>>> Index()
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/SSD/getSSD");
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getSSD = JsonConvert.DeserializeObject<List<SSD>>(context);

            return View(getSSD);
        }

        //Create----------------------------------------------------------------------------------//

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(SSD ssd)
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = ("http://localhost:59964/api/SSD/addSSD");
                request.AddJsonBody(ssd);
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
            request.Resource = $"http://localhost:59964/api/SSD/editSSD/{id}";
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getSSD = JsonConvert.DeserializeObject<SSD>(context);

            return View(getSSD);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, RAM ram)
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = $"http://localhost:59964/api/SSD/editSSD/{id}";
                request.AddJsonBody(ram);
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
            request.Resource = $"http://localhost:59964/api/SSD/deleteSSD/{id}";
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getSSD = JsonConvert.DeserializeObject<SSD>(context);

            return View(getSSD);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = $"http://localhost:59964/api/SSD/deleteSSD/{id}";
                var response = await client.ExecuteAsync(request, CancellationToken.None);
                var context = response.Content;
                var responseError = JsonConvert.DeserializeObject<string>(context);
                ModelState.AddModelError("", responseError);

                return RedirectToAction("Index", "SSD", new { area = "Admin" });
            }
            else
            {
                return View();
            }
        }
    }
}
