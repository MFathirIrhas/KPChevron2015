using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPChevron2015.Controllers
{
    public class HomeRequestController : Controller
    {
        // GET: HomeRequest
        public ActionResult Index()
        {
            if (Session["pe"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}