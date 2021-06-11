using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminitracionDeTorneosP.Model
{
    public class reportePlanillaArbitro
    {
        //clase modelo para reporte de pago de arbitros
        public string arbitroNombre { get; set; }
        public string arbitroApellido { get; set; }
        public string arbitroNacionalidad { get; set; }
        public string arbitroTelefono { get; set; }
        public decimal pagoRecibido { get; set; }
        public string torneoNombre { get; set; }
    }
}
