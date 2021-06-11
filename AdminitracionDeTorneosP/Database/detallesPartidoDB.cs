using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminitracionDeTorneosP.Database
{
    public class detallesPartidoDB
    {
        private string connectionstring = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";
        public DateTime getFechaInicio(int id)
        {
            string query = "exec LA_obtenerFechaInicioTornero @id ";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@id", id);


                connection.Open();
                DateTime fechaInicio = Convert.ToDateTime(sql.ExecuteScalar());


                connection.Close();

                return fechaInicio;


            }

        }

        public DateTime getFechaFin(int id)
        {
            string query = "exec LA_obtenerFechaFinTorneo @id ";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@id", id);


                connection.Open();
                DateTime fechaFin = Convert.ToDateTime(sql.ExecuteScalar());


                connection.Close();

                return fechaFin;


            }

        }


        public int getIdCancha(string nombre)
        {
            string query = "exec LA_buscarIdCanchaPorNombre @nombre ";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@nombre", nombre);


                connection.Open();
                int idCancha = Convert.ToInt32(sql.ExecuteScalar());


                connection.Close();

                return idCancha;


            }

        }



        public void updateDetallesPartido(int idPartido, int idCancha, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin)
        {
            //query para actualizar datos 
            string query = "exec LA_actualizarDetallesPartido @idPartido, @idCancha, @fecha, @horaInicio, @horafin";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //añadir valor a los procesos almacenados 
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idPartido", idPartido);
                command.Parameters.AddWithValue("@idCancha", idCancha);
                command.Parameters.AddWithValue("@fecha", fecha);
                command.Parameters.AddWithValue("@horaInicio", horaInicio);
                command.Parameters.AddWithValue("@horaFin", horaFin);


                try
                {
                    //abrir conexion
                    connection.Open();
                    command.ExecuteNonQuery();
                    //cerrar conexion 
                    connection.Close();
                    MessageBox.Show("Datos actualizados correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar los datos en la base de datos" + ex.Message);
                }
            }
        }





    }
}