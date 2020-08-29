using System;
using System.Drawing;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    [Serializable]
    public class Message
    {
        public User from;
        public User to;
        public string msg;
        public bool isToAll;
        public DateTime dateTimeInSend;

        public Message(User from, User to, string msg, bool isToall, DateTime dateTimeInSend)
        {
            
            this.from = from;
            this.to = to;
            this.msg = msg;
            this.isToAll = isToall;
            this.dateTimeInSend = dateTimeInSend;
        }
    }
}
