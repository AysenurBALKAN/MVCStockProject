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
        [HttpGet]
        public ActionResult Product_new()
        {
            List<SelectListItem> degerler = (from i in db.tbl_kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KatwgoriAd,
                                                 Value = i.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }



        [HttpPost]
        public ActionResult Product_new(tbl_urunler p1)
        {
            db.tbl_urunler.Add(p1);
            db.SaveChanges();
            return View();
        }
    }
}