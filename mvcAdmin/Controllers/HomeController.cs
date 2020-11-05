using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcAdmin.Models;

namespace mvcAdmin.Controllers
{
    public class HomeController : Controller
    {
        mvcfinalEntities veri = new mvcfinalEntities();
        public ActionResult Index()
        {
            if (Session["id"] == null)
            {
                return Redirect("/Login/Index");
            }else
            return View();
        }
        public ActionResult TumListe()
        {
            var kisiler = veri.musterilers.ToList();
            return View(kisiler);
        }
        public ActionResult KullaniciSil(int id)
        {
            veri.kisiSil(id);
            return RedirectToAction("TumListe");
        }
        public ActionResult KullaniciGuncelle(int id)
        {
            var musteri = veri.musterilers.Find(id);
            return View(musteri);
        }
        [HttpPost]
        public ActionResult KullaniciGuncelle(musteriler kisi)
        {
            veri.kisiGuncelle(kisi.musteriid, kisi.musteriad, kisi.musterisoyad, kisi.musterisehir, kisi.musteritc, kisi.musteritelefon);
            return RedirectToAction("TumListe");
        }
        public ActionResult KullaniciEkle()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult KullaniciEkle(musteriler kisi)
        {
            veri.kisiEkle(kisi.musteriad, kisi.musterisoyad, kisi.musterisehir, kisi.musteritc, kisi.musteritelefon);
            return RedirectToAction("TumListe");
        }
        public ActionResult LogOut()
        {
            Session["id"] = null;
            return Redirect("/Login/Index");
        }
    }
}