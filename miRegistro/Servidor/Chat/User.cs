using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    [Serializable]
    public class User
    {
        public string id;
        public string nick;
        public int idDataBase;
        public int myImageIndex;

        public User(string id, string nick, int idDb, int myImageIndex)
        {
            this.id = id;
            this.nick = nick;
            this.idDataBase = idDb;
            this.myImageIndex = myImageIndex;
        }
    }
}
