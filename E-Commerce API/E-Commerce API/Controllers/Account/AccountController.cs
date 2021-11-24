using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_API.Data;
using E_Commerce_API.RegisterModel;
using Microsoft.AspNetCore.Http;
using SignInNS = Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration; //appsettings.Development - dan melumatlari oxumaq ucundur
        private readonly IPasswordValidator<ApplicationUser> _passwordValidator;
        private readonly List<string> _roles;
        public string errorDescription;

        public AccountController(UserManager<ApplicationUser> userManager
                               , SignInManager<ApplicationUser> signInManager
                               , IConfiguration configuration
                               , IPasswordValidator<ApplicationUser> passwordValidator) //API qalxanda anda Konstruktor işə düşür və UserManager klassının obyekti yaranır anda
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _passwordValidator = passwordValidator;
            _roles = new List<string>();
        }

        [HttpGet]
        [Route("User")]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetUsers() //Application Run olunanda bu metod işə düşür. Database-dən Table'dakı məlumatları HttpGet sorğusu vasitəs ilə (Http protokolunda Get metodu vasitesi ilə) asinxron olaraq Json formatında servisdə göndərirəm
        {
            return Ok(await _userManager.Users.ToListAsync());
        }

        //-------------------------------------------------------------------------------------//

        public List<string> GetRoles()
        {
            //string[] UserRoles = _configuration["Roles"].Split(","); Birinci usul
            string[] userRoles = _configuration.GetSection("Roles").Value.Split(","); //Split metodu vasitəsilə, massivdə vergül ilə ayrılan sözləri Split metodunun içərisində olan durğu işarələri(əgər boşluq varsa, boşluğu silir) varsa durğu işarələrini silir və alt alta listələyir
            foreach (var item in userRoles)
            {
                _roles.Add(item);
            }
            return _roles;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<string> AddRegister(Register register)
        {
            ApplicationUser existEmail = await _userManager.FindByEmailAsync(register.Email); //Daxil etdiyimiz email'in User table'ın email stunundakı email ilə üst-üstə düşüb düşmədiyini yoxlayır 

            if (existEmail == null) //Əgər User table'da email mövcud deyilsə bu şərt yerinə yetirilir
            {
                ApplicationUser applicationUser = new ApplicationUser()
                {
                    FirstName = register.FirstName.Replace(" ", String.Empty), //Register View'sunda(yəni Register səhifəsində) daxil olan First Name məlumatlarında boşluq varsa(və ya durğu işarələri varsa) onu silir
                    LastName = register.LastName.Replace(" ", String.Empty),
                    UserName = register.UserName.Replace(" ", String.Empty),
                    Email = register.Email.Replace(" ", String.Empty),
                    //SecurityStamp = Guid.NewGuid().ToString()
                };
                var identityUserResult = await _userManager.CreateAsync(applicationUser, register.Password.Replace(" ", String.Empty)); //Servisdən gələn sorğunu User table'na daxil edir

                if (identityUserResult.Succeeded)
                {
                    var roles = GetRoles();
                    await _userManager.AddToRoleAsync(applicationUser, roles[1]);
                    return "Created";
                }
                else
                {
                    foreach (var item in identityUserResult.Errors)
                    {
                        errorDescription = item.Description;
                    }
                    return errorDescription;
                }
            }
            else //Yox əgər User table'da email mövcuddursa bu şərt yerinə yetirilir
            {
                return "Email already exist";
            }
        }

        //-------------------------------------------------------------------------------------//

        [HttpPost]
        [Route("Login")]
        public async Task<string> AddLogin(Login login)
        {
            var existEmail = await _userManager.FindByEmailAsync(login.Email); //Daxil etdiyimiz email'in User table'ın email stunundakı email ilə üst-üstə düşüb düşmədiyini yoxlayır 
            var existPassword = _passwordValidator.ValidateAsync(_userManager, existEmail, login.Password); //Mövcud olan email'ə görə, daxil etdiyimiz password'un User table'da PasswordHash stunundakı password ilə üst-üstə düşüb düşmədiyini yoxlayır

            if (existEmail != null) //Əgər User table'da email mövcuddursa, bu şərt yerinə yetirilir
            {
                SignInNS.SignInResult signInResult = await _signInManager.PasswordSignInAsync(existEmail, login.Password, true, false);

                if (signInResult.Succeeded)
                {
                    return "Okey";
                    //return "Sign prosses is okey";
                }
                else
                {
                    return "Password is incorrect";
                }
            }
            else //Yox Əgər User table'da email mövcud deyilsə və password uğurlu deyilsə, bu şərt yerinə yetirilir
            {
                return "Such an account does not exist";
            }
        }
    }
}
