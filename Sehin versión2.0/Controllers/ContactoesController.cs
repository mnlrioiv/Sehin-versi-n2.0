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
    public class ContactoesController : Controller
    {
        private ModeloContainer db = new ModeloContainer();

        // GET: Contactoes
        public ActionResult Index()
        {
            var contactoSet = db.ContactoSet.Include(c => c.Localidades).Include(c => c.Clientes);
            return View(contactoSet.ToList());
        }

        // GET: Contactoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto contacto = db.ContactoSet.Find(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            return View(contacto);
        }

        // GET: Contactoes/Create
        public ActionResult Create()
        {
            ViewBag.LocalidadesId = new SelectList(db.LocalidadesSet, "Id", "Nombre");
            ViewBag.ClientesId = new SelectList(db.ClientesSet, "Id", "RazonSocial");
            return View();
        }

        // POST: Contactoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,TipoDoc,NumeroDoc,Email,Telefono,Domicilio,Foto,LocalidadesId,ClientesId")] Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                db.ContactoSet.Add(contacto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocalidadesId = new SelectList(db.LocalidadesSet, "Id", "Nombre", contacto.LocalidadesId);
            ViewBag.ClientesId = new SelectList(db.ClientesSet, "Id", "RazonSocial", contacto.ClientesId);
            return View(contacto);
        }

        // GET: Contactoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto contacto = db.ContactoSet.Find(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocalidadesId = new SelectList(db.LocalidadesSet, "Id", "Nombre", contacto.LocalidadesId);
            ViewBag.ClientesId = new SelectList(db.ClientesSet, "Id", "RazonSocial", contacto.ClientesId);
            return View(contacto);
        }

        // POST: Contactoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,TipoDoc,NumeroDoc,Email,Telefono,Domicilio,Foto,LocalidadesId,ClientesId")] Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contacto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocalidadesId = new SelectList(db.LocalidadesSet, "Id", "Nombre", contacto.LocalidadesId);
            ViewBag.ClientesId = new SelectList(db.ClientesSet, "Id", "RazonSocial", contacto.ClientesId);
            return View(contacto);
        }

        // GET: Contactoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto contacto = db.ContactoSet.Find(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            return View(contacto);
        }

        // POST: Contactoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contacto contacto = db.ContactoSet.Find(id);
            db.ContactoSet.Remove(contacto);
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
