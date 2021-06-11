using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AdminitracionDeTorneosP.Model;
using System.Collections.Generic;

namespace AdminitracionDeTorneosP.Database
{
    public class PartidoDB
    {
        //Conexion a Base de Datos
        private string connectionString = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";
        //Procedimiento Para Obtener Todos los Partidos en la base de Datos
        public List<Partidos> GetPartidos()
        {
            List<Partidos> partidos = new List<Partidos>();
            string query = "SELECT * FROM partido";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    //Ejecuta el query
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        Partidos partido = new Partidos();
                        //Obtiene los datos de la tabla y se guardan en un lista
                        partido.Id_Juego = reader.GetInt32(0);
                        partido.Id_Torneo = reader.GetInt32(1);
                        partido.Id_EquipoLocal = reader.GetInt32(2);
                        partido.Id_EquipoVisita = reader.GetInt32(3);
                        partido.Fecha = reader.GetDateTime(4);
                        partido.HoraInicio = reader.GetTimeSpan(5);
                        partido.HoraFinal = reader.GetTimeSpan(6);
                        partidos.Add(partido);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al obtener los datos" + error, "ERROR");
                }
            }
            return partidos;
        }

        public void Get_Torneos(ComboBox cbx)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cbx.Items.Clear();
                connection.Open();
                //Query de consulta para obtener equipos
                SqlCommand sql = new SqlCommand("SELECT * FROM torneo", connection);
                //Lectura de datos y agregar al combo box los datos
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    //Agregar registros al combo box
                    cbx.Items.Add($"{dr[0]}- {dr[1]}");
                }
                connection.Close();
            }
        }

        //Seleccionar Equipo

        public List<EQUIPO_TORNEO> encuentros(int? id_equipo)
        {

            List<EQUIPO_TORNEO> equipos = new List<EQUIPO_TORNEO>();
            string query = "exec J_J_S_getEquipos @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id_equipo);
                try
                {
                    connection.Open();
                    //Ejecuta el query
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        EQUIPO_TORNEO equipo_tor = new EQUIPO_TORNEO();
                        //Obtiene los datos de la tabla y se guardan en un lista
                        equipo_tor.Id_Torneo = reader.GetInt32(0);
                        equipo_tor.Id_Equipo = reader.GetInt32(1);
                        equipos.Add(equipo_tor);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al obtener los datos" + error, "ERROR");
                }
            }
            return equipos;
        }

        public void GuardarJornadas(Partidos listaPartidos)
        {
            string query = "EXEC JCGO_JORNADAS @Id_Torneo, @Id_EquipoLocal, @Id_EquipoVisita";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@Id_Torneo", listaPartidos.Id_Torneo);
                sql.Parameters.AddWithValue("@Id_EquipoLocal", listaPartidos.Id_EquipoLocal);
                sql.Parameters.AddWithValue("@Id_EquipoVisita", listaPartidos.Id_EquipoVisita);

                try
                {
                    conexion.Open();
                    sql.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error en el ingreso" + ex.Message);
                }

            }
        }

        public void UpdateTorneo(int id_torneo)
        {
            string query = "EXEC JCGO_UPDATE_TORNEO_PROCESO @Id_Torneo";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@Id_Torneo", id_torneo);

                try
                {
                    conexion.Open();
                    sql.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Torneo en Proceso");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error en el ingreso" + ex.Message);
                }

            }
        }
    }
}
