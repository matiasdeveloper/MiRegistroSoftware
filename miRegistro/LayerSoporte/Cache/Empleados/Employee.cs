using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerSoporte.Cache
{
    public class Employee
    {
        public int id;
        public string usuario;
        public string nombre;
        public string nombreCorto;
        public string nombreCompleto;
        public string privilegios;
        public string city;
        public string email;
        public DateTime fechaNacimiento;
        public DateTime fechaAcceso;
        public string cellphone;
        public DataTable tramitesMes;
        public DataTable alertas;
        public DateTime fechaContratacion;
        public string salario;
        public string observaciones;

        public Employee(int id, string usuario, string nombre, string nombreCorto ,string nombreCompleto, string privilegios, string city, string email, DateTime fechaNacimiento, DateTime fechaAcceso,string cellphone, DataTable tramitesMes, DataTable alertas, DateTime fechaContratacion, string salario, string observaciones)
        {
            this.id = id;
            this.usuario = usuario;
            this.nombreCorto = nombreCorto;
            this.nombreCompleto = nombreCompleto;
            this.nombre = nombre;
            this.privilegios = privilegios;
            this.city = city;
            this.email = email;
            this.fechaNacimiento = fechaNacimiento;
            this.fechaAcceso = fechaAcceso;
            this.cellphone = cellphone;
            this.tramitesMes = tramitesMes;
            this.alertas = alertas;
            this.fechaContratacion = fechaContratacion;
            this.salario = salario;
            this.observaciones = observaciones;
        }
    }
}
