using Sehin_versión2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sehin_versión2._0.ViewModels
{
    public class PresupuestoView
    {
        public int numero { get; set; }
        public DateTime fecha { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public Clientes Cliente { get; set; }
        public Técnicos Tecnico { get; set; }
        public PresupuestoServicio Servicio { get; set; }
        public List<PresupuestoServicio> Servicios { get; set; }
    }
}