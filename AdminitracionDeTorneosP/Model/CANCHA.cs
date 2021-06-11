using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminitracionDeTorneosP.Model
{
   public class CANCHA
    {
        public int NumeroCancha
        {
            get;
            set;
        }

        public string Nombre
        {

            get;
            set;
        }

        public string TipoCancha
        {
            get;
            set;
        }

        public string Disponibilidad
        {
            get;
            set;
        }

        public Decimal precio_hora
        {
            get;
            set;
        }
    }
}
