using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminitracionDeTorneosP.Database;
using AdminitracionDeTorneosP.Model;
using System.Data.SqlClient;

namespace AdminitracionDeTorneosP.Database
{
  public  class CANCHA_DB
    {

        private string connectionstring = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";

        SqlConnection conexion;

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
        //Mostrar Cancha
        public List<CANCHA> Muestra_Cancha ()
        {
            List<CANCHA> cliente = new List<CANCHA>();
            string query = "Exec BG_Muestra_Cancha";
            using (SqlConnection conexion = new SqlConnection(connectionstring))
            {

                SqlCommand sql = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        CANCHA Listacancha = new CANCHA();
                        Listacancha.NumeroCancha = reader.GetInt32(0);
                        Listacancha.Nombre = reader.GetString(1);
                        Listacancha.TipoCancha = reader.GetString(2);
                        Listacancha.Disponibilidad = reader.GetString(3);
                        Listacancha.precio_hora = reader.GetDecimal(4);
                       
                        cliente.Add(Listacancha);
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

        // agregar cancha 
        public void Insertar_Cancha(CANCHA Canchaa)
        {
            //$"insert into TIPO_PRODUCTO (NOMBRE)values(@nombre)"+
            string query = "exec BG_Insertar_Cancha @Nombre,@TipoCancha,@Disponibilidad,@precio_hora";
            using (SqlConnection conexion = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, conexion);
                
                sql.Parameters.AddWithValue("@Nombre", Canchaa.Nombre);
                sql.Parameters.AddWithValue("@TipoCancha", Canchaa.TipoCancha);
                sql.Parameters.AddWithValue("@Disponibilidad", Canchaa.Disponibilidad);
                sql.Parameters.AddWithValue("@precio_hora", Canchaa.precio_hora);

                try
                {
                    conexion.Open();
                    sql.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Cancha ingresada: " + " " + Canchaa.Nombre);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("error en el ingreso" + ex.Message);
                }

            }

        }

        //seleccionar cancha 
        //Buscar informacion
        public CANCHA buscar_cancha(int? id)
        {
            CANCHA Canchaa = new CANCHA();
            string query = "select*from Cancha where NumeroCancha=@id";
            using (SqlConnection conexion = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, conexion);
                sql.Parameters.AddWithValue("@id", id);
                try
                {
                    conexion.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read(); //leer solo un registro (read)
                    Canchaa.NumeroCancha = reader.GetInt32(0);
                    Canchaa.Nombre = reader.GetString(1);
                    Canchaa.TipoCancha = reader.GetString(2);
                    Canchaa.Disponibilidad = reader.GetString(3);
                    Canchaa.precio_hora = reader.GetDecimal(4);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener solo un registro de la base de datos " + ex.Message);
                }
                return Canchaa;
            }
        }
        // ACTUALIZAR INFORMACION
        public void actualizar_Cancha(CANCHA agregarcancha)
        {
            //update TIPO_PRODUCTO  set nombre =@nombre where TIPO_PRODUCTO=@id

            string query = "exec BG_Editar_Cancha @NumeroCancha,@Nombre,@TipoCancha,@Disponibilidad,@precio_hora";
            using (SqlConnection conexion = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@NumeroCancha", agregarcancha.NumeroCancha);
                command.Parameters.AddWithValue("@Nombre", agregarcancha.Nombre);
                command.Parameters.AddWithValue("@TipoCancha", agregarcancha.TipoCancha);
                command.Parameters.AddWithValue("@Disponibilidad", agregarcancha.Disponibilidad);
                command.Parameters.AddWithValue("@precio_hora", agregarcancha.precio_hora);

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

        //eliminar cancha 
        public void eliminar_Cancha(int? id)
        {
            // delete from cliente where TIPO_PRODUCTO=@id
            string query = "Exec eliminar_Cancha @NumeroCancha";
            using (SqlConnection conexion = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@NumeroCancha", id);
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
