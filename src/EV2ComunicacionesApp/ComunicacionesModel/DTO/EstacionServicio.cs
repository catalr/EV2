using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionesModel.DTO
{
    class EstacionServicio
    {
        private int capacidadMaxima;
        private Direccion direction;

        public int CapacidadMaxima { get => capacidadMaxima; set => capacidadMaxima = value; }
        internal Direccion Direction { get => direction; set => direction = value; }
    }
}
