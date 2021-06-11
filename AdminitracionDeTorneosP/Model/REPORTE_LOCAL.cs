using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminitracionDeTorneosP.Model
{
     public class REPORTE_LOCAL
    {



        public string nombres { get; set; }
        public int partidos_jugados { get; set; }
        public int partidos_ganados { get; set; }
        public int partidos_empatados { get; set; }
        public int partidos_perdidos { get; set; }
        public int goles_favor { get; set; }

        public int goles_conttra { get; set; }
        public int diferencia_goles { get; set; }
        public int total_puntos { get; set; }





    }
}
