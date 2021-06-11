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
    class UsuariosDB
    {
        private string connectionString = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";


        public List<Usuarios> getUsuarios()
        {
            List<Usuarios> usuarios = new List<Usuarios>();
            string query = "SELECT * FROM USUARIOS";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                try
                {
                    connection.Open();

                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        Usuarios Usuario = new Usuarios();

                        Usuario.id = reader.GetInt32(0);
                        Usuario.dpi = reader.GetString(1);
                        Usuario.nombres = reader.GetString(2);
                        Usuario.apellidos = reader.GetString(3);
                        Usuario.usuario = reader.GetString(4);
                        Usuario.contrasena = reader.GetString(5);
                        Usuario.telefono = reader.GetString(6);
                        Usuario.direccion = reader.GetString(7);
                        Usuario.correo = reader.GetString(8);
                        Usuario.puesto = reader.GetString(9);
                        Usuario.rol = reader.GetString(10);
                        Usuario.estado = reader.GetBoolean(11);
                        usuarios.Add(Usuario);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error al obtener los datos");
                }
            }
            return usuarios;
        }

        public Usuarios getUsuarioByID(int usuarioID)
        {
            Usuarios usuarios = new Usuarios();
            string query = "SELECT * FROM USUARIOS WHERE ID = @ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@ID", usuarioID);
                try
                {
                    connection.Open();

                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();

                    usuarios.id = reader.GetInt32(0);
                    usuarios.dpi = reader.GetString(1);
                    usuarios.nombres = reader.GetString(2);
                    usuarios.apellidos = reader.GetString(3);
                    usuarios.usuario = reader.GetString(4);
                    usuarios.contrasena = reader.GetString(5);
                    usuarios.telefono = reader.GetString(6);
                    usuarios.direccion = reader.GetString(7);
                    usuarios.correo = reader.GetString(8);
                    usuarios.puesto = reader.GetString(9);
                    usuarios.rol = reader.GetString(10);
                    usuarios.estado = reader.GetBoolean(11);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error al obtener los datos");
                }
                return usuarios;
            }
        }

        public void addUsuarios(Usuarios usuarios)
        {
            string query = "EXEC SP_ADD_USUARIO  @DPI, @Nombres,@Apellidos,@Usuario,@Contrasena,@Telefono,@Direccion ,@Correo ,@Puesto ,@Rol";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand sql= new SqlCommand(query, connection);

                    sql.Parameters.AddWithValue("@DPI", usuarios.dpi);
                    sql.Parameters.AddWithValue("@Nombres", usuarios.nombres);
                    sql.Parameters.AddWithValue("@Apellidos", usuarios.apellidos);
                    sql.Parameters.AddWithValue("@Usuario", usuarios.usuario);
                    sql.Parameters.AddWithValue("@Contrasena", usuarios.contrasena);
                    sql.Parameters.AddWithValue("@Telefono", usuarios.telefono);
                    sql.Parameters.AddWithValue("@Direccion", usuarios.direccion);
                    sql.Parameters.AddWithValue("@Correo", usuarios.correo);
                    sql.Parameters.AddWithValue("@Puesto", usuarios.puesto);
                    sql.Parameters.AddWithValue("@Rol", usuarios.rol);

                    connection.Open();

                    sql.ExecuteNonQuery();
                    MessageBox.Show("El usuario se ha agregado correctamente");
                    
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error al agregar usuario");
                }
            }
        }

        public void updateUsuario(Usuarios usuario)
        {
            string query = "EXEC SP_UPDATE_USUARIO @ID,@DPI,@Nombres,@Apellidos,@Usuario,@Contrasena,@Telefono,@Direccion ,@Correo ,@Puesto ,@Rol";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //Envia Parametros al Procedimiento
                command.Parameters.AddWithValue("@ID", usuario.id);
                command.Parameters.AddWithValue("@DPI", usuario.dpi);
                command.Parameters.AddWithValue("@Nombres", usuario.nombres);
                command.Parameters.AddWithValue("@Apellidos", usuario.apellidos);
                command.Parameters.AddWithValue("@Usuario", usuario.usuario);
                command.Parameters.AddWithValue("@Contrasena", usuario.contrasena);
                command.Parameters.AddWithValue("@Telefono", usuario.telefono);
                command.Parameters.AddWithValue("@Direccion", usuario.direccion);
                command.Parameters.AddWithValue("@Correo", usuario.correo);
                command.Parameters.AddWithValue("@Puesto", usuario.puesto);
                command.Parameters.AddWithValue("@Rol", usuario.rol);
                try
                {
                    connection.Open();
                    //Ejecuta el query
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("El usuario se ha actualizado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error al modificar usuario");
                }
            }
        }

        public void desactivarUsuario (int ID, Boolean estado)
        {
            string query = "EXEC SP_DESACTIVAR_USER @ID, @Estado";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //Envia parametro al procedimiento
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Estado", estado);
                try
                {
                    connection.Open();
                    //Ejecuta el Query
                    command.ExecuteNonQuery();
                    connection.Close();
                    if(estado == true)
                    {
                        MessageBox.Show("El usuario se ha deshabilitado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("El usuario se ha habilitado correctamente");
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error al deshabilitar usuario");
                }
            }
        }
    }
}
