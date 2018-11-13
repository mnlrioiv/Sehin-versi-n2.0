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
    public class TareasController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: Tareas
        public ActionResult Index()
        {
            return View(db.TareasSet.ToList());
        }

        // GET: Tareas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tareas tareas = db.TareasSet.Find(id);
            if (tareas == null)
            {
                return HttpNotFound();
            }
            return View(tareas);
        }

        // GET: Tareas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tareas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Categoria")] Tareas tareas)
        {
            if (ModelState.IsValid)
            {
                db.TareasSet.Add(tareas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tareas);
        }

        // GET: Tareas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tareas tareas = db.TareasSet.Find(id);
            if (tareas == null)
            {
                return HttpNotFound();
            }
            return View(tareas);
        }

        // POST: Tareas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Categoria")] Tareas tareas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tareas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tareas);
        }

        // GET: Tareas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tareas tareas = db.TareasSet.Find(id);
            if (tareas == null)
            {
                return HttpNotFound();
            }
            return View(tareas);
        }

        // POST: Tareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tareas tareas = db.TareasSet.Find(id);
            db.TareasSet.Remove(tareas);
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
