using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerSoporte.Cache
{
    public class EmployeesDataCache
    {
        LinkedList<Employee> usersCache;
        public int current;
        public int totalEmployees;

        public EmployeesDataCache(int current, int totalEmployees)
        {
            this.usersCache = new LinkedList<Employee>();
            this.current = current;
            this.totalEmployees = totalEmployees;
        }

        public bool AddUser(Employee u)
        {
            LinkedListNode<Employee> currentUser = usersCache.Find(u);

            if (currentUser == null)
            {
                this.usersCache.AddLast(u);
                return true;
            }
            else
            {
                return false;
            }
        }
        public LinkedList<Employee> GetUserInfo(int id)
        {
            LinkedList<Employee> tmpUser = new LinkedList<Employee>();
            LinkedListNode<Employee> currentUser = this.usersCache.First;
            while (currentUser != null)
            {
                if (currentUser.Value.id == id)
                {
                    tmpUser.AddLast(currentUser.Value);
                    break;
                }
                currentUser = currentUser.Next;
            }
            return tmpUser;
        }
        public LinkedList<Employee> GetUsers()
        {
            return usersCache;
        }
        public int GetTotalEmployees() 
        {
            return totalEmployees;
        }
    }
}
