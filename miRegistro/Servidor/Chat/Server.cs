using System;
using System.Collections;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using Chat;
using Serialization;

namespace ChatServer.Chat
{
    class Server
    {
        Socket socket;
        Thread listenThread;
        Hashtable usersTable;
        public Server()
        {
            try
            {
                IPHostEntry host = Dns.GetHostEntry("localhost");
                IPAddress addr = host.AddressList[0];
                IPEndPoint endPoint = new IPEndPoint(addr, 4404);

                socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(endPoint);
                socket.Listen(10);

                listenThread = new Thread(this.Listen);
                listenThread.Start();
                usersTable = new Hashtable();

                Console.WriteLine("Servidor en linea!" + " LOCALHOST");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }
        }

        /// <summary>
        /// Ready to accept connection from clients
        /// </summary>
        private void Listen()
        {
            Socket client;
            while(true) 
            {
                client = this.socket.Accept();
                listenThread = new Thread(this.ListenClient);
                listenThread.Start(client);
            }
        }

        /// <summary>
        /// Listen to client
        /// </summary>
        /// <param name="o">Socket client</param>
        private void ListenClient(object o)
        {
            Socket client = (Socket)o;
            object received;
            do
            {
                received = this.Receive(client);
            } while (!(received is User));         
            if (received is User)
            {
                User u = (User)received;
                if (userIsConnected(u)) 
                {
                    this.usersTable.Add(received, client);
                    this.BroadCast(received);
                    this.SendAllUsers(client);
                    Console.WriteLine("Cliente nuevo en linea!" + " " + u.nick);
                }
                else 
                {
                    this.usersTable.Add(received, client);
                    this.BroadCast(received);
                    this.SendAllUsers(client);
                    Console.WriteLine("Cliente nuevo en linea!" + " " + u.nick);
                }
            }
            while (true) 
            {
                received = this.Receive(client);
                if(received is Message) 
                {
                    if (((Message)received).isToAll) 
                    {
                        this.BroadCast(received);
                    }
                    else if(!((Message)received).isToAll)
                    {
                        this.SendMessage((Message)received);
                    }
                }
            }
        }
        /// <summary>
        /// Verify if the user is connected
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        private bool userIsConnected(User newUser)
        {
            bool isConnected = false;
            int y = 0;
            foreach(var u in usersTable.Keys) 
            {
                if(u == newUser) 
                {
                    usersTable.Remove(y);
                    isConnected = true;
                    break;
                }
                y++;
            }

            return isConnected;
        }
        /// <summary>
        /// Send a object to all users connected
        /// </summary>
        /// <param name="o">object to send</param>
        private void BroadCast(object o)
        {
            foreach(DictionaryEntry d in this.usersTable)
            {
                this.Send((Socket)d.Value, o);
            }
        }

        /// <summary>
        /// Send all connected users to the client
        /// </summary>
        /// <param name="s">Socket client</param>
        private void SendAllUsers(Socket s)
        {
            foreach (DictionaryEntry d in this.usersTable)
            {
                this.Send(s, d.Key);
            }
        }

        /// <summary>
        /// Send a message to the destinatary
        /// </summary>
        /// <param name="m">Message to send</param>
        private void SendMessage(Message m)
        {
            User tempUser;
            foreach (DictionaryEntry d in this.usersTable)
            {
                tempUser = (User)d.Key;
                if(tempUser.id == m.to.id) 
                {
                    this.Send((Socket)d.Value, m);
                    break;
                }
            }
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
    }
}
