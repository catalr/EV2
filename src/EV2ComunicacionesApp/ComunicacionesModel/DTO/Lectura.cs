using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionesModel.DTO
{
    public class Lectura
    {
        private DateTime fecha;
        private String valor;
        private int tipo;
        private String unidadMedida;

        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Valor { get => valor; set => valor = value; }
        public int Tipo { get => tipo; set => tipo = value; }
        public string UnidadMedida { get => unidadMedida; set => unidadMedida = value; }
    }
}
