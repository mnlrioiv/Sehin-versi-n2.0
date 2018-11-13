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
    public class TrabajadoresController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: Trabajadores
        public ActionResult Index()
        {
            return View(db.TrabajadoresSet.ToList());
        }

        // GET: Trabajadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajadores trabajadores = db.TrabajadoresSet.Find(id);
            if (trabajadores == null)
            {
                return HttpNotFound();
            }
            return View(trabajadores);
        }

        // GET: Trabajadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trabajadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] Trabajadores trabajadores)
        {
            if (ModelState.IsValid)
            {
                db.TrabajadoresSet.Add(trabajadores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trabajadores);
        }

        // GET: Trabajadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajadores trabajadores = db.TrabajadoresSet.Find(id);
            if (trabajadores == null)
            {
                return HttpNotFound();
            }
            return View(trabajadores);
        }

        // POST: Trabajadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] Trabajadores trabajadores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trabajadores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trabajadores);
        }

        // GET: Trabajadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajadores trabajadores = db.TrabajadoresSet.Find(id);
            if (trabajadores == null)
            {
                return HttpNotFound();
            }
            return View(trabajadores);
        }

        // POST: Trabajadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trabajadores trabajadores = db.TrabajadoresSet.Find(id);
            db.TrabajadoresSet.Remove(trabajadores);
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
