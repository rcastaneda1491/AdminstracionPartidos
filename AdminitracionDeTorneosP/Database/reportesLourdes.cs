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
    public class reportesLourdes
    {
        //ruta de conexion a base de datos 
        private string connectionString = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";

        //método para btener el tiempo de uso de la cancha por rango de fecha 
        public List<reporteUsoCanchasModel> getTiempos(DateTime fechaInicio, DateTime fechaFin)
        {
            List<reporteUsoCanchasModel> listadoTiempos = new List<reporteUsoCanchasModel>();
            //query para obtner daos 
            string query = "exec LA_tiempoUsoCanchasPorFecha @fechaInicio, @fechaFin ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                sql.Parameters.AddWithValue("@fechaFin", fechaFin);
                try
                {
                    connection.Open();
                    //crear lector de datos 
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        //lectura de datos 
                        reporteUsoCanchasModel model = new reporteUsoCanchasModel();
                        model.nombreCancha = reader.GetString(0);
                        model.nombreTorneo = reader.GetString(1);
                        model.minutos = reader.GetInt32(2);
                        listadoTiempos.Add(model);
                    }
                    reader.Close();
                    connection.Close();
                }
                //informar de algún problema 
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos desde la base de datos. " + ex.Message);
                }
            }
            //retornar lista obtenida
            return listadoTiempos;
        }

        //método para btener el tiempo de uso de la cancha por nombre de cancha
        public List<reporteUsoCanchasModel> getTiemposPorNombreCancha(string nombre)
        {
            List<reporteUsoCanchasModel> listadoTiempos = new List<reporteUsoCanchasModel>();
            //query para obtner daos 
            string query = "exec LA_tiempoUsoPorNombreCancha @nombreCancha ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@nombreCancha", nombre);
                
                try
                {
                    connection.Open();
                    //crear lector de datos 
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        //lectura de datos 
                        reporteUsoCanchasModel model = new reporteUsoCanchasModel();
                        model.nombreCancha = reader.GetString(0);
                        model.nombreTorneo = reader.GetString(1);
                        model.minutos = reader.GetInt32(2);
                        listadoTiempos.Add(model);
                    }
                    reader.Close();
                    connection.Close();
                }
                //informar de algún problema 
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos desde la base de datos. " + ex.Message);
                }
            }
            //retornar lista obtenida
            return listadoTiempos;
        }

        //método para btener el tiempo de uso de la cancha por nombre de torneo 
        public List<reporteUsoCanchasModel> getTiemposPorNombreTorneo(string nombre)
        {
            List<reporteUsoCanchasModel> listadoTiempos = new List<reporteUsoCanchasModel>();
            //query para obtner daos 
            string query = "exec LA_tiempoUsoCanchaPorNombreTorneo @nombreTorneo";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@nombreTorneo", nombre);

                try
                {
                    connection.Open();
                    //crear lector de datos 
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        //lectura de datos 
                        reporteUsoCanchasModel model = new reporteUsoCanchasModel();
                        model.nombreCancha = reader.GetString(0);
                        model.nombreTorneo = reader.GetString(1);
                        model.minutos = reader.GetInt32(2);
                        listadoTiempos.Add(model);
                    }
                    reader.Close();
                    connection.Close();
                }
                //informar de algún problema 
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos desde la base de datos. " + ex.Message);
                }
            }
            //retornar lista obtenida
            return listadoTiempos;
        }
        //método para obtener el pago de los arbitros 
        public List<reportePlanillaArbitro> getPagoArbitros(DateTime fechaInicio, DateTime fechaFin)
        {
            List<reportePlanillaArbitro> listadoPagos = new List<reportePlanillaArbitro>();
            //query para obtner daos 
            string query = "exec LA_pagoArbitrosPorFecha @fechaInicio, @fechaFin";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                sql.Parameters.AddWithValue("@fechaFin", fechaFin);

                try
                {
                    connection.Open();
                    //crear lector de datos 
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        //lectura de datos 
                        reportePlanillaArbitro planilla = new reportePlanillaArbitro();
                        planilla.arbitroNombre = reader.GetString(0);
                        planilla.arbitroApellido = reader.GetString(1);
                        planilla.arbitroNacionalidad = reader.GetString(2);
                        planilla.arbitroTelefono = reader.GetString(3);
                        planilla.pagoRecibido = reader.GetDecimal(4);
                        planilla.torneoNombre = reader.GetString(5);
                        listadoPagos.Add(planilla);
                    }
                    reader.Close();
                    connection.Close();
                }
                //informar de algún problema 
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos desde la base de datos. " + ex.Message);
                }
            }
            //retornar lista obtenida
            return listadoPagos;
        }

        //método para obtener los partidos afectados por canchas no disponibles 
        public List<reporteJuegosAfectadosPorCancha> getPartidosAfectados()
        {
            List<reporteJuegosAfectadosPorCancha> juegosAfectados = new List<reporteJuegosAfectadosPorCancha>();
            //query para obtner daos 
            string query = "select * from LA_partidosAfectadosPorCancha";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                
                try
                {
                    connection.Open();
                    //crear lector de datos 
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        //lectura de datos 
                        reporteJuegosAfectadosPorCancha juego = new reporteJuegosAfectadosPorCancha();
                        juego.idJuego = reader.GetInt32(0);
                        juego.fechaJuego = reader.GetDateTime(1);
                        juego.horaInicio = reader.GetTimeSpan(2);
                        juego.horaFinal = reader.GetTimeSpan(3);
                        juego.nombreCancha = reader.GetString(4);
                        juegosAfectados.Add(juego);
                    }
                    reader.Close();
                    connection.Close();
                }
                //informar de algún problema 
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos desde la base de datos. " + ex.Message);
                }
            }
            //retornar lista obtenida
            return juegosAfectados;
        }

    }
}
