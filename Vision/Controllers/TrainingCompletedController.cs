using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vision.Models;
using Vision.DataAccessLayer;

namespace Vision.Controllers
{
    public class TrainingCompletedController : Controller
    {
        private VisionContext db = new VisionContext();

        // GET: /TrainingCompleted/
        public ActionResult Index()
        {
            return View(db.TrainingCompleted.ToList());
        }

        // GET: /TrainingCompleted/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingCompleted trainingcompleted = db.TrainingCompleted.Find(id);
            if (trainingcompleted == null)
            {
                return HttpNotFound();
            }
            return View(trainingcompleted);
        }

        // GET: /TrainingCompleted/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TrainingCompleted/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,UserId,TrainingEventId,DateCompleted,ApprovedByUserId")] TrainingCompleted trainingcompleted)
        {
            if (ModelState.IsValid)
            {
                db.TrainingCompleted.Add(trainingcompleted);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainingcompleted);
        }

        // GET: /TrainingCompleted/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingCompleted trainingcompleted = db.TrainingCompleted.Find(id);
            if (trainingcompleted == null)
            {
                return HttpNotFound();
            }
            return View(trainingcompleted);
        }

        // POST: /TrainingCompleted/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,UserId,TrainingEventId,DateCompleted,ApprovedByUserId")] TrainingCompleted trainingcompleted)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingcompleted).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainingcompleted);
        }

        // GET: /TrainingCompleted/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingCompleted trainingcompleted = db.TrainingCompleted.Find(id);
            if (trainingcompleted == null)
            {
                return HttpNotFound();
            }
            return View(trainingcompleted);
        }

        // POST: /TrainingCompleted/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainingCompleted trainingcompleted = db.TrainingCompleted.Find(id);
            db.TrainingCompleted.Remove(trainingcompleted);
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
