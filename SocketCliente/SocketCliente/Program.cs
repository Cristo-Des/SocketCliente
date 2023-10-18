using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SocketCliente
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CONFIgurar SERVER
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11200);
            try
            {
                //Creacion de socket
                Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                //conectar y enviar texto
                sender.Connect(remoteEP);
                Console.WriteLine("Conectado Con El Servidor");

                Console.WriteLine("Ingrese Un Texto Para Enviar");
                string texto = Console.ReadLine();
                //convercion a byetes
                byte[] msg = Encoding.ASCII.GetBytes(texto + "<EOF>");
                //enviar texto
                int byteSent = sender.Send(msg);
                sender.Shutdown(SocketShutdown.Both);
               sender.Close();

            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
        }
    }
}
