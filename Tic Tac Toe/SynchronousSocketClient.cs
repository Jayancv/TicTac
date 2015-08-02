using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace Tic_Tac_Toe
{
    class SynchronousSocketClient
    {
        private static bool isWantToSendData;

        public static bool IsWantToSendData
        {
            get { return SynchronousSocketClient.isWantToSendData; }
            set { SynchronousSocketClient.isWantToSendData = value; }
        }
        public static Socket StartClient()
        {
            // Data buffer for incoming data.
            byte[] bytes = new byte[1024];
            Socket sender = null;
            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                // This example uses port 11000 on the local computer.
                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP  socket.
                sender = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    sender.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}",
                        sender.RemoteEndPoint.ToString());


                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return sender;
        }

        public static void sendData(Socket s, string message)
        {
            // Encode the data string into a byte array.
            byte[] msg = Encoding.ASCII.GetBytes(message + "<EOF>");

            // Send the data through the socket.
            int bytesSent = s.Send(msg);
            isWantToSendData = false;
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
    }
}
