using Galeriden_com.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Galeriden_com.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SatisController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var Satis = c.Satis.Include("musteri").Include("arac").ToList();

            return View(Satis);

        }


        [HttpGet]
        public IActionResult Create(int ID)
        {
            var musteriListesi = new List<SelectListItem>();
            var aracListesi = new List<SelectListItem>();

            foreach (var item in c.Musteri.Where(x=> x.Type=="Müşteri").ToList())
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
                var satis = c.Satis.Find(ID);
                return View(satis);
            }


        }

        [HttpPost]
        public IActionResult Create(Satis satis)
        {
            satis.SatisFiyatiDate = DateTime.Now;

            if (satis.Id == 0)
            {
                satis.AracID = satis.arac.Id;
                satis.MusteriID = satis.musteri.Id;
                satis.arac = null;
                satis.musteri = null;

                c.Satis.Add(satis);
                c.SaveChanges();
            }
            else
            {
                var dbsatis = c.Satis.Find(satis.Id);
                dbsatis.AracID = satis.arac.Id;
                dbsatis.MusteriID = satis.musteri.Id;
                dbsatis.SatisFiyati = satis.SatisFiyati;
                dbsatis.SatisFiyatiDate = DateTime.Now;

                c.SaveChanges();
            }


            return RedirectToAction("Index", "Satis");
        }

        [HttpGet]
        public IActionResult Delete(int ID)
        {
            var dbrow = c.Satis.Find(ID);

            c.Remove(dbrow);
            c.SaveChanges();

            return RedirectToAction("Index", "Satis");
        }

    }


}
