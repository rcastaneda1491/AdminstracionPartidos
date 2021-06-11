using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminitracionDeTorneosP.Model
{
    public class POSICION_JUGADOR
    {
        public int Id_Torneo { get; set; }
        public int Id_Equipo { get; set; }
        public long DPI_JUGADOR { get; set; }
        public string Posicion { get; set; }
        public int NumeroCamisola { get; set; }

    }
}