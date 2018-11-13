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
    public class PuestosController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: Puestos
        public ActionResult Index()
        {
            return View(db.PuestosSet.ToList());
        }

        // GET: Puestos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puestos puestos = db.PuestosSet.Find(id);
            if (puestos == null)
            {
                return HttpNotFound();
            }
            return View(puestos);
        }

        // GET: Puestos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Puestos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TareasPuestoId")] Puestos puestos)
        {
            if (ModelState.IsValid)
            {
                db.PuestosSet.Add(puestos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(puestos);
        }

        // GET: Puestos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puestos puestos = db.PuestosSet.Find(id);
            if (puestos == null)
            {
                return HttpNotFound();
            }
            return View(puestos);
        }

        // POST: Puestos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TareasPuestoId")] Puestos puestos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(puestos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(puestos);
        }

        // GET: Puestos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puestos puestos = db.PuestosSet.Find(id);
            if (puestos == null)
            {
                return HttpNotFound();
            }
            return View(puestos);
        }

        // POST: Puestos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Puestos puestos = db.PuestosSet.Find(id);
            db.PuestosSet.Remove(puestos);
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
