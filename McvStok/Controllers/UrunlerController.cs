using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using McvStok.Models.Entity;
namespace McvStok.Controllers

{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        MvcDbStokEntities2 db = new MvcDbStokEntities2();
        public ActionResult Index()
        {
            var degerler = db.TBLURUNLER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<System.Web.Mvc.SelectListItem> degerler =
      (from i in db.TBLKATEGORILER.ToList()
       select new System.Web.Mvc.SelectListItem
       {
           Text = i.KATEGORIAD,
           Value = i.KATEGORIID.ToString()
       }).ToList();
            ViewBag.dgr = degerler; // diğer yerlere taşınması için
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(TBLURUNLER p1)
        {
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORILER = ktg;
            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id )
        {
            var urun = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            return View("UrunGetir", urun);
        }
        public ActionResult GUNCELLE(TBLURUNLER p1)
        {
            var urun = db.TBLURUNLER.Find(p1.URUNID);
            urun.URUNAD = p1.URUNAD;
            urun.MARKA = p1.MARKA;
            urun.FIYAT = p1.FIYAT;
            urun.STOK = p1.STOK;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    } 
}