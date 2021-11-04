using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPClientBroadcast
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            UdpClient socket = new UdpClient();
            SendMessage(socket, message);
        }

        public static void SendMessage(UdpClient socket, string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            socket.Send(data, data.Length, "255.255.255.255", 65000);

            while (true)
            {
                IPEndPoint from = null;
                byte[] received = socket.Receive(ref from);
                string receivedString = Encoding.UTF8.GetString(received);
                Console.WriteLine(receivedString + " - " + from.Address);
            }
        }
    }
}
