using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult customerList()
        {
            var customer = db.tbl_musteriler.ToList();
            return View(customer);
        }

        [HttpGet]
        public ActionResult Customer_new()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Customer_new(tbl_musteriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("Customer_new");
            }
            db.tbl_musteriler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("customerList");
        }

        public ActionResult delete(int id)
        {
            var cstmr = db.tbl_musteriler.Find(id);
            db.tbl_musteriler.Remove(cstmr);
            db.SaveChanges();
            return RedirectToAction("customerList");
        }

        public ActionResult customer_getir(int id)
        {
            var cstmr = db.tbl_musteriler.Find(id);
            return View("customer_getir", cstmr);
        }

        public ActionResult Guncelle( tbl_musteriler p1)
        {
            var cstmr = db.tbl_musteriler.Find(p1.MusteriID);
            cstmr.MusteriAd = p1.MusteriAd;
            cstmr.MusteriSoyad = p1.MusteriSoyad;
            db.SaveChanges();
            return RedirectToAction("customerList");
        }
    }
}