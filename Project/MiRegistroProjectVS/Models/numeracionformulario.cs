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
    
    public partial class numeracionformulario
    {
        public int IdNumeracion { get; set; }
        public int FkIdFormulario { get; set; }
        public string Numeracion { get; set; }
        public Nullable<int> Stock { get; set; }
        public Nullable<sbyte> Deleted { get; set; }
    
        public virtual formulario formulario { get; set; }
    }
}
