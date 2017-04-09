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
using cho500.Models.Queue;
using AutoMapper;

namespace cho500.Controllers
{
    public class QueueController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Queue
        public async Task<ActionResult> Index()
        {
            var people = await db.Queues.ToListAsync();
            List<QueueListViewModel> patientsOnQueue = new List<QueueListViewModel>();
            if (people.Any())
            {
                patientsOnQueue = Mapper.Map<List<Queue>, List<QueueListViewModel>>(people);
            }
            return View(patientsOnQueue.ToList());
            //return View(await db.Queues.ToListAsync());
        }

        // GET: Queue/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Queue queue = await db.Queues.FindAsync(id);
            if (queue == null)
            {
                return HttpNotFound();
            }
            return View(queue);
        }

        // GET: Queue/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Queue/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,QueueNo,DateQueued,FirstName,MiddleName,FamilyName,Birthday,PhilHealthNo,ChiefComplaint,Barangay,HouseholdNo,Status,Served")] Queue queue)
        {
            if (ModelState.IsValid)
            {
                db.Queues.Add(queue);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(queue);
        }

        // GET: Queue/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Queue queue = await db.Queues.FindAsync(id);
            if (queue == null)
            {
                return HttpNotFound();
            }
            return View(queue);
        }

        // POST: Queue/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,QueueNo,DateQueued,FirstName,MiddleName,FamilyName,Birthday,PhilHealthNo,ChiefComplaint,Barangay,HouseholdNo,Status,Served")] Queue queue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(queue).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(queue);
        }

        // GET: Queue/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Queue queue = await db.Queues.FindAsync(id);
            if (queue == null)
            {
                return HttpNotFound();
            }
            return View(queue);
        }

        // POST: Queue/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Queue queue = await db.Queues.FindAsync(id);
            db.Queues.Remove(queue);
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
