using AdminitracionDeTorneosP.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminitracionDeTorneosP.Database
{
    public class Reporte_UtilidadesDB
    {
        //Conexion a Base de Datos
        private string connectionString = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";

        public List<Reporte_Utilidades> GetReporte_Utilidades(DateTime FechaInicio, DateTime FechaFinal)
        {
            List<Reporte_Utilidades> reporte_Utilidad = new List<Reporte_Utilidades>();
            string query = "EXEC proc_erickecheverria_Utilidades @FechaInicio, @FechaFinal";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@FechaInicio", FechaInicio.Date);
                sql.Parameters.AddWithValue("@FechaFinal", FechaFinal.Date);
                try
                {
                    connection.Open();
                    //Ejecuta el query
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        Reporte_Utilidades reporte_Utilidades = new Reporte_Utilidades();
                        //Obtiene los datos de la tabla y se guardan en un lista
                        reporte_Utilidades.nombre = reader.GetString(0);
                        reporte_Utilidades.IngresosPorInscripcion = reader.GetDouble(1);
                        reporte_Utilidades.IngresosPorTarjeta = reader.GetDecimal(2);
                        reporte_Utilidades.PagosArbitro = reader.GetDecimal(3);
                        reporte_Utilidades.UnidadTotal = reader.GetDouble(4);
                        reporte_Utilidad.Add(reporte_Utilidades);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al obtener los datos" + error, "ERROR");
                }
            }
            return reporte_Utilidad;
        }
    }
}
