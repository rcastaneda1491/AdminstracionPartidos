using System;

namespace AdminitracionDeTorneosP.Model
{
    public class Amonestacion
    {
        public int Id_Tarjeta { get; set; }
        public string Color_Tarjeta { get; set; }
        public decimal Valor_Multa { get; set; }
        public string Comentario { get; set; }
    }
}