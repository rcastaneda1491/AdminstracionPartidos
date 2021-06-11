using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using AdminitracionDeTorneosP.Model;

namespace AdminitracionDeTorneosP.Database
{
    public class AdministraciónDeJornadasDB
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

        public List<PartidosNombres> GetEnfrentamientoDeTorneo(int Id_Torneo)
        {
            List<PartidosNombres> partidos = new List<PartidosNombres>();
            string query = "exec proc_erick_obtenerPartidosDeTorneo @Id_Torneo ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Torneo", @Id_Torneo);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        PartidosNombres partido = new PartidosNombres();
                        partido.Id_Juego = reader.GetInt32(0);
                        partido.EquipoLocal = reader.GetString(1);
                        partido.EquipoVisita = reader.GetString(2);
                        partido.Fecha = reader.GetDateTime(3);
                        partido.HoraInicio = reader.GetTimeSpan(4);
                        partido.HoraFinal = reader.GetTimeSpan(5);

                        partidos.Add(partido); // Los valores leidos atraves del "SELECT" se guardaran en el LIST
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al obtener los datos desde la base de datos. " + ex.Message);
                }
            }
            return partidos;
        }

        public List<POSICION_JUGADOR_CON_NOMBRE> obtenerJugadoresDeEquipos(int Id_Torneo, int Id_Equipo1, int Id_Equipo2)
        {
            List<POSICION_JUGADOR_CON_NOMBRE> jugadores = new List<POSICION_JUGADOR_CON_NOMBRE>();
            string query = "exec proc_erick_obtenerJugadoresDeEquipos @Id_Torneo, @Id_Equipo1, @Id_Equipo2";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Torneo", Id_Torneo);
                sql.Parameters.AddWithValue("@Id_Equipo1", Id_Equipo1);
                sql.Parameters.AddWithValue("@Id_Equipo2", Id_Equipo2);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        POSICION_JUGADOR_CON_NOMBRE jugador = new POSICION_JUGADOR_CON_NOMBRE();
                        jugador.Id_Torneo = reader.GetInt32(0);
                        jugador.NombreTorneo = reader.GetString(1);
                        jugador.Id_Equipo = reader.GetInt32(2);
                        jugador.NombreEquipo = reader.GetString(3);
                        jugador.DPI_JUGADOR = reader.GetInt64(4);
                        jugador.NombreJugador = reader.GetString(5);
                        jugador.ApellidoJugador = reader.GetString(6);
                        jugador.Posicion = reader.GetString(7);
                        jugador.NumeroCamisola = reader.GetInt32(8);

                        jugadores.Add(jugador); // Los valores leidos atraves del "SELECT" se guardaran en el LIST
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al obtener los datos desde la base de datos. " + ex.Message);
                }
            }
            return jugadores;
        }

        int id;

        public int ObtenerIdEquipo(string Nombre)
        {
            string query = "exec proc_erick_obtenerIdEquipoSeleccionado @Nombre ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Nombre", Nombre);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al obtener la edad del jugador en la base de datos " + ex.Message);
                }
            }
            return id;
        }

        public void Agregar_Nuevos_Goles(GOL tipo_gol)
        {
            string query = "insert into gol(Id_Juego,DPI_Jugador,Tipo,Tiempo) VALUES (@Id_Juego,@DPI_Jugador,@Tipo,@Tiempo); ";
            using (SqlConnection connec = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connec);
                sql.Parameters.AddWithValue("@Id_Juego", tipo_gol.Id_Juego);
                sql.Parameters.AddWithValue("@DPI_Jugador", tipo_gol.DPI_Jugador);
                sql.Parameters.AddWithValue("@Tipo", tipo_gol.Tipo);
                sql.Parameters.AddWithValue("@Tiempo", tipo_gol.Tiempo);

                try
                {
                    connec.Open();
                    sql.ExecuteNonQuery();
                    connec.Close();
                    MessageBox.Show("Se Agrego correctamente al gol tipo : " + " " + tipo_gol.Tipo + " Minuto:   " + tipo_gol.Tiempo);
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR no se puede agregar, este numero de (DPI / CEDULA / CUI) ya esta en USO", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        int cantidad;

        public int ObtenerPunteoYaCreado(int Id_Juego)
        {
            string query = "exec proc_erick_obtenerPunteoYaRealizado @Id_Juego ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Juego", Id_Juego);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        cantidad = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al obtener el precio del producto en la base de datos " + ex.Message);
                }
            }
            return cantidad;
        }

        public int obtenerPunteoEquipoLocal(int Id_Juego)
        {
            string query = "exec proc_erick_obtenerPunteoEquipoLocal @Id_Juego ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Juego", Id_Juego);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        cantidad = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al obtener el precio del producto en la base de datos " + ex.Message);
                }
            }
            return cantidad;
        }

        public int obtenerPunteoEquipoVisita(int Id_Juego)
        {
            string query = "exec proc_erick_obtenerPunteoEquipoVisita @Id_Juego ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Juego", Id_Juego);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        cantidad = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al obtener el precio del producto en la base de datos " + ex.Message);
                }
            }
            return cantidad;
        }

        public int obtenerIdLocal(int Id_Juego)
        {
            string query = "exec proc_erick_obtenerIdLocal @Id_Juego ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Juego", Id_Juego);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        cantidad = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al obtener el precio del producto en la base de datos " + ex.Message);
                }
            }
            return cantidad;
        }

        public void ActualizarPunteo(int Id_Juego, int punteoLocal, int punteoVisita)
        {
            string query = "UPDATE punteo SET PunteoEquipoLocal=@punteoLocal , PunteoEquipoVisita = @punteoVisita WHERE Id_Juego=@Id_Juego"; // Ejecutando UPDATE con los datos recibidos de la vista (View.ActualizarProducto)
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id_Juego", Id_Juego);
                command.Parameters.AddWithValue("@punteoLocal", punteoLocal);
                command.Parameters.AddWithValue("@punteoVisita", punteoVisita);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Punteo actualizado correctamente.");
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al actualizar el punteo en la base de datos" + ex.Message);
                }
            }
        }

        public void AddPunteo(Punteo punteo)
        {
            string query = $"INSERT INTO punteo (Id_Juego,Id_EquipoLocal,Id_EquipoVisita,PunteoEquipoLocal,PunteoEquipoVisita) " +
                                    $"VALUES (@Id_Juego,@Id_EquipoLocal,@Id_EquipoVisita,@PunteoEquipoLocal,@PunteoEquipoVisita)"; // Ejecutando INSERT con los datos recibidos de la vista (View.AgregarFactura)
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Juego", punteo.Id_Juego);
                sql.Parameters.AddWithValue("@Id_EquipoLocal", punteo.Id_EquipoLocal);
                sql.Parameters.AddWithValue("@Id_EquipoVisita", punteo.Id_EquipoVisita);
                sql.Parameters.AddWithValue("@PunteoEquipoLocal", punteo.PunteoEquipoLocal);
                sql.Parameters.AddWithValue("@PunteoEquipoVisita", punteo.PunteoEquipoVisita);
                try
                {
                    connection.Open();
                    sql.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("El Punteo se ha agregado correctamente");
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al insertar el punteo a la base de datos" + ex.Message);
                }
            }
        }

        public List<GOL_ConNombre> obtenerGolesJuego(int Id_Juego)
        {
            List<GOL_ConNombre> goles = new List<GOL_ConNombre>();
            string query = "exec proc_erick_obtenerGolesJuego @Id_Juego";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Juego", Id_Juego);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        GOL_ConNombre gol = new GOL_ConNombre();
                        gol.IdGol = reader.GetInt32(0);
                        gol.Id_Juego = reader.GetInt32(1);
                        gol.DPI_Jugador = reader.GetInt64(2);
                        gol.NombreJugador = reader.GetString(3);
                        gol.Tipo = reader.GetString(4);
                        gol.Tiempo = reader.GetString(5);

                        goles.Add(gol); // Los valores leidos atraves del "SELECT" se guardaran en el LIST
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al obtener los datos desde la base de datos. " + ex.Message);
                }
            }
            return goles;
        }

        public void ActualizarGol(int IdGol, string Tipo, string Tiempo)
        {
            string query = "UPDATE gol SET Tipo=@Tipo , Tiempo = @Tiempo WHERE IdGol=@IdGol"; // Ejecutando UPDATE con los datos recibidos de la vista (View.ActualizarProducto)
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdGol", IdGol);
                command.Parameters.AddWithValue("@Tipo", Tipo);
                command.Parameters.AddWithValue("@Tiempo", Tiempo);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Gol actualizado correctamente.");
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al actualizar el Gol en la base de datos" + ex.Message);
                }
            }
        }

        public void DeleteGol(int IdGol)
        {
            string query = "DELETE FROM gol WHERE IdGol=@IdGol"; // Ejecutando UPDATE con los datos recibidos de la vista (View.ActualizarProducto)
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdGol", IdGol);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Gol eliminado correctamente.");
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al eliminar el Gol en la base de datos" + ex.Message);
                }
            }
        }
        public int obtenerGolesDeEquipoTorneo(int Id_Equipo, int Id_Torneo)
        {
            string query = "exec proc_erick_obtenerGolesDeEquipoTorneo @Id_Equipo, @Id_Torneo ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Equipo", Id_Equipo);
                sql.Parameters.AddWithValue("@Id_Torneo", Id_Torneo);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        cantidad = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al obtener el precio del producto en la base de datos " + ex.Message);
                }
            }
            return cantidad;
        }

    }
}
