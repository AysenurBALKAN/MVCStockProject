using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;
namespace MVCStok.Controllers
{
    
    public class SaleController : Controller
    {
        // GET: Sale
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Sales()
        {
            var saleee =db.tbl_satislar.ToList();
            return View(saleee);
        }

        

        [HttpGet]
        public ActionResult new_sales()
        {
            return View();
        }


        [HttpPost]
        public ActionResult new_sales(tbl_satislar p)
        {
            db.tbl_satislar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Sales");
        }

        public ActionResult delete(int id)
        {
            var saleee = db.tbl_satislar.Find(id);
            db.tbl_satislar.Remove(saleee);
            db.SaveChanges();
            return RedirectToAction("Sales");
        }

        public ActionResult sale_guncelle(int id)
        {
            var saleee = db.tbl_satislar.Find(id);
            return View("sale_guncelle", saleee);
        }

        public ActionResult Guncelle (tbl_satislar p1)
        {
            var saleee = db.tbl_satislar.Find(p1.SatisID);
            saleee.Urun = p1.Urun;
            saleee.Musteri = p1.Musteri;
            saleee.Adet = p1.Adet;
            saleee.Fiyat = p1.Fiyat;
            db.SaveChanges();
            return RedirectToAction("Sales");
        }

    }
}