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
    public class RiesgosController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: Riesgos
        public ActionResult Index()
        {
            var riesgosSet = db.RiesgosSet.Include(r => r.TipoRiesgos);
            return View(riesgosSet.ToList());
        }

        // GET: Riesgos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Riesgos riesgos = db.RiesgosSet.Find(id);
            if (riesgos == null)
            {
                return HttpNotFound();
            }
            return View(riesgos);
        }

        // GET: Riesgos/Create
        public ActionResult Create()
        {
            ViewBag.TipoRiesgosId = new SelectList(db.TipoRiesgosSet, "Id", "Descripcion");
            return View();
        }

        // POST: Riesgos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Factor,CondicionTrabajo,TipoRiesgosId")] Riesgos riesgos)
        {
            if (ModelState.IsValid)
            {
                db.RiesgosSet.Add(riesgos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoRiesgosId = new SelectList(db.TipoRiesgosSet, "Id", "Descripcion", riesgos.TipoRiesgosId);
            return View(riesgos);
        }

        // GET: Riesgos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Riesgos riesgos = db.RiesgosSet.Find(id);
            if (riesgos == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoRiesgosId = new SelectList(db.TipoRiesgosSet, "Id", "Descripcion", riesgos.TipoRiesgosId);
            return View(riesgos);
        }

        // POST: Riesgos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Factor,CondicionTrabajo,TipoRiesgosId")] Riesgos riesgos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(riesgos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoRiesgosId = new SelectList(db.TipoRiesgosSet, "Id", "Descripcion", riesgos.TipoRiesgosId);
            return View(riesgos);
        }

        // GET: Riesgos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Riesgos riesgos = db.RiesgosSet.Find(id);
            if (riesgos == null)
            {
                return HttpNotFound();
            }
            return View(riesgos);
        }

        // POST: Riesgos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Riesgos riesgos = db.RiesgosSet.Find(id);
            db.RiesgosSet.Remove(riesgos);
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
