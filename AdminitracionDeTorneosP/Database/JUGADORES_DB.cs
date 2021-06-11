using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using AdminitracionDeTorneosP.Model;

namespace AdminitracionDeTorneosP.Database
{
    public class JUGADORES_DB
    {

        //variable que me permitira hacer una conexion a mi base de datos
        private string connectionstring = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";
        SqlConnection conn;
        public int banera_agregar;
        public JUGADORES_DB()
        {
        }
        //metodo para verificar si existe la conexion a la base de datos
        public void OPENCONEXION()
        {
            try
            {
                conn = new SqlConnection(connectionstring);
                conn.Open();
                MessageBox.Show("Conexion a la base de datos con exito!!!!!! ADMINISTRACION DE JUGADORES");
            }
            catch
            {
                MessageBox.Show("No se pudo conectar a abase de datos ");
            }

        }

        //METODO PARA BUSCAR A TODOS LOS JUGADORES
        public List<JUGADORES> busqueda_jugadores_total()
        {
            List<JUGADORES> listado_jugadores = new List<JUGADORES>();
            string query = "exec J_C_getalljugadores";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {

                SqlCommand sql = new SqlCommand(query, connec);
                try
                {
                    connec.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        JUGADORES jugador = new JUGADORES();

                        jugador.DPI_Jugador = reader.GetInt64(0);
                        jugador.Nombres = reader.GetString(1);
                        jugador.Apellidos = reader.GetString(2);
                        jugador.Fecha_nac = reader.GetDateTime(3);
                        jugador.Direccion = reader.GetString(4);
                        jugador.Nacionalidad = reader.GetString(5);
                        jugador.Correo = reader.GetString(6);
                        jugador.Telefono = reader.GetString(7);
                        listado_jugadores.Add(jugador);
                    }
                    reader.Close();
                    connec.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al traer los datos en la base de datos" + ex.Message);
                }
            }
            return listado_jugadores;
        }



        //metodo para insertar nuevos productos
        public void Agregar_Jugadores(JUGADORES tipo_jugador)
        {
            //$"insert into TIPO_PRODUCTO (NOMBRE)values(@nombre)"+
            string query = "exec J_C_INSETAR_JUGADOR @DPI_Jugador,@Nombres,@Apellidos,@Fecha_nac,@Direccion,@Nacionalidad,@Correo,@Telefono";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connec);
                sql.Parameters.AddWithValue("@DPI_Jugador", tipo_jugador.DPI_Jugador);
                sql.Parameters.AddWithValue("@Nombres", tipo_jugador.Nombres);
                sql.Parameters.AddWithValue("@Apellidos", tipo_jugador.Apellidos);
                sql.Parameters.AddWithValue("@Fecha_nac", tipo_jugador.Fecha_nac);
                sql.Parameters.AddWithValue("@Direccion", tipo_jugador.Direccion);
                sql.Parameters.AddWithValue("@Nacionalidad", tipo_jugador.Nacionalidad);
                sql.Parameters.AddWithValue("@Correo", tipo_jugador.Correo);
                sql.Parameters.AddWithValue("@Telefono", tipo_jugador.Telefono);

                try
                {
                    connec.Open();
                    sql.ExecuteNonQuery();
                    connec.Close();
                    MessageBox.Show("Se Agrego correctamente el jugador: " + " " + tipo_jugador.Nombres + " " + tipo_jugador.Apellidos);
                    banera_agregar = 1;
                }
                catch (Exception)
                {
                    banera_agregar = 0;
                    MessageBox.Show("ERROR no se puede agregar, este numero de (DPI / CEDULA / CUI) ya esta en USO", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        //metodo que me permitira buscar informacion de los jugadores
        public JUGADORES Get_jugador_A_EDITAR(long? dpi)
        {
            JUGADORES jugador_editar = new JUGADORES();
            string query = "exec J_C_buscar_jugador_por_id @dpi_jugador";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connec);
                sql.Parameters.AddWithValue("@dpi_jugador", dpi); //pasandole a la variable el parametro
                try
                {
                    connec.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read(); //leer solo un registro (read)
                    jugador_editar.DPI_Jugador = reader.GetInt64(0);
                    jugador_editar.Nombres = reader.GetString(1);
                    jugador_editar.Apellidos = reader.GetString(2);
                    jugador_editar.Fecha_nac = reader.GetDateTime(3);
                    jugador_editar.Direccion = reader.GetString(4);
                    jugador_editar.Nacionalidad = reader.GetString(5);
                    jugador_editar.Correo = reader.GetString(6);
                    jugador_editar.Telefono = reader.GetString(7);


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener solo un registro de la base de datos " + ex.Message);
                }
                return jugador_editar;
            }
        }



        //metodo para actualizar la informacion de los jugadores
        public void Actualizar_jugador(long? dpi_jugador_actualizar, string nombre_actualizar, string apellido_actualizar, DateTime fecha_actualizar, string direccion_actualizar, string nacionalidad_actualizar, string correo_actualizar, string telefono_actualizar)
        {


            string query = "exec J_C_editar_jugadores @DPI_Jugador,@Nombres,@Apellidos,@Fecha_nac,@Direccion,@Nacionalidad,@Correo,@Telefono";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(query, connec);
                command.Parameters.AddWithValue("@DPI_Jugador", dpi_jugador_actualizar);
                command.Parameters.AddWithValue("@Nombres", nombre_actualizar);
                command.Parameters.AddWithValue("@Apellidos", apellido_actualizar);
                command.Parameters.AddWithValue("@Fecha_nac", fecha_actualizar);
                command.Parameters.AddWithValue("@Direccion", direccion_actualizar);
                command.Parameters.AddWithValue("@Nacionalidad", nacionalidad_actualizar);
                command.Parameters.AddWithValue("@Correo", correo_actualizar);
                command.Parameters.AddWithValue("@Telefono", telefono_actualizar);
                try
                {
                    connec.Open();
                    command.ExecuteNonQuery();
                    connec.Close();
                    MessageBox.Show("Actualizacion Correcta ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puedo actualizra en la base de datos" + ex.Message);
                }

            }
        }



        //metodo para eliminar
        public void Eliminar_jugador(long? dpi_jugador)
        {
            // delete from TIPO_PRODUCTO  where TIPO_PRODUCTO=@id
            string query = "exec J_B_eliminar_jugador @dpi";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(query, connec);
                command.Parameters.AddWithValue("@dpi", dpi_jugador);
                try
                {
                    connec.Open();
                    command.ExecuteNonQuery();
                    connec.Close();
                    MessageBox.Show("Se elimino un registro al jugador.\n DPI:" + dpi_jugador);
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR..........\nNo se puede eliminar a este Jugador, este jugador esta relacionado\nSi quiere ELIMINAR este jugador\nAsegurese primero de borrar sus relaciones");
                }

            }
        }
    }
}

