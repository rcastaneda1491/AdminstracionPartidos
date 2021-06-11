using System;


namespace AdminitracionDeTorneosP.Model
{
    public class Torneos
    {
        public int Id_Torneo { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaIncio { get; set; }
        public DateTime FechaFinaliza { get; set; }
        public string Tipo { get; set; }
        public int NumeroMaximoJugadores { get; set; }
        public int EdadMinima { get; set; }
        public int EdadMaxima { get; set; }
        public int PuntosVictoria { get; set; }
        public int PuntosEmpate { get; set; }
        public int PuntosDerrota { get; set; }
        public string tipoFutbolTorneo { get; set; }
        public double costo { get; set; }
        public bool Proceso { get; set; }

    }
}