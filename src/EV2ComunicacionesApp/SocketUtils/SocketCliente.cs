using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketUtils
{
    class SocketCliente
    {
        private Socket comCliente;
        private StreamReader reader;
        private StreamWriter writer;

        public SocketCliente(Socket comCliente)
        {
            this.comCliente = comCliente;
            Stream stream = new NetworkStream(this.comCliente);
            this.writer = new StreamWriter(stream);
            this.reader = new StreamReader(stream);
        }

        public bool Escribir(Stream mensaje)
        {
            try
            {
                this.writer.WriteLine(mensaje);
                this.writer.Flush();
                return true;
            }catch(IOException e)
            {
                return false;
            }
        }

        public string Leer()
        {
            try
            {
                return this.reader.ReadLine().Trim();
            }
            catch (IOException e)
            {
                return null;
            }
        }

        public void CerrarConexion()
        {
            this.comCliente.Close();
        }
    }
}
