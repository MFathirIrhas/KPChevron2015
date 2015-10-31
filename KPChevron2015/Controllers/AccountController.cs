using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using KPChevron2015.Models;
using KPChevron2015.DAL;



namespace KPChevron2015.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Enrollment model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                using (DataContext db = new DataContext())
                {
                    string name = model.Name;
                    string username = model.Username;
                    string password = model.Password;
                    string rolename = model.RoleName;
                    //var pe = db.Enrollments.Where(e => e.RoleName == "PE");
                    //var leader= db.Enrollments.Where(e => e.RoleName == "Leader") ;
                    //var submit = db.Enrollments.Where(e => e.RoleName == "Leader");
                    //var pic = db.Enrollments.Where(e => e.RoleName == "PIC");
                    
                    // Now if our password was enctypted or hashed we would have done the
                    // same operation on the user entered password here, But for now
                    // since the password is in plain text lets just authenticate directly

                    bool userValid = db.Enrollments.Any(user => user.Username == username && user.Password == password && user.RoleName==rolename);
                    var DB = db.Enrollments;
                    // User found in the database
                    if (userValid)
                    {

                        FormsAuthentication.SetAuthCookie(username, false);
                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        else if (rolename == "Leader")
                        {
                            ViewBag.name = name;
                            Session["leader"] = new Enrollment() { Username = username, Name = model.Name };
                            return RedirectToAction("Index", "HomeApproval");
                        }
                        else if (rolename == "PIC")
                        {
                            ViewBag.name = name;                          
                            Session["pic"] = new Enrollment() { Username = username, Name = model.Name };
                            return RedirectToAction("Index", "HomePIC");
                        }
                        else if (rolename == "PE")
                        {
                            ViewBag.name = name;
                            Session["pe"] = new Enrollment() { Username = username, Name = model.Name };
                            return RedirectToAction("Index", "HomeRequest");
                        }
                        else if (rolename == "Admin")
                        {
                            ViewBag.name = name;
                            Session["admin"] = new Enrollment() { Username = username, Name = model.Name };
                            return RedirectToAction("Index", "Admins");
                        }
                        else
                        {
                            ViewBag.name = name;
                            Session["submitter"] = new Enrollment() { Username = username, Name = model.Name };
                            return RedirectToAction("Index", "HomeSubmission");
                        }
                    }
                    else
                    {
                        ViewBag.id = "Failed";
                        ModelState.AddModelError("", "The user name or password or your Role provided is incorrect.");
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            //if (Session["pe"] == null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            //else if (Session["leader"] == null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            //else if (Session["submitter"] == null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            //else if (Session["pic"] == null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            //else if (Session["admin"] == null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            FormsAuthentication.SignOut();
            
            Session["pe"] = null;
            Session["leader"] = null;
            Session["submitter"] = null;
            Session["pic"] = null;
            Session["admin"] = null;
            //return RedirectToAction("Logout", "Account");
            return View();
        }

        
    }
}