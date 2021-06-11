using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminitracionDeTorneosP.Model
{
    public class reporteJuegosAfectadosPorCancha
    {
        //Clase modelo para reporte de partidos afectados por la tabla 
        public int idJuego { get; set; }
        public DateTime fechaJuego { get; set; }
        public TimeSpan horaInicio { get; set; }
        public TimeSpan horaFinal { get; set; }
        public string nombreCancha { get; set; }
    }
}
