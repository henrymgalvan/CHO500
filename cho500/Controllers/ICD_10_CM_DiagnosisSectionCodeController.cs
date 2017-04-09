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

namespace cho500.Controllers
{
    public class ICD_10_CM_DiagnosisSectionCodeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ICD_10_CM_DiagnosisSectionCode
        public async Task<ActionResult> Index()
        {
            var iCD_10_CM_DiagnosisSectionCode = db.ICD_10_CM_DiagnosisSectionCode.Include(i => i.ICD_10_CM_DiagnosisCode);
            return View(await iCD_10_CM_DiagnosisSectionCode.ToListAsync());
        }

        // GET: ICD_10_CM_DiagnosisSectionCode/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICD_10_CM_DiagnosisSectionCode iCD_10_CM_DiagnosisSectionCode = await db.ICD_10_CM_DiagnosisSectionCode.FindAsync(id);
            if (iCD_10_CM_DiagnosisSectionCode == null)
            {
                return HttpNotFound();
            }
            return View(iCD_10_CM_DiagnosisSectionCode);
        }

        // GET: ICD_10_CM_DiagnosisSectionCode/Create
        public ActionResult Create()
        {
            ViewBag.ICD_10_CM_DiagnosisCodeID = new SelectList(db.ICD_10_CM_DiagnosisCode, "ID", "DiagnosisCodeRange");
            return View();
        }

        // POST: ICD_10_CM_DiagnosisSectionCode/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,ICD_10_CM_DiagnosisCodeID,DiagnosisSectionCode,Description")] ICD_10_CM_DiagnosisSectionCode iCD_10_CM_DiagnosisSectionCode)
        {
            if (ModelState.IsValid)
            {
                db.ICD_10_CM_DiagnosisSectionCode.Add(iCD_10_CM_DiagnosisSectionCode);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ICD_10_CM_DiagnosisCodeID = new SelectList(db.ICD_10_CM_DiagnosisCode, "ID", "DiagnosisCodeRange", iCD_10_CM_DiagnosisSectionCode.ICD_10_CM_DiagnosisCodeID);
            return View(iCD_10_CM_DiagnosisSectionCode);
        }

        // GET: ICD_10_CM_DiagnosisSectionCode/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICD_10_CM_DiagnosisSectionCode iCD_10_CM_DiagnosisSectionCode = await db.ICD_10_CM_DiagnosisSectionCode.FindAsync(id);
            if (iCD_10_CM_DiagnosisSectionCode == null)
            {
                return HttpNotFound();
            }
            ViewBag.ICD_10_CM_DiagnosisCodeID = new SelectList(db.ICD_10_CM_DiagnosisCode, "ID", "DiagnosisCodeRange", iCD_10_CM_DiagnosisSectionCode.ICD_10_CM_DiagnosisCodeID);
            return View(iCD_10_CM_DiagnosisSectionCode);
        }

        // POST: ICD_10_CM_DiagnosisSectionCode/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,ICD_10_CM_DiagnosisCodeID,DiagnosisSectionCode,Description")] ICD_10_CM_DiagnosisSectionCode iCD_10_CM_DiagnosisSectionCode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iCD_10_CM_DiagnosisSectionCode).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ICD_10_CM_DiagnosisCodeID = new SelectList(db.ICD_10_CM_DiagnosisCode, "ID", "DiagnosisCodeRange", iCD_10_CM_DiagnosisSectionCode.ICD_10_CM_DiagnosisCodeID);
            return View(iCD_10_CM_DiagnosisSectionCode);
        }

        // GET: ICD_10_CM_DiagnosisSectionCode/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICD_10_CM_DiagnosisSectionCode iCD_10_CM_DiagnosisSectionCode = await db.ICD_10_CM_DiagnosisSectionCode.FindAsync(id);
            if (iCD_10_CM_DiagnosisSectionCode == null)
            {
                return HttpNotFound();
            }
            return View(iCD_10_CM_DiagnosisSectionCode);
        }

        // POST: ICD_10_CM_DiagnosisSectionCode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ICD_10_CM_DiagnosisSectionCode iCD_10_CM_DiagnosisSectionCode = await db.ICD_10_CM_DiagnosisSectionCode.FindAsync(id);
            db.ICD_10_CM_DiagnosisSectionCode.Remove(iCD_10_CM_DiagnosisSectionCode);
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
