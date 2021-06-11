using AdminitracionDeTorneosP.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminitracionDeTorneosP.Database
{
    class AlquilerCanchaDB
    {
        private string connectionString = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";

        public void getAlquiler(DataGridView list)
        {
            string query = "EXEC SP_VIEW_ALQUILER";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    //Adaptador para almacenar consulta

                    SqlDataAdapter sqll = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();

                    //Cargar tabla con la informacion de la consulta
                    sqll.Fill(data);
                    //Cargar datos en lista
                    list.DataSource = data;
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se pudo realizar la consulta");
                }
            }
        }

        public void getClientes(ComboBox cbx)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cbx.Items.Clear();
                connection.Open();
                SqlCommand sql = new SqlCommand("SELECT * FROM CLIENTE", connection);
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    cbx.Items.Add($"{dr[2]} {dr[3]}");
                }
                connection.Close();
            }
        }

        public void getCanchas(ComboBox cbx, DateTime Fecha_Apartada, TimeSpan Hora_Inicio, TimeSpan Hora_Final)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cbx.Items.Clear();
                connection.Open();
                //Query de consulta para obtener equipos
                SqlCommand sql = new SqlCommand("EXEC SP_CANCHA_DISPONIBLE @Fecha_Apartada, @Hora_Inicio,@Hora_Final", connection);
                sql.Parameters.AddWithValue("@Fecha_Apartada", Fecha_Apartada);
                sql.Parameters.AddWithValue("@Hora_Inicio", Hora_Inicio);
                sql.Parameters.AddWithValue("@Hora_Final", Hora_Final);
                //Lectura de datos y agregar al combo box los datos
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    //Agregar registros al combo box
                    cbx.Items.Add($"{dr[0]}| {dr[1]}");
                }
                connection.Close();
            }
        }


        public void addAlquilerCancha(AlquilarCancha alquiler_Cancha)
        {
            string query = "EXEC SP_ADD_AlQUILER @NoCancha  ,@ID_CLIENTE , @Fecha_Apartada ,@Hora_Inicio ,@Hora_Final ,@Total_Precio";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //Envia parametros al Proceso Almacenado
                command.Parameters.AddWithValue("@NoCancha", alquiler_Cancha.NumeroCancha);
                command.Parameters.AddWithValue("@ID_CLIENTE", alquiler_Cancha.IDCliente);
                command.Parameters.AddWithValue("@Fecha_Apartada", alquiler_Cancha.FechaApartada);
                command.Parameters.AddWithValue("@Hora_Inicio", alquiler_Cancha.HoraInicio);
                command.Parameters.AddWithValue("@Hora_Final", alquiler_Cancha.HoraFinal);
                command.Parameters.AddWithValue("@Total_Precio", alquiler_Cancha.TotalPrecio);
                try
                {
                    connection.Open();
                    //Ejecuta el Query
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Alquiler Agregado Correctamente");
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al insertar Alquiler" + error.Message, "ERROR");
                }
            }
        }


        public int getIdCliente(string Nombres, string Apellidos)
        {
            int ID = 0;
            string query = "EXEC SP_ID_CLIENTE @Nombres , @Apellidos";
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
                    ID = reader.GetInt32(0);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al obtener los datos" + error, "ERROR");
                }
                return ID;
            }

        }

        public decimal getPrecioCancha(int NOCANCHA)
        {
            decimal precio = 0;
            string query = "EXEC SP_PRECIO_CANCHA @NOCANCHA";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@NOCANCHA", NOCANCHA);
                try
                {
                    connection.Open();
                    //Ejecuta el query y lee lo q esta en la tabla
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();

                    //Se guarda lo que esta en la tabla en el modelo
                    precio = reader.GetDecimal(0);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al obtener los datos" + error, "ERROR");
                }
                return precio;
            }

        }

        public decimal totalAlquilerCancha(TimeSpan Hora_Inicio, TimeSpan Hora_Final, int NOCANCHA)
        {
            decimal Total = 0;
            string query = "EXEC SP_PRECIO_TOTAL @Hora_Inicio, @Hora_Final, @NOCANCHA";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Hora_Inicio", Hora_Inicio);
                sql.Parameters.AddWithValue("@Hora_Final", Hora_Final);
                sql.Parameters.AddWithValue("@NOCANCHA", NOCANCHA);
                try
                {
                    connection.Open();
                    //Ejecuta el query y lee lo q esta en la tabla
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();

                    //Se guarda lo que esta en la tabla en el modelo
                    Total = reader.GetDecimal(0);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al obtener los datos" + error, "ERROR");
                }
                return Total;
            }
        }

        public decimal totalPrecioArbitraje(TimeSpan Hora_Inicio, TimeSpan Hora_Final, int DPI_ARBITRO)
        {
            decimal TotalAArbitraje = 0;
            string query = "EXEC SP_PRECIO_TOTAL_ARBITRAJE @Hora_Inicio , @Hora_Final , @DPI_ARBITRO";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Hora_Inicio", Hora_Inicio);
                sql.Parameters.AddWithValue("@Hora_Final", Hora_Final);
                sql.Parameters.AddWithValue("@DPI_ARBITRO", DPI_ARBITRO);
                try
                {
                    connection.Open();
                    //Ejecuta el query y lee lo q esta en la tabla
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();

                    //Se guarda lo que esta en la tabla en el modelo
                    TotalAArbitraje = reader.GetDecimal(0);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al obtener los datos" + error, "ERROR");
                }
                return TotalAArbitraje;
            }
        }


        public void getArbitroDisponible(ComboBox cbx, DateTime fechaApartada, TimeSpan horaInicio, TimeSpan horaFinal)
        {
            string query = "EXEC SP_ARBITRO_DISPONIBLE @FechaApartada, @HoraInicio,@HoraFinal";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cbx.Items.Clear();
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@FechaApartada", fechaApartada);
                sql.Parameters.AddWithValue("@HoraInicio", horaInicio);
                sql.Parameters.AddWithValue("@HoraFinal", horaFinal);
                try
                {
                    connection.Open();
                    //Ejecuta el query
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        cbx.Items.Add($"{reader[0]}| {reader[1]} {reader[2]}");
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error al obtener los datos");
                }
            }
        }

        public void addArbitroAlquilado(DateTime Fecha_Apartada, TimeSpan Hora_Inicio, TimeSpan Hora_Final, int DPI, int ID_Alquiler, Decimal Total_Precio)
        {
            string query = "EXEC SP_INSERT_ARBITRAJE_ALQUILADO @Fecha_Apartado , @Hora_Inicio , @Hora_Final , @DPI_Arbitro ,@ID_ALQUILER ,@Total_Precio_Arbitro ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //Envia parametros al Proceso Almacenado
                command.Parameters.AddWithValue("@Fecha_Apartado", Fecha_Apartada);
                command.Parameters.AddWithValue("@Hora_Inicio", Hora_Inicio);
                command.Parameters.AddWithValue("@Hora_Final", Hora_Final);
                command.Parameters.AddWithValue("@DPI_Arbitro", DPI);
                command.Parameters.AddWithValue("@ID_ALQUILER", ID_Alquiler);
                command.Parameters.AddWithValue("@Total_Precio_Arbitro", Total_Precio);
                try
                {
                    connection.Open();
                    //Ejecuta el Query
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al insertar Alquiler" + error.Message, "ERROR");
                }
            }
        }




        public int getIdAlquiler()
        {
            int ID = 0;
            string query = "SELECT TOP 1 * FROM ALQUILER_CANCHA ORDER BY ID DESC";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();

                    ID = reader.GetInt32(0);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al obtener los datos" + error, "ERROR");
                }
                return ID;
            }
        }


        public List<Horario> getHorario()
        {
            List<Horario> horarios = new List<Horario>();
            string query = "SELECT * FROM HORARIO";
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
                        Horario horario = new Horario();
                        //Obtiene los datos de la tabla y se guardan en un lista
                        horario.dia = reader.GetString(0);
                        horario.horaApertura = reader.GetTimeSpan(1);
                        horario.horaCierre = reader.GetTimeSpan(2);
                        horarios.Add(horario);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al obtener los datos" + error, "ERROR");
                }
            }
            return horarios;
        }

        public void deleteAlquiler(int id)
        {
            string query = "EXEC SP_DELETE_ALQUILER_CANCHA @ID";
            string query2 = "EXEC SP_DELETE_ALQUILER_ARBITRO @ID";
            //crear la coneccion para la base de datos 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand sql = new SqlCommand(query, connection);
                SqlCommand sql2 = new SqlCommand(query2, connection);

                //enviar y valor valor del parametro mediante el valor del proceso almacenado
                sql.Parameters.AddWithValue("@ID", id);
                sql2.Parameters.AddWithValue("@ID", id);
                try
                {
                    //abrir conexion a la base de datos 
                    connection.Open();
                    sql2.ExecuteNonQuery();
                    sql.ExecuteNonQuery();
                    //cerrar conexion 
                    connection.Close();
                    //notificar al usuario 
                    MessageBox.Show("Registro eliminado correctamente");
                }
                //caso contrario 
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(),"Error al eliminar el alquiler");
                }
            }
        }
    }
}
