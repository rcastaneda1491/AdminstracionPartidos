using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminitracionDeTorneosP.Model
{
    public class Arbitro_Partido
    {
        public long DPI_Arbitro { get; set; }
        public int Id_Juego { get; set; }
        public decimal Pago { get; set; }
    }
}
