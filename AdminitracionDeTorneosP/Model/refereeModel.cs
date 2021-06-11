using System;

namespace AdminitracionDeTorneosP.Model
{
    public class refereeModel
    {
        //Clase modelo tabla arbitro 
        public long DPI { get; set; }
        public string name { get; set; }

        public string lastname { get; set; }
        public string address { get; set; }

        public string phone { get; set; }
        public string nacionality { get; set; }
        public DateTime birthDate { get; set; }
        public string email { get; set; }
        public string role { get; set; }

        public Decimal precio_hora { get; set; }
    }
}
