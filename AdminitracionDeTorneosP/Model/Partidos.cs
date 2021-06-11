using System;

namespace AdminitracionDeTorneosP.Model
{
	public class Partidos
	{
		public int Id_Juego { get; set; }
		public int Id_Torneo { get; set; }
		public int Id_EquipoLocal { get; set; }
		public int Id_EquipoVisita { get; set; }
		public DateTime Fecha { get; set; }
		public TimeSpan HoraInicio { get; set; }
		public TimeSpan HoraFinal { get; set; }
	}
}