using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionesModel.DAL
{
    class LecturaDALFactory
    {
        public static ILecturasDAL CreateDAL()
        {
            return LecturaDALArchivos.GetInstancia();
        }
    }
}
