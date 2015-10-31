using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPChevron2015.Controllers
{
    public class HomeApprovalController : Controller
    {
        // GET: HomeApproval
        public ActionResult Index()
        {
            if (Session["leader"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}