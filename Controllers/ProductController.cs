using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class ProductController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        // GET: Product
        public ActionResult ProductList()
        {
            var product = db.tbl_urunler.ToList();
            return View(product);
        }
        
    }
}