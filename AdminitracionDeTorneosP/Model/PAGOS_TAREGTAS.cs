using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminitracionDeTorneosP.Model
{
    public class PAGOS_TAREGTAS
    {

        public int Id_Juego { get; set; }
        public long DPI_Jugador { get; set; }
        public int Id_Tarjeta { get; set; }
        public string Tiempo { get; set; }
        public string Pagada { get; set; }
        public string Fecha_Pago { get; set; }


    }
}
