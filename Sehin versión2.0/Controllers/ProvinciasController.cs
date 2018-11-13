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
    public class ProvinciasController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: Provincias
        public ActionResult Index()
        {
            return View(db.ProvinciasSet.ToList());
        }

        // GET: Provincias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincias provincias = db.ProvinciasSet.Find(id);
            if (provincias == null)
            {
                return HttpNotFound();
            }
            return View(provincias);
        }

        // GET: Provincias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Provincias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] Provincias provincias)
        {
            if (ModelState.IsValid)
            {
                db.ProvinciasSet.Add(provincias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(provincias);
        }

        // GET: Provincias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincias provincias = db.ProvinciasSet.Find(id);
            if (provincias == null)
            {
                return HttpNotFound();
            }
            return View(provincias);
        }

        // POST: Provincias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] Provincias provincias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provincias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(provincias);
        }

        // GET: Provincias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincias provincias = db.ProvinciasSet.Find(id);
            if (provincias == null)
            {
                return HttpNotFound();
            }
            return View(provincias);
        }

        // POST: Provincias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Provincias provincias = db.ProvinciasSet.Find(id);
            db.ProvinciasSet.Remove(provincias);
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
