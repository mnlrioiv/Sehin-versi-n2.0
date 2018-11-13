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
    public class ClientesController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: Clientes
        public ActionResult Index()
        {
            var clientesSet = db.ClientesSet.Include(c => c.CondicionIva).Include(c => c.Localidades);
            return View(clientesSet.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.ClientesSet.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.CondicionIvaId = new SelectList(db.CondicionIvaSet, "Id", "Descripcion");
            ViewBag.LocalidadesId = new SelectList(db.LocalidadesSet, "Id", "Nombre");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RazonSocial,CUIT,IngBrutos,CondicionIvaId,LocalidadesId")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.ClientesSet.Add(clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CondicionIvaId = new SelectList(db.CondicionIvaSet, "Id", "Descripcion", clientes.CondicionIvaId);
            ViewBag.LocalidadesId = new SelectList(db.LocalidadesSet, "Id", "Nombre", clientes.LocalidadesId);
            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.ClientesSet.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.CondicionIvaId = new SelectList(db.CondicionIvaSet, "Id", "Descripcion", clientes.CondicionIvaId);
            ViewBag.LocalidadesId = new SelectList(db.LocalidadesSet, "Id", "Nombre", clientes.LocalidadesId);
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RazonSocial,CUIT,IngBrutos,CondicionIvaId,LocalidadesId")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CondicionIvaId = new SelectList(db.CondicionIvaSet, "Id", "Descripcion", clientes.CondicionIvaId);
            ViewBag.LocalidadesId = new SelectList(db.LocalidadesSet, "Id", "Nombre", clientes.LocalidadesId);
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.ClientesSet.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clientes clientes = db.ClientesSet.Find(id);
            db.ClientesSet.Remove(clientes);
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
