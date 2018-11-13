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
    public class TécnicosController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: Técnicos
        public ActionResult Index()
        {
            var técnicosSet = db.TécnicosSet.Include(t => t.Localidades);
            return View(técnicosSet.ToList());
        }

        // GET: Técnicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Técnicos técnicos = db.TécnicosSet.Find(id);
            if (técnicos == null)
            {
                return HttpNotFound();
            }
            return View(técnicos);
        }

        // GET: Técnicos/Create
        public ActionResult Create()
        {
            ViewBag.LocalidadesId = new SelectList(db.LocalidadesSet, "Id", "Nombre");
            return View();
        }

        // POST: Técnicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Legajo,Nombre,TipoDoc,NumeroDoc,Domicilio,Email,Telefono,LocalidadesId")] Técnicos técnicos)
        {
            if (ModelState.IsValid)
            {
                db.TécnicosSet.Add(técnicos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocalidadesId = new SelectList(db.LocalidadesSet, "Id", "Nombre", técnicos.LocalidadesId);
            return View(técnicos);
        }

        // GET: Técnicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Técnicos técnicos = db.TécnicosSet.Find(id);
            if (técnicos == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocalidadesId = new SelectList(db.LocalidadesSet, "Id", "Nombre", técnicos.LocalidadesId);
            return View(técnicos);
        }

        // POST: Técnicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Legajo,Nombre,TipoDoc,NumeroDoc,Domicilio,Email,Telefono,LocalidadesId")] Técnicos técnicos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(técnicos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocalidadesId = new SelectList(db.LocalidadesSet, "Id", "Nombre", técnicos.LocalidadesId);
            return View(técnicos);
        }

        // GET: Técnicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Técnicos técnicos = db.TécnicosSet.Find(id);
            if (técnicos == null)
            {
                return HttpNotFound();
            }
            return View(técnicos);
        }

        // POST: Técnicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Técnicos técnicos = db.TécnicosSet.Find(id);
            db.TécnicosSet.Remove(técnicos);
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
