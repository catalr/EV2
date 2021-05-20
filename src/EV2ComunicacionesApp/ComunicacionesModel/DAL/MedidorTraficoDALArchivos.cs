using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComunicacionesModel.DTO;

namespace ComunicacionesModel.DAL
{
    public class MedidorTraficoDALArchivos : IMedidorDAL
    {
        private static List<Medidor> medidoresTrafico = new List<Medidor>();

        private MedidorTraficoDALArchivos()
        {
            medidoresTrafico.Add(new MedidorTrafico(5, DateTime.Now));
            medidoresTrafico.Add(new MedidorTrafico(6, DateTime.Now));
            medidoresTrafico.Add(new MedidorTrafico(7, DateTime.Now));
            medidoresTrafico.Add(new MedidorTrafico(8, DateTime.Now));

        }


        private static IMedidorDAL instancia;

        public static IMedidorDAL GetInstancia()
        {
            if (instancia == null)
                instancia = new MedidorTraficoDALArchivos();
            return instancia;
        }

        public bool Buscar(int tipo)
        {
            return medidoresTrafico.Exists(x => x.Id == tipo);
        }
        

       
        public List<Medidor> ObtenerMedidores()
        {

            return medidoresTrafico;
        }
    }
}
