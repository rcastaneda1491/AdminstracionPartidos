using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminitracionDeTorneosP.Model
{
    public class reporteUsoCanchasModel
    {
        //clase modelo para reporte de tiempo de uso de cancha
        public string nombreCancha { get; set; }

        public string nombreTorneo { get; set; }
        public int minutos { get; set; }
    }
}
