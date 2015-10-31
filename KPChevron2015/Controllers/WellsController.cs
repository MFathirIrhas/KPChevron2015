using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KPChevron2015.DAL;
using KPChevron2015.Models;

namespace KPChevron2015.Controllers
{
    public class WellsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Wells
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(db.Wells.ToList());
        }

        // GET: Wells/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Well well = db.Wells.Find(id);
            if (well == null)
            {
                return HttpNotFound();
            }
            return View(well);
        }

        // GET: Wells/Create
        public ActionResult Create()
        {
            KPChevron2015.Models.Well u = new Well();
            //u.UpdateBy = "Admin";
            //u.UpdateDate = DateTime.Now;
            return View(u);
        }

        // POST: Wells/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WellID,WellName,Location,Area,LastSurveyType,LastSurveyDate")] Well well)
        {
            if (ModelState.IsValid)
            {
                db.Wells.Add(well);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(well);
        }

        // GET: Wells/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Well well = db.Wells.Find(id);
            if (well == null)
            {
                return HttpNotFound();
            }
            return View(well);
        }

        // POST: Wells/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WellID,WellName,Location,Area,LastSurveyType,LastSurveyDate")] Well well)
        {
            if (ModelState.IsValid)
            {
                db.Entry(well).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(well);
        }

        // GET: Wells/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Well well = db.Wells.Find(id);
            if (well == null)
            {
                return HttpNotFound();
            }
            return View(well);
        }

        // POST: Wells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Well well = db.Wells.Find(id);
            db.Wells.Remove(well);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
