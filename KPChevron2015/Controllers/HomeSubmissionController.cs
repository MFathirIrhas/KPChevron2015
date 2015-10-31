using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPChevron2015.Controllers
{
    public class HomeSubmissionController : Controller
    {
        // GET: HomeSubmission
        public ActionResult Index()
        {
            if (Session["submitter"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}