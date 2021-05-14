using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionesModel.DTO
{
    class ZonaHoraria
    {
        private String codigo;
        private String nombreLargo;
        private TarifaElectrica tarifa;

        public string Codigo { get => codigo; set => codigo = value; }
        public string NombreLargo { get => nombreLargo; set => nombreLargo = value; }
        internal TarifaElectrica Tarifa { get => tarifa; set => tarifa = value; }
    }
}
