using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcAdmin.Models;

namespace mvcAdmin.Controllers
{
    public class LoginController : Controller
    {
        durgunka_1Entities veri = new durgunka_1Entities();
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(admin kisi)
        {
            var varolanKisi = from nesne in veri.admins where nesne.userad == kisi.userad && nesne.usersifre == kisi.usersifre select nesne;
            if (varolanKisi.Any())
            {
                Session["id"] = varolanKisi.SingleOrDefault().userid;
                return Redirect("/Home/Index");
            }
            else
            {
                ViewBag.hata = "Kullanıcı Adı veya Şifre Hatalı";
                return View();
            }
        }
    }
}