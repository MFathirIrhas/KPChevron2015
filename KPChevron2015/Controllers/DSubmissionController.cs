﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KPChevron2015.DAL;
using KPChevron2015.Models;
using PagedList;
namespace KPChevron2015.Controllers
{
    public class DSubmissionController : Controller
    {
        private DataContext db = new DataContext();

        // GET: DSubmission
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            //var surveys = db.Surveys.Include(s => s.Well);
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var surveys = from s in db.Surveys.Include(s => s.Well)
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                surveys = surveys.Where(s =>
                    s.Well.WellName.ToUpper().Contains(searchString.ToUpper()) || s.SurveyDesc.ToUpper().Contains(searchString.ToUpper()) || s.RequestBy.ToUpper().Contains(searchString.ToUpper()) ||
                    s.Type.ToUpper().Contains(searchString.ToUpper()) || s.Team.ToUpper().Contains(searchString.ToUpper()) ||
                    s.Status.ToUpper().Contains(searchString.ToUpper()) || s.Progress.ToUpper().Contains(searchString.ToUpper()));

            }
            switch (sortOrder)
            {
                case "name_desc":
                    surveys = surveys.OrderByDescending(s => s.RequestBy);
                    break;
                case "Date":
                    surveys = surveys.OrderBy(s => s.RequestDate);
                    break;
                case "date_desc":
                    surveys = surveys.OrderByDescending(s => s.RequestDate);
                    break;
                default:
                    surveys = surveys.OrderBy(s => s.SurveyID);
                    break;
            }
            //var surveys = db.Surveys.Include(s => s.Well);


            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(surveys.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult IndexPIC()
        {
            var PICName = db.Enrollments.Where(e => e.RoleName == "PIC");
            return View(PICName.ToList());
        }
        // GET: DSubmission/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // GET: DSubmission/Create
        public ActionResult Create()
        {
            ViewBag.WellID = new SelectList(db.Wells, "WellID", "WellName");
            return View();
        }

        // POST: DSubmission/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SurveyID,WellID,SurveyDesc,Type,Team,RequestBy,RequestDate,Comment,Status,Progress,ApprovedBy,ApprovedDate,SubmitBy,SubmitDate,PICName,FileData")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Surveys.Add(survey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WellID = new SelectList(db.Wells, "WellID", "WellName", survey.WellID);
            return View(survey);
        }

        // GET: DSubmission/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            ViewBag.WellID = new SelectList(db.Wells, "WellID", "WellName", survey.WellID);
            survey.SubmitDate = DateTime.Now;
            ViewBag.PICName = new SelectList(db.Enrollments.Where(e => e.RoleName == "PIC"), "EnrollmentID", "Name");
            return View(survey);
        }

        // POST: DSubmission/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SurveyID,WellID,SurveyDesc,Type,Team,RequestBy,RequestDate,Comment,Status,Progress,ApprovedBy,ApprovedDate,SubmitBy,SubmitDate,PICName,FileData")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(survey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WellID = new SelectList(db.Wells, "WellID", "WellName", survey.WellID);
            ViewBag.PICName = new SelectList(db.Enrollments.Where(e => e.RoleName == "PIC"), "EnrollmentID", "Name");
            return View(survey);
        }

        // GET: DSubmission/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // POST: DSubmission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Survey survey = db.Surveys.Find(id);
            db.Surveys.Remove(survey);
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
