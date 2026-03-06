using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using McvStok.Models.Entity;
using McvStok.Controllers;

namespace McvStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities2 db = new MvcDbStokEntities2();
        public ActionResult Index()
        {
            var degerler = db.TBLMUSTERILER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusterı()
        {
            return View();
        }

        [HttpPost] 
        public ActionResult YeniMusterı(TBLMUSTERILER p1)
        {
            db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var deger = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir", musteri);
        }

        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var musterı = db.TBLMUSTERILER.Find(p1.MUSTERIID);
        
            musterı.MUSTERIAD = p1.MUSTERIAD;
            musterı.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}