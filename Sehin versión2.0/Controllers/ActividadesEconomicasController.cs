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
    public class ActividadesEconomicasController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: ActividadesEconomicas
        public ActionResult Index()
        {
            return View(db.ActividadesEconomicasSet.ToList());
        }

        // GET: ActividadesEconomicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActividadesEconomicas actividadesEconomicas = db.ActividadesEconomicasSet.Find(id);
            if (actividadesEconomicas == null)
            {
                return HttpNotFound();
            }
            return View(actividadesEconomicas);
        }

        // GET: ActividadesEconomicas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActividadesEconomicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion")] ActividadesEconomicas actividadesEconomicas)
        {
            if (ModelState.IsValid)
            {
                db.ActividadesEconomicasSet.Add(actividadesEconomicas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actividadesEconomicas);
        }

        // GET: ActividadesEconomicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActividadesEconomicas actividadesEconomicas = db.ActividadesEconomicasSet.Find(id);
            if (actividadesEconomicas == null)
            {
                return HttpNotFound();
            }
            return View(actividadesEconomicas);
        }

        // POST: ActividadesEconomicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion")] ActividadesEconomicas actividadesEconomicas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actividadesEconomicas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actividadesEconomicas);
        }

        // GET: ActividadesEconomicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActividadesEconomicas actividadesEconomicas = db.ActividadesEconomicasSet.Find(id);
            if (actividadesEconomicas == null)
            {
                return HttpNotFound();
            }
            return View(actividadesEconomicas);
        }

        // POST: ActividadesEconomicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActividadesEconomicas actividadesEconomicas = db.ActividadesEconomicasSet.Find(id);
            db.ActividadesEconomicasSet.Remove(actividadesEconomicas);
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
