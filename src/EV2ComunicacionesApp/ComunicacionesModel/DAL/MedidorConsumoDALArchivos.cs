using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComunicacionesModel.DTO;

namespace ComunicacionesModel.DAL
{
    public class MedidorConsumoDALArchivos : IMedidorDAL
    {
        private static List<Medidor> medidoresConsumo = new List<Medidor>();
        
        private MedidorConsumoDALArchivos()
        {
            medidoresConsumo.Add(new MedidorConsumo(1, DateTime.Now));
            medidoresConsumo.Add(new MedidorConsumo(2, DateTime.Now));
            medidoresConsumo.Add(new MedidorConsumo(3, DateTime.Now));
            medidoresConsumo.Add(new MedidorConsumo(4, DateTime.Now));

        }


        private static IMedidorDAL instancia;

        public static IMedidorDAL GetInstancia()
        {
            if (instancia == null)
                instancia = new MedidorConsumoDALArchivos();
            return instancia;
        }

        public bool Buscar(int tipo)
        {
            return medidoresConsumo.Exists(x => x.Id == tipo);
        }

        public List<Medidor> ObtenerMedidores()
        {

            return medidoresConsumo;
        }
    }
}
