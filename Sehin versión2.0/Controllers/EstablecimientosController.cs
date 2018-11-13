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
    public class EstablecimientosController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: Establecimientos
        public ActionResult Index()
        {
            var establecimientosSet = db.EstablecimientosSet.Include(e => e.Clientes).Include(e => e.Localidades).Include(e => e.ActividadesEconomicas);
            return View(establecimientosSet.ToList());
        }

        // GET: Establecimientos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Establecimientos establecimientos = db.EstablecimientosSet.Find(id);
            if (establecimientos == null)
            {
                return HttpNotFound();
            }
            return View(establecimientos);
        }

        // GET: Establecimientos/Create
        public ActionResult Create()
        {
            ViewBag.ClientesId = new SelectList(db.ClientesSet, "Id", "RazonSocial");
            ViewBag.LocalidadesId = new SelectList(db.LocalidadesSet, "Id", "Nombre");
            ViewBag.ActividadesEconomicasId = new SelectList(db.ActividadesEconomicasSet, "Id", "Descripcion");
            return View();
        }

        // POST: Establecimientos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,CantTrabajadores,Superficie,ART,Domicilio,ClientesId,LocalidadesId,ActividadesEconomicasId")] Establecimientos establecimientos)
        {
            if (ModelState.IsValid)
            {
                db.EstablecimientosSet.Add(establecimientos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientesId = new SelectList(db.ClientesSet, "Id", "RazonSocial", establecimientos.ClientesId);
            ViewBag.LocalidadesId = new SelectList(db.LocalidadesSet, "Id", "Nombre", establecimientos.LocalidadesId);
            ViewBag.ActividadesEconomicasId = new SelectList(db.ActividadesEconomicasSet, "Id", "Descripcion", establecimientos.ActividadesEconomicasId);
            return View(establecimientos);
        }

        // GET: Establecimientos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Establecimientos establecimientos = db.EstablecimientosSet.Find(id);
            if (establecimientos == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientesId = new SelectList(db.ClientesSet, "Id", "RazonSocial", establecimientos.ClientesId);
            ViewBag.LocalidadesId = new SelectList(db.LocalidadesSet, "Id", "Nombre", establecimientos.LocalidadesId);
            ViewBag.ActividadesEconomicasId = new SelectList(db.ActividadesEconomicasSet, "Id", "Descripcion", establecimientos.ActividadesEconomicasId);
            return View(establecimientos);
        }

        // POST: Establecimientos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,CantTrabajadores,Superficie,ART,Domicilio,ClientesId,LocalidadesId,ActividadesEconomicasId")] Establecimientos establecimientos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(establecimientos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientesId = new SelectList(db.ClientesSet, "Id", "RazonSocial", establecimientos.ClientesId);
            ViewBag.LocalidadesId = new SelectList(db.LocalidadesSet, "Id", "Nombre", establecimientos.LocalidadesId);
            ViewBag.ActividadesEconomicasId = new SelectList(db.ActividadesEconomicasSet, "Id", "Descripcion", establecimientos.ActividadesEconomicasId);
            return View(establecimientos);
        }

        // GET: Establecimientos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Establecimientos establecimientos = db.EstablecimientosSet.Find(id);
            if (establecimientos == null)
            {
                return HttpNotFound();
            }
            return View(establecimientos);
        }

        // POST: Establecimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Establecimientos establecimientos = db.EstablecimientosSet.Find(id);
            db.EstablecimientosSet.Remove(establecimientos);
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
