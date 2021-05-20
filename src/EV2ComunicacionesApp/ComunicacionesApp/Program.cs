using ComunicacionesApp.Hilos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ComunicacionesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            //Console.WriteLine("Iniciando Hilo del Socket Servidor");
            HiloServer hiloServer = new HiloServer(puerto);
            //Console.WriteLine(puerto);
            Thread t = new Thread(new ThreadStart(hiloServer.Ejecutar));
            t.IsBackground = false;
            t.Start();
            
        }
    }
}
