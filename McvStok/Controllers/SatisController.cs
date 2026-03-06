using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using McvStok.Models.Entity;
using PagedList;
namespace McvStok.Controllers
{
    public class SatisController : Controller
    {
        MvcDbStokEntities2 db = new MvcDbStokEntities2();
        // GET: Satis
        public ActionResult Index(int sayfa = 1)
        {
            var satislar = db.TBLSATISLAR.ToList().ToPagedList(sayfa, 10);
            ViewBag.urunler = db.TBLURUNLER
                                   .Select(u => new SelectListItem
                                   {
                                       Text = u.URUNAD,
                                       Value = u.URUNID.ToString()
                                   }).ToList();

            ViewBag.musteriler = db.TBLMUSTERILER
                                   .Select(m => new SelectListItem
                                   {
                                       Text = m.MUSTERIAD + " " + m.MUSTERISOYAD,
                                       Value = m.MUSTERIID.ToString()
                                   }).ToList();

            return View(satislar);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(TBLSATISLAR p1)
        {

            p1.TBLURUNLER = db.TBLURUNLER.Find(p1.URUN);
            p1.TBLMUSTERILER = db.TBLMUSTERILER.Find(p1.MUSTERI);
            db.TBLSATISLAR.Add(p1);
            db.SaveChanges();
            return View("Index");
        }
    }
}