//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sehin_versión2._0.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetallePresupuesto
    {
        public int id { get; set; }
        public double Monto { get; set; }
        public int ServicioId { get; set; }
        public string descripcion { get; set; }
        public double cantidad { get; set; }
        public double preciounitario { get; set; }
        public double descuento { get; set; }
        public int PresupuestoId { get; set; }
    
        public virtual Servicio Servicio { get; set; }
        public virtual Presupuesto Presupuesto { get; set; }
    }
}
