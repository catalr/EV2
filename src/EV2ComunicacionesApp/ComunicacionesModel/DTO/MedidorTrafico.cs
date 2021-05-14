using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionesModel.DTO
{
    class MedidorTrafico : Medidor
    {
        public override bool enviarLectura(Lectura Lectura)
        {
            throw new NotImplementedException();
        }

        public int leerEstado()
        {
            return 0;
        }

        public Double obtenerKwhConsumidos()
        {
            return 0.0;
        }

    }
}
