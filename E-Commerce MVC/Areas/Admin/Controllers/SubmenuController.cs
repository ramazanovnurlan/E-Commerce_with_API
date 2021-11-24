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

    public class SubmenuController : Controller
    {
        RestClient client = new RestClient();

        //Index------------------------------------------------------------------------------------//

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Submenu>>> Index()
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/Submenu/getSubmenu");
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getSubmenu = JsonConvert.DeserializeObject<List<Submenu>>(context);

            return View(getSubmenu);
        }

        //Create----------------------------------------------------------------------------------//

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Submenu submenu)
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = ("http://localhost:59964/api/Submenu/addSubmenu");
                request.AddJsonBody(submenu);
                var response = await client.ExecuteAsync(request, CancellationToken.None);
                var context = response.Content;
                var responseError = JsonConvert.DeserializeObject<string>(context);
                ModelState.AddModelError("", responseError);

                return View();
                //return RedirectToAction("Index", "Submenu", new { area = "Admin" });
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
            request.Resource = $"http://localhost:59964/api/Submenu/editSubmenu/{id}";
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getSubmenu = JsonConvert.DeserializeObject<Submenu>(context);

            return View(getSubmenu);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Submenu submenu)
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = $"http://localhost:59964/api/Submenu/editSubmenu/{id}";
                request.AddJsonBody(submenu);
                var response = await client.ExecuteAsync(request, CancellationToken.None);
                var context = response.Content;
                var responseError = JsonConvert.DeserializeObject<string>(context);
                ModelState.AddModelError("", responseError);

                return View();
                //return RedirectToAction("Index", "Submenu", new { area = "Admin" });
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
            request.Resource = $"http://localhost:59964/api/Submenu/deleteSubmenu/{id}";
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getSubmenu = JsonConvert.DeserializeObject<Submenu>(context);

            return View(getSubmenu);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = $"http://localhost:59964/api/Submenu/deleteSubmenu/{id}";
                var response = await client.ExecuteAsync(request, CancellationToken.None);
                var context = response.Content;
                var responseError = JsonConvert.DeserializeObject<string>(context);
                ModelState.AddModelError("", responseError);

                return RedirectToAction("Index", "Submenu", new { area = "Admin" });
            }
            else
            {
                return View();
            }
        }

        //============================================================================================//

        //GetAllSubmenus(Json)------------------------------------------------------------------------//

        [HttpGet]
        public async Task<IActionResult> GetAllSubmenus()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/Submenu/getSubmenu");
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            string context = response.Content;
            var getSubmenu = JsonConvert.DeserializeObject<List<Submenu>>(context);

            return Json(getSubmenu);
        }
    }
}
