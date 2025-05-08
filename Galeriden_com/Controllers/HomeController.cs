using Galeriden_com.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Galeriden_com.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        Context c = new Context();

        public IActionResult Index()
        {
            var FirmaSayisi = c.Musteri.Count();
            ViewBag.FirmaSayisi = FirmaSayisi;
            
            var AracSayisi = c.Arac.Count();
            ViewBag.AracSayisi = AracSayisi;

            var ToplamSatinAlmaFiyati = c.SatinAlma.Sum(x=> x.AlimFiyati);
            ViewBag.ToplamSatinAlmaFiyati = ToplamSatinAlmaFiyati;

            var ToplamSatisFiyati = c.Satis.Sum(x => x.SatisFiyati);
            ViewBag.ToplamSatisFiyati = ToplamSatisFiyati;

            return View();
        }
    }
}
