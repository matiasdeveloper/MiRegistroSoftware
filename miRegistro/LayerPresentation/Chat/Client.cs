using System;
using System.Collections.Generic;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using Serialization;
using Chat;
using System.Diagnostics;
using LayerPresentation;
using Message = Chat.Message;
using LayerSoporte.Cache;
using LayerBusiness;
using System.Data;
using System.Drawing;

namespace ChatUI.Chat
{
    public class Client
    {
        public Client(string username, frm_chat form, int myImage)
        {
            f = form;
            this.u = new User(Guid.NewGuid().ToString("N"), username, getDataBaseId(), myImage);
            this.chat = new ChatManager(u);
            this.usersCache = new UserChatInfo(getDataBaseId());

            try
            {
                host = Dns.GetHostEntry("localhost");
                addr = host.AddressList[0];
                endPoint = new IPEndPoint(addr, 4404);
                socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

        }

        #region Variables

        Cn_Usuarios _cnObject = new Cn_Usuarios();
        Cn_alertas _cnObjectAlert = new Cn_alertas();

        //Form
        private frm_chat f;
        //Chat manager
        User u;
        ChatManager chat;
        public UserChatInfo usersCache;
        //Chat connection
        readonly IPHostEntry host;
        readonly IPAddress addr;
        readonly IPEndPoint endPoint ;
        readonly Socket socket;
        Thread listenThread;

        #endregion

        /// <summary>
        /// Return database id from the user
        /// </summary>
        private int getDataBaseId() 
        {
            return UserLoginCache.IdUser;
        }
        /// <summary>
        /// Start the client
        /// </summary>
        public void Start()
        {
            // try catch
            this.socket.Connect(endPoint);
            this.Send(this.socket, this.u);
            listenThread = new Thread(this.Listen);
            listenThread.SetApartmentState(ApartmentState.STA);
            listenThread.Start();
        }

        /// <summary>
        /// Listen for messages and users from the server
        /// </summary>
        private void Listen()
        {
            object received;
            while (true) 
            {
                received = this.Receive(this.socket);
                if(received is Message) 
                {
                    if (((Message)received).isToAll == true) 
                    {
                        this.AddMessageToAll((Message)received);
                    } else
                    {
                        this.AddMessage((Message)received);
                    }
                } else if(received is User)
                {
                    this.AddUser((User)received);
                }
            }
        }
        /// <summary>
        /// Return if the user isConnected and remove them for add new user
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        private bool userIsConnected(User newUser)
        {
            bool isConnected = false;

            LinkedList<User> tmp = GetUsers();
            LinkedListNode<User> user = tmp.First;

            for (int i = 0; i < tmp.Count; i++)
            {
                if (user.Value.id == newUser.id && newUser.id != GetMyClientUser().id && user.Value.id != GetMyClientUser().id)
                {
                    // Charge data
                    user.Value = newUser;
                    isConnected = true;
                }
                user = user.Next;
            }

            return isConnected;
        }
        /// <summary>
        /// Add a user to the chat db
        /// </summary>
        /// <param name="user"></param>
        private void AddUser(User user)
        {
            bool tmp = userIsConnected(user);
            if (user.id != this.u.id && this.chat.AddUser(user)) 
            {
                f.UpdateUI(user, tmp);
                //this.usersCache.AddUser(generateUserDataCache(user));

                string msg = user.nick + " se ha conectado..";
                Message m = new Message(user, this.u, msg, true, DateTime.Now);
                chat.AddMessage(m);
            }  
        }

        private UserChat generateUserDataCache(User u)
        {
            DataTable tmpData = new DataTable();
            DataTable tmpDataAlert = new DataTable();

            tmpData = _cnObject.FindDataFromSpecificUser(u.idDataBase.ToString());
            tmpDataAlert = _cnObjectAlert.mostrarAlertasFromUser(u.nick);

            string nombre = tmpData.Rows[0][1].ToString();
            string privilegios = tmpData.Rows[1][3].ToString();
            string city = tmpData.Rows[0][3].ToString();
            string email = tmpData.Rows[0][4].ToString();
            DateTime fechaNacimiento = Convert.ToDateTime(tmpData.Rows[0][5].ToString());
            string cellphone = tmpData.Rows[0][7].ToString();
            int selectedImage = u.myImageIndex;

            UserChat cache = new UserChat(u.idDataBase, nombre, privilegios, city, email, fechaNacimiento, cellphone, selectedImage, tmpDataAlert);
            return cache;
        }
        /// <summary>
        /// Add a message to the chat db
        /// </summary>
        /// <param name="m">Message to add</param>
        private void AddMessage(Message m)
        {
            chat.AddMessage(m);
            f.UpdateUI(m, false);
        }
        private void AddMessageToAll(Message m) 
        {
            chat.AddMessage(m);
            f.UpdateUI(m, false);
        }
        /// <summary>
        /// Get all messages received and sended to user
        /// </summary>
        /// <param name="u">User context</param>
        /// <returns></returns>
        public LinkedList<Message> GetMessages(User u)
        {
            return chat.GetMessages(u, false);
        }

        public LinkedList<Message> GetMessagesToAll(User u)
        {
            return chat.GetMessages(u, true);
        }

        /// <summary>
        /// Get all the users
        /// </summary>
        /// <returns>Users</returns>
        public LinkedList<User> GetUsers()
        {
            return chat.GetUsers();
        }

        public string GetMyClientNick() 
        {
            return this.u.nick;
        }
        public User GetMyClientUser()
        {
            return this.u;
        }
        /// <summary>
        /// Send a message to the server
        /// </summary>
        /// <param name="msg"></param>
        public Message SendMessage(string msg, User to, bool isToAll, DateTime now)
        {
            Message m = new Message(this.u, to, msg, isToAll, now);
            this.Send(this.socket, m);
            if (((Message)m).isToAll) 
            {
                //this.AddMessageToAll(m);
            }
            else if(!((Message)m).isToAll) 
            {
                this.AddMessage(m);
            }
            return m;
        }

        /// <summary>
        /// Send a object to the client
        /// </summary>
        /// <param name="s">Socket client</param>
        /// <param name="o">Object to send</param>
        private void Send(Socket s, object o)
        {
            byte[] buffer = new byte[1024];
            byte[] obj = BinarySerialization.Serializate(o);
            Array.Copy(obj, buffer, obj.Length);
            s.Send(buffer);
        }

        /// <summary>
        /// Receive all the serialized object
        /// </summary>
        /// <param name="s">Socket that receive the object</param>
        /// <returns>Object received from client</returns>
        private object Receive(Socket s)
        {
            byte[] buffer = new byte[1024];
            s.Receive(buffer);
            return BinarySerialization.Deserializate(buffer);
        }
        public void notificaciones(string msg, string from)
        {
            //Notificaciones frm = new Notificaciones();
            //frm.showAlert(msg, from);
        }
    }
}
