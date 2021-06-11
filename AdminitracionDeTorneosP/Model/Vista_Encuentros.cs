using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminitracionDeTorneosP.Model
{
    public class Vista_Encuentros
    {

        public int Id_Torneo { get; set; }
        public string Nombre_torneo { get; set; }
        public string equipo_local { get; set; }
        public string equipo_visita { get; set; }

    }
}