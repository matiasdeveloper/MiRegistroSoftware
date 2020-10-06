using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerSoporte.Cache
{
    public class UserChatInfo
    {
        LinkedList<UserChat> usersCache;
        int currentId;

        public UserChatInfo(int currentId)
        {
            this.usersCache = new LinkedList<UserChat>();
            this.currentId = currentId;
        }

        public bool AddUser(UserChat u)
        {
            LinkedListNode<UserChat> currentUser = usersCache.Find(u);

            if (currentUser == null && this.currentId != u.id)
            {
                this.usersCache.AddLast(u);
                return true;
            }
            else
            {
                return false;
            }
        }

        public LinkedList<UserChat> GetUserInfo(int id)
        {
            LinkedList<UserChat> tmpUser = new LinkedList<UserChat>();
            LinkedListNode<UserChat> currentUser = this.usersCache.First;
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
    }

}
