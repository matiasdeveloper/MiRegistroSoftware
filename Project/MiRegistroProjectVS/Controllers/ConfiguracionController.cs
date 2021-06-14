using MiRegistro.Views.Main;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ConfiguracionController
    {
        Configuracion _view { get; set; }

        FormModel _formModel = new FormModel();
        //MainViewModel _model = new MainViewModel();

        public ConfiguracionController(Configuracion view)
        {
            this._view = view;
        }
    }
}
