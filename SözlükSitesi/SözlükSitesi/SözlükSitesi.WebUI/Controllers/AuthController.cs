using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SözlükSitesi.Business.Dtos;
using SözlükSitesi.Business.Services;
using SözlükSitesi.WebUI.Models;
using System.Security.Claims;

namespace SözlükSitesi.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("kayit-ol")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("kayit-ol")]
        public IActionResult Register(RegisterViewModel formData)
        {
            if (!ModelState.IsValid)
            {
                return View(formData);
            }
            var addUserDto = new AddUserDto()
            {
                FirstName = formData.FirstName,
                LastName = formData.LastName,
                Password = formData.Password,
                Email = formData.Email
            };

            var response = _userService.AddUser(addUserDto);

            if (response.IsSucceed == false)
            {
                ViewBag.ErrorMessage = response.Message;
                return View(formData);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet] 
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel formData) 
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            var loginDto = new LoginDto()
            {
                Email = formData.Email,
                Password = formData.Password,
            };

            var userDto = _userService.Login(loginDto);

            if (userDto is null)
            {
                TempData["ErrorMessage"] = "Kullanıcı adı veya şifre hatalı."; 

                return RedirectToAction("Index", "Home");
            }

            var claims = new List<Claim>();

            claims.Add(new Claim("id", userDto.Id.ToString()));
            claims.Add(new Claim("email", userDto.Email));
            claims.Add(new Claim("firstName", userDto.FirstName));
            claims.Add(new Claim("lastName", userDto.LastName));
            claims.Add(new Claim("userType", userDto.UserType.ToString()));

            claims.Add(new Claim(ClaimTypes.Role, userDto.UserType.ToString()));

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var autProperties = new AuthenticationProperties
            {
                AllowRefresh = true, 
                ExpiresUtc = new DateTimeOffset(DateTime.Now.AddHours(48)) 
            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), autProperties);

            TempData["LoginMessage"] = "Giriş başarıyla yapıldı.";

            return RedirectToAction("Index", "Home");

        }
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(); 

            return RedirectToAction("Index", "Home");
        }

    }
}
