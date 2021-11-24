using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_API.Models.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace E_Commerce_API.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public readonly UserManager<ApplicationUser> userManager;
        public readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("RegisterModel")]
        public async Task<IActionResult> Register(RegisterM register)
        {
            var userExist = await userManager.FindByIdAsync(register.UserName);

            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exist" });
            }

            ApplicationUser applicationUser = new ApplicationUser()
            {
                Email = register.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = register.UserName,
                FirstName = register.FirstName,
                LastName = register.LastName
            };

            var result = await userManager.CreateAsync(applicationUser, register.Password);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation faild" });
            }

            return Ok(new Response { Status = "Success", Message = "User Created Successfully" });
        }

    }
}
