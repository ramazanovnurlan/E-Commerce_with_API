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

    public class GraphicsCardController : Controller
    {
        RestClient client = new RestClient();

        //Index------------------------------------------------------------------------------------//

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GraphicsCard>>> Index()
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = ("http://localhost:59964/api/GraphicsCard/getGraphicsCard");
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getGraphicsCard = JsonConvert.DeserializeObject<List<GraphicsCard>>(context);

            return View(getGraphicsCard);
        }

        //Create----------------------------------------------------------------------------------//

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(GraphicsCard graphicsCard)
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = ("http://localhost:59964/api/GraphicsCard/addGraphicsCard");
                request.AddJsonBody(graphicsCard);
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
            request.Resource = $"http://localhost:59964/api/GraphicsCard/editGraphicsCard/{id}";
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getGraphicsCard = JsonConvert.DeserializeObject<GraphicsCard>(context);

            return View(getGraphicsCard);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, GraphicsCard graphicsCard)
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = $"http://localhost:59964/api/GraphicsCard/editGraphicsCard/{id}";
                request.AddJsonBody(graphicsCard);
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
            request.Resource = $"http://localhost:59964/api/GraphicsCard/deleteGraphicsCard/{id}";
            var response = await client.ExecuteAsync(request, CancellationToken.None);
            var context = response.Content;
            var getGraphicsCard = JsonConvert.DeserializeObject<GraphicsCard>(context);

            return View(getGraphicsCard);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = $"http://localhost:59964/api/GraphicsCard/deleteGraphicsCard/{id}";
                var response = await client.ExecuteAsync(request, CancellationToken.None);
                var context = response.Content;
                var responseError = JsonConvert.DeserializeObject<string>(context);
                ModelState.AddModelError("", responseError);

                return RedirectToAction("Index", "GraphicsCard", new { area = "Admin" });
            }
            else
            {
                return View();
            }
        }
    }
}
