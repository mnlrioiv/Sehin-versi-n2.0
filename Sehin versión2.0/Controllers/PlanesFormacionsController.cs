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
    public class PlanesFormacionsController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: PlanesFormacions
        public ActionResult Index()
        {
            var planesFormacionSet = db.PlanesFormacionSet.Include(p => p.Cursos).Include(p => p.Trabajadores);
            return View(planesFormacionSet.ToList());
        }

        // GET: PlanesFormacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanesFormacion planesFormacion = db.PlanesFormacionSet.Find(id);
            if (planesFormacion == null)
            {
                return HttpNotFound();
            }
            return View(planesFormacion);
        }

        // GET: PlanesFormacions/Create
        public ActionResult Create()
        {
            ViewBag.CursosId = new SelectList(db.CursosSet, "Id", "nombre");
            ViewBag.TrabajadoresId = new SelectList(db.TrabajadoresSet, "Id", "Id");
            return View();
        }

        // POST: PlanesFormacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,CursosId,TrabajadoresId,Fecha,Estado")] PlanesFormacion planesFormacion)
        {
            if (ModelState.IsValid)
            {
                db.PlanesFormacionSet.Add(planesFormacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CursosId = new SelectList(db.CursosSet, "Id", "nombre", planesFormacion.CursosId);
            ViewBag.TrabajadoresId = new SelectList(db.TrabajadoresSet, "Id", "Id", planesFormacion.TrabajadoresId);
            return View(planesFormacion);
        }

        // GET: PlanesFormacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanesFormacion planesFormacion = db.PlanesFormacionSet.Find(id);
            if (planesFormacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursosId = new SelectList(db.CursosSet, "Id", "nombre", planesFormacion.CursosId);
            ViewBag.TrabajadoresId = new SelectList(db.TrabajadoresSet, "Id", "Id", planesFormacion.TrabajadoresId);
            return View(planesFormacion);
        }

        // POST: PlanesFormacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,CursosId,TrabajadoresId,Fecha,Estado")] PlanesFormacion planesFormacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planesFormacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursosId = new SelectList(db.CursosSet, "Id", "nombre", planesFormacion.CursosId);
            ViewBag.TrabajadoresId = new SelectList(db.TrabajadoresSet, "Id", "Id", planesFormacion.TrabajadoresId);
            return View(planesFormacion);
        }

        // GET: PlanesFormacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanesFormacion planesFormacion = db.PlanesFormacionSet.Find(id);
            if (planesFormacion == null)
            {
                return HttpNotFound();
            }
            return View(planesFormacion);
        }

        // POST: PlanesFormacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlanesFormacion planesFormacion = db.PlanesFormacionSet.Find(id);
            db.PlanesFormacionSet.Remove(planesFormacion);
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
