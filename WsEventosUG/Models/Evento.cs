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
    
    public partial class Evento
    {
        public int id_evento { get; set; }
        public string Titulo { get; set; }
        public string Detalle { get; set; }
        public System.DateTime fecha_inicio { get; set; }
        public System.DateTime fecha_fin { get; set; }
        public System.DateTime fecha_creacion { get; set; }
        public System.DateTime fecha_modificacion { get; set; }
        public int usuario_creacion { get; set; }
        public int estado { get; set; }
        public int id_preferencia { get; set; }
    
        public virtual Estados Estados { get; set; }
        public virtual Catalogo_Preferencias Catalogo_Preferencias { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
