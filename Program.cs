using System;
using System.Net;
using System.Net.Sockets;

class FirewallExample
{
    static void Main()
    {
        string ipAddress = "127.0.0.1"; // Tarmoq manzili
        int port = 80; // Port

        try
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Parse(ipAddress), port);
            tcpListener.Start();
            Console.WriteLine("Firewall is running and monitoring the network...");
            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                Console.WriteLine($"Connection attempt detected from {client.Client.RemoteEndPoint}");
                client.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
