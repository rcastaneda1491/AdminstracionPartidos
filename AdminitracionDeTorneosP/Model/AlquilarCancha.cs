using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminitracionDeTorneosP.Model
{
    class AlquilarCancha
    {
        public int NumeroCancha { get; set; }
        public int IDCliente { get; set; }
        public DateTime FechaApartada { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFinal { get; set; }
        public decimal TotalPrecio { get; set; }
    }
}
