using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sehin_versión2._0.Models;

namespace Sehin_versión2._0.Controllers
{
    public class DetallePlanesFormacionsController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: DetallePlanesFormacions
        public ActionResult Index()
        {
            return View(db.DetallePlanesFormacionSet.ToList());
        }

        // GET: DetallePlanesFormacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePlanesFormacion detallePlanesFormacion = db.DetallePlanesFormacionSet.Find(id);
            if (detallePlanesFormacion == null)
            {
                return HttpNotFound();
            }
            return View(detallePlanesFormacion);
        }

        // GET: DetallePlanesFormacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetallePlanesFormacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] DetallePlanesFormacion detallePlanesFormacion)
        {
            if (ModelState.IsValid)
            {
                db.DetallePlanesFormacionSet.Add(detallePlanesFormacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(detallePlanesFormacion);
        }

        // GET: DetallePlanesFormacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePlanesFormacion detallePlanesFormacion = db.DetallePlanesFormacionSet.Find(id);
            if (detallePlanesFormacion == null)
            {
                return HttpNotFound();
            }
            return View(detallePlanesFormacion);
        }

        // POST: DetallePlanesFormacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] DetallePlanesFormacion detallePlanesFormacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detallePlanesFormacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(detallePlanesFormacion);
        }

        // GET: DetallePlanesFormacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePlanesFormacion detallePlanesFormacion = db.DetallePlanesFormacionSet.Find(id);
            if (detallePlanesFormacion == null)
            {
                return HttpNotFound();
            }
            return View(detallePlanesFormacion);
        }

        // POST: DetallePlanesFormacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetallePlanesFormacion detallePlanesFormacion = db.DetallePlanesFormacionSet.Find(id);
            db.DetallePlanesFormacionSet.Remove(detallePlanesFormacion);
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
