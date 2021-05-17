using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComunicacionesModel.DTO;

namespace ComunicacionesModel.DAL
{
    public interface ILecturasDAL
    {
        List<Lectura> ObtenerLecturasTrafico();
        void RegistrarLectura(Lectura lectura);
        List<Lectura> ObtenerLecturasConsumos();
    }
}
