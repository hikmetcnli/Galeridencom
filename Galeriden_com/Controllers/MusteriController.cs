using Galeriden_com.Models;
using Microsoft.AspNetCore.Mvc;

namespace Galeriden_com.Controllers
{
    public class MusteriController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Musteri musteri_ )
        {
            return RedirectToAction("Index", "Musteri");
        }
    }
}
