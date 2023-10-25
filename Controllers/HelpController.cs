using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCStok.Controllers
{
    public class HelpController : Controller
    {
        // GET: Help
        public ActionResult help()
        {
            return View();
        }
    }
}