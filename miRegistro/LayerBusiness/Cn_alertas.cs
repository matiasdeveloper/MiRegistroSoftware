using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using LayerData;

namespace LayerBusiness
{
    public class Cn_alertas
    {
        private Cd_Alertas _cdObject = new Cd_Alertas();

        public DataTable mostrarAlertas() 
        {
            DataTable _dtTable = new DataTable();
            _dtTable = _cdObject.mostarAlertas();
            return _dtTable;
        }

        public DataTable mostrarAlertasFromUser(string idUser)
        {
            DataTable _dtTable = new DataTable();
            _dtTable = _cdObject.mostrarAlertasFromUser(idUser);
            return _dtTable;
        }

        public DataTable buscarNuevasAlertas(int stockMenorQue) 
        {
            DataTable _dtTable = new DataTable();
            _dtTable = _cdObject.buscarNuevasAlertas(stockMenorQue);
            return _dtTable;
        }

        public int insertarNuevaAlerta(string user)
        {
            int id = _cdObject.insertarAlertas(user);
            return id;
        }

        public void insertarDetallesAlerta(int id, int id_formulario, string detalleOperacion) 
        {
            _cdObject.insertarDetallesAlerta(id, id_formulario, detalleOperacion);
        }

        public DataTable mostrarSpecificAlert(int[] formulariosStock) 
        {
            DataTable _dtTable = new DataTable();
            _dtTable = _cdObject.mostrarSpecificAlert(formulariosStock);
            return _dtTable;
        }

        public int[] buscarDetallesAlerta(int cod_alerta) 
        {
            int[] tmp = _cdObject.buscarDetallesAlerta(cod_alerta);
            return tmp;
        }
    }
}
