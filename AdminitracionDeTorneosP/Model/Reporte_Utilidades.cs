using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminitracionDeTorneosP.Model
{
    public class Reporte_Utilidades
    {
        public string nombre { get; set; }
        public Double IngresosPorInscripcion { get; set; }
        public decimal IngresosPorTarjeta { get; set; }
        public decimal PagosArbitro { get; set; }
        public Double UnidadTotal { get; set; }
    }
}
