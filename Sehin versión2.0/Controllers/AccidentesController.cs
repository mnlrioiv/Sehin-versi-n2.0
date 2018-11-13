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
    public class AccidentesController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: Accidentes
        public ActionResult Index()
        {
            var accidentesSet = db.AccidentesSet.Include(a => a.Puestos).Include(a => a.Trabajadores);
            return View(accidentesSet.ToList());
        }

        // GET: Accidentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accidentes accidentes = db.AccidentesSet.Find(id);
            if (accidentes == null)
            {
                return HttpNotFound();
            }
            return View(accidentes);
        }

        // GET: Accidentes/Create
        public ActionResult Create()
        {
            ViewBag.PuestosId = new SelectList(db.PuestosSet, "Id", "Id");
            ViewBag.TrabajadoresId = new SelectList(db.TrabajadoresSet, "Id", "Id");
            return View();
        }

        // POST: Accidentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PuestosId,TrabajadoresId,Fecha,Consecuencia")] Accidentes accidentes)
        {
            if (ModelState.IsValid)
            {
                db.AccidentesSet.Add(accidentes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PuestosId = new SelectList(db.PuestosSet, "Id", "Id", accidentes.PuestosId);
            ViewBag.TrabajadoresId = new SelectList(db.TrabajadoresSet, "Id", "Id", accidentes.TrabajadoresId);
            return View(accidentes);
        }

        // GET: Accidentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accidentes accidentes = db.AccidentesSet.Find(id);
            if (accidentes == null)
            {
                return HttpNotFound();
            }
            ViewBag.PuestosId = new SelectList(db.PuestosSet, "Id", "Id", accidentes.PuestosId);
            ViewBag.TrabajadoresId = new SelectList(db.TrabajadoresSet, "Id", "Id", accidentes.TrabajadoresId);
            return View(accidentes);
        }

        // POST: Accidentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PuestosId,TrabajadoresId,Fecha,Consecuencia")] Accidentes accidentes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accidentes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PuestosId = new SelectList(db.PuestosSet, "Id", "Id", accidentes.PuestosId);
            ViewBag.TrabajadoresId = new SelectList(db.TrabajadoresSet, "Id", "Id", accidentes.TrabajadoresId);
            return View(accidentes);
        }

        // GET: Accidentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accidentes accidentes = db.AccidentesSet.Find(id);
            if (accidentes == null)
            {
                return HttpNotFound();
            }
            return View(accidentes);
        }

        // POST: Accidentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accidentes accidentes = db.AccidentesSet.Find(id);
            db.AccidentesSet.Remove(accidentes);
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
