using LayerSoporte.Cache;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerPresentation
{
    public class DataEmployee
    {
        public DataEmployee(int current, int totalEmployees) 
        {
            employeesCache = new EmployeesDataCache(current, totalEmployees);
        }

        public EmployeesDataCache employeesCache;

        public EmployeesDataCache GetCache() 
        {
            return employeesCache;
        }
    }
}
