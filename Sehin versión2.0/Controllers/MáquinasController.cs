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
    public class MáquinasController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: Máquinas
        public ActionResult Index()
        {
            return View(db.MáquinasSet.ToList());
        }

        // GET: Máquinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Máquinas máquinas = db.MáquinasSet.Find(id);
            if (máquinas == null)
            {
                return HttpNotFound();
            }
            return View(máquinas);
        }

        // GET: Máquinas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Máquinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion")] Máquinas máquinas)
        {
            if (ModelState.IsValid)
            {
                db.MáquinasSet.Add(máquinas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(máquinas);
        }

        // GET: Máquinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Máquinas máquinas = db.MáquinasSet.Find(id);
            if (máquinas == null)
            {
                return HttpNotFound();
            }
            return View(máquinas);
        }

        // POST: Máquinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion")] Máquinas máquinas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(máquinas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(máquinas);
        }

        // GET: Máquinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Máquinas máquinas = db.MáquinasSet.Find(id);
            if (máquinas == null)
            {
                return HttpNotFound();
            }
            return View(máquinas);
        }

        // POST: Máquinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Máquinas máquinas = db.MáquinasSet.Find(id);
            db.MáquinasSet.Remove(máquinas);
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
