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
        public ActionResult Customer_new()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Customer_new(tbl_musteriler p1)
        {
            db.tbl_musteriler.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult delete(int id)
        {
            var cstmr = db.tbl_musteriler.Find(id);
            db.tbl_musteriler.Remove(cstmr);
            db.SaveChanges();
            return RedirectToAction("customerList");
        }
    }
}