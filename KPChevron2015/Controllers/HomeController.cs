using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPChevron2015.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //if (Session["user"] == null)
            //{
            //    return RedirectToAction("Login", "Account");
            //}
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This Page is used For Requesting Survey For Well for Production Use";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}