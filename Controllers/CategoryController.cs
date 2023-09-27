using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult CategoryList()
        {
            var categories = db.tbl_kategoriler.ToList(); ;
           
            return View(categories);
        }
        [HttpGet]
        public ActionResult Category_new()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Category_new(tbl_kategoriler p1)
        {
            db.tbl_kategoriler.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult delete(int id)
        {
            var ctgry = db.tbl_kategoriler.Find(id);
            db.tbl_kategoriler.Remove(ctgry);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        public ActionResult categoryGetir(int id)
        {
            var ctgr = db.tbl_kategoriler.Find(id);
            return View("categoryGetir", ctgr);
        }
            public ActionResult update(tbl_kategoriler p2)
        {
            var ctgrrr = db.tbl_kategoriler.Find(p2.KategoriID);

            ctgrrr.KatwgoriAd = p2.KatwgoriAd;
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }
    }
}