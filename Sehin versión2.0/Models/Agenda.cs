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
    
    public partial class Agenda
    {
        public int Id { get; set; }
        public string Fecha { get; set; }
        public string Estado { get; set; }
        public int TécnicosLegajo { get; set; }
        public int OrdenTrabajoId { get; set; }
        public int EstablecimientosId { get; set; }
    
        public virtual Técnicos Técnicos { get; set; }
        public virtual OrdenTrabajo OrdenTrabajo { get; set; }
        public virtual Establecimientos Establecimientos { get; set; }
    }
}
