namespace AdminitracionDeTorneosP.Model
{
    public class Punteo
    {
        public int Id_Punteo { get; set; }
        public int Id_Juego { get; set; }
        public int Id_EquipoLocal { get; set; }
        public int Id_EquipoVisita { get; set; }
        public int PunteoEquipoLocal { get; set; }
        public int PunteoEquipoVisita { get; set; }

    }
}