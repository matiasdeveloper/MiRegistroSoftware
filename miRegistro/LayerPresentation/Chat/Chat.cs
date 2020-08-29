using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat;

namespace ChatUI.Chat
{
    public class ChatManager
    {
        LinkedList<User> users;
        LinkedList<Message> messages;
        LinkedList<Message> allMessages;
        User current;

        public ChatManager(User current)
        {
            this.users = new LinkedList<User>();
            this.messages = new LinkedList<Message>();
            this.allMessages = new LinkedList<Message>();
            this.current = current;
        }

        public bool AddUser(User u)
        {
            LinkedListNode<User> currentUser = users.Find(u);

            if (currentUser == null && this.current.id != u.id)
            {
                this.users.AddLast(u);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddMessage(Message m)
        {
            this.messages.AddLast(m);
        }

        public LinkedList<Message> GetMessages(User from, bool isToAll)
        {
            LinkedList<Message> tmpMSG = new LinkedList<Message>();
            LinkedListNode<Message> currentMSG = this.messages.First;
            while(currentMSG != null)
            {
                if (isToAll)
                {
                    if (currentMSG.Value.isToAll) 
                    {
                        tmpMSG.AddLast(currentMSG.Value);
                    }
                } else 
                {
                    if (currentMSG.Value.from.id == from.id || currentMSG.Value.to.id == from.id)
                    {
                        tmpMSG.AddLast(currentMSG.Value);
                    }
                }
                currentMSG = currentMSG.Next;
            }
            return tmpMSG;
        }

        public LinkedList<User> GetUsers()
        {
            return this.users;
        }
    }
}
