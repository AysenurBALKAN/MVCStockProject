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



    }
}