using Galeriden_com.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            /*AYLIK SATIŞ RAPORU*/
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

            /*AYLIK SATIN ALMA RAPORU*/
            var AylikSatinAlmaData = c.SatinAlma.
                            GroupBy(x => new { x.AlimFiyatiDate.Year, x.AlimFiyatiDate.Month }).
                            Select(s => new
                            {
                                AyYil = s.Key.Year.ToString() + "/" + s.Key.Month.ToString(),
                                ToplamFiyat = s.Sum(x => x.AlimFiyati)

                            }).ToList();
            List<string> MonthLabel = new List<string>();
            List<double> MonthValue = new List<double>();

            foreach (var x in AylikSatinAlmaData)
            {
                MonthLabel.Add(x.AyYil.ToString());
                MonthValue.Add(x.ToplamFiyat);
            }
            ViewBag.MonthLabel = MonthLabel;
            ViewBag.MonthValue = MonthValue;


            var last3Satis = c.Satis.
                            Include("musteri").
                            Include("arac").                           
                            OrderByDescending(x=> x.SatisFiyatiDate).
                            Take(3).ToList();
             

            return View(last3Satis);
        }
    }
}
