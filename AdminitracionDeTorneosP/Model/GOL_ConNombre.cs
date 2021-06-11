namespace AdminitracionDeTorneosP.Model
{
    public class GOL_ConNombre
    {
        public int IdGol { get; set; }
        public int Id_Juego { get; set; }
        public long DPI_Jugador { get; set; }
        public string NombreJugador { get; set; }
        public string Tipo { get; set; }
        public string Tiempo { get; set; }
    }
}