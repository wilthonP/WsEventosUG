//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WsEventosUG.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Perfiles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Perfiles()
        {
            this.Usuarios = new HashSet<Usuarios>();
        }
    
        public int id_perfil { get; set; }
        public string descripcion { get; set; }
        public int usuario_creacion { get; set; }
        public System.DateTime fecha_creacion { get; set; }
        public System.DateTime fecha_modificacion { get; set; }
        public int estado { get; set; }
    
        public virtual Estados Estados { get; set; }
        public virtual Perfiles Perfiles1 { get; set; }
        public virtual Perfiles Perfiles2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
