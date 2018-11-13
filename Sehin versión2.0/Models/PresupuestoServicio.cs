using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sehin_versión2._0.Models
{
    public class PresupuestoServicio : Sehin_versión2._0.Models.Servicio
    {
        public int cantidad { get; set; }
        public double preciototal { get { return cantidad * Convert.ToInt32(precio); } }
    }
}