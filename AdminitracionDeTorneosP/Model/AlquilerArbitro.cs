using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminitracionDeTorneosP.Model
{
    class AlquilerArbitro
    {
        public DateTime fechaApartado { get; set; }

        public TimeSpan horaInicio { get; set; }

        public TimeSpan horaFinal { get; set; }

        public int dpiArbitro { get; set; }

        public int IDAlquilerCancha { get; set; }

        public decimal totalArbitraje { get; set; }
    }
}
