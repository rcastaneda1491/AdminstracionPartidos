using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminitracionDeTorneosP.Model
{
   public class GOLEADOR
    {
        public string Equipo 
        {
            get; 
            set;
        
        }
        public long DPI_Jugador 
        {
            get;
            set;

        }

        public string Nombres
        {
            get;
            set;

        }

        public string Apellidos
        {
            get;
            set;

        }
        public int NumeroCamisola
        {
            get;
            set;

        }
        public int cantidad_de_goles_anotados
        {
            get;
            set;

        }

    }

}
