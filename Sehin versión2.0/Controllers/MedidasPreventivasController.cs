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
    public class MedidasPreventivasController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: MedidasPreventivas
        public ActionResult Index()
        {
            return View(db.MedidasPreventivasSet.ToList());
        }

        // GET: MedidasPreventivas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedidasPreventivas medidasPreventivas = db.MedidasPreventivasSet.Find(id);
            if (medidasPreventivas == null)
            {
                return HttpNotFound();
            }
            return View(medidasPreventivas);
        }

        // GET: MedidasPreventivas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedidasPreventivas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] MedidasPreventivas medidasPreventivas)
        {
            if (ModelState.IsValid)
            {
                db.MedidasPreventivasSet.Add(medidasPreventivas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medidasPreventivas);
        }

        // GET: MedidasPreventivas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedidasPreventivas medidasPreventivas = db.MedidasPreventivasSet.Find(id);
            if (medidasPreventivas == null)
            {
                return HttpNotFound();
            }
            return View(medidasPreventivas);
        }

        // POST: MedidasPreventivas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] MedidasPreventivas medidasPreventivas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medidasPreventivas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medidasPreventivas);
        }

        // GET: MedidasPreventivas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedidasPreventivas medidasPreventivas = db.MedidasPreventivasSet.Find(id);
            if (medidasPreventivas == null)
            {
                return HttpNotFound();
            }
            return View(medidasPreventivas);
        }

        // POST: MedidasPreventivas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedidasPreventivas medidasPreventivas = db.MedidasPreventivasSet.Find(id);
            db.MedidasPreventivasSet.Remove(medidasPreventivas);
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
