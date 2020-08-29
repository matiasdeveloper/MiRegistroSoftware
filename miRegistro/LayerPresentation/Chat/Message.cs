using System;
using System.Collections.Generic;
using System.Drawing;
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

        public Message(User from, User to, string msg, bool isToAll, DateTime dateTimeInSend)
        {
            this.from = from;
            this.to = to;
            this.msg = msg;
            this.isToAll = isToAll;
            this.dateTimeInSend = dateTimeInSend;
        }
    }
}
