using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComunicacionesModel.DTO;

namespace ComunicacionesModel.DAL
{
    public class MedidorDALArchivos : IMedidorDAL
    {
        private MedidorDALArchivos()
        {

        }

        
        List<Medidor> IMedidorDAL.ObtenerMedidores()
        {
            throw new NotImplementedException();
        }
    }
}
