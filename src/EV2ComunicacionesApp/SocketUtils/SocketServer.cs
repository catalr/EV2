 using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketUtils
{
    public class SocketServer
    {
        private int puerto;
        private Socket servidor;

        public SocketServer(int puerto)
        {
            this.puerto = puerto;
        }

        public bool Iniciar()
        {
            try
            {
                this.servidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.servidor.Bind(new IPEndPoint(IPAddress.Any, this.puerto));
                this.servidor.Listen(10);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public SocketCliente ObtenerCliente()
        {
            try
            {
                return new SocketCliente(this.servidor.Accept());


            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
