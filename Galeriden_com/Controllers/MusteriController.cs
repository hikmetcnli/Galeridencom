﻿using Galeriden_com.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Galeriden_com.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MusteriController : Controller
    {

        Context c = new Context();     
        public IActionResult Index()
        {           
            var MusteriListesi = c.Musteri.ToList();
            //var MusteriListesi = new List<Musteri>
            //   {
            //    new Musteri { Id = 1, Adi = "HİKMET", Soyadi = "CANLI", Adres="ORDU", Telefon="5367848888"},
            //    new Musteri {Id = 2, Adi="GİZEM",Soyadi = "KORKMAZ",Adres="İSTANBUL",Telefon="99999999999"},
            //    new Musteri {Id = 3, Adi="İREM", Soyadi="BAYRAKTAR",Adres="RİZE",Telefon="8888888"}
            //    };

            return View(MusteriListesi);
        }

        [HttpGet]
        public IActionResult Create(int ID) 
        { 

            if (ID > 0) //güncelleme yapılacak kayıt varsa
            {
                var musteri = c.Musteri.Where(x=> x.Id== ID).FirstOrDefault();
                return View(musteri);
            }
            else //yeni kayıt varsa
            {
                return View();
            }            
        }         

        [HttpPost]
        public IActionResult Create(Musteri musteri_, IFormFile ResimYolu)
        {
            if (ResimYolu != null && ResimYolu.Length > 0)
            {
                string dosyaAdi = Path.GetFileName(ResimYolu.FileName);

                string dosyayolu = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", "musteriresimleri", dosyaAdi);


                using (var FileStream = new FileStream(dosyayolu, FileMode.Create))
                {
                    ResimYolu.CopyTo(FileStream);
                }

                //musteri_.ResimYolu = "/musteriresimleri/"+ dosyaAdi;
                musteri_.ResimYolu = dosyaAdi;

            }



            if (musteri_.Id == 0) //YERNİ KAYIT EKLE
            {
                c.Musteri.Add(musteri_);
                c.SaveChanges();
            }
            else
            {
                var musteri = c.Musteri.Find(musteri_.Id);
               
                musteri.Adi = musteri_.Adi;
                musteri.Soyadi = musteri_.Soyadi;
                musteri.Adres = musteri_.Adres;
                musteri.Telefon = musteri_.Telefon;
                musteri.Type = musteri_.Type;
                musteri.ResimYolu = musteri_.ResimYolu;

                c.SaveChanges();


            }
           

            return RedirectToAction("Index", "Musteri");
        }


        [HttpGet]
        public IActionResult Delete(int ID)
        {
            //var musteri = c.Musteri.Find(ID);
            var musteri = c.Musteri.Where(x=> x.Id ==ID).FirstOrDefault();

            if (musteri != null)
            {
                c.Musteri.Remove(musteri);
                c.SaveChanges();
            }

            return RedirectToAction("Index", "Musteri");
        }

    }
}
