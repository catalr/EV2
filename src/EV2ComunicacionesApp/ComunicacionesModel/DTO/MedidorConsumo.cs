using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionesModel.DTO
{
    class MedidorConsumo : Medidor
    {

        public MedidorConsumo(int v, DateTime now) : base(v,now)
        {

        }

        public override bool enviarLectura(Lectura Lectura)
        {
            throw new NotImplementedException();
        }

        public int obtenerCantVehiculos()
        {
            return 0;
        }
    }
}
