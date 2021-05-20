using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SocketUtils;

namespace ComunicacionesApp.Hilos
{
    class HiloServer
    {
        private int puerto;
        private SocketServer server;
        public HiloServer(int puerto)
        {
            this.puerto = puerto;

        }

        public void Ejecutar()
        {
            server = new SocketServer(puerto);
            //Console.WriteLine("Iniciando server en puerto {0}", puerto);
            if (server.Iniciar())
            {
                //Console.WriteLine("Servidor iniciado");
                while (true)
                {
                    //Console.WriteLine("Esperando Clientes...");
                    SocketCliente clienteSocket = server.ObtenerCliente();
                    HiloCliente hiloCliente = new HiloCliente(clienteSocket);
                    Thread t = new Thread(new ThreadStart(hiloCliente.Ejecutar));
                    t.IsBackground = true;
                    t.Start();
                }
            }
            //else
                //Console.WriteLine("we got an oopsie");
            //Console.ReadKey();
        }
    }
}
