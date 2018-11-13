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
    public class DetallePresupuestoesController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: DetallePresupuestoes
        public ActionResult Index()
        {
            var detallePresupuestoSet = db.DetallePresupuestoSet.Include(d => d.Servicio).Include(d => d.Presupuesto);
            return View(detallePresupuestoSet.ToList());
        }

        // GET: DetallePresupuestoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePresupuesto detallePresupuesto = db.DetallePresupuestoSet.Find(id);
            if (detallePresupuesto == null)
            {
                return HttpNotFound();
            }
            return View(detallePresupuesto);
        }

        // GET: DetallePresupuestoes/Create
        public ActionResult Create()
        {
            ViewBag.ServicioId = new SelectList(db.ServicioSet, "Id", "nombre");
            ViewBag.PresupuestoId = new SelectList(db.PresupuestoSet, "Id", "Fecha");
            return View();
        }

        // POST: DetallePresupuestoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Monto,ServicioId,descripcion,cantidad,preciounitario,descuento,PresupuestoId")] DetallePresupuesto detallePresupuesto)
        {
            if (ModelState.IsValid)
            {
                db.DetallePresupuestoSet.Add(detallePresupuesto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ServicioId = new SelectList(db.ServicioSet, "Id", "nombre", detallePresupuesto.ServicioId);
            ViewBag.PresupuestoId = new SelectList(db.PresupuestoSet, "Id", "Fecha", detallePresupuesto.PresupuestoId);
            return View(detallePresupuesto);
        }

        // GET: DetallePresupuestoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePresupuesto detallePresupuesto = db.DetallePresupuestoSet.Find(id);
            if (detallePresupuesto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ServicioId = new SelectList(db.ServicioSet, "Id", "nombre", detallePresupuesto.ServicioId);
            ViewBag.PresupuestoId = new SelectList(db.PresupuestoSet, "Id", "Fecha", detallePresupuesto.PresupuestoId);
            return View(detallePresupuesto);
        }

        // POST: DetallePresupuestoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Monto,ServicioId,descripcion,cantidad,preciounitario,descuento,PresupuestoId")] DetallePresupuesto detallePresupuesto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detallePresupuesto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ServicioId = new SelectList(db.ServicioSet, "Id", "nombre", detallePresupuesto.ServicioId);
            ViewBag.PresupuestoId = new SelectList(db.PresupuestoSet, "Id", "Fecha", detallePresupuesto.PresupuestoId);
            return View(detallePresupuesto);
        }

        // GET: DetallePresupuestoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePresupuesto detallePresupuesto = db.DetallePresupuestoSet.Find(id);
            if (detallePresupuesto == null)
            {
                return HttpNotFound();
            }
            return View(detallePresupuesto);
        }

        // POST: DetallePresupuestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetallePresupuesto detallePresupuesto = db.DetallePresupuestoSet.Find(id);
            db.DetallePresupuestoSet.Remove(detallePresupuesto);
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
