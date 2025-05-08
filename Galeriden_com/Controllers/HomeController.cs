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

            var ToplamSatinAlmaFiyati = c.SatinAlma.Where(x=> x.AlimFiyatiDate>= DateTime.Now.AddDays(-30)). Sum(x=> x.AlimFiyati);
            ViewBag.ToplamSatinAlmaFiyati = ToplamSatinAlmaFiyati;

            var ToplamSatisFiyati = c.Satis.Where(x=> x.SatisFiyatiDate>= DateTime.Now.AddDays(-30) ).Sum(x => x.SatisFiyati);
            ViewBag.ToplamSatisFiyati = ToplamSatisFiyati;

            var MusteriSayisi = c.Musteri.Where(x=>x.Type=="Müşteri").Count();
            ViewBag.MusteriSayisi = MusteriSayisi;

            var TedarikciSayisi = c.Musteri.Where(x => x.Type == "Tedarikçi").Count();
            ViewBag.TedarikciSayisi = TedarikciSayisi;
            /* var MusteriSayisi2 = c.Musteri.Count(x => x.Type == "Müşteri");*/

            var AylikSatisData = c.Satis.
                    GroupBy(x=> new { x.SatisFiyatiDate.Year,x.SatisFiyatiDate.Month }).
                    Select(s=> new
                    {
                            AyYil = s.Key.Year.ToString() + "/"+ s.Key.Month.ToString(),
                            ToplamFiyat = s.Sum(x=> x.SatisFiyati)

                    } ).ToList();

            List<string> xValue = new List<string>();
            List<double> yValue = new List<double>();

            foreach(var x in AylikSatisData)
            {
                xValue.Add(x.AyYil.ToString());
                yValue.Add(x.ToplamFiyat);
            }


            ViewBag.XValue = xValue;
            ViewBag.yValue = yValue;



            return View();
        }
    }
}
