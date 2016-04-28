using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cho500.Entity;
using cho500.Models;
using PagedList;
using System.Data.Entity.Infrastructure;
//using AutoMapper;
using System.Collections.ObjectModel;

namespace cho500.Controllers
{
    public class PatientController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Patient
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
            var people = from person in db.People select person;
            List<IndexPatientViewModel> patients = new List<IndexPatientViewModel>();
            if (people.Any())
            {
                foreach(var p in people)
                {
                    patients.Add(new IndexPatientViewModel()
                    {
                        ID = p.ID,
                        FullName = p.FullName,
                        DateOfBirth = p.DateOfBirth,
                        Sex=p.Sex,
                        CivilStatus=p.CivilStatus,
                        Address=p.Address,
                        Barangay=p.Barangay,
                        HouseHoldNo=p.HouseholdNo,
                        ContactNumber=p.ContactNumber,
                        Notes=p.Notes
                    });
                }
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                patients = patients.Where(p => p.FullName.ToUpper().Contains(searchString.ToUpper()) || p.Barangay.ToUpper().Contains(searchString.ToUpper())).ToList();
            }
            switch (sortOrder)
            {
                case "name_desc":
                    patients = patients.OrderByDescending(s => s.FullName).ToList();
                    break;
                case "Barangay":
                    patients = patients.OrderBy(s => s.Barangay).ToList();
                    break;
                case "Barangay_desc":
                    patients = patients.OrderByDescending(s => s.Barangay).ToList();
                    break;
                default:
                    patients = patients.OrderBy(s => s.FullName).ToList();
                    break;
            }
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(patients.ToPagedList(pageNumber, pageSize));
        }

        // GET: Patient/Details/5
        public async Task<ActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = await db.People.FindAsync(Id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            CreatePersonViewModel Model = new CreatePersonViewModel();
            Model.DateCreated = DateTime.Now;

            return View(Model);
        }

        // POST: Patient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,MiddleName,LastName,DateOfBirth,Sex,CivilStatus,Address,Barangay,HouseHoldNo,ContactNumber,Encoder,DateCreated,Notes")] CreatePersonViewModel createPersonViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var patient = new Person();
                    patient.FirstName = createPersonViewModel.FirstName;
                    patient.MiddleName = createPersonViewModel.MiddleName;
                    patient.LastName = createPersonViewModel.LastName;
                    patient.DateOfBirth = createPersonViewModel.DateOfBirth;
                    patient.Sex = (Person.Gender)createPersonViewModel.Sex;
                    patient.CivilStatus = (Person.State)createPersonViewModel.CivilStatus;
                    patient.Address = createPersonViewModel.Address;
                    patient.Barangay = createPersonViewModel.Barangay;
                    patient.HouseholdNo = createPersonViewModel.HouseHoldNo;
                    patient.ContactNumber = createPersonViewModel.ContactNumber;
                    patient.Encoder = createPersonViewModel.Encoder;
                    patient.DateCreated = createPersonViewModel.DateCreated;
                    patient.Notes = createPersonViewModel.Notes;

                    db.People.Add(patient);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            return View(createPersonViewModel);
        }

        // GET: Patient/Edit/5
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
            return View(person);
        }

        // POST: Patient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,MiddleName,LastName,DateOfBirth,Sex,CivilStatus,Address,Barangay,HouseHoldNo,ContactNumber,Encoder,DateCreated,Notes")] Person person)
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
            return View(person);
        }

        // GET: Patient/Delete/5
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

        // POST: Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.People.Find(id);
            db.People.Remove(person);
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
