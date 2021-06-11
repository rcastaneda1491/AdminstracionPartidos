using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using AdminitracionDeTorneosP.Model;
using System.Collections.Generic;

namespace AdminitracionDeTorneosP.Database
{
    public class Reporte_Tabla_VisitanteDB
    {
        //Conexion a Base de Datos
        private string connectionString = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";

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

        public List<Tabla_Visitante> GetTabla_Visitantes(int id_torneo)
        {
            List<Tabla_Visitante> Tabla_visitante = new List<Tabla_Visitante>();
            string query = "EXEC tabla_general_seleccionando_datos @id_torneo";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@id_torneo", id_torneo);
                try
                {
                    connection.Open();
                    //Ejecuta el query
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        Tabla_Visitante tabla_Visitante = new Tabla_Visitante();
                        //Obtiene los datos de la tabla y se guardan en un lista
                        tabla_Visitante.nombres = reader.GetString(0);
                        tabla_Visitante.jugados  = reader.GetInt32(1);
                        tabla_Visitante.ganados = reader.GetInt32(2);
                        tabla_Visitante.empatados = reader.GetInt32(3);
                        tabla_Visitante.perdidos = reader.GetInt32(4);
                        tabla_Visitante.goles_favor = reader.GetInt32(5);
                        tabla_Visitante.goles_contra = reader.GetInt32(6);
                        tabla_Visitante.diferencia_goles = reader.GetInt32(7);
                        tabla_Visitante.puntos = reader.GetInt32(11);
                        Tabla_visitante.Add(tabla_Visitante);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al obtener los datos" + error, "ERROR");
                }
            }
            return Tabla_visitante;
        }
    }
}
