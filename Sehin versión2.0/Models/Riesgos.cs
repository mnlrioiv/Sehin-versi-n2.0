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
    
    public partial class Riesgos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Riesgos()
        {
            this.OrdenTrabajo = new HashSet<OrdenTrabajo>();
        }
    
        public int Id { get; set; }
        public string Factor { get; set; }
        public string CondicionTrabajo { get; set; }
        public int TipoRiesgosId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdenTrabajo> OrdenTrabajo { get; set; }
        public virtual TipoRiesgos TipoRiesgos { get; set; }
    }
}
