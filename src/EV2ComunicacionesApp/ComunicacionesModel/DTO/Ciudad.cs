using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionesModel.DTO
{
    class Ciudad
    {
        private int codigo;
        private String nombre;
        private Region region;

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        internal Region Region { get => region; set => region = value; }
    }
}
