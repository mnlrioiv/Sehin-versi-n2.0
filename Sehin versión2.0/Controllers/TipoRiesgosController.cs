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
    public class TipoRiesgosController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: TipoRiesgos
        public ActionResult Index()
        {
            return View(db.TipoRiesgosSet.ToList());
        }

        // GET: TipoRiesgos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoRiesgos tipoRiesgos = db.TipoRiesgosSet.Find(id);
            if (tipoRiesgos == null)
            {
                return HttpNotFound();
            }
            return View(tipoRiesgos);
        }

        // GET: TipoRiesgos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoRiesgos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion")] TipoRiesgos tipoRiesgos)
        {
            if (ModelState.IsValid)
            {
                db.TipoRiesgosSet.Add(tipoRiesgos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoRiesgos);
        }

        // GET: TipoRiesgos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoRiesgos tipoRiesgos = db.TipoRiesgosSet.Find(id);
            if (tipoRiesgos == null)
            {
                return HttpNotFound();
            }
            return View(tipoRiesgos);
        }

        // POST: TipoRiesgos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion")] TipoRiesgos tipoRiesgos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoRiesgos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoRiesgos);
        }

        // GET: TipoRiesgos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoRiesgos tipoRiesgos = db.TipoRiesgosSet.Find(id);
            if (tipoRiesgos == null)
            {
                return HttpNotFound();
            }
            return View(tipoRiesgos);
        }

        // POST: TipoRiesgos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoRiesgos tipoRiesgos = db.TipoRiesgosSet.Find(id);
            db.TipoRiesgosSet.Remove(tipoRiesgos);
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
