using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComunicacionesModel.DTO;
using Newtonsoft.Json;

namespace ComunicacionesModel.DAL
{
    public class LecturaDALArchivos : ILecturasDAL
    {
        private LecturaDALArchivos()
        {

        }

        private static ILecturasDAL instancia;
        
        public static ILecturasDAL GetInstancia()
        {
            if (instancia == null)
                instancia = new LecturaDALArchivos();
            return instancia;
        }

        private string consumo = Directory.GetCurrentDirectory()
           + Path.DirectorySeparatorChar + "consumo.txt";
        private string trafico = Directory.GetCurrentDirectory()
           + Path.DirectorySeparatorChar + "trafico.txt";

        public List<Lectura> ObtenerLecturasConsumo()
        {
            return ObtenerLectura(consumo);
        }

        public List<Lectura> ObtenerLecturasTrafico()
        {
            return ObtenerLectura(trafico);
        }

        public List<Lectura> ObtenerLectura(string path)
        {
            List<Lectura> lecturas = new List<Lectura>();
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string jsonString = null;
                    do
                    {
                        jsonString = reader.ReadLine();

                        if (jsonString != null)
                        {
                            Lectura l = JsonConvert.DeserializeObject<Lectura>(jsonString);
                            lecturas.Add(l);
                        }
                    } while (jsonString != null);
                }
            }
            catch (Exception e)
            {
                //lmao
            }
            return lecturas;
        }


        public void RegistrarLectura(Lectura lectura)
        {
            if (lectura.Tipo.Equals("trafico")){
                Save(lectura, trafico);
            }
            if (lectura.Tipo.Equals("consumo"))
            {
                Save(lectura, trafico);
            }
        }

        private void Save(Lectura l, String path)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(JsonConvert.SerializeObject(l,Formatting.None, new JsonSerializerSettings
                        {
                        NullValueHandling = NullValueHandling.Ignore
                        }));
                    writer.Flush();
                }
                
            }
            catch (IOException ex)
            {

            }
        }
    }
}
