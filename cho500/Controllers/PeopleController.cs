using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cho500.Entity;
using cho500.Models;
using PagedList;
using System.Data.Entity.Infrastructure;

namespace cho500.Controllers
{
    public class PeopleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: People
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.BarangaySortParm = sortOrder == "Barangay" ? "Barangay_desc" : "Barangay";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var Peoples = from s in db.People
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                Peoples = Peoples.Where(s =>
                s.LastName.ToUpper().Contains(searchString.ToUpper())
                ||
                s.FirstName.ToUpper().Contains(searchString.ToUpper())
                ||
                s.Barangay.ToUpper().Contains(searchString.ToUpper())
                );
            }
            switch (sortOrder)
            {
                case "name_desc":
                    Peoples = Peoples.OrderByDescending(s => s.LastName);
                    break;
                case "Barangay":
                    Peoples = Peoples.OrderBy(s => s.Barangay);
                    break;
                case "Barangay_desc":
                    Peoples = Peoples.OrderByDescending(s => s.Barangay);
                    break;
                default:
                    Peoples = Peoples.OrderBy(s => s.LastName);
                    break;
            }
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(Peoples.ToPagedList(pageNumber, pageSize));
            //return View(Peoples.ToList());
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            //PopulateBloodTypeDropDownList();

            Person Model = new Person();
            Model.DateCreated = DateTime.Now;

            return View(Model);
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,MiddleName,LastName,DateOfBirth,Sex,Status,Deceased,BloodType,FathersName,MothersName,Address,Barangay,Email,ContactPerson,RelationshipToContact,PhoneNoOfContact,PatientContactNumber,PhilHealth,DateCreated,DateLastUpdated,Notes")] Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.People.Add(person);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            //PopulateBloodTypeDropDownList(person.BloodType.Id);
            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            //PopulateBloodTypeDropDownList(person.BloodType.Id);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,MiddleName,LastName,DateOfBirth,Sex,Status,Deceased,BloodType,FathersName,MothersName,Address,Barangay,Email,ContactPerson,RelationshipToContact,PhoneNoOfContact,PatientContactNumber,PhilHealth,DateCreated,DateLastUpdated,Notes")] Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(person).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            //PopulateBloodTypeDropDownList(person.BloodType.Id);
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.People.Find(id);
            db.People.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //private void PopulateBloodTypeDropDownList(object selectedBloodType = null)
        //{
        //    var BloodTypeQuery = from bt in db.BloodTypes
        //                         orderby db.BloodTypes
        //                         select bt;
        //    ViewBag.BloodTypeID = new SelectList(BloodTypeQuery, "BloodTypeID",
        //                                        "BloodType", selectedBloodType);
        //}

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
