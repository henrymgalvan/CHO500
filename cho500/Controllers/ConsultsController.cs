using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using cho500.Entity;
using cho500.Models;
using System;
using PagedList;
using System.Collections.Generic;

namespace cho500.Controllers
{
    public class ConsultsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //GET: Consults
        //public async Task<ActionResult> Index()
        //{
        //    return View(await db.Consultations.ToListAsync());
        //}

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PhysicianSortParm = sortOrder == "Physician" ? "Physician_desc" : "Physician";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var consultations = from cons in db.Consultations select cons;
             List<IndexConsultViewModel> consults = new List<IndexConsultViewModel>();
            if (consultations.Any())
            {
                foreach (var con in consultations)
                {
                    consults.Add(new IndexConsultViewModel()
                    {
                        Id = con.Id,
                        PatientName = con.PatientName,
                        AdmittedBy = con.AdmittedBy,
                        DateOfConsult = con.DateOfConsult,
                        ChiefComplaint = con.ChiefComplaint,
                        Age=con.Age,
                        BPAverage=con.BPAverage,
                        PulseRate=con.PulseRate,
                        RR=con.RR,
                        Temperature=con.Temperature,
                        WeightInKgms=con.WeightInKgms,
                        HeightInCm=con.HeightInCm,
                        WaistCircumferenceInCm=con.WaistCircumferenceInCm,
                        CentralAdiposity=con.CentralAdiposity,
                        BMI=con.BMI,
                        BMIStatus=con.BMIStatus,
                        History=con.History,
                        PhysicalExam=con.PhysicalExam,
                        DiagnosisLabResult=con.DiagnosisLabResult,
                        ManagementTreatment=con.ManagementTreatment,
                        Recommendation=con.Recommendation,
                        Pharmacy=con.Pharmacy,
                        Physician=con.Physician

                    });
                }
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                consults = consults.Where(p =>p.PatientName.ToUpper().Contains(searchString.ToUpper()) || p.Physician.ToUpper().Contains(searchString.ToUpper())).ToList();
            }
            switch (sortOrder)
            {
                case "name_desc":
                    consults = consults.OrderByDescending(s => s.PatientName).ToList();
                    break;
                case "Physician":
                    consults = consults.OrderBy(s => s.Physician).ToList();
                    break;
                case "Physician_desc":
                    consults = consults.OrderByDescending(s => s.Physician).ToList();
                    break;
                default:
                    consults = consults.OrderBy(s => s.PatientName).ToList();
                    break;
            }
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(consults.ToPagedList(pageNumber, pageSize));
        }

        // GET: Consults/Details/5
        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultation consultation = db.Consultations.Find(Id);
            if (consultation == null)
            {
                return HttpNotFound();
            }
            var model = new DetailsConsultViewModel();
            model.Id = consultation.Id;
            model.PatientName = consultation.PatientName;
            model.ChiefComplaint = consultation.ChiefComplaint;
            model.Age = consultation.Age;
            model.AdmittedBy = consultation.AdmittedBy;
            model.DateOfConsult = consultation.DateOfConsult;
            model.PreviousConsultDate = consultation.PreviousConsultDate;
            model.PreviousConsult = consultation.PreviousConsult;
            model.BPFirstReading = consultation.BPFirstReading;
            model.BPSecondReading = consultation.BPSecondReading;
            model.BPAverage = consultation.BPAverage;
            model.RaisedBP = consultation.RaisedBP;
            model.PulseRate = consultation.PulseRate;
            model.RR = consultation.RR;
            model.Temperature = consultation.Temperature;
            model.WeightInKgms = consultation.WeightInKgms;
            model.HeightInCm = consultation.HeightInCm;
            model.WaistCircumferenceInCm = consultation.WaistCircumferenceInCm;
            model.CentralAdiposity = consultation.CentralAdiposity;
            model.BMI = consultation.BMI;
            model.BMIStatus = consultation.BMIStatus;
            model.History = consultation.History;
            model.PhysicalExam = consultation.PhysicalExam;
            model.DiagnosisLabResult = consultation.DiagnosisLabResult;
            model.ManagementTreatment = consultation.ManagementTreatment;
            model.Recommendation = consultation.Recommendation;
            model.Pharmacy = consultation.Pharmacy;
            model.Physician = consultation.Physician;

            return View(model);
        }

        // GET: Consults/Create
        public ActionResult Create(int? PatientId, string PatientName)
        {
            if (PatientId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = new CreateConsultViewModel();

            model.PatientId = (int)PatientId;
            model.PatientName = PatientName;
            model.DateOfConsult = DateTime.Now;
            model.PreviousConsultDate = DateTime.Now;
            return View(model);
        }

        // POST: Consults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientId,PatientName,AdmittedBy,DateOfConsult,PreviousConsultDate,PreviousConsult,ChiefComplaint,Age,BPFirstReading,BPSecondReading,BPAverage,RaisedBP,PulseRate,RR,Temperature,WeightInKgms,HeightInCm,WaistCircumferenceInCm,CentralAdiposity,BMI,BMIStatus,History,PhysicalExam,DiagnosisLabResult,ManagementTreatment,Recommendation,Pharmacy,Physician")] CreateConsultViewModel createConsultationViewModel)
        {
            if (ModelState.IsValid)
            {
                Person patient = db.People.Single(d => d.ID == createConsultationViewModel.PatientId);
                var consult = new Consultation();
                consult.PatientId = createConsultationViewModel.PatientId;
                consult.PatientName = createConsultationViewModel.PatientName;
                consult.AdmittedBy = createConsultationViewModel.AdmittedBy;
                consult.DateOfConsult = createConsultationViewModel.DateOfConsult;
                consult.PreviousConsultDate = createConsultationViewModel.PreviousConsultDate;
                consult.PreviousConsult = (Entity.PlaceOfPreviousConsult) createConsultationViewModel.PreviousConsult;
                consult.ChiefComplaint = createConsultationViewModel.ChiefComplaint;
                consult.Age = createConsultationViewModel.Age;
                consult.BPFirstReading = createConsultationViewModel.BPFirstReading;
                consult.BPSecondReading = createConsultationViewModel.BPSecondReading;
                consult.BPAverage = createConsultationViewModel.BPAverage;
                consult.RaisedBP = createConsultationViewModel.RaisedBP;
                consult.RR = createConsultationViewModel.RR;
                consult.Temperature = createConsultationViewModel.Temperature;
                consult.WeightInKgms = createConsultationViewModel.WeightInKgms;
                consult.HeightInCm = createConsultationViewModel.HeightInCm;
                consult.WaistCircumferenceInCm = createConsultationViewModel.WaistCircumferenceInCm;
                consult.CentralAdiposity = createConsultationViewModel.CentralAdiposity;
                consult.BMI = createConsultationViewModel.BMI;
                consult.BMIStatus = (Entity.BMIStatus)createConsultationViewModel.BMIStatus;
                consult.History = createConsultationViewModel.History;
                consult.PhysicalExam = createConsultationViewModel.PhysicalExam;
                consult.DiagnosisLabResult = createConsultationViewModel.DiagnosisLabResult;
                consult.ManagementTreatment = createConsultationViewModel.ManagementTreatment;
                consult.Recommendation = createConsultationViewModel.Recommendation;
                consult.Pharmacy = createConsultationViewModel.Pharmacy;
                consult.Physician = createConsultationViewModel.Physician;

                patient.Consultations.Add(consult);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("Details", "Patient", new { Id = createConsultationViewModel.PatientId });
            }

            return View(createConsultationViewModel);
        }

        // GET: Consults/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultation consultation = await db.Consultations.FindAsync(id);
            if (consultation == null)
            {
                return HttpNotFound();
            }
            EditConsultViewModel editConsultViewModel = new EditConsultViewModel();
            editConsultViewModel.Id = consultation.Id;
            editConsultViewModel.PatientId = consultation.PatientId;
            editConsultViewModel.PatientName = consultation.PatientName;
            editConsultViewModel.AdmittedBy = consultation.AdmittedBy;
            editConsultViewModel.DateOfConsult = consultation.DateOfConsult;
            editConsultViewModel.PreviousConsultDate = consultation.PreviousConsultDate;
            editConsultViewModel.ChiefComplaint = consultation.ChiefComplaint;
            editConsultViewModel.Age = consultation.Age;
            editConsultViewModel.BPFirstReading = consultation.BPFirstReading;
            editConsultViewModel.BPSecondReading = consultation.BPSecondReading;
            editConsultViewModel.BPAverage = consultation.BPAverage;
            editConsultViewModel.RaisedBP = consultation.RaisedBP;
            editConsultViewModel.PulseRate = consultation.PulseRate;
            editConsultViewModel.RR = consultation.RR;
            editConsultViewModel.Temperature = consultation.Temperature;
            editConsultViewModel.WeightInKgms = consultation.WeightInKgms;
            editConsultViewModel.HeightInCm = consultation.HeightInCm;
            editConsultViewModel.WaistCircumferenceInCm = consultation.WaistCircumferenceInCm;
            editConsultViewModel.CentralAdiposity = consultation.CentralAdiposity;
            editConsultViewModel.BMI = consultation.BMI;
            editConsultViewModel.BMIStatus = consultation.BMIStatus;
            editConsultViewModel.History = consultation.History;
            editConsultViewModel.Pharmacy = consultation.Pharmacy;
            editConsultViewModel.Physician = consultation.Physician;


            return View(editConsultViewModel);
        }

        // POST: Consults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PatientId,PatientName,AdmittedBy,DateOfConsult,PreviousConsultDate,PreviousConsult,ChiefComplaint,Age,BPFirstReading,BPSecondReading,BPAverage,RaisedBP,PulseRate,RR,Temperature,WeightInKgms,HeightInCm,WaistCircumferenceInCm,CentralAdiposity,BMI,BMIStatus,History,PhysicalExam,ManagementTreatment,Recommendation,Pharmacy,Physician")] EditConsultViewModel editConsultViewModel)
        {
            if (ModelState.IsValid)
            {
                Consultation consultation = await db.Consultations.FindAsync(editConsultViewModel.Id);
                consultation.PatientId = editConsultViewModel.PatientId;
                consultation.PatientName = editConsultViewModel.PatientName;
                consultation.AdmittedBy = editConsultViewModel.AdmittedBy;
                consultation.DateOfConsult = editConsultViewModel.DateOfConsult;
                consultation.PreviousConsultDate = editConsultViewModel.PreviousConsultDate;
                consultation.PreviousConsult = editConsultViewModel.PreviousConsult;
                consultation.ChiefComplaint = editConsultViewModel.ChiefComplaint;
                consultation.Age = editConsultViewModel.Age;
                consultation.BPFirstReading = editConsultViewModel.BPFirstReading;
                consultation.BPSecondReading = editConsultViewModel.BPSecondReading;
                consultation.BPAverage = editConsultViewModel.BPAverage;
                consultation.RaisedBP = editConsultViewModel.RaisedBP;
                consultation.PulseRate = editConsultViewModel.PulseRate;
                consultation.RR = editConsultViewModel.RR;
                consultation.Temperature = editConsultViewModel.Temperature;
                consultation.WeightInKgms = editConsultViewModel.WeightInKgms;
                consultation.HeightInCm = editConsultViewModel.HeightInCm;
                consultation.WaistCircumferenceInCm = editConsultViewModel.WaistCircumferenceInCm;
                consultation.CentralAdiposity = editConsultViewModel.CentralAdiposity;
                consultation.BMI = editConsultViewModel.BMI;
                consultation.BMIStatus = editConsultViewModel.BMIStatus;
                consultation.History = editConsultViewModel.History;
                consultation.PhysicalExam = editConsultViewModel.PhysicalExam;
                consultation.DiagnosisLabResult = editConsultViewModel.DiagnosisLabResult;
                consultation.ManagementTreatment = editConsultViewModel.ManagementTreatment;
                consultation.Recommendation = editConsultViewModel.Recommendation;
                consultation.Pharmacy = editConsultViewModel.Pharmacy;
                consultation.Physician = editConsultViewModel.Physician;

                db.Entry(consultation).State = EntityState.Modified;

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(editConsultViewModel);
        }

        // GET: Consults/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultation consultation = await db.Consultations.FindAsync(id);
            if (consultation == null)
            {
                return HttpNotFound();
            }
            return View(consultation);
        }

        // POST: Consults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Consultation consultation = await db.Consultations.FindAsync(id);
            db.Consultations.Remove(consultation);
            await db.SaveChangesAsync();
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
