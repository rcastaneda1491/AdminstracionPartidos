using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using AdminitracionDeTorneosP.Model;




namespace AdminitracionDeTorneosP.Database
{
    public class EUIPO_DB
    {
        private string connectionstring = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";

        SqlConnection conexion;


        public long getEntrenadorDPI(string nombre, string apellido)
        {
            string query = "exec obtener_dpi_entrenadores @nombre, @apellido ";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@nombre", nombre);
                sql.Parameters.AddWithValue("@apellido", apellido);

                connection.Open();
                long DPI = Convert.ToInt64(sql.ExecuteScalar());


                connection.Close();

                return DPI;


            }

        }


        //verifcar conexion
        public void openConexion()
        {
            try
            {
                conexion = new SqlConnection(connectionstring);
                conexion.Open();
                MessageBox.Show("Conexion realizada con exito");
            }
            catch
            {
                MessageBox.Show("NO SEA REALIZADO LA CONEXION");
            }
        }

        // Mostrar Clientes 

        public List<EQUIPO> Muestra_equipos()
        {
            List<EQUIPO> cliente = new List<EQUIPO>();
            string query = "exec BG_Mostrar_Equipos";
            using (SqlConnection conexion = new SqlConnection(connectionstring))
            {

                SqlCommand sql = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        EQUIPO ListaEquipo = new EQUIPO();
                        ListaEquipo.Id_Equipo = reader.GetInt32(0);
                        ListaEquipo.Nombre = reader.GetString(1);
                        ListaEquipo.Representante = reader.GetString(2);
                        ListaEquipo.DPI_Entrenador = reader.GetInt64(3);

                        cliente.Add(ListaEquipo);
                    }
                    reader.Close();
                    conexion.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la base de datos" + ex.Message);
                }
            }
            return cliente;
        }

        // agregar un equipo

        public void Insertar_Equipo(EQUIPO Equipos)
        {
            //$"insert into TIPO_PRODUCTO (NOMBRE)values(@nombre)"+
            string query = "exec BG_Insertar_Equipo @Nombre,@Representante,@DPI_Entrenador";
            using (SqlConnection conexion = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@nombre", Equipos.Nombre);
                sql.Parameters.AddWithValue("@Representante", Equipos.Representante);
                sql.Parameters.AddWithValue("@DPI_Entrenador", Equipos.DPI_Entrenador);


                try
                {
                    conexion.Open();
                    sql.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Equipo ingresado: " + " " + Equipos.Nombre);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("error en el ingreso" + ex.Message);
                }

            }

        }


        //Buscar informacion
        public EQUIPO buscar(int? id)
        {
            EQUIPO Equiposs = new EQUIPO();
            string query = "select*from Equipo where Id_Equipo=@id";
            using (SqlConnection conexion = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@id", id);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read(); //leer solo un registro (read)
                    Equiposs.Id_Equipo = reader.GetInt32(0);
                    Equiposs.Nombre = reader.GetString(1);
                    Equiposs.Representante = reader.GetString(2);
                    Equiposs.DPI_Entrenador = reader.GetInt64(3);


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener solo un registro de la base de datos " + ex.Message);
                }
                return Equiposs;
            }
        }
        // ACTUALIZAR INFORMACION
        public void actualizar_Equipo(int? Id_Equipo, string Nombre, string Representante, long DPI_entrenador)
        {
            //update TIPO_PRODUCTO  set nombre =@nombre where TIPO_PRODUCTO=@id

            string query = "exec BG_Editar_Equipo @Id_Equipo, @Nombre,@Representante,@DPI_Entrenador";
            using (SqlConnection conexion = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@Id_Equipo", Id_Equipo);
                command.Parameters.AddWithValue("@Nombre", Nombre);
                command.Parameters.AddWithValue("@Representante", Representante);
                command.Parameters.AddWithValue("@DPI_Entrenador", DPI_entrenador);



                try
                {
                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Actualizacion Realizada ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en actualizacion" + ex.Message);
                }

            }
        }

        public void eliminar_Equipo(int? id)
        {
            // delete from cliente where TIPO_PRODUCTO=@id
            string query = "exec BG_eliminar_equipo @id";
            using (SqlConnection conexion = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Se a eliminado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error en eliminar " + ex.Message);
                }

            }
        }

    }
}