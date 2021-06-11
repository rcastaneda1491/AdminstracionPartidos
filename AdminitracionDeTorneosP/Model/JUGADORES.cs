using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminitracionDeTorneosP.Model
{
    public class JUGADORES
    {

        public long DPI_Jugador { get; set; }

        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime Fecha_nac { get; set; }
        public string Direccion { get; set; }
        public string Nacionalidad { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

    }
}
