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
    public class LocalidadesController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: Localidades
        public ActionResult Index()
        {
            var localidadesSet = db.LocalidadesSet.Include(l => l.Provincias);
            return View(localidadesSet.ToList());
        }

        // GET: Localidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localidades localidades = db.LocalidadesSet.Find(id);
            if (localidades == null)
            {
                return HttpNotFound();
            }
            return View(localidades);
        }

        // GET: Localidades/Create
        public ActionResult Create()
        {
            ViewBag.ProvinciasId = new SelectList(db.ProvinciasSet, "Id", "Nombre");
            return View();
        }

        // POST: Localidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,ProvinciasId,CodigoPostal")] Localidades localidades)
        {
            if (ModelState.IsValid)
            {
                db.LocalidadesSet.Add(localidades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProvinciasId = new SelectList(db.ProvinciasSet, "Id", "Nombre", localidades.ProvinciasId);
            return View(localidades);
        }

        // GET: Localidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localidades localidades = db.LocalidadesSet.Find(id);
            if (localidades == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProvinciasId = new SelectList(db.ProvinciasSet, "Id", "Nombre", localidades.ProvinciasId);
            return View(localidades);
        }

        // POST: Localidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,ProvinciasId,CodigoPostal")] Localidades localidades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(localidades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProvinciasId = new SelectList(db.ProvinciasSet, "Id", "Nombre", localidades.ProvinciasId);
            return View(localidades);
        }

        // GET: Localidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localidades localidades = db.LocalidadesSet.Find(id);
            if (localidades == null)
            {
                return HttpNotFound();
            }
            return View(localidades);
        }

        // POST: Localidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Localidades localidades = db.LocalidadesSet.Find(id);
            db.LocalidadesSet.Remove(localidades);
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
