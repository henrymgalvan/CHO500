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
    public class ICD_10_CM_CategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ICD_10_CM_Category
        public async Task<ActionResult> Index()
        {
            var iCD_10_CM_Category = db.ICD_10_CM_Category.Include(i => i.ICD_10_CM_DiagnosisSectionCode);
            return View(await iCD_10_CM_Category.ToListAsync());
        }

        // GET: ICD_10_CM_Category/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICD_10_CM_Category iCD_10_CM_Category = await db.ICD_10_CM_Category.FindAsync(id);
            if (iCD_10_CM_Category == null)
            {
                return HttpNotFound();
            }
            return View(iCD_10_CM_Category);
        }

        // GET: ICD_10_CM_Category/Create
        public ActionResult Create()
        {
            ViewBag.ICD_10_CM_DiagnosisSectionCodeID = new SelectList(db.ICD_10_CM_DiagnosisSectionCode, "ID", "DiagnosisSectionCode");
            return View();
        }

        // POST: ICD_10_CM_Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,ICD_10_CM_DiagnosisSectionCodeID,Category,Description")] ICD_10_CM_Category iCD_10_CM_Category)
        {
            if (ModelState.IsValid)
            {
                db.ICD_10_CM_Category.Add(iCD_10_CM_Category);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ICD_10_CM_DiagnosisSectionCodeID = new SelectList(db.ICD_10_CM_DiagnosisSectionCode, "ID", "DiagnosisSectionCode", iCD_10_CM_Category.ICD_10_CM_DiagnosisSectionCodeID);
            return View(iCD_10_CM_Category);
        }

        // GET: ICD_10_CM_Category/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICD_10_CM_Category iCD_10_CM_Category = await db.ICD_10_CM_Category.FindAsync(id);
            if (iCD_10_CM_Category == null)
            {
                return HttpNotFound();
            }
            ViewBag.ICD_10_CM_DiagnosisSectionCodeID = new SelectList(db.ICD_10_CM_DiagnosisSectionCode, "ID", "DiagnosisSectionCode", iCD_10_CM_Category.ICD_10_CM_DiagnosisSectionCodeID);
            return View(iCD_10_CM_Category);
        }

        // POST: ICD_10_CM_Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,ICD_10_CM_DiagnosisSectionCodeID,Category,Description")] ICD_10_CM_Category iCD_10_CM_Category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iCD_10_CM_Category).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ICD_10_CM_DiagnosisSectionCodeID = new SelectList(db.ICD_10_CM_DiagnosisSectionCode, "ID", "DiagnosisSectionCode", iCD_10_CM_Category.ICD_10_CM_DiagnosisSectionCodeID);
            return View(iCD_10_CM_Category);
        }

        // GET: ICD_10_CM_Category/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICD_10_CM_Category iCD_10_CM_Category = await db.ICD_10_CM_Category.FindAsync(id);
            if (iCD_10_CM_Category == null)
            {
                return HttpNotFound();
            }
            return View(iCD_10_CM_Category);
        }

        // POST: ICD_10_CM_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ICD_10_CM_Category iCD_10_CM_Category = await db.ICD_10_CM_Category.FindAsync(id);
            db.ICD_10_CM_Category.Remove(iCD_10_CM_Category);
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
