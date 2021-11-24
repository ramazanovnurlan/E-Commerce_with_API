using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using E_Commerce_MVC.Models.Account;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace E_Commerce_MVC.Controllers.Account
{
    public class AccountController : Controller
    {
        RestClient client = new RestClient();

        //-------------------------------------------------------------------------------------//

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register register) //Bu metod vasitəsi ilə Register adında View yaradılır
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = ("http://localhost:59964/api/Account/Register");
                request.AddJsonBody(register);
                var response = await client.ExecuteAsync(request, CancellationToken.None);
                var context = response.Content;
                var responseError = JsonConvert.DeserializeObject<string>(context);

                if (responseError == "Created")
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", responseError); //API-dan qayıdan error'ları Register View'sunda göstərir
                return View();
            }
            else
            {
                return RedirectToAction("Register", "Account");
            }
        }

        //-------------------------------------------------------------------------------------//

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login) //Bu metod vasitəsi ilə Login adında View yaradılır
        {
            if (ModelState.IsValid)
            {
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = ("http://localhost:59964/api/Account/Login");
                request.AddJsonBody(login);
                var response = await client.ExecuteAsync(request, CancellationToken.None);
                var context = response.Content;
                var responseError = JsonConvert.DeserializeObject<string>(context);

                if (responseError == "Okey")
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", responseError); //API-dan qayıdan error'ları Register View'sunda göstərir
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}
