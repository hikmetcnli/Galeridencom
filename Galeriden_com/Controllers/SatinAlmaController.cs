using Galeriden_com.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Galeriden_com.Controllers
{
    public class SatinAlmaController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var satinalma = c.SatinAlma.Include("musteri").Include("arac").ToList();

            return View(satinalma);
        }

        [HttpGet]
        public IActionResult Create(int ID)
        {
            var musteriListesi = new List<SelectListItem>();
            var aracListesi = new List<SelectListItem>();

            foreach (var item in c.Musteri.ToList())
            {

                musteriListesi.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Adi + " " + item.Soyadi
                }
               );
            }

            foreach (var item in c.Arac.ToList())
            {
                aracListesi.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Marka + " - " + item.Model
                }
             );
            }


            ViewBag.musteriListesi = musteriListesi;
            ViewBag.aracListesi = aracListesi;


            if (ID == 0)
            {
                return View();
            }
            else
            {
                var Satinalma = c.SatinAlma.Find(ID);
                return View(Satinalma);
            }


        }

        [HttpPost]
        public IActionResult Create(SatinAlma satinAlma)
        {
            satinAlma.AlimFiyatiDate = DateTime.Now;

            if (satinAlma.Id == 0)
            {
                satinAlma.AracID = satinAlma.arac.Id;
                satinAlma.MusteriID = satinAlma.musteri.Id;
                satinAlma.arac = null;
                satinAlma.musteri = null;

                c.SatinAlma.Add(satinAlma);
                c.SaveChanges();
            }
            else
            {
                var dbsatinalma = c.SatinAlma.Find(satinAlma.Id);
                dbsatinalma.AracID = satinAlma.arac.Id;
                dbsatinalma.MusteriID = satinAlma.musteri.Id;
                dbsatinalma.AlimFiyati = satinAlma.AlimFiyati;
                dbsatinalma.AlimFiyatiDate = DateTime.Now;

                c.SaveChanges();
            }


            return RedirectToAction("Index", "SatinAlma");
        }

        [HttpGet]
        public IActionResult Delete(int ID)
        {
            var dbrow = c.SatinAlma.Find(ID);

            c.Remove(dbrow);
            c.SaveChanges();

            return RedirectToAction("Index", "SatinAlma");
        }

    }
}
