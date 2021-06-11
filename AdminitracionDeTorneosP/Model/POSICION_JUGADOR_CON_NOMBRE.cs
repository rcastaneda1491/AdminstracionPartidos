namespace AdminitracionDeTorneosP.Model
{
    public class POSICION_JUGADOR_CON_NOMBRE
    {
        public int Id_Torneo { get; set; }
        public string NombreTorneo { get; set; }
        public int Id_Equipo { get; set; }
        public string NombreEquipo { get; set; }
        public long DPI_JUGADOR { get; set; }
        public string NombreJugador { get; set; }
        public string ApellidoJugador { get; set; }
        public string Posicion { get; set; }
        public int NumeroCamisola { get; set; }

    }
}
