using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Servidor;

namespace LayerData.Servidor
{
    class Template
    {
        private static byte[] _buffer = new byte[1024];

        private static List<Socket> _clientSocket = new List<Socket>();

        private static Socket _serverSocket = new Socket
            (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private static IPEndPoint connect = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);

        private static void SetupServer()
        {
            _serverSocket.Bind(connect);
            _serverSocket.Listen(100);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallBack), null);
            Console.WriteLine("Servidor en linea!");
        }

        private static void AcceptCallBack(IAsyncResult AR)
        {
            Socket socket = _serverSocket.EndAccept(AR);
            _clientSocket.Add(socket);
            Program p = new Program();
            Console.WriteLine("Client Connected..");
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallBack), null);
            //Thread UserThread = new Thread(new ThreadStart(() => p.User(socket)));
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), null);
            //UserThread.Start();
        }
        public void User(Socket client)
        {
            while (true)
            {
                byte[] msg = new byte[1024];
                int size = client.Receive(msg);
                Debug.WriteLine(msg);
                client.Send(msg, 0, size, SocketFlags.None);
            }
        }

        private static void ReceiveCallBack(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            int received = socket.EndReceive(AR);
            byte[] dataBuf = new byte[received];
            Array.Copy(_buffer, dataBuf, received);

            string text = Encoding.ASCII.GetString(dataBuf);

            Console.WriteLine("Recibido: " + text);

            string response = String.Empty;

            response = "Recibido!";

            Byte[] data = Encoding.ASCII.GetBytes(response);
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallBack), null);
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), null);
        }
        private static void SendCallBack(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }
    } 
}
