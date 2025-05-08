using Galeriden_com.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Galeriden_com.Controllers
{
    public class LoginController : Controller
    {

        Context c = new Context();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            var p = c.User.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);

            if (p != null)
            {

                var claim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.Email),
                    new Claim(ClaimTypes.Role,p.Role),
                };

                var claimidentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimProperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimidentity), claimProperties);


                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            } 
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Login");
        }


    }
}
