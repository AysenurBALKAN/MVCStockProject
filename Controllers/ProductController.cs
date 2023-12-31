﻿using System;
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
            var ctgrs = db.tbl_kategoriler.Where(m => m.KategoriID == p1.tbl_kategoriler.KategoriID).FirstOrDefault();
            p1.tbl_kategoriler = ctgrs;
            db.tbl_urunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public ActionResult delete(int id)
        {
            var prdct = db.tbl_urunler.Find(id);
            db.tbl_urunler.Remove(prdct);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public ActionResult product_getir(int id)
        {
            var prdct = db.tbl_urunler.Find(id);
            List<SelectListItem> degerler = (from i in db.tbl_kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KatwgoriAd,
                                                 Value = i.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("product_getir", prdct);
        }

        public ActionResult Guncelle (tbl_urunler p1)
        {
            var prdct = db.tbl_urunler.Find(p1.UrunID);
            prdct.UrunAd = p1.UrunAd;
            prdct.Marka = p1.Marka;
            prdct.Fiyat = p1.Fiyat;
            prdct.Stok = p1.Stok;
            var ctgrs = db.tbl_kategoriler.Where(m => m.KategoriID == p1.tbl_kategoriler.KategoriID).FirstOrDefault();
            prdct.UrunKategori = ctgrs.KategoriID;
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }


    }
}