using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminitracionDeTorneosP.Database
{
    class LoginDB
    {
        private string connectionString = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";

        public string getRol(int id_user)
        {
            string rol = "";
            string query = $"EXEC SP_ROLUSER {id_user}";
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
                        rol = reader.GetString(0);

                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Usuario incorrecto o no existente");
                }
            }
            return rol;
        }

        public int getId(string user, string contraseña)
        {
            int id = 1;
            string query = $"EXEC estadoid '{user}', '{contraseña}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
                reader.Close();
                connection.Close();
            }
            return id;
        }


        public Boolean getEstado(string user, string contraseña)
        {
            Boolean estado = false;
            string query = $"EXEC SP_ESTADOUSUARIO '{user}', '{contraseña}'";
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
                        estado = reader.GetBoolean(0);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Usuario incorrecto o no existente");
                }
            }
            return estado;
        }


        public void addBitacora(int ID_USUARIO, string Accion, string FECHA, string HORA)
        {
            string query = "EXEC SP_INSERT_BITACORA  @IdUsuario, @ACCION,@FECHA, @HORA";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //Envia parametros al Proceso Almacenado
                command.Parameters.AddWithValue("@IdUsuario", ID_USUARIO);
                command.Parameters.AddWithValue("@ACCION", Accion);
                command.Parameters.AddWithValue("@FECHA", FECHA);
                command.Parameters.AddWithValue("@HORA", HORA);
                try
                {
                    connection.Open();
                    //Ejecuta el Query
                    command.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error" + error.Message, "ERROR");
                }
            }
        }
    }
}
