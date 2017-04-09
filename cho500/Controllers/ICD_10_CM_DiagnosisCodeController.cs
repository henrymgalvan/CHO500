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
    public class ICD_10_CM_DiagnosisCodeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ICD_10_CM_DiagnosisCode
        public async Task<ActionResult> Index()
        {
            var iCD_10_CM_DiagnosisCode = db.ICD_10_CM_DiagnosisCode.Include(i => i.ICD_10_CM_CodeRange);
            return View(await iCD_10_CM_DiagnosisCode.ToListAsync());
        }

        // GET: ICD_10_CM_DiagnosisCode/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICD_10_CM_DiagnosisCode iCD_10_CM_DiagnosisCode = await db.ICD_10_CM_DiagnosisCode.FindAsync(id);
            if (iCD_10_CM_DiagnosisCode == null)
            {
                return HttpNotFound();
            }
            return View(iCD_10_CM_DiagnosisCode);
        }

        // GET: ICD_10_CM_DiagnosisCode/Create
        public ActionResult Create()
        {
            ViewBag.ICD_10_CM_CodeRangeID = new SelectList(db.ICD_10_CM_CodeRange, "ID", "CodeRange");
            return View();
        }

        // POST: ICD_10_CM_DiagnosisCode/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,ICD_10_CM_CodeRangeID,DiagnosisCodeRange,Description")] ICD_10_CM_DiagnosisCode iCD_10_CM_DiagnosisCode)
        {
            if (ModelState.IsValid)
            {
                db.ICD_10_CM_DiagnosisCode.Add(iCD_10_CM_DiagnosisCode);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ICD_10_CM_CodeRangeID = new SelectList(db.ICD_10_CM_CodeRange, "ID", "CodeRange", iCD_10_CM_DiagnosisCode.ICD_10_CM_CodeRangeID);
            return View(iCD_10_CM_DiagnosisCode);
        }

        // GET: ICD_10_CM_DiagnosisCode/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICD_10_CM_DiagnosisCode iCD_10_CM_DiagnosisCode = await db.ICD_10_CM_DiagnosisCode.FindAsync(id);
            if (iCD_10_CM_DiagnosisCode == null)
            {
                return HttpNotFound();
            }
            ViewBag.ICD_10_CM_CodeRangeID = new SelectList(db.ICD_10_CM_CodeRange, "ID", "CodeRange", iCD_10_CM_DiagnosisCode.ICD_10_CM_CodeRangeID);
            return View(iCD_10_CM_DiagnosisCode);
        }

        // POST: ICD_10_CM_DiagnosisCode/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,ICD_10_CM_CodeRangeID,DiagnosisCodeRange,Description")] ICD_10_CM_DiagnosisCode iCD_10_CM_DiagnosisCode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iCD_10_CM_DiagnosisCode).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ICD_10_CM_CodeRangeID = new SelectList(db.ICD_10_CM_CodeRange, "ID", "CodeRange", iCD_10_CM_DiagnosisCode.ICD_10_CM_CodeRangeID);
            return View(iCD_10_CM_DiagnosisCode);
        }

        // GET: ICD_10_CM_DiagnosisCode/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICD_10_CM_DiagnosisCode iCD_10_CM_DiagnosisCode = await db.ICD_10_CM_DiagnosisCode.FindAsync(id);
            if (iCD_10_CM_DiagnosisCode == null)
            {
                return HttpNotFound();
            }
            return View(iCD_10_CM_DiagnosisCode);
        }

        // POST: ICD_10_CM_DiagnosisCode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ICD_10_CM_DiagnosisCode iCD_10_CM_DiagnosisCode = await db.ICD_10_CM_DiagnosisCode.FindAsync(id);
            db.ICD_10_CM_DiagnosisCode.Remove(iCD_10_CM_DiagnosisCode);
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
