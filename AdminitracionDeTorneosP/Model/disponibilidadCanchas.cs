using System;

namespace AdminitracionDeTorneosP.Model
{
    public class disponibilidadCanchas
    {
        public int numeroCancha { get; set; }
        public string nombre { get; set; }
        public string disponibilidad { get; set; }

        public int id_Juego { get; set; }
        public TimeSpan horaInicio { get; set; }
        public TimeSpan horaFinal { get; set; }

    }
}
