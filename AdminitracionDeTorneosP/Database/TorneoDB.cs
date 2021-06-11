using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using AdminitracionDeTorneosP.Model;
using System.Collections.Generic;

namespace AdminitracionDeTorneosP.Database
{
    public class TorneoDB
    {
        //Conexion a Base de Datos
        private string connectionString = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";

        //Procedimiento Para Obtener un Torneo en especifico
        public Torneos GetTorneo(int? Id_Cliente)
        {
            Torneos torneo = new Torneos();
            string query = "EXEC JCGO_SELEC_TORNEO @Id_Torneo";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Torneo", Id_Cliente);
                try
                {
                    connection.Open();
                    //Ejecuta el query y lee lo q esta en la tabla
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();

                    //Se guarda lo que esta en la tabla en el modelo
                    torneo.Id_Torneo = reader.GetInt32(0);
                    torneo.Nombre = reader.GetString(1);
                    torneo.FechaIncio = reader.GetDateTime(2);
                    torneo.FechaFinaliza = reader.GetDateTime(3);
                    torneo.Tipo = reader.GetString(4);
                    torneo.NumeroMaximoJugadores = reader.GetInt32(5);
                    torneo.EdadMinima = reader.GetInt32(6);
                    torneo.EdadMaxima = reader.GetInt32(7);
                    torneo.PuntosVictoria = reader.GetInt32(8);
                    torneo.PuntosEmpate = reader.GetInt32(9);
                    torneo.PuntosDerrota = reader.GetInt32(10);
                    torneo.tipoFutbolTorneo = reader.GetString(11);
                    torneo.costo = reader.GetDouble(12);
                    torneo.Proceso = reader.GetBoolean(13);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al obtener los datos" + error, "ERROR");
                }
                return torneo;
            }
        }

        //Procedimiento Para Obtener Todos los torneos en la base de Datos
        public List<Torneos> GetTorneos()
        {
            List<Torneos> torneos = new List<Torneos>();
            string query = "EXEC JCGO_SELEC_TORNEOS ";
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
                        Torneos torneo = new Torneos();
                        //Obtiene los datos de la tabla y se guardan en un lista
                        torneo.Id_Torneo = reader.GetInt32(0);
                        torneo.Nombre = reader.GetString(1);
                        torneo.FechaIncio = reader.GetDateTime(2);
                        torneo.FechaFinaliza = reader.GetDateTime(3);
                        torneo.Tipo = reader.GetString(4);
                        torneo.NumeroMaximoJugadores = reader.GetInt32(5);
                        torneo.EdadMinima = reader.GetInt32(6);
                        torneo.EdadMaxima = reader.GetInt32(7);
                        torneo.PuntosVictoria = reader.GetInt32(8);
                        torneo.PuntosEmpate = reader.GetInt32(9);
                        torneo.PuntosDerrota = reader.GetInt32(10);
                        torneo.tipoFutbolTorneo = reader.GetString(11);
                        torneo.costo = reader.GetDouble(12);
                        torneo.Proceso = reader.GetBoolean(13);
                        torneos.Add(torneo);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al obtener los datos" + error, "ERROR");
                }
            }
            return torneos;
        }

        public void AddTorneo(Torneos torneo)
        {
            string query = "EXEC  JCGO_INSERT_TORNEO @Nombre, @FechaInicio, @FechaFinal, @Tipo, @NumeroMaximoDeJugadores,@EdadMinima ,@EdadMaxima	,@PuntosVictoria ,@PuntosEmpate  ,@PuntosDerrota, @tipoFutbolTorneo,@Costo";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //Envia parametros al Proceso Almacenado
                command.Parameters.AddWithValue("@Nombre", torneo.Nombre);
                command.Parameters.AddWithValue("@FechaInicio", torneo.FechaIncio);
                command.Parameters.AddWithValue("@FechaFinal", torneo.FechaFinaliza);
                command.Parameters.AddWithValue("@Tipo", torneo.Tipo);
                command.Parameters.AddWithValue("@NumeroMaximoDeJugadores", torneo.NumeroMaximoJugadores);
                command.Parameters.AddWithValue("@EdadMinima", torneo.EdadMinima);
                command.Parameters.AddWithValue("@EdadMaxima", torneo.EdadMaxima);
                command.Parameters.AddWithValue("@PuntosVictoria", torneo.PuntosVictoria);
                command.Parameters.AddWithValue("@PuntosEmpate", torneo.PuntosEmpate);
                command.Parameters.AddWithValue("@PuntosDerrota", torneo.PuntosDerrota);
                command.Parameters.AddWithValue("@tipoFutbolTorneo", torneo.tipoFutbolTorneo);
                command.Parameters.AddWithValue("@Costo", torneo.costo);
                try
                {
                    connection.Open();
                    //Ejecuta el Query
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Torneo Agregado Correctamente");
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al insertar Torneo" + error.Message, "ERROR");
                }
            }
        }

        public void UpdateTorneo(int Id_Torneo, string Nombre, DateTime FechaIncio, DateTime FechaFinaliza, string Tipo, int NumeroMaximoJugadores, int EdadMinima, int EdadMaxima, int PuntosVictoria, int PuntosEmpate, int PuntosDerrota, string tipoFutbolTorneo, double costo, bool Proceso)
        {
            string query = "EXEC JCGO_UPDATE_TORNEO @Id_Torneo,@Nombre, @FechaInicio,@FechaFinal,@Tipo,@NumeroMaximoDeJugadores,@EdadMinima,@EdadMaxima,@PuntosVictoria,@PuntosEmpate,@PuntosDerrota,@tipoFutbolTorneo,@Costo,@En_Proceso";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //Envia Parametros al Procedimiento Almacenado
                command.Parameters.AddWithValue("@Id_Torneo", Id_Torneo);
                command.Parameters.AddWithValue("@Nombre", Nombre);
                command.Parameters.AddWithValue("@FechaInicio", FechaIncio);
                command.Parameters.AddWithValue("@FechaFinal", FechaFinaliza);
                command.Parameters.AddWithValue("@Tipo", Tipo);
                command.Parameters.AddWithValue("@NumeroMaximoDeJugadores", NumeroMaximoJugadores);
                command.Parameters.AddWithValue("@EdadMinima", EdadMinima);
                command.Parameters.AddWithValue("@EdadMaxima", EdadMaxima);
                command.Parameters.AddWithValue("@PuntosVictoria", PuntosVictoria);
                command.Parameters.AddWithValue("@PuntosEmpate", PuntosEmpate);
                command.Parameters.AddWithValue("@PuntosDerrota", PuntosDerrota);
                command.Parameters.AddWithValue("@tipoFutbolTorneo", tipoFutbolTorneo);
                command.Parameters.AddWithValue("@Costo", costo);
                command.Parameters.AddWithValue("@En_Proceso", Proceso);
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

        public void DeleteTorneo(int Id_Torneo)
        {
            string query = "JCGO_EXEC DELETE_TORNEO @Id_Torneo";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //Envia parametro al procedimiento
                command.Parameters.AddWithValue("@Id_Torneo", Id_Torneo);
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
