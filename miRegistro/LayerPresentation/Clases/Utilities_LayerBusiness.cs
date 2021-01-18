using LayerBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerPresentation.Clases
{
    public class Utilities_LayerBusiness
    {
        public Cn_Usuarios cn_usuarios;
        public Cn_alertas cn_alertas;
        public Cn_Tramites cn_tramites;
        public Cn_Empleados cn_empleados;
        public Cn_Formularios cn_formularios;

        /// <summary>
        /// Initialize all classes for an layer business
        /// </summary>
        public Utilities_LayerBusiness()
        {
            cn_usuarios = new Cn_Usuarios();
            cn_alertas = new Cn_alertas();
            cn_tramites = new Cn_Tramites();
            cn_empleados = new Cn_Empleados();
            cn_formularios = new Cn_Formularios();
        }    
    }
}
