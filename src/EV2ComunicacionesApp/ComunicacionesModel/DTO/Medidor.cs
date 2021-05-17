using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionesModel.DTO
{
    public abstract class Medidor
    {
        protected int id;
        protected DateTime fechaInstalacion;

        public Medidor(int v, DateTime now)
        {
            this.id = v;
            this.fechaInstalacion = now;
        }

        public int Id { get => id; set => id = value; }
        public DateTime FechaInstalacion { get => fechaInstalacion; set => fechaInstalacion = value; }

        public abstract Boolean enviarLectura(Lectura Lectura);
    }
}
