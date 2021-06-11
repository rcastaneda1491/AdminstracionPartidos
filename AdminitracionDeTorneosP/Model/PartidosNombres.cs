using System;

namespace AdminitracionDeTorneosP.Model
{
	public class PartidosNombres
	{
		public int Id_Juego { get; set; }
		public string EquipoLocal { get; set; }
		public string EquipoVisita { get; set; }
		public DateTime Fecha { get; set; }
		public TimeSpan HoraInicio { get; set; }
		public TimeSpan HoraFinal { get; set; }
	}
}