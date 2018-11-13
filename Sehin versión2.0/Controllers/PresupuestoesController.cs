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
    public class PresupuestoesController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: Presupuestoes
        public ActionResult Index()
        {
            var presupuestoSet = db.PresupuestoSet.Include(p => p.Clientes);
            return View(presupuestoSet.ToList());
        }

        // GET: Presupuestoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Presupuesto presupuesto = db.PresupuestoSet.Find(id);
            if (presupuesto == null)
            {
                return HttpNotFound();
            }
            return View(presupuesto);
        }

        // GET: Presupuestoes/Create
        public ActionResult Create()
        {
            ViewBag.ClientesId = new SelectList(db.ClientesSet, "Id", "RazonSocial");
            return View();
        }

        // POST: Presupuestoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClientesId,Fecha,numero,fechavencimiento")] Presupuesto presupuesto)
        {
            if (ModelState.IsValid)
            {
                db.PresupuestoSet.Add(presupuesto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientesId = new SelectList(db.ClientesSet, "Id", "RazonSocial", presupuesto.ClientesId);
            return View(presupuesto);
        }

        // GET: Presupuestoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Presupuesto presupuesto = db.PresupuestoSet.Find(id);
            if (presupuesto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientesId = new SelectList(db.ClientesSet, "Id", "RazonSocial", presupuesto.ClientesId);
            return View(presupuesto);
        }

        // POST: Presupuestoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClientesId,Fecha,numero,fechavencimiento")] Presupuesto presupuesto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(presupuesto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientesId = new SelectList(db.ClientesSet, "Id", "RazonSocial", presupuesto.ClientesId);
            return View(presupuesto);
        }

        // GET: Presupuestoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Presupuesto presupuesto = db.PresupuestoSet.Find(id);
            if (presupuesto == null)
            {
                return HttpNotFound();
            }
            return View(presupuesto);
        }

        // POST: Presupuestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Presupuesto presupuesto = db.PresupuestoSet.Find(id);
            db.PresupuestoSet.Remove(presupuesto);
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
