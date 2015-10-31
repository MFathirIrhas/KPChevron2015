using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPChevron2015.Controllers
{
    public class HomePICController : Controller
    {
        // GET: HomePIC
        public ActionResult Index()
        {
            if (Session["pic"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}