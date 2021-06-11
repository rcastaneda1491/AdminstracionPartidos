using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminitracionDeTorneosP.Model
{
    public class Horario
    {
        public string dia { get; set; }

        public TimeSpan horaApertura { get; set; }

        public TimeSpan horaCierre { get; set; }
    }
}
