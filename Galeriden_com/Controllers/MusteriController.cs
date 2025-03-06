using Galeriden_com.Models;
using Microsoft.AspNetCore.Mvc;

namespace Galeriden_com.Controllers
{
    public class MusteriController : Controller
    {
        public IActionResult Index()
        {

            var MusteriListesi = new List<Musteri>
               {
                new Musteri { Id = 1, Adi = "HİKMET", Soyadi = "CANLI", Adres="ORDU", Telefon="5367848888"},
                new Musteri {Id = 2, Adi="GİZEM",Soyadi = "KORKMAZ",Adres="İSTANBUL",Telefon="99999999999"},
                new Musteri {Id = 3, Adi="İREM", Soyadi="BAYRAKTAR",Adres="RİZE",Telefon="8888888"}
                };

            return View(MusteriListesi);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Musteri musteri_)
        {
            return RedirectToAction("Index", "Musteri");
        }
    }
}
