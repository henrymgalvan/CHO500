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
    public class ICD_10_CM_CodeRangeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ICD_10_CM_CodeRange
        public async Task<ActionResult> Index()
        {
            return View(await db.ICD_10_CM_CodeRange.ToListAsync());
        }

        // GET: ICD_10_CM_CodeRange/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICD_10_CM_CodeRange iCD_10_CM_CodeRange = await db.ICD_10_CM_CodeRange.FindAsync(id);
            if (iCD_10_CM_CodeRange == null)
            {
                return HttpNotFound();
            }
            return View(iCD_10_CM_CodeRange);
        }

        // GET: ICD_10_CM_CodeRange/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ICD_10_CM_CodeRange/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,CodeRange,Description")] ICD_10_CM_CodeRange iCD_10_CM_CodeRange)
        {
            if (ModelState.IsValid)
            {
                db.ICD_10_CM_CodeRange.Add(iCD_10_CM_CodeRange);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(iCD_10_CM_CodeRange);
        }

        // GET: ICD_10_CM_CodeRange/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICD_10_CM_CodeRange iCD_10_CM_CodeRange = await db.ICD_10_CM_CodeRange.FindAsync(id);
            if (iCD_10_CM_CodeRange == null)
            {
                return HttpNotFound();
            }
            return View(iCD_10_CM_CodeRange);
        }

        // POST: ICD_10_CM_CodeRange/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,CodeRange,Description")] ICD_10_CM_CodeRange iCD_10_CM_CodeRange)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iCD_10_CM_CodeRange).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(iCD_10_CM_CodeRange);
        }

        // GET: ICD_10_CM_CodeRange/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICD_10_CM_CodeRange iCD_10_CM_CodeRange = await db.ICD_10_CM_CodeRange.FindAsync(id);
            if (iCD_10_CM_CodeRange == null)
            {
                return HttpNotFound();
            }
            return View(iCD_10_CM_CodeRange);
        }

        // POST: ICD_10_CM_CodeRange/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ICD_10_CM_CodeRange iCD_10_CM_CodeRange = await db.ICD_10_CM_CodeRange.FindAsync(id);
            db.ICD_10_CM_CodeRange.Remove(iCD_10_CM_CodeRange);
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
