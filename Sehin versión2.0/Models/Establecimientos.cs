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
    
    public partial class Establecimientos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Establecimientos()
        {
            this.Agenda = new HashSet<Agenda>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public short CantTrabajadores { get; set; }
        public double Superficie { get; set; }
        public string ART { get; set; }
        public string Domicilio { get; set; }
        public int ClientesId { get; set; }
        public int LocalidadesId { get; set; }
        public int ActividadesEconomicasId { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        public virtual Localidades Localidades { get; set; }
        public virtual ActividadesEconomicas ActividadesEconomicas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Agenda> Agenda { get; set; }
    }
}
