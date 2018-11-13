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
    public class CondicionIvasController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: CondicionIvas
        public ActionResult Index()
        {
            return View(db.CondicionIvaSet.ToList());
        }

        // GET: CondicionIvas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CondicionIva condicionIva = db.CondicionIvaSet.Find(id);
            if (condicionIva == null)
            {
                return HttpNotFound();
            }
            return View(condicionIva);
        }

        // GET: CondicionIvas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CondicionIvas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,PorcentajeIva,DiscriminaIva,LetraFiscal")] CondicionIva condicionIva)
        {
            if (ModelState.IsValid)
            {
                db.CondicionIvaSet.Add(condicionIva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(condicionIva);
        }

        // GET: CondicionIvas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CondicionIva condicionIva = db.CondicionIvaSet.Find(id);
            if (condicionIva == null)
            {
                return HttpNotFound();
            }
            return View(condicionIva);
        }

        // POST: CondicionIvas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,PorcentajeIva,DiscriminaIva,LetraFiscal")] CondicionIva condicionIva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(condicionIva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(condicionIva);
        }

        // GET: CondicionIvas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CondicionIva condicionIva = db.CondicionIvaSet.Find(id);
            if (condicionIva == null)
            {
                return HttpNotFound();
            }
            return View(condicionIva);
        }

        // POST: CondicionIvas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CondicionIva condicionIva = db.CondicionIvaSet.Find(id);
            db.CondicionIvaSet.Remove(condicionIva);
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
