using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminitracionDeTorneosP.Model
{
    class AlquilerCancha
    {
		public int id { get; set; }

		public int numeroCancha { get; set; }

		public int idCliente { get; set; }

		public DateTime fechaApartada { get; set; }

		public TimeSpan horaInicio { get; set; }

		public TimeSpan horaFinal { get; set; }

		public Decimal totalAlquilerCancha { get; set; }
	}
}
