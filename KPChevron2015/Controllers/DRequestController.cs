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
using PagedList;
namespace KPChevron2015.Controllers
{
    public class DRequestController : Controller
    {
        private DataContext db = new DataContext();

        // GET: DRequest
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

        // GET: DRequest/Details/5
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

        //public ActionResult DetailWell(string? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Well well= db.Wells.Find(id);
        //    if (well == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(well);
        //}

        public ActionResult IndexWell()
        {
            var well = db.Wells;
            return View(well.ToList());
        }
        // GET: DRequest/Create
        public ActionResult Create()
        {
            ViewBag.WellID = new SelectList(db.Wells, "WellID", "WellName");
            Survey s = new Survey();
            s.RequestDate = DateTime.Now;
            s.ApprovedDate = DateTime.Now;
            s.SubmitDate = DateTime.Now;
            s.Status = "Waiting For Approval";
            s.Progress= "Waiting For Submission";
            return View(s);
        }

        // POST: DRequest/Create
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

        // GET: DRequest/Edit/5
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
            return View(survey);
        }

        // POST: DRequest/Edit/5
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
            return View(survey);
        }

        // GET: DRequest/Delete/5
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

        // POST: DRequest/Delete/5
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
