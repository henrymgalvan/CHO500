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

            var people = from person in db.Patient.Include(b => b.Barangay) select person;
            List<IndexPatientViewModel> patients = new List<IndexPatientViewModel>();
            if (people.Any())
            {
                foreach (var p in people)
                {
                    patients.Add(new IndexPatientViewModel()
                    {
                        ID = p.PersonID,
                        FullName = p.FullName,
                        DateOfBirth = (DateTime)p.DateOfBirth,
                        Sex = p.Sex,
                        CivilStatus = p.CivilStatus,
                        Address = p.Address,
                        Barangay = p.Barangay.Name,
                        HouseHoldNo = p.HouseholdNo,
                        ContactNumber = p.ContactNumber,
                        Notes = p.Notes
                    });
                }
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                patients = patients.Where(p => p.FullName.ToUpper().Contains(searchString.ToUpper()) || p.Barangay.ToString().ToUpper().Contains(searchString.ToUpper())).ToList();
            }
            switch (sortOrder)
            {
                case "name_desc":
                    patients = patients.OrderByDescending(s => s.FullName).ToList();
                    break;
                case "Barangay":
                    patients = patients.OrderBy(s => s.Barangay.ToString()).ToList();
                    break;
                case "Barangay_desc":
                    patients = patients.OrderByDescending(s => s.Barangay.ToString()).ToList();
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
            Person person = await db.Patient.FindAsync(Id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            PopulateBarangaysDropDownList();
            CreatePersonViewModel Model = new CreatePersonViewModel();
            Model.DateCreated = DateTime.Now;

            return View(Model);
        }

        // POST: Patient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,MiddleName,LastName,DateOfBirth,Sex,CivilStatus,Address,BarangayID,HouseHoldNo,ContactNumber,Encoder,DateCreated,Notes")] CreatePersonViewModel createPersonViewModel)
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
                    patient.BarangayID = createPersonViewModel.BarangayID;
                    patient.HouseholdNo = createPersonViewModel.HouseHoldNo;
                    patient.ContactNumber = createPersonViewModel.ContactNumber;
                    patient.Encoder = createPersonViewModel.Encoder;
                    patient.DateCreated = createPersonViewModel.DateCreated;
                    patient.Notes = createPersonViewModel.Notes;
                    db.Patient.Add(patient);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateBarangaysDropDownList(createPersonViewModel.BarangayID);
            return View(createPersonViewModel);
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Patient.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            EditPersonViewModel model = new EditPersonViewModel();
            model.ID = person.PersonID;
            model.FirstName = person.FirstName;
            model.MiddleName = person.MiddleName;
            model.LastName = person.LastName;
            model.DateOfBirth = (DateTime)person.DateOfBirth;
            model.Sex = person.Sex;
            model.CivilStatus = person.CivilStatus;
            model.Address = person.Address;
            model.BarangayID = person.BarangayID;
            model.HouseHoldNo = person.HouseholdNo;
            model.ContactNumber = person.ContactNumber;
            model.Encoder = person.Encoder;
            model.DateCreated = person.DateCreated;
            model.Notes = person.Notes;

            PopulateBarangaysDropDownList(person.BarangayID);
            return View(model);
        }

        // POST: Patient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,MiddleName,LastName,DateOfBirth,Sex,CivilStatus,Address,BarangayID,HouseHoldNo,ContactNumber,Encoder,DateCreated,Notes")] EditPersonViewModel editPersonViewModel)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Person person = db.Patient.Find(editPersonViewModel.ID);
                    db.Entry(person).State = EntityState.Modified;
                    person.FirstName = editPersonViewModel.FirstName;
                    person.MiddleName = editPersonViewModel.MiddleName;
                    person.LastName = editPersonViewModel.LastName;
                    person.DateOfBirth = editPersonViewModel.DateOfBirth;
                    person.Sex = editPersonViewModel.Sex;
                    person.CivilStatus = editPersonViewModel.CivilStatus;
                    person.Address = editPersonViewModel.Address;
                    person.BarangayID = editPersonViewModel.BarangayID;
                    person.HouseholdNo = editPersonViewModel.HouseHoldNo;
                    person.ContactNumber = editPersonViewModel.ContactNumber;
                    person.Encoder = editPersonViewModel.Encoder;
                    person.DateCreated = editPersonViewModel.DateCreated;
                    person.Notes = editPersonViewModel.Notes;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(editPersonViewModel);
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Patient.Find(id);
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
            Person person = db.Patient.Find(id);
            db.Patient.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void PopulateBarangaysDropDownList(object selectedBarangay = null)
        {
            var barangaysQuery = from b in db.Barangays
                                 orderby b.Name
                                 select b;
            ViewBag.BarangayID = new SelectList(barangaysQuery, "BarangayID", "Name", selectedBarangay);
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
