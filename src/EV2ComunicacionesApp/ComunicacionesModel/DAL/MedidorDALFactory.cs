using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComunicacionesModel.DTO;

namespace ComunicacionesModel.DAL
{
    public class MedidorDALFactory
    {
        public static IMedidorDAL CreateDal()
        {
            return MensajesDALArchivos.GetInstancia();
        }
    }
}
