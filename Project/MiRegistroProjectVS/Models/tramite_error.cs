//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiRegistro.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tramite_error
    {
        public int IdTramite { get; set; }
        public int IdCategoriaError { get; set; }
        public int FkIdEmpleado { get; set; }
        public Nullable<sbyte> Resuelto { get; set; }
    
        public virtual categoriaerror categoriaerror { get; set; }
        public virtual empleado empleado { get; set; }
        public virtual tramite tramite { get; set; }
    }
}