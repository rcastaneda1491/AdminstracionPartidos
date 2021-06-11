using AdminitracionDeTorneosP.Model;
using AdminitracionDeTorneosP.View;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminitracionDeTorneosP.Database
{
    public class refereeDB
    {
        //ruta de conexion a base de datos 
        //ruta de conexion a base de datos 
        private string connectionstring = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";
        //añadir objeto del tipo refereeModel a la base de datos 
        public void addReferee(refereeModel referee)
        {
            //query de insercion 
            string query = "exec LA_insertar_Arbitro  @DPI, @nombre, @apellido," +
                " @direccion, @telefono, @nacionalidad, @fechaNac, @email, @rol, @precio_hora";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //valores del proceso almacenado 
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@DPI", referee.DPI);
                sql.Parameters.AddWithValue("@nombre", referee.name);
                sql.Parameters.AddWithValue("@apellido", referee.lastname);
                sql.Parameters.AddWithValue("@direccion", referee.address);
                sql.Parameters.AddWithValue("@telefono", referee.phone);
                sql.Parameters.AddWithValue("@nacionalidad", referee.nacionality);
                sql.Parameters.AddWithValue("@fechaNac", referee.birthDate);
                sql.Parameters.AddWithValue("@email", referee.email);
                sql.Parameters.AddWithValue("@rol", referee.role);
                sql.Parameters.AddWithValue("@precio_hora", referee.precio_hora);

                try
                {
                    //Abrir conexion 
                    connection.Open();
                    sql.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Arbitro agregado correctamente!");
                }
                //informar de algún problema 
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar el arbitro la base de datos" + ex.Message);
                }
            }
        }

        public List<refereeModel> getRefereee()
        {
            List<refereeModel> listReferees = new List<refereeModel>();
            //query para obtner daos 
            string query = "exec LA_obtener_Arbitros";
            using (SqlConnection connection = new SqlConnection(connectionstring))
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
                        refereeModel referee = new refereeModel();
                        referee.DPI = reader.GetInt64(0);
                        referee.name = reader.GetString(1);
                        referee.lastname = reader.GetString(2);
                        referee.address = reader.GetString(3);
                        referee.phone = reader.GetString(4);
                        referee.nacionality = reader.GetString(5);
                        referee.birthDate = reader.GetDateTime(6);
                        referee.email = reader.GetString(7);
                        referee.role = reader.GetString(8);
                        referee.precio_hora = reader.GetDecimal(9);
                        listReferees.Add(referee);
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
            return listReferees;
        }

        public void updateReferee(long? DPI, string name, string lastname, string address, string phone, string nacionality, DateTime birthDate, string email, string role, Decimal precio_hora)
        {
            //query para actualizar datos 
            string query = "exec LA_actualizar_Arbitro @DPI, @nombre, @apellido, " +
                "@direccion, @telefono, @nacionalidad, @fechaNa," +
                "@email, @rol, @precio_hora";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                //añadir valor a los procesos almacenados 
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@DPI", DPI);
                sql.Parameters.AddWithValue("@nombre", name);
                sql.Parameters.AddWithValue("@apellido", lastname);
                sql.Parameters.AddWithValue("@direccion", address);
                sql.Parameters.AddWithValue("@telefono", phone);
                sql.Parameters.AddWithValue("@nacionalidad", nacionality);
                sql.Parameters.AddWithValue("@fechaNa", birthDate);
                sql.Parameters.AddWithValue("@email", email);
                sql.Parameters.AddWithValue("@rol", role);
                sql.Parameters.AddWithValue("@precio_hora", precio_hora);

                try
                {
                    //abrir conexion
                    connection.Open();
                    sql.ExecuteNonQuery();
                    //cerrar conexion 
                    connection.Close();
                    MessageBox.Show("Datos del arbitro actualizado correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar los datos del arbitro en la base de datos" + ex.Message);
                }
            }
        }


        public void deleteReferee(long? DPI)
        {
            //query de eliminacion para la base de datos 
            string query = "exec LA_eliminar_Arbitro @DPI";
            //crear la coneccion para la base de datos 
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {

                SqlCommand sql = new SqlCommand(query, connection);
                //enviar y valor valor del parametro mediante el valor del proceso almacenado
                sql.Parameters.AddWithValue("@DPI", DPI);
                try
                {
                    //abrir conexion a la base de datos 
                    connection.Open();
                    sql.ExecuteNonQuery();
                    //cerrar conexion 
                    connection.Close();
                    //notificar al usuario 
                    MessageBox.Show("Registro eliminado correctamente");
                }
                //caso contrario 
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el arbitro en la base de datos" + ex.Message);
                }
            }
        }

        public refereeModel getRefereeByDPI(long? dpi)
        {
            refereeModel referee = new refereeModel();
            //query de obtención de datos mediante dpi
            string query = "LA_obtener_arbitro_por_dpi @DPI";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                //añadir valor al proceso almacenado
                sql.Parameters.AddWithValue("@DPI", dpi);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();
                    //lectura de datos 
                    referee.DPI = reader.GetInt64(0);
                    referee.name = reader.GetString(1);
                    referee.lastname = reader.GetString(2);
                    referee.address = reader.GetString(3);
                    referee.phone = reader.GetString(4);
                    referee.nacionality = reader.GetString(5);
                    referee.birthDate = reader.GetDateTime(6);
                    referee.email = reader.GetString(7);
                    referee.role = reader.GetString(8);
                    referee.precio_hora = reader.GetDecimal(9);
                }
                //informar sobre algun problema
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el arbitro. " + ex.Message);
                }
            }
            //retornar lista obtenida
            return referee;
        }

    }

}
