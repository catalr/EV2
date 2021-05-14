using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionesModel.DTO
{
    class PuntoCarga
    {
        private MedidorConsumo medCons;
        private MedidorTrafico medTraf;
        private int id;
        private int tipo;
        private int capacidadMaxima;
        private DateTime fechaVencimiento;
        private EstacionServicio estacionServicio;

        public int Id { get => id; set => id = value; }
        public int Tipo { get => tipo; set => tipo = value; }
        public int CapacidadMaxima { get => capacidadMaxima; set => capacidadMaxima = value; }
        public DateTime FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }
        internal MedidorConsumo MedCons { get => medCons; set => medCons = value; }
        internal MedidorTrafico MedTraf { get => medTraf; set => medTraf = value; }
        internal EstacionServicio EstacionServicio { get => estacionServicio; set => estacionServicio = value; }
    }
}
