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
    class ClienteDB
    {
        private string connectionString = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";

        public List<Cliente> getClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            string query = "SELECT * FROM Cliente";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                try
                {
                    connection.Open();

                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente();

                        cliente.id = reader.GetInt32(0);
                        cliente.dpi = reader.GetString(1);
                        cliente.nombres = reader.GetString(2);
                        cliente.apellidos = reader.GetString(3);
                        cliente.telefono = reader.GetString(4);
                        cliente.correo = reader.GetString(5);
                        listaClientes.Add(cliente);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error al obtener los datos");
                }
            }
            return listaClientes;
        }

        public Cliente getClienteById(int idCliente)
        {
            Cliente cliente = new Cliente();
            string query = "SELECT * FROM Cliente WHERE ID = @ID";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@ID", idCliente);
                try
                {
                    connection.Open();
                    
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();

                    cliente.id = reader.GetInt32(0);
                    cliente.dpi = reader.GetString(1);
                    cliente.nombres = reader.GetString(2);
                    cliente.apellidos = reader.GetString(3);
                    cliente.telefono = reader.GetString(4);
                    cliente.correo = reader.GetString(5);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error al obtener los datos de clientes");
                }
                return cliente;
            }
        }

        public void addCliente(Cliente cliente)
        {
            string query = "EXEC SP_ADD_CLIENTE @DPI, @Nombres, @Apellidos, @Telefono, @Correo";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                
                command.Parameters.AddWithValue("@DPI", cliente.dpi);
                command.Parameters.AddWithValue("@Nombres", cliente.nombres);
                command.Parameters.AddWithValue("@Apellidos", cliente.apellidos);
                command.Parameters.AddWithValue("@Telefono", cliente.telefono);
                command.Parameters.AddWithValue("@Correo", cliente.correo);
                try
                {
                    connection.Open();
                
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("El cliente ha sido agregado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error al agregar el cliente");
                }
            }
        }

        public void updateCliente(Cliente cliente)
        {
            string query = "EXEC SP_UPDATE_CLIENTE @ID, @DPI, @Nombres, @Apellidos, @Telefono, @Correo";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //Envia Parametros al Procedimiento
                command.Parameters.AddWithValue("@ID", cliente.id);
                command.Parameters.AddWithValue("@DPI", cliente.dpi);
                command.Parameters.AddWithValue("@Nombres", cliente.nombres);
                command.Parameters.AddWithValue("@Apellidos", cliente.apellidos);
                command.Parameters.AddWithValue("@Telefono", cliente.telefono);
                command.Parameters.AddWithValue("@Correo", cliente.correo);
                try
                {
                    connection.Open();
                    //Ejecuta el query
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("El cliente se ha actualizado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error al actualizar el cliente");
                }
            }
        }

        public void deleteCliente(int idCliente)
        {
            string query = "EXEC SP_DELETE_CLIENTE @ID";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //Envia parametro al procedimiento
                command.Parameters.AddWithValue("@ID", idCliente);
                try
                {
                    connection.Open();
                    //Ejecuta el Query
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("El cliente se ha eliminado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el Cliente", ex.Message);
                }
            }
        }
    }
}
