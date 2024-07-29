using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Context = MvcOnlineTicariOtomasyon.Models.Sınıflar.Context;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Cariler p)
        {
            c.Carilers.Add(p);
            c.SaveChanges();
            return PartialView();
        }

        [HttpGet]
        public ActionResult CariLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariLogin1(Cariler p)
        {
            var bilgiler = c.Carilers.FirstOrDefault(x => x.CariMail == p.CariMail && x.CariSifre == p.CariSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"] = bilgiler.CariMail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult AdminLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin1(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.KullaniciAd == p.KullaniciAd && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd, false);
                Session["KullaniciAd"] = bilgiler.KullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}