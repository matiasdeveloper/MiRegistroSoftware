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
    
    public partial class direccion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public direccion()
        {
            this.direccion_empresa = new HashSet<direccion_empresa>();
            this.perfil_direccion = new HashSet<perfil_direccion>();
        }
    
        public int IdDireccion { get; set; }
        public Nullable<int> FkIdPais { get; set; }
        public string Ciudad { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<direccion_empresa> direccion_empresa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<perfil_direccion> perfil_direccion { get; set; }
        public virtual pais pais { get; set; }
    }
}
