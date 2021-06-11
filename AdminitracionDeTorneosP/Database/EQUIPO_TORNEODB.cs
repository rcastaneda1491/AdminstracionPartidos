using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using AdminitracionDeTorneosP.Model;

// Erick Eduardo Echeverría Garrido

namespace AdminitracionDeTorneosP.Database
{
    public class EQUIPO_TORNEODB
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
        public DataTable CargarComboEquipos()
        {
            SqlDataAdapter da = new SqlDataAdapter("proc_erick_cargar_idYnombresDeEquipo", connectionString); // Traera el id y el nombre de cada equipo para el comboBox
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable CargarComboJugadores()
        {
            SqlDataAdapter da = new SqlDataAdapter("proc_erick_cargar_DPI_Nombres_deJugadores", connectionString); // Traera el id y el nombre de cada equipo para el comboBox
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        double costoTorneo;
        public double ObtenerCostoTorneo(int Id_Torneo)
        {
            string query = "exec proc_erick_obtener_costoDeTorneo @Id_Torneo ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Torneo", Id_Torneo);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        costoTorneo = reader.GetDouble(0);
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al obtener el costo del torneo en la base de datos" + ex.Message);
                }
            }
            return costoTorneo;
        }
        public void AddEquipoTorneo(EQUIPO_TORNEO equipoTorneo)
        {
            string query = $"INSERT INTO torneo_equipo (Id_Torneo,Id_Equipo,CostoInscripcion) " +
                                    $"VALUES (@Id_Torneo,@Id_Equipo,@CostoInscripcion)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Torneo", equipoTorneo.Id_Torneo);
                sql.Parameters.AddWithValue("@Id_Equipo", equipoTorneo.Id_Equipo);
                sql.Parameters.AddWithValue("@CostoInscripcion", equipoTorneo.costoInscripcion);
                try
                {
                    connection.Open();
                    sql.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("El equipo se ha agregado correctamente al torneo");
                }
                catch (Exception) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("El Equipo actualmente ya esta participando en el Torneo asignado");
                }
            }
        }
        public List<EQUIPO_TORNEO> GetEquiposEnTorneo(int idTorneo)
        {
            List<EQUIPO_TORNEO> equipos = new List<EQUIPO_TORNEO>();
            string query = "exec proc_erick_cargar_equiposEnTorneo @idTorneo ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@idTorneo", idTorneo);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        EQUIPO_TORNEO equipo = new EQUIPO_TORNEO();
                        equipo.Id_Torneo = reader.GetInt32(0);
                        equipo.Id_Equipo = reader.GetInt32(1);
                        equipo.costoInscripcion = reader.GetDecimal(2);

                        equipos.Add(equipo); // Los valores leidos atraves del "SELECT" se guardaran en el LIST
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al obtener los datos desde la base de datos. " + ex.Message);
                }
            }
            return equipos;
        }

        int cantidadJugadores;
        public int contarJugadoresEnElEquipoMismoTorneo(int Id_Torneo, int Id_Equipo)
        {
            string query = "exec proc_erick_contarJugadoresEnElEquipoMismoTorneo @Id_Torneo, @Id_Equipo ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Torneo", Id_Torneo);
                sql.Parameters.AddWithValue("@Id_Equipo", Id_Equipo);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        cantidadJugadores = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al obtener la cantidad de jugadores en la base de datos" + ex.Message);
                }
            }
            return cantidadJugadores;
        }

        bool resultado;
        public bool obtenerTorneoComenzado(int Id_Torneo)
        {
            string query = "exec proc_erick_obtenerTorneoComenzado @Id_Torneo ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Torneo", Id_Torneo);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        resultado = reader.GetBoolean(0);
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al obtener la cantidad de jugadores en la base de datos" + ex.Message);
                }
            }
            return resultado;
        }
        public void DeleteEquipoCompetencia(int idTorneo, int Id_Equipo)
        {
            string query = "DELETE FROM torneo_equipo WHERE Id_Torneo=@idTorneo and Id_Equipo=@Id_Equipo";  // Ejecutando DELETE con los datos recibidos de la vista (View.EliminarCliente)
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idTorneo", idTorneo);
                command.Parameters.AddWithValue("@Id_Equipo", Id_Equipo);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Equipo eliminado correctamente del Torneo");
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al eliminar el equipo de la competencia" + ex);
                }
            }
        }
        public List<EQUIPO> GetEquiposEnTorneoDatosDelEquipo(int Id_Torneo)
        {
            List<EQUIPO> equipos = new List<EQUIPO>();
            string query = "exec proc_erick_obtenerEquiposMismoTorneo @Id_Torneo ";
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
                        EQUIPO equipo = new EQUIPO();
                        equipo.Id_Equipo = reader.GetInt32(0);
                        equipo.Nombre = reader.GetString(1);
                        equipo.Representante = reader.GetString(2);
                        equipo.DPI_Entrenador = reader.GetInt64(3);

                        equipos.Add(equipo); // Los valores leidos atraves del "SELECT" se guardaran en el LIST
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al obtener los datos desde la base de datos. " + ex.Message);
                }
            }
            return equipos;
        }
        public List<POSICION_JUGADOR_CON_NOMBRE> obtenerJugadoresDelEquipo(int Id_Torneo, int Id_Equipo)
        {
            List<POSICION_JUGADOR_CON_NOMBRE> jugadores = new List<POSICION_JUGADOR_CON_NOMBRE>();
            string query = "exec obtenerJugadoresDelEquipo @Id_Torneo, @Id_Equipo";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Torneo", Id_Torneo);
                sql.Parameters.AddWithValue("@Id_Equipo", Id_Equipo);
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

        int edad, edadMinima, edadMaxima;
        public int ObtenerEdadJugador(long DPI)
        {
            string query = "exec proc_erick_obtenerEdadDeJugador @DPI ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@DPI", DPI);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        edad = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al obtener la edad del jugador en la base de datos " + ex.Message);
                }
            }
            return edad;
        }
        public int ObtenerEdadMinimaTorneo(int Id_Torneo)
        {
            string query = "exec proc_erick_obtenerEdadMinimaTorneo @Id_Torneo ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Torneo", Id_Torneo);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        edadMinima = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al obtener el precio del producto en la base de datos " + ex.Message);
                }
            }
            return edadMinima;
        }
        public int ObtenerEdadMaximaTorneo(int Id_Torneo)
        {
            string query = "exec proc_erick_obtenerEdadMaximaTorneo @Id_Torneo ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Torneo", Id_Torneo);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        edadMaxima = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al obtener el precio del producto en la base de datos " + ex.Message);
                }
            }
            return edadMaxima;
        }

        int maximoPermitido, cantidadJugadoresEnEquipo;

        public int ObtenerMaximoPermitido(int Id_Torneo)
        {
            string query = "exec proc_erick_obtenerMaximoJugadores @Id_Torneo ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Torneo", Id_Torneo);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        maximoPermitido = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al obtener el precio del producto en la base de datos " + ex.Message);
                }
            }
            return maximoPermitido;
        }
        public int CantidadJugadoresEnEquipoTorneo(int idTorneo, int idEquipo)
        {
            string query = "exec proc_erick_obtenerCantidadJugadoresEnEquipo @Id_Torneo, @idEquipo ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Torneo", idTorneo);
                sql.Parameters.AddWithValue("@idEquipo", idEquipo);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        cantidadJugadoresEnEquipo = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al obtener el precio del producto en la base de datos " + ex.Message);
                }
            }
            return cantidadJugadoresEnEquipo;
        }
        public int obtenerCantidadJugadoresConNumeroDeCamiseta(int idTorneo, int idEquipo, int NumeroCamisola)
        {
            string query = "exec proc_erick_obtenerCantidadJugadoresConNumeroDeCamiseta @Id_Torneo, @idEquipo, @NumeroCamisola";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Torneo", idTorneo);
                sql.Parameters.AddWithValue("@idEquipo", idEquipo);
                sql.Parameters.AddWithValue("@NumeroCamisola", NumeroCamisola);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        cantidadJugadoresEnEquipo = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al obtener el precio del producto en la base de datos " + ex.Message);
                }
            }
            return cantidadJugadoresEnEquipo;
        }
        public int obtenerJugadorDiferenteEquipoMismoTorneo(int idTorneo, long dpiJugador)
        {
            string query = "exec proc_erick_obtenerJugadorDiferenteEquipoMismoTorneo @Id_Torneo, @dpiJugador";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Torneo", idTorneo);
                sql.Parameters.AddWithValue("@dpiJugador", dpiJugador);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        cantidadJugadoresEnEquipo = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close(); // Cerrando conexion
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al obtener el conteo de jugadores en la base de datos " + ex.Message);
                }
            }
            return cantidadJugadoresEnEquipo;
        }
        public void AddJugadorAEquipo(POSICION_JUGADOR jugador)
        {
            string query = $"INSERT INTO posicion_jugador (Id_Torneo,Id_Equipo,DPI_Jugador,Posicion,NumeroCamisola) " +
                                    $"VALUES (@Id_Torneo,@Id_Equipo,@DPI_Jugador,@Posicion,@NumeroCamisola)"; // Ejecutando INSERT con los datos recibidos de la vista (View.AgregarTipoProducto)
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Torneo", jugador.Id_Torneo);
                sql.Parameters.AddWithValue("@Id_Equipo", jugador.Id_Equipo);
                sql.Parameters.AddWithValue("@DPI_Jugador", jugador.DPI_JUGADOR);
                sql.Parameters.AddWithValue("@Posicion", jugador.Posicion);
                sql.Parameters.AddWithValue("@NumeroCamisola", jugador.NumeroCamisola);
                try
                {
                    connection.Open();
                    sql.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("El jugador se ha agregado correctamente al equipo");
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Actualmente el jugador ya esta participando en el equipo" + ex);
                }
            }
        }

        public POSICION_JUGADOR GetJugadorPosicion(int codigoTorneo, int codigoEquipo, long DPI_Jugador)
        {
            POSICION_JUGADOR jugador = new POSICION_JUGADOR();
            string query = "SELECT * FROM posicion_jugador WHERE Id_Torneo=@codigoTorneo and  Id_Equipo=@codigoEquipo and  DPI_Jugador=@DPI_Jugador"; // Ejecutando DELETE en la base de datos con la informacion recibida de la funcion
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@codigoTorneo", codigoTorneo);
                sql.Parameters.AddWithValue("@codigoEquipo", codigoEquipo);
                sql.Parameters.AddWithValue("@DPI_Jugador", DPI_Jugador);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();

                    jugador.Id_Torneo = reader.GetInt32(0);
                    jugador.Id_Equipo = reader.GetInt32(1);
                    jugador.DPI_JUGADOR = reader.GetInt64(2);
                    jugador.Posicion = reader.GetString(3);
                    jugador.NumeroCamisola = reader.GetInt32(4);
                }
                catch (Exception ex) // Capturando posibles datos
                {
                    MessageBox.Show("Error al obtener el jugador... " + ex.Message);
                }
            }
            return jugador;
        }
        public void UpdatePosJugador(int codigoTorneo, int codigoEquipo, long DPI_Jugador, string posicion, int numeroCamisola)
        {
            string query = "UPDATE posicion_jugador set Posicion=@posicion, NumeroCamisola=@numeroCamisola WHERE Id_Torneo=@codigoTorneo and  Id_Equipo=@codigoEquipo and  DPI_Jugador=@DPI_Jugador"; // Ejecutando UPDATE con los datos recibidos de la vista (View.ActualizarProducto)
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@codigoTorneo", codigoTorneo);
                command.Parameters.AddWithValue("@codigoEquipo", codigoEquipo);
                command.Parameters.AddWithValue("@DPI_Jugador", DPI_Jugador);
                command.Parameters.AddWithValue("@posicion", posicion);
                command.Parameters.AddWithValue("@numeroCamisola", numeroCamisola);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Jugador del equipo actualizado correctamente.");
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al actualizar el cliente en la base de datos" + ex.Message);
                }
            }
        }
        public void DeleteJugadorDeEquipo(int codigoTorneo, int codigoEquipo, long DPI_Jugador)
        {
            string query = "DELETE FROM posicion_jugador WHERE Id_Torneo=@codigoTorneo and  Id_Equipo=@codigoEquipo and  DPI_Jugador=@DPI_Jugador";  // Ejecutando DELETE con los datos recibidos de la vista (View.EliminarCliente)
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@codigoTorneo", codigoTorneo);
                command.Parameters.AddWithValue("@codigoEquipo", codigoEquipo);
                command.Parameters.AddWithValue("@DPI_Jugador", DPI_Jugador);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Registro eliminado correctamente");
                }
                catch (Exception ex) // Capturando posible error en la base de datos
                {
                    MessageBox.Show("Error al eliminar el jugador del equipo en la base de datos" + ex.Message);
                }
            }
        }

    }
}
