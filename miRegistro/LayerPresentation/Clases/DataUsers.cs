using LayerPresentation;
using LayerSoporte.Cache;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayerPresentation.Clases;

public static class DataUsers
{
    public static List<string>[] GetUserData(int id)
    {
        LinkedListNode<Employee> employee = Statistics.tmp.First;
        List<List<string>> all = new List<List<string>>();

        List<string> user = new List<string>();
        List<string> info = new List<string>();
        List<string> empleado = new List<string>();

        for (int i = 0; i < Statistics.tmp.Count; i++)
        {
            if (employee.Value.nombre != "Admin S.")
            {
                if(employee.Value.id == id) 
                {
                    user.Add(employee.Value.usuario);
                    user.Add("");
                    string priv = "1";
                    if(employee.Value.privilegios == "Estandar") 
                    {
                        priv = "0";
                    }
                    user.Add(priv);

                    info.Add(employee.Value.nombreCompleto);
                    info.Add(employee.Value.nombreCorto);
                    info.Add(employee.Value.city);
                    info.Add(employee.Value.email);

                    empleado.Add(employee.Value.nombre);
                    empleado.Add(employee.Value.salario);
                    empleado.Add(employee.Value.observaciones);
                }
            }
            employee = employee.Next;
        }

        all.Add(user);
        all.Add(info);
        all.Add(empleado);

        return all.ToArray();
    }
}
