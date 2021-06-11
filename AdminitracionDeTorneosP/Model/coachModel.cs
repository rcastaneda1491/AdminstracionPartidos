using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminitracionDeTorneosP.Model
{
    public class coachModel
    {
        //clase modelo para la tabla entrenador en base de datos 
        public long DPI { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string phone { get; set; }
        public DateTime birthDate { get; set; }
        public string email { get; set; }
        public string time { get; set; }
        public decimal salary { get; set; }
    }
}
