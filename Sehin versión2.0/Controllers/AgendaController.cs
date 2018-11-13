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
    public class AgendaController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: Agenda
        public ActionResult Index()
        {
            var agendaSet = db.AgendaSet.Include(a => a.Técnicos).Include(a => a.OrdenTrabajo).Include(a => a.Establecimientos);
            return View(agendaSet.ToList());
        }

        // GET: Agenda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda agenda = db.AgendaSet.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            return View(agenda);
        }

        // GET: Agenda/Create
        public ActionResult Create()
        {
            ViewBag.TécnicosLegajo = new SelectList(db.TécnicosSet, "Legajo", "Nombre");
            ViewBag.OrdenTrabajoId = new SelectList(db.OrdenTrabajoSet, "Id", "Id");
            ViewBag.EstablecimientosId = new SelectList(db.EstablecimientosSet, "Id", "Nombre");
            return View();
        }

        // POST: Agenda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,Estado,TécnicosLegajo,OrdenTrabajoId,EstablecimientosId")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                db.AgendaSet.Add(agenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TécnicosLegajo = new SelectList(db.TécnicosSet, "Legajo", "Nombre", agenda.TécnicosLegajo);
            ViewBag.OrdenTrabajoId = new SelectList(db.OrdenTrabajoSet, "Id", "Id", agenda.OrdenTrabajoId);
            ViewBag.EstablecimientosId = new SelectList(db.EstablecimientosSet, "Id", "Nombre", agenda.EstablecimientosId);
            return View(agenda);
        }

        // GET: Agenda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda agenda = db.AgendaSet.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            ViewBag.TécnicosLegajo = new SelectList(db.TécnicosSet, "Legajo", "Nombre", agenda.TécnicosLegajo);
            ViewBag.OrdenTrabajoId = new SelectList(db.OrdenTrabajoSet, "Id", "Id", agenda.OrdenTrabajoId);
            ViewBag.EstablecimientosId = new SelectList(db.EstablecimientosSet, "Id", "Nombre", agenda.EstablecimientosId);
            return View(agenda);
        }

        // POST: Agenda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,Estado,TécnicosLegajo,OrdenTrabajoId,EstablecimientosId")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TécnicosLegajo = new SelectList(db.TécnicosSet, "Legajo", "Nombre", agenda.TécnicosLegajo);
            ViewBag.OrdenTrabajoId = new SelectList(db.OrdenTrabajoSet, "Id", "Id", agenda.OrdenTrabajoId);
            ViewBag.EstablecimientosId = new SelectList(db.EstablecimientosSet, "Id", "Nombre", agenda.EstablecimientosId);
            return View(agenda);
        }

        // GET: Agenda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda agenda = db.AgendaSet.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            return View(agenda);
        }

        // POST: Agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agenda agenda = db.AgendaSet.Find(id);
            db.AgendaSet.Remove(agenda);
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
