using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionesModel.DTO
{
    public abstract class Medidor
    {
        private int id;
        private DateTime fechaInstalacion;

        public int Id { get => id; set => id = value; }
        public DateTime FechaInstalacion { get => fechaInstalacion; set => fechaInstalacion = value; }

        public abstract Boolean enviarLectura(Lectura Lectura);
    }
}
