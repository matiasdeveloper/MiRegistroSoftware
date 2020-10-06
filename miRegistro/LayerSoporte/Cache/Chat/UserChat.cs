using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerSoporte.Cache
{
    public class UserChat
    {
        public int id;
        public string nombre;
        public string privilegios;
        public string city;
        public string email;
        public DateTime fechaNacimiento;
        public string cellphone;
        public int image;
        public DataTable lastAlert;

        public UserChat(int id, string nombre, string privilegios, string city,string email, DateTime fechaNacimiento, string cellphone, int image, DataTable lastAlert) 
        {
            this.id = id;
            this.nombre = nombre;
            this.privilegios = privilegios;
            this.city = city;
            this.email = email;
            this.fechaNacimiento = fechaNacimiento;
            this.cellphone = cellphone;
            this.image = image;
            this.lastAlert = lastAlert;
        }
    }
}
