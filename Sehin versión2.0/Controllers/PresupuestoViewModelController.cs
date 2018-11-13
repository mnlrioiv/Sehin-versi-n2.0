using Sehin_versión2._0.Models;
using Sehin_versión2._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sehin_versión2._0.Controllers
{
    public class PresupuestoViewModelController : Controller
    {

        private ModeloContainer db = new ModeloContainer();
        // GET: PresupuestoViewModel
        public ActionResult NuevoPresupuesto()
        {
            var presupuestoView = new PresupuestoView();
            presupuestoView.Cliente = new Clientes();
            presupuestoView.Servicios = new List<PresupuestoServicio>();
            Session["presupuestoView"] = presupuestoView;
            var list = db.ClientesSet.ToList();
            list.Add(new Clientes { Id = 0, RazonSocial = "[Seleccione un cliente]" });
            list = list.OrderBy(c => c.RazonSocial).ToList();
            ViewBag.Id = new SelectList(list, "Id", "RazonSocial");
            return View(presupuestoView);
        }
        [HttpPost]
        public ActionResult NuevoPresupuesto(PresupuestoView presupuestoView)
        {
            presupuestoView = Session["presupuestoView"] as PresupuestoView;
            var clienteId = int.Parse(Request["Id"]);
            if (clienteId == 0)
            {
                var list = db.ClientesSet.ToList();
                list.Add(new Clientes { Id = 0, RazonSocial = "[Seleccione un cliente]" });
                list = list.OrderBy(c => c.RazonSocial).ToList();
                ViewBag.Id = new SelectList(list, "Id", "RazonSocial");
                ViewBag.Error = "Debe seleccionar un cliente";
                return View(presupuestoView);
            }
            var cliente = db.ClientesSet.Find(clienteId);
            if (cliente == null)
            {
                var list = db.ClientesSet.ToList();
                list.Add(new Clientes { Id = 0, RazonSocial = "[Seleccione un cliente]" });
                list = list.OrderBy(c => c.RazonSocial).ToList();
                ViewBag.Id = new SelectList(list, "Id", "RazonSocial");
                ViewBag.Error = "Cliente no existe";
                return View(presupuestoView);

            }
            if (presupuestoView.Servicios.Count == 0)
            {
                var list = db.ClientesSet.ToList();
                list.Add(new Clientes { Id = 0, RazonSocial = "[Seleccione un cliente]" });
                list = list.OrderBy(c => c.RazonSocial).ToList();
                ViewBag.Id = new SelectList(list, "Id", "RazonSocial");
                ViewBag.Error = "Debe ingresar servicios";
                return View(presupuestoView);

            }
            short ultpresupuestonumero;
            try

            {
                ultpresupuestonumero = (short)db.PresupuestoSet.ToList().Select(p => p.numero).Max();
                //bool valorvalido = true;    //ESTO NO ESTA VALIDANDO EL FORMATO DEL MAXIMO. VALIDARLO

            }
            catch
            {
                ultpresupuestonumero = 0;
            }
            
            var presupuesto = new Presupuesto
            {
                ClientesId = clienteId,
                //TecnicoId = 1,  //falta el técnico, combobox
                Fecha = DateTime.Parse(Request["fecha"]),
                numero = (1 + ultpresupuestonumero),
                fechavencimiento = DateTime.Parse(Request["fechaVencimiento"])

            };
            db.PresupuestoSet.Add(presupuesto);
            db.SaveChanges();

            var presupuestoId = db.PresupuestoSet.ToList().Select(p => p.Id).Max();
            foreach (var item in presupuestoView.Servicios)
            {
                var presupuestoitem = new DetallePresupuesto
                {
                    descripcion = item.nombre,
                    descuento = 0,
                    preciounitario = item.precio,
                    //total = item.preciototal,
                    ServicioId = item.Id,
                    PresupuestoId = presupuestoId

                };
                db.DetallePresupuestoSet.Add(presupuestoitem);
                db.SaveChanges();
            }

            ViewBag.Message = string.Format("El presupuesto: {0}, se grabó con exito", presupuestoId);

            var listC = db.ClientesSet.ToList();
            listC.Add(new Clientes { Id = 0, RazonSocial = "[Seleccione un cliente]" });
            listC = listC.OrderBy(c => c.RazonSocial).ToList();
            ViewBag.Id = new SelectList(listC, "Id", "RazonSocial");

            presupuestoView = new PresupuestoView();
            presupuestoView.Cliente = new Clientes();
            presupuestoView.Servicios = new List<PresupuestoServicio>();
            Session["presupuestoView"] = presupuestoView;

            return View(presupuestoView);
        }


        public ActionResult AgregarServicio()
        {
            var list = db.ServicioSet.ToList();
            list.Add(new Servicio { Id = 0, nombre = "[Seleccione un servicio]" });
            list = list.OrderBy(s => s.nombre).ToList();
            ViewBag.Id = new SelectList(list, "Id", "nombre");
            return View();
        }
        [HttpPost]
        public ActionResult AgregarServicio(PresupuestoServicio presupuestoServicio)
        {
            var presupuestoView = Session["presupuestoView"] as PresupuestoView;
            var servicioID = int.Parse(Request["Id"]);
            if (servicioID == 0)
            {
                var list = db.ServicioSet.ToList();
                list.Add(new PresupuestoServicio { Id = 0, nombre = "[Seleccione un servicio]" });
                list = list.OrderBy(s => s.nombre).ToList();
                ViewBag.Id = new SelectList(list, "Id", "nombre");
                ViewBag.Error = "Debe seleccionar un servicio";
                return View(presupuestoServicio);
            }

            var product = db.ServicioSet.Find(servicioID);
            if (product == null)
            {
                var list = db.ServicioSet.ToList();
                list.Add(new Servicio { Id = 0, nombre = "[Seleccione un servicio]" });
                list = list.OrderBy(s => s.nombre).ToList();
                ViewBag.Id = new SelectList(list, "Id", "nombre");
                ViewBag.Error = "No existe el servicio";
                return View(presupuestoServicio);
            }

            presupuestoServicio = presupuestoView.Servicios.Find(s => s.Id == servicioID);
            //esto es para ver si el servicio existe para no agregarlo varias veces
            if (presupuestoServicio == null)
            {
                presupuestoServicio = new PresupuestoServicio
                {
                    activo = product.activo,
                    nombre = product.nombre,
                    precio = product.precio,
                    Id = product.Id,
                    cantidad = int.Parse(Request["Cantidad"])
                };
                presupuestoView.Servicios.Add(presupuestoServicio);
            }
            else
            {
                presupuestoServicio.cantidad = presupuestoServicio.cantidad + int.Parse(Request["Cantidad"]);

            }
            var listC = db.ClientesSet.ToList();
            listC.Add(new Clientes { Id = 0, RazonSocial = "[Seleccione un cliente]" });
            listC = listC.OrderBy(c => c.RazonSocial).ToList();
            ViewBag.Id = new SelectList(listC, "Id", "RazonSocial");

            return View("NuevoPresupuesto", presupuestoView);
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