using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComunicacionesModel.DAL;
using ComunicacionesModel.DTO;
using SocketUtils;

namespace ComunicacionesApp.Hilos
{
    class HiloCliente
    {
        private SocketCliente socketCliente;
        private ILecturasDAL daLec = LecturaDALFactory.CreateDAL();
        private IMedidorDAL daMeCo = MedidorConsumoDALFactory.CreateDal();
        private IMedidorDAL daMeTr = MedidorTraficoDALFactory.CreateDal();

        private string tipo;
        private string nroMedidor = "";
        CultureInfo cultureInfo = new CultureInfo(ConfigurationManager.AppSettings["cultureInfo"]);

        public HiloCliente(SocketCliente socket)
        {
            this.socketCliente = socket;
        }


        public void Ejecutar()
        {
            //Console.Write("Cliente Conectado");
            //I recibir mensaje en estructura fecha|nro_medidor|tipo
            string mensajeInicial = GetMensaje();         
            if (buscarMedidor(mensajeInicial))
            {
                // II mandar mensaje fechaServidor|WAIT 
                // III esperar mensaje nroSerie|fecha|tipo|valor|{estado}|UPDATE
                string respuesta1 = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "|WAIT";
                socketCliente.Escribir(respuesta1);
                string mensajeLectura = GetMensaje();
                //Console.WriteLine("mensaje gotten");
                if (ingresarLectura(mensajeLectura))
                {
                    // 7.- OK ==>  nroSerie|OKy  cerrar la conexión remota
                    string respuesta2 = nroMedidor + "|OK";
                    socketCliente.Escribir(respuesta2);
                    socketCliente.CerrarConexion();
                }
                else {
                    
                    SendErrorMessage();
                    //Console.WriteLine("reached wrong mensajelectura");

                }
                    
            }
            else
                SendErrorMessage();
            
            //socketCliente.CerrarConexion();
            //string text = string.Join("\n", (daLec.ObtenerLecturasTrafico()));
            //Console.WriteLine(text);
            //string text2 = string.Join("\n", (daLec.ObtenerLecturasConsumo()));
            //Console.WriteLine(text2); verificacion del funcionamiento de ObtenerLecturasTrafico

        }


        private string GetMensaje()
        {
            string mensaje = "";
            do
            {
                mensaje = socketCliente.Leer().Trim();
            } while (mensaje == string.Empty);
            return mensaje;
        }


        private void SendErrorMessage()
        {
            // 6 .- failed verification ==> fecha|nroSerie|ERROR
            // no esta explicitado en ninguno de los documentos pero en esta version del programa cualquier error en los mensajes
            // tendrá como consecuencia el mensaje fecha|nroSerie|ERROR y se cerrara la conexion 
            // en caso de que el mensaje no tenga nroSerie se enviara fecha|-|ERROR y cerrara la conexion
            // como se recibe una lectura por conexion las variables de la lectura seran campos estaticos del Hilo 
            string error = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "|" + nroMedidor + "|ERROR";
            socketCliente.Escribir(error);
            socketCliente.CerrarConexion();
        }


        /**
         * ingresarLectura: string -> bool
         * ingresa una lectura al archivo de lecturas
         * con parametros sacados de una cadena de texto mensaje
         * si realiza correctamente su funcion responde con valor de verdad
         * si el mensaje no tiene todos los parametros requeridos
         * o si existen errores en el mensaje o los parametros
         * responde con falso
         * ejemplo:
         * ingresarLectura("2|2021-05-05-05-05|trafico|25|2|UPDATE") 
         * si se ingresa la Lectura con las propiedades anteriores al erchivo trafico.txt
         * la funcion reaponde true
         */
        private bool ingresarLectura(string mensaje)
        {
            // 0.- verificar formato del mensaje
            string[] datos = mensaje.Split('|');
            //Console.WriteLine(datos.Length);
            if (datos.Length != 6)  //no estado ==> nroSerie|fecha|tipo|valor||UPDATE
                return false;

            if (datos[5] != "UPDATE")
                return false;
            // 1.- verificar que tipo sea trafico o consumo done before :/
            // 2.- verificar que MedidoresTipo.GetAll.Contains(nro_medidor :/ also done)
            //deberia verificarse que tipo y nro sean los mismos que se dieron en el mensaje anterios
            // 3.- fecha en formato correcto??

            if (!DateTime.TryParseExact(datos[1], "yyyy-MM-dd-HH-mm-ss", cultureInfo,
                                 DateTimeStyles.None, out DateTime fecha))
                return false;
            // 4.- verificar valor entre 0 y 1000
            String unidadMedida;
            //verificando que es un numero
            if (!double.TryParse(datos[3], out double valor))
                return false;
            //verificando que trafico no es float
            if (tipo == "trafico") {
                if (!int.TryParse(datos[3], out int value))
                    return false;
                unidadMedida = "int";
            }
            else
                unidadMedida = "double";
            if (valor > 1000 || valor < 0)
                return false;
           
            Lectura l = new Lectura()
            {
                Fecha = fecha,
                Valor = datos[3],
                Tipo = tipo,
                UnidadMedida = unidadMedida             
            };
            if (datos[4] != "" && int.TryParse(datos[4], out int estado))
            {
                // 5.- verificar estado entre -1 (error) y 2
                if (estado >= -1 && estado <= 2)
                {
                    l.Estado = estado;
                }
                   

                return false;                
            }
            lock (daLec)
            {
                daLec.RegistrarLectura(l);
            }
            //Console.WriteLine("Lectura Recibida y Registrada");
            return true;
        }


        private bool buscarMedidor(string mensajeInicial)
        {
            // 1.-verificar que la estructura general del mensaje sea correcta fecha|nro_medidor|tipo
            string[] datos = mensajeInicial.Split('|');
            if (datos.Length != 3)
                return false;
            // 2.-verificar que la fecha corresponda al formato yyyy-MM-dd-HH-mm-ss
            if (!DateTime.TryParseExact(datos[0], "yyyy-MM-dd-HH-mm-ss", cultureInfo,
                                 DateTimeStyles.None, out DateTime fecha))
                return false;
            // 5.- verificar que mensaje no sea mas viejo que 30 minutos
            TimeSpan interval = DateTime.Now - fecha;
            if (interval.Minutes > 30)
                return false;
            // 3.-verificar que tipo corresponda a trafico o consumo
            datos[2] = datos[2].ToLower();
            if (!int.TryParse(datos[1], out int idMedidor))
                return false;
            // 4.-verificar que MedidoresTipo.GetAll.Contains(nro_medidor) use hash??
            if (datos[2].Equals("consumo")){ 
                lock (daMeCo)
                {
                    //List<Medidor> medidores = daMeCo.ObtenerMedidores()
                    if (!daMeCo.Buscar(idMedidor))
                    {
                        return false;
                    }
                        
                }
            }
            if (datos[2].Equals("trafico")){
                lock (daMeTr)
                {
                    //List<Medidor> medidores = daMeTr.ObtenerMedidores()
                    if (!daMeTr.Buscar(idMedidor))
                    {
                        return false;
                    }
                }
            }
            //if (medidores.Exists(x => x.Id == tipo))
            //return true
            this.tipo = datos[2];
            this.nroMedidor = datos[1];
            //Console.Write("Mensaje de saludo recibido y verificado");
            return true;
        }
    }
}
