using SocketUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorMedidor
{
    class Program
    {
        static void Main()
        {

            /*uses socket utils*/
            String tipo = "";
            do
            {
                Console.WriteLine("1. Medidor de Trafico");
                Console.WriteLine("2. Medidor de Consumo");
                string opcion = Console.ReadLine().Trim();
                switch (opcion)
                {
                    case "1":
                        tipo = "trafico";
                        break;
                    case "2":
                        tipo = "consumo";
                        break;
                    default:
                        break;
                }
            } while (tipo.Equals(""));
            //por que esta la conexion aqui?? ==> (ofrecer la selección de tipo de medidor al inicio de la aplicación), conectándose al servicio de comunicaciones ...
            string ip = ConfigurationManager.AppSettings["ip"];
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            SocketCliente socketCliente = new SocketCliente(ip, puerto);
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("Conectandose al servidor {0} en el puerto {1}", ip, puerto);
            if (socketCliente.Conectar())
            {
                string nro;
                do
                {
                    Console.WriteLine("Ingrese numero del medidor");
                    nro = Console.ReadLine().Trim();
                } while (!int.TryParse(nro, out int id));
                String fechaMensaje1 = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                string msg = "Fecha : " + fechaMensaje1 + "\n Presione cualquier tecla para confirmar y enviar mensaje";
                Console.WriteLine(msg);
                Console.ReadKey();

                string msgInicial = fechaMensaje1 + "|" + nro + "|" + tipo;
                socketCliente.Escribir(msgInicial);
                string respuestaSer = "";
                do
                {
                    respuestaSer = socketCliente.Leer();
                } while (respuestaSer == string.Empty);

                if (!respuestaSer.Contains("|WAIT"))
                {
                    if (!respuestaSer.Contains("|ERROR"))
                    {//could happen but then i should verify if the server answer is valid u.u 
                        Console.WriteLine("Respuesta invalida de servidor"); 
                        Console.WriteLine("Presione cualquier tecla para salir");
                    }
                    else
                        Console.WriteLine(respuestaSer);
                    Console.ReadKey();
                    System.Environment.Exit(-1);
                }
                Console.WriteLine(respuestaSer); // does the CLI show the info??
                string vlr, std, fecha;
                std = "";
                do
                {
                    Console.WriteLine("Ingrese valor de la lectura");
                    vlr = Console.ReadLine().Trim();
                } while (!double.TryParse(vlr, out double valor));
                do
                {
                    Console.WriteLine("Ingrese fecha de medicion yyyy-MM-dd-HH-mm-ss");
                    fecha = Console.ReadLine().Trim();
                } while (fecha.Equals(""));
                do
                {
                    Console.WriteLine("[Opcional] Ingrese estado de la lectura");
                    Console.WriteLine("-1 : Error de Lectura");
                    Console.WriteLine("0 : OK");
                    Console.WriteLine("1 : Punto de carga lleno");
                    Console.WriteLine("2: Requiere mantencion preventiva");
                    std = Console.ReadLine().Trim();
                } while (std != "" && !int.TryParse(std, out int estado));

                string msgLectura = nro + "|" + fecha + "|" + tipo + "|" + vlr + "|" + std + "|" + "UPDATE";
                socketCliente.Escribir(msgLectura);
                string respuestaSer2 = "";
                do
                {
                    respuestaSer2 = socketCliente.Leer();
                } while (!respuestaSer2.Contains("|"));
                Console.WriteLine(respuestaSer2);//here it doesn't matter the answer
                Console.ReadKey();
            }
            else
            {
                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine("Error de conexion");
            }



        }
    }
}
