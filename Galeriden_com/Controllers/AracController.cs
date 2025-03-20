using Galeriden_com.Models;
using Microsoft.AspNetCore.Mvc;

namespace Galeriden_com.Controllers
{
    public class AracController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var AracListesi = c.Arac.ToList();

            return View(AracListesi);
        }


        [HttpGet]
        public IActionResult Create(int ID)
        {

            if (ID == 0)
            {
                return View();
            }               
            else
            {
                var arac = c.Arac.Where(x=> x.Id==ID).FirstOrDefault();
                return View(arac);
            }
        }

        [HttpPost]
        public IActionResult Create(Arac arac)
        {
            if (arac.Id == 0)
            {
                c.Arac.Add(arac);
                c.SaveChanges();
            }
            else
            {
                var VTArac = c.Arac.Find(arac.Id);

                VTArac.Plaka = arac.Plaka;
                VTArac.Model = arac.Model;
                VTArac.Marka= arac.Marka;
                VTArac.Fiyat= arac.Fiyat;

                c.SaveChanges();
            }
            

            return RedirectToAction("Index", "Arac");
        }

        [HttpGet]
        public IActionResult Delete(int ID) {
            var arac = c.Arac.Find(ID);

            c.Arac.Remove(arac);

            c.SaveChanges();

            return RedirectToAction("Index", "Arac");

        
        }

    }
}
