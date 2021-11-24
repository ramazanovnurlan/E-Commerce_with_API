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

    public class StyleJoinController : Controller
    {
        RestClient client = new RestClient();

        //Index------------------------------------------------------------------------------------//

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StyleJoin>>> Index()
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/StyleJoin/getStyleJoin");
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getStyleJoin = JsonConvert.DeserializeObject<List<StyleJoin>>(context);

            return View(getStyleJoin);
        }

        //Create----------------------------------------------------------------------------------//

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(StyleJoin styleJoin)
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = ("http://localhost:59964/api/StyleJoin/addStyleJoin");
                request.AddJsonBody(styleJoin);
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
            request.Resource = $"http://localhost:59964/api/StyleJoin/editStyleJoin/{id}";
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getStyleJoin = JsonConvert.DeserializeObject<StyleJoin>(context);

            return View(getStyleJoin);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, StyleJoin styleJoin)
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = $"http://localhost:59964/api/StyleJoin/editStyleJoin/{id}";
                request.AddJsonBody(styleJoin);
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
            request.Resource = $"http://localhost:59964/api/StyleJoin/deleteStyleJoin/{id}";
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getStyleJoin = JsonConvert.DeserializeObject<StyleJoin>(context);

            return View(getStyleJoin);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = $"http://localhost:59964/api/StyleJoin/deleteStyleJoin/{id}";
                var response = await client.ExecuteAsync(request, CancellationToken.None);
                var context = response.Content;
                var responseError = JsonConvert.DeserializeObject<string>(context);
                ModelState.AddModelError("", responseError);

                return RedirectToAction("Index", "StyleJoin", new { area = "Admin" });
            }
            else
            {
                return View();
            }
        }
    }
}
