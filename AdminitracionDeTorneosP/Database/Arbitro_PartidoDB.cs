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
    public class Arbitro_PartidoDB
    {
        private string connectionString = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";

        public Arbitro_Partido GetArbitro(int Id_Juego, long DPI)
        {
            Arbitro_Partido arbitro_Partido = new Arbitro_Partido();
            string query = "SELECT * FROM arbitro_partido WHERE Id_Juego = @Id_Juego AND DPI_Arbitro = @DPI_Arbitro";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Juego", Id_Juego);
                sql.Parameters.AddWithValue("@DPI_Arbitro", DPI);
                try
                {
                    connection.Open();
                    //Ejecuta el query y lee lo q esta en la tabla
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();

                    //Se guarda lo que esta en la tabla en el modelo
                    arbitro_Partido.Pago = reader.GetDecimal(2);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al obtener los datos" + error, "ERROR");
                }
                return arbitro_Partido;
            }
        }

        public List<Arbitro_Partido> Get_Arbitro()
        {
            List<Arbitro_Partido> arbitros_Partido = new List<Arbitro_Partido>();
            string query = "SELECT * FROM arbitro_partido";
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
                        Arbitro_Partido arbitro_Partido = new Arbitro_Partido();
                        //Obtiene los datos de la tabla y se guardan en un lista
                        arbitro_Partido.DPI_Arbitro = reader.GetInt64(0);
                        arbitro_Partido.Id_Juego = reader.GetInt32(1);
                        arbitro_Partido.Pago = reader.GetDecimal(2);
                        arbitros_Partido.Add(arbitro_Partido);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al obtener los datos" + error, "ERROR");
                }
            }
            return arbitros_Partido;
        }

        public void Get_Arbitros(ComboBox cbx)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cbx.Items.Clear();
                connection.Open();
                //Query de consulta para obtener equipos
                SqlCommand sql = new SqlCommand("SELECT A.Nombres, A.Apellidos FROM arbitro A", connection);
                //Lectura de datos y agregar al combo box los datos
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    //Agregar registros al combo box
                    cbx.Items.Add($"{dr[0]} {dr[1]}");
                }
                connection.Close();
            }
        }

        public long DPI_Arbitros(string Nombres, string Apellidos)
        {
            long DPI = 0;
            string query = "EXEC JCGO_GET_DPI_ARBITRO @Nombres , @Apellidos ";
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

        public void AddArbitroPartido(Arbitro_Partido arbitro_Partido, int Id_Juego)
        {
            string query = "EXEC JCGO_Insert_Arbitro_Partido  @DPI_Arbitro,@Id_Juego,@Pago";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //Envia parametros al Proceso Almacenado
                command.Parameters.AddWithValue("@DPI_Arbitro", arbitro_Partido.DPI_Arbitro);
                command.Parameters.AddWithValue("@Id_Juego", Id_Juego);
                command.Parameters.AddWithValue("@Pago", arbitro_Partido.Pago);
                try
                {
                    connection.Open();
                    //Ejecuta el Query
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Arbitro Agregado Correctamente");
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error Este Arbitro ya esta asignado al Partido" + error.Message, "ERROR");
                }
            }
        }

        public void Arbitros(ComboBox cbx, int DPI)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cbx.Items.Clear();
                connection.Open();
                //Query de consulta para obtener equipos
                SqlCommand sql = new SqlCommand("SELECT A.Nombres, A.Apellidos FROM arbitro A WHERE A.DPI = @DPI_Arbitro", connection);
                sql.Parameters.AddWithValue("@DPI_Arbitro", DPI);
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

        public void UpdateArbitroPartido(Arbitro_Partido arbitro_Partido, int Id_Juego, long DPI_Arbitro_Buscar)
        {
            string query = "EXEC JCGO_Update_Arbitro_Partido @DPI_Arbitro ,@Id_Juego ,@Pago ,  @DPI_Arbitro_Buscar";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //Envia Parametros al Procedimiento
                command.Parameters.AddWithValue("@DPI_Arbitro", arbitro_Partido.DPI_Arbitro);
                command.Parameters.AddWithValue("@Id_Juego", Id_Juego);
                command.Parameters.AddWithValue("@Pago", arbitro_Partido.Pago);         
                command.Parameters.AddWithValue("@DPI_Arbitro_Buscar", DPI_Arbitro_Buscar);
                try
                {
                    connection.Open();
                    //Ejecuta el query
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Error Este Arbitro ya esta asignado al Partido");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar Registro", ex.Message);
                }
            }
        }

    }
}
