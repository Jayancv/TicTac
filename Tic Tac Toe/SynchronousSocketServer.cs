using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace Tic_Tac_Toe
{
    class SynchronousSocketServer
    {
        private static bool isWantToSendData;

        public static bool IsWantToSendData
        {
            get { return SynchronousSocketServer.isWantToSendData; }
            set { SynchronousSocketServer.isWantToSendData = value; }
        }
        public static Socket StartListening()
        {
            isWantToSendData = false;

            // Establish the local endpoint for the socket.
            // Dns.GetHostName returns the name of the 
            // host running the application.
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.
            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);


            Socket handler = null;
            // Bind the socket to the local endpoint and 
            // listen for incoming connections.
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.
                Console.WriteLine("Waiting for a connection...");
                // Program is suspended while waiting for an incoming connection.
                handler = listener.Accept();



            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return handler;

        }

        public static void getData(Socket socket)
        {
            string data = null;
            // Data buffer for incoming data.
            byte[] bytes = new Byte[1024];
            // An incoming connection needs to be processed.
            while (true)
            {
                bytes = new byte[1024];
                int bytesRec = socket.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                if ((data.IndexOf("<EOF>") > -1) || isWantToSendData)
                {
                    break;
                }
            }

            if (!isWantToSendData)
            {
                Console.WriteLine("Text received : {0}", data);
            }

        }

        public static void SendData(Socket so, string sendData)
        {
            Console.WriteLine("Sending data back to Client\n");
            byte[] data = Encoding.ASCII.GetBytes(sendData + "<EOF>");
            so.Send(data);
            isWantToSendData = false;

        }
    }
}
