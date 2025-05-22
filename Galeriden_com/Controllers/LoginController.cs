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

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user,string RePassword)
        { 
            if (user.Password == RePassword)
            {
                if (  c.User.Where(x=> x.Email == user.Email).Count() == 0)
                {
                    user.Role = "Admin";

                    c.User.Add(user);
                    c.SaveChanges();

                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ViewBag.Message = "Bu E-mail adresi kullanılıyor.";
                    return View();
                }               
            }
            else
            {
                ViewBag.Message = "Şifreler Eşleşmiyor.";
                return View();
            } 

            
        }


    }
}
