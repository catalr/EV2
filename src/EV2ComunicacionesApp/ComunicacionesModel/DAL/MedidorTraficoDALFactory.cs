using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComunicacionesModel.DTO;

namespace ComunicacionesModel.DAL
{
    public class MedidorTraficoDALFactory
    {
        public static IMedidorDAL CreateDal()
        {
            return MedidorTraficoDALArchivos.GetInstancia();
        }
    }
}
