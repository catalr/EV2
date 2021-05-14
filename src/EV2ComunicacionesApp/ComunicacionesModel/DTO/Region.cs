using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionesModel.DTO
{
    class Region
    {
        private int codigo;
        private String nombre;
        private ZonaHoraria zonaHoraria;

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        internal ZonaHoraria ZonaHoraria { get => zonaHoraria; set => zonaHoraria = value; }
    }
}
