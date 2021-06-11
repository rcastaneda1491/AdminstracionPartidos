using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminitracionDeTorneosP.Model
{
    public class Tabla_Visitante
    {
        public string nombres { get; set; }
        public int jugados { get; set; }
        public int ganados { get; set; }
        public int empatados { get; set; }
        public int perdidos { get; set; }
        public int goles_favor { get; set; }
        public int goles_contra { get; set; }
        public int diferencia_goles { get; set; }
        public int puntos { get; set; }
    }
}
