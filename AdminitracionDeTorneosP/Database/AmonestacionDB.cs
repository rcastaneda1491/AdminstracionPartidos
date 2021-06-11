using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using AdminitracionDeTorneosP.Model;
using System.Collections.Generic;

namespace AdminitracionDeTorneosP.Database
{
    public class AmonestacionDB
    {
        //Conexion a Base de Datos
        private string connectionString = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";

        public void AddTarjeta(Amonestacion amonestacion)
        {
            string query = "EXEC  JCGO_INSERT_AMONESTACION @ColorTarjeta,@Valor_multa,@Comentario";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //Envia parametros al Proceso Almacenado
                command.Parameters.AddWithValue("@ColorTarjeta", amonestacion.Color_Tarjeta);
                command.Parameters.AddWithValue("@Valor_multa", amonestacion.Valor_Multa);
                command.Parameters.AddWithValue("@Comentario", amonestacion.Comentario);
                try
                {
                    connection.Open();
                    //Ejecuta el Query
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Tarjeta Agregada Correctamente");
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al Guardar Tarjeta" + error.Message, "ERROR");
                }
            }
        }

        //Obtiene todos los datos de la base de Datos de Amonestacion
        public List<Amonestacion> GetAmonestacion()
        {
            List<Amonestacion> amonestaciones = new List<Amonestacion>();
            string query = "SELECT * FROM amonestacion";
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
                        Amonestacion amonestacion = new Amonestacion();
                        //Obtiene los datos de la tabla y se guardan en un lista
                        amonestacion.Id_Tarjeta = reader.GetInt32(0);
                        amonestacion.Color_Tarjeta = reader.GetString(1);
                        amonestacion.Valor_Multa = reader.GetDecimal(2);
                        amonestacion.Comentario = reader.GetString(3);
                        amonestaciones.Add(amonestacion);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al obtener los datos" + error, "ERROR");
                }
            }
            return amonestaciones;
        }

        //Procedimiento Para Obtener un Torneo en especifico
        public Amonestacion GetTarjeta(int? Id_Tarjeta)
        {
            Amonestacion amonestacion = new Amonestacion();
            string query = "SELECT * FROM amonestacion WHERE Id_Tarjeta = @Id_Tarjeta";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Tarjeta", Id_Tarjeta);
                try
                {
                    connection.Open();
                    //Ejecuta el query y lee lo q esta en la tabla
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();

                    //Se guarda lo que esta en la tabla en el modelo
                    amonestacion.Id_Tarjeta = reader.GetInt32(0);
                    amonestacion.Color_Tarjeta = reader.GetString(1);
                    amonestacion.Valor_Multa = reader.GetDecimal(2);
                    amonestacion.Comentario = reader.GetString(3);

                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al obtener los datos" + error, "ERROR");
                }
                return amonestacion;
            }
        }

        public void UpdateTarjeta(Amonestacion amonestacion)
        {
            string query = "EXEC JCGO_UPDATE_AMONESTACION @Id_Tarjeta, @ColorTarjeta, @Valor_multa,@Comentario";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //Envia Parametros al Procedimiento
                command.Parameters.AddWithValue("@Id_Tarjeta", amonestacion.Id_Tarjeta);
                command.Parameters.AddWithValue("@ColorTarjeta", amonestacion.Color_Tarjeta);
                command.Parameters.AddWithValue("@Valor_multa", amonestacion.Valor_Multa);
                command.Parameters.AddWithValue("@Comentario", amonestacion.Comentario);
                try
                {
                    connection.Open();
                    //Ejecuta el query
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Dato actualizado correctmanete");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar Torneo", ex.Message);
                }
            }
        }

        public void DeleteTorneo(int Id_Tarjeta)
        {
            string query = "EXEC JCGO_DELETE_AMONESTACION @Id_Tarjeta";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //Envia parametro al procedimiento
                command.Parameters.AddWithValue("@Id_Tarjeta", Id_Tarjeta);
                try
                {
                    connection.Open();
                    //Ejecuta el Query
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Eliminado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al Eliminar Torneo", ex.Message);
                }
            }
        }
    }
}