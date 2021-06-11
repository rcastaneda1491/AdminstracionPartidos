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
    public class Registro_AmonestacionDB
    {
        private string connectionString = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";

        public Registro_Amonestacion Get_Amonestacion(int Id_Juego, long DPI, int Id_Tarjeta)
        {
            Registro_Amonestacion registro_Amonestacion = new Registro_Amonestacion();
            string query = "JCGO_GET_AMONESTACION @Id_Juego , @DPI_Jugador , @Id_Tarjeta ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Juego", Id_Juego);
                sql.Parameters.AddWithValue("@DPI_Jugador", DPI);
                sql.Parameters.AddWithValue("@Id_Tarjeta", Id_Tarjeta);
                try
                {
                    connection.Open();
                    //Ejecuta el query y lee lo q esta en la tabla
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();

                    //Se guarda lo que esta en la tabla en el modelo
                    registro_Amonestacion.Tiempo = reader.GetString(3);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al obtener los datos" + error, "ERROR");
                }
                return registro_Amonestacion;
            }
        }

        public List<Registro_Amonestacion> GetRegistro_Amonestacions()
        {
            List<Registro_Amonestacion> registro_Amonestacion = new List<Registro_Amonestacion>();
            string query = "SELECT * FROM registro_amonestacion";
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
                        Registro_Amonestacion registro_Amonestacions = new Registro_Amonestacion();
                        //Obtiene los datos de la tabla y se guardan en un lista
                        registro_Amonestacions.id = reader.GetInt32(0);
                        registro_Amonestacions.Id_Juego = reader.GetInt32(1);
                        registro_Amonestacions.DPI_Jugador = reader.GetInt64(2);
                        registro_Amonestacions.Id_Tarjeta = reader.GetInt32(3);
                        registro_Amonestacions.Tiempo = reader.GetString(4);
                        registro_Amonestacions.Pagada = reader.GetString(5);
                        registro_Amonestacions.Fecha_Pagp = reader.GetString(6);
                        registro_Amonestacion.Add(registro_Amonestacions);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al obtener los datos" + error, "ERROR");
                }
            }
            return registro_Amonestacion;
        }

        public void Equipos_Partido(ComboBox cbx, int Id_Juego)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cbx.Items.Clear();
                connection.Open();
                //Query de consulta para obtener equipos
                SqlCommand sql = new SqlCommand("EXEC JCGO_Equipos_Partido @Id_Juego", connection);
                sql.Parameters.AddWithValue("@Id_Juego", Id_Juego);
                //Lectura de datos y agregar al combo box los datos
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    //Agregar registros al combo box
                    cbx.Items.Add($"{dr[0]}- {dr[1]}");
                    cbx.Items.Add($"{dr[2]}- {dr[3]}");
                }
                connection.Close();
            }
        }

        public void Jugadores_Equipo(ComboBox cbx, int Id_Equipo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cbx.Items.Clear();
                connection.Open();
                //Query de consulta para obtener equipos
                SqlCommand sql = new SqlCommand("EXEC JCGO_Jugadores_Equipo @Id_Equipo ", connection);
                sql.Parameters.AddWithValue("@Id_Equipo", Id_Equipo);
                //Lectura de datos y agregar al combo box los datos
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    //Agregar registros al combo box
                    cbx.Items.Add($"{dr[1]} {dr[2]}");
                }
                connection.Close();
            }
        }

        public long DPI_Jugador(string Nombres, string Apellidos)
        {
            long DPI = 0;
            string query = "EXEC JCGO_DPI_Jugador @Nombres, @Apellidos";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Nombres", Nombres);
                sql.Parameters.AddWithValue("@Apellidos", Apellidos);
                try
                {
                    connection.Open();
                    //Ejecuta el query y lee lo q esta en la tabla
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();

                    //Se guarda lo que esta en la tabla en el modelo
                    DPI = reader.GetInt64(0);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al obtener los datos" + error, "ERROR");
                }
                return DPI;
            }

        }

        public void GetTarjetas(ComboBox cbx)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cbx.Items.Clear();
                connection.Open();
                //Query de consulta para obtener equipos
                SqlCommand sql = new SqlCommand("JCGO_GET_TARJETAS", connection);
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

        public void AddRegistroAmonestacion(Registro_Amonestacion registro_Amonestacion, int Id_Juego)
        {
            string query = "EXEC JCGO_Insert_registro_amonestacion   @Id_Juego , @DPI_Jugador , @Id_Tarjeta , @Tiempo ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //Envia parametros al Proceso Almacenado
                command.Parameters.AddWithValue("@Id_Juego", Id_Juego);
                command.Parameters.AddWithValue("@DPI_Jugador", registro_Amonestacion.DPI_Jugador);
                command.Parameters.AddWithValue("@Id_Tarjeta", registro_Amonestacion.Id_Tarjeta);
                command.Parameters.AddWithValue("@Tiempo", registro_Amonestacion.Tiempo);
                try
                {
                    connection.Open();
                    //Ejecuta el Query
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Amonestacion Agregada Correctamente");
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al insertar Amonestacion" + error.Message, "ERROR");
                }
            }
        }

        public void Jugadores(ComboBox cbx, int DPI)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cbx.Items.Clear();
                connection.Open();
                //Query de consulta para obtener equipos
                SqlCommand sql = new SqlCommand("SELECT J.Nombres, J.Apellidos FROM jugador J WHERE J.DPI_Jugador = @DPI_Jugador", connection);
                sql.Parameters.AddWithValue("@DPI_Jugador", DPI);
                //Lectura de datos y agregar al combo box los datos
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    //Agregar registros al combo box
                    cbx.Text = ($"{dr[0]} {dr[1]}");
                }
                connection.Close();
            }
        }

        public void Tarjetas(ComboBox cbx, int Id_Tarjeta)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cbx.Items.Clear();
                connection.Open();
                //Query de consulta para obtener equipos
                SqlCommand sql = new SqlCommand("SELECT A.Id_Tarjeta, A.ColorTarjeta FROM amonestacion A WHERE A.Id_Tarjeta = @Id_Tarjeta", connection);
                sql.Parameters.AddWithValue("@Id_Tarjeta", Id_Tarjeta);
                //Lectura de datos y agregar al combo box los datos
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    //Agregar registros al combo box
                    cbx.Text = ($"{dr[0]}- {dr[1]}");
                }
                connection.Close();
            }
        }

        public void UpdateRegistro(Registro_Amonestacion registro_Amonestacion, int Id_Juego, long Buscar_DPI_Jugador, int Buscar_Id_Tarjeta)
        {
            string query = "EXEC JCGO_Updatet_registro_amonestacion @Id_Juego , @DPI_Jugador, @Id_Tarjeta, @Tiempo , @Buscar_DPI_Jugador, @Buscar_Id_Tarjeta";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //Envia Parametros al Procedimiento
                command.Parameters.AddWithValue("@Id_Juego", Id_Juego);
                command.Parameters.AddWithValue("@DPI_Jugador", registro_Amonestacion.DPI_Jugador);
                command.Parameters.AddWithValue("@Id_Tarjeta", registro_Amonestacion.Id_Tarjeta);
                command.Parameters.AddWithValue("@Tiempo", registro_Amonestacion.Tiempo);
                command.Parameters.AddWithValue("@Buscar_DPI_Jugador", Buscar_DPI_Jugador);
                command.Parameters.AddWithValue("@Buscar_Id_Tarjeta", Buscar_Id_Tarjeta);
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
                    MessageBox.Show("Error al actualizar Registro", ex.Message);
                }
            }
        }

        public void DeleteRegistro(int Id_Juego, long DPI_Jugador, int Id_Tarjeta)
        {
            string query = "EXEC JCGO_Delete_Registro_amonestacion @Id_Juego, @DPI_Jugador, @Id_Tarjeta";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //Envia parametro al procedimiento
                command.Parameters.AddWithValue("@Id_Juego", Id_Juego);
                command.Parameters.AddWithValue("@DPI_Jugador", DPI_Jugador);
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
                    MessageBox.Show("Error al Eliminar Registro", ex.Message);
                }
            }
        }
    }
}
