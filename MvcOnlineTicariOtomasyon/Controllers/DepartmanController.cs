using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using Context = MvcOnlineTicariOtomasyon.Models.Sınıflar.Context;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmens.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }
        [Authorize(Roles ="A")]
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();

        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmens.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeparmanSil(int id)
        {
            var dep = c.Departmens.Find(id);
            dep.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dpt = c.Departmens.Find(id);
            return View("DepartmanGetir", dpt);
        }
        public ActionResult DepartmanGuncelle(Departman p)
        {
            var dept = c.Departmens.Find(p.Departmanid);
            dept.DepartmanAd = p.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.Departmanid == id).ToList();
            var dpt = c.Departmens.Where(x => x.Departmanid == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.d = dpt;
            return View(degerler);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Personelid == id).ToList();
            var per = c.SatisHarekets.Where(x => x.Personelid == id).Select(y => y.Personel.PersonelAd + " " + y.Personel.PersonelSoyad).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);
        }
    }
}