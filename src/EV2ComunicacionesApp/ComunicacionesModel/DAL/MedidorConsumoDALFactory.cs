using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComunicacionesModel.DTO;

namespace ComunicacionesModel.DAL
{
    public class MedidorConsumoDALFactory
    {
        public static IMedidorDAL CreateDal()
        {
            return MedidorConsumoDALArchivos.GetInstancia();
        }
    }
}
