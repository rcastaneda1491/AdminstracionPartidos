using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminitracionDeTorneosP.Model
{
    public class CAMBIO
    {
        public int Id_Cambio { get; set; }
        public int Id_Juego { get; set; }
        public long DPI_JugadorEntra { get; set; }
        public long DPI_JugadorSALE { get; set; }
        public int TiempoEntrada { get; set; }
        public int TiempoSalida { get; set; }
    }
}
