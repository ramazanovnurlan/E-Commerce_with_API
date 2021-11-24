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

    public class StorageController : Controller
    {
        RestClient client = new RestClient();

        //Index------------------------------------------------------------------------------------//

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Storage>>> Index()
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/Storage/getStorage");
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getStorage = JsonConvert.DeserializeObject<List<Storage>>(context);

            return View(getStorage);
        }

        //Create----------------------------------------------------------------------------------//

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Storage storage)
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = ("http://localhost:59964/api/Storage/addStorage");
                request.AddJsonBody(storage);
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
            request.Resource = $"http://localhost:59964/api/Storage/editStorage/{id}";
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getStorage = JsonConvert.DeserializeObject<Storage>(context);

            return View(getStorage);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Storage storage)
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = $"http://localhost:59964/api/Storage/editStorage/{id}";
                request.AddJsonBody(storage);
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
            request.Resource = $"http://localhost:59964/api/Storage/deleteStorage/{id}";
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getStorage = JsonConvert.DeserializeObject<Storage>(context);

            return View(getStorage);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = $"http://localhost:59964/api/Storage/deleteStorage/{id}";
                var response = await client.ExecuteAsync(request, CancellationToken.None);
                var context = response.Content;
                var responseError = JsonConvert.DeserializeObject<string>(context);
                ModelState.AddModelError("", responseError);

                return RedirectToAction("Index", "Storage", new { area = "Admin" });
            }
            else
            {
                return View();
            }
        }
    }
}
