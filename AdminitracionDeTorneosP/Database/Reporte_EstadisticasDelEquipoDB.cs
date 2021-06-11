using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using AdminitracionDeTorneosP.Model;
using AdminitracionDeTorneosP.View;

namespace AdminitracionDeTorneosP.Database
{
    public class Reporte_EstadisticasDelEquipoDB
    {
        private string connectionString = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;"; // Conectando a la base de datos SQL

        public DataTable CargarComboTorneo()
        {
            SqlDataAdapter da = new SqlDataAdapter("proc_erick_cargar_idYnombresDeTorneo", connectionString); // Traera el id y el nombre de cada equipo para el comboBox
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public EstadisticaDelEquipo Estadistica_Equipo(string NombreEquipo, int Id_Torneo)
        {
            EstadisticaDelEquipo estadistica = new EstadisticaDelEquipo();
            string query = "exec proc_erickecheverria_estadisticasDelEquipo @NombreEquipo,@Id_Torneo";
            using (SqlConnection connec = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connec);
                sql.Parameters.AddWithValue("@NombreEquipo", NombreEquipo);
                sql.Parameters.AddWithValue("@Id_Torneo", Id_Torneo);//pasandole a la variable el parametro
                try
                {
                    connec.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read(); //leer solo un registro (read)
                    estadistica.POS = reader.GetInt64(0);
                    estadistica.Nombre = reader.GetString(1);
                    estadistica.J = reader.GetInt32(2);
                    estadistica.G = reader.GetInt32(3);
                    estadistica.E = reader.GetInt32(4);
                    estadistica.P = reader.GetInt32(5);
                    estadistica.Puntos = reader.GetInt32(6);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener las estadisticas del equipo en la base de datos " + ex.Message);
                }
                return estadistica;
            }
        }

    }
}
