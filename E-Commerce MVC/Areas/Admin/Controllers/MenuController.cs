using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using E_Commerce_MVC.Areas.Admin.Models.AllMenu;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace E_Commerce_MVC.Areas.Admin.Controllers.AllMenu
{
    [Area("Admin")]

    public class MenuController : Controller
    {
        RestClient client = new RestClient();

        //List-------------------------------------------------------------------------------------//

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menu>>> Index()
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/Menu/getMenu");
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getMenu = JsonConvert.DeserializeObject<List<Menu>>(context);

            return View(getMenu);
        }


        //Create----------------------------------------------------------------------------------//

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Menu menu)
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = ("http://localhost:59964/api/Menu/addMenu");
                request.AddJsonBody(menu);
                var response = await client.ExecuteAsync(request, CancellationToken.None);
                var context = response.Content;
                var responseError = JsonConvert.DeserializeObject<string>(context);
                ModelState.AddModelError("", responseError);

                return View();
                //return RedirectToAction("Index", "Menu", new { area = "Admin" });
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
            request.Resource = $"http://localhost:59964/api/Menu/editMenu/{id}";
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getMenu = JsonConvert.DeserializeObject<Menu>(context);

            return View(getMenu);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Menu menu)
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = $"http://localhost:59964/api/Menu/editMenu/{id}";
                request.AddJsonBody(menu);
                var response = await client.ExecuteAsync(request, CancellationToken.None);
                var context = response.Content;
                var responseError = JsonConvert.DeserializeObject<string>(context);
                ModelState.AddModelError("", responseError);

                return View();
                //return RedirectToAction("Index", "Menu", new { area = "Admin" });
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
            request.Resource = $"http://localhost:59964/api/Menu/deleteMenu/{id}";
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getMenu = JsonConvert.DeserializeObject<Menu>(context);

            return View(getMenu);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = $"http://localhost:59964/api/Menu/deleteMenu/{id}";
                var response = await client.ExecuteAsync(request, CancellationToken.None);
                var context = response.Content;
                var responseError = JsonConvert.DeserializeObject<string>(context);
                ModelState.AddModelError("", responseError);

                return RedirectToAction("Index", "Menu", new { area = "Admin" });
            }
            else
            {
                return View();
            }
        }

        //============================================================================================//

        //GetAllMenus(Json)---------------------------------------------------------------------------//

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
    }
}
