//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FacebookBD.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comentarios
    {
        public int IdComentario { get; set; }
        public Nullable<int> IdPublicacion { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public string Contenido { get; set; }
        public Nullable<System.DateTime> FechaComentario { get; set; }
    
        public virtual Publicaciones Publicaciones { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
