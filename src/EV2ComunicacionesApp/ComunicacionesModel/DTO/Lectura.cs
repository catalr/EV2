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
        private String tipo;
        private String unidadMedida;
        private int estado;

        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Valor { get => valor; set => valor = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string UnidadMedida { get => unidadMedida; set => unidadMedida = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}
