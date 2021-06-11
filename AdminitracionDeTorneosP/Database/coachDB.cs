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
    public class coachDB
    {
        //ruta de conexion a base de datos 
        //ruta de conexion a base de datos 
        private string connectionString = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";

        //añadir objeto del tipo coachModel a la base de datos 
        public void addCoach(coachModel coach)
        {
            //query de insercion 
            string query = "exec LA_agregar_Entrenador @DPI, @nombre, @apellido, @telefono, @fecha_Nacimiento, @correo, @tiempo, @salario ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //valores del proceso almacenado 
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@DPI", coach.DPI);
                sql.Parameters.AddWithValue("@nombre", coach.name);
                sql.Parameters.AddWithValue("@apellido", coach.lastname);
                sql.Parameters.AddWithValue("@telefono", coach.phone);
                sql.Parameters.AddWithValue("@fecha_Nacimiento", coach.birthDate);
                sql.Parameters.AddWithValue("@correo", coach.email);
                sql.Parameters.AddWithValue("@tiempo", coach.time);
                sql.Parameters.AddWithValue("@salario", coach.salary);

                try
                {
                    //Abrir conexion 
                    connection.Open();
                    sql.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Entrenador agregado correctamente!");
                }
                //informar de algún problema 
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar el entrenador a la base de datos" + ex.Message);
                }
            }
        }

        //método para obtener la lista de entrenadores
        public List<coachModel> getCoach()
        {
            List<coachModel> coachesList = new List<coachModel>();
            //query para obtner daos 
            string query = "exec LA_obtner_Entrenadores ";
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
                        coachModel coach = new coachModel();
                        coach.DPI = reader.GetInt64(0);
                        coach.name = reader.GetString(1);
                        coach.lastname = reader.GetString(2);
                        coach.phone = reader.GetString(3);
                        coach.birthDate = reader.GetDateTime(4);
                        coach.email = reader.GetString(5);
                        coach.time = reader.GetString(6);
                        coach.salary = reader.GetDecimal(7);
                        coachesList.Add(coach);
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
            return coachesList;
        }

        //método para actalizar un entrenador 
        public void updateCoach(long? DPI, string name, string lastname, string phone, DateTime birthDate, string email, string time, decimal salary)
        {
            //query para actualizar datos 
            string query = "exec LA_actualizar_Entrenador @DPI, @nombre, @apellido, @telefono, @fecha_Nacimiento, @correo, @tiempo, @salario";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //añadir valor a los procesos almacenados 
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DPI", DPI);
                command.Parameters.AddWithValue("@nombre", name);
                command.Parameters.AddWithValue("@apellido", lastname);
                command.Parameters.AddWithValue("@telefono", phone);
                command.Parameters.AddWithValue("@fecha_Nacimiento", birthDate);
                command.Parameters.AddWithValue("@correo", email);
                command.Parameters.AddWithValue("@tiempo", time);
                command.Parameters.AddWithValue("@salario", salary);

                try
                {
                    //abrir conexion
                    connection.Open();
                    command.ExecuteNonQuery();
                    //cerrar conexion 
                    connection.Close();
                    MessageBox.Show("Datos de entrenador actualizados correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar los datos del entrenador en la base de datos" + ex.Message);
                }
            }
        }

        //método para eliminar un entrenador 
        public void deleteCoach(long? DPI)
        {
            //query de eliminacion para la base de datos 
            string query = "exec LA_eliminar_Entrenador @DPI";
            //crear la coneccion para la base de datos 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(query, connection);
                //enviar y valor valor del parametro mediante el valor del proceso almacenado
                command.Parameters.AddWithValue("@DPI", DPI);
                try
                {
                    //abrir conexion a la base de datos 
                    connection.Open();
                    command.ExecuteNonQuery();
                    //cerrar conexion 
                    connection.Close();
                    //notificar al usuario 
                    MessageBox.Show("Registro eliminado correctamente");
                }
                //caso contrario 
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el entrenador en la base de datos" + ex.Message);
                }
            }
        }

        //método para obtner los datos de un entrenador mediante su dpi 
        public coachModel getCoachByDPI(long? dpi)
        {
            coachModel coach = new coachModel();
            //query de obtención de datos mediante dpi
            string query = "exec LA_obtner_Entrenador_Por_DPI @DPI";
            using (SqlConnection connection = new SqlConnection(connectionString))
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
                    coach.DPI = reader.GetInt64(0);
                    coach.name = reader.GetString(1);
                    coach.lastname = reader.GetString(2);
                    coach.phone = reader.GetString(3);
                    coach.birthDate = reader.GetDateTime(4);
                    coach.email = reader.GetString(5);
                    coach.time = reader.GetString(6);
                    coach.salary = reader.GetDecimal(7);
                }
                //informar sobre algun problema
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el entrenador solicitado. " + ex.Message);
                }
            }
            //retornar lista obtenida
            return coach;
        }


    }
}
