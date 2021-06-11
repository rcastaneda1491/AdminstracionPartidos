using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.SqlClient;
using System.Windows.Forms;
using AdminitracionDeTorneosP.Model;
using AdminitracionDeTorneosP.View;


namespace AdminitracionDeTorneosP.Database
{
    public class CAMBIO_DB
    {


        //variable que me permitira hacer una conexion a mi base de datos
        private string connectionstring = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";
        SqlConnection conn;
        public int banera_agregar;
        public CAMBIO_DB()
        {
        }

        //METODO PARA BUSCAR A TODOS LOS registros de la tabla cambios de la bases de datos
        public List<CAMBIO> busqueda_CAMBIOS_total()
        {
            List<CAMBIO> listado_cambios = new List<CAMBIO>();
            string query = "exec J_Cgetall_cambios";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {

                SqlCommand sql = new SqlCommand(query, connec);
                try
                {
                    connec.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        CAMBIO cambios = new CAMBIO();

                        cambios.Id_Cambio = reader.GetInt32(0);
                        cambios.Id_Juego = reader.GetInt32(1);
                        cambios.DPI_JugadorEntra = reader.GetInt64(2);
                        cambios.DPI_JugadorSALE = reader.GetInt64(3);
                        cambios.TiempoEntrada = reader.GetInt32(4);
                        cambios.TiempoSalida = reader.GetInt32(5);
                        listado_cambios.Add(cambios);
                    }
                    reader.Close();
                    connec.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al traer los datos en la base de datos" + ex.Message);
                }
            }
            return listado_cambios;
        }




        //metodo praa seleccionar que tipo de informacion se van a mostrtar en los labels de la tabla partidos pero solo de  un registro
        public string[] captar_info_partidos(int codigo)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand("exec J_B_busqueda_solo_un_registr_tabla_partido @id_juego='" + codigo + "'", connection);
                //lee lo que esta en la base de datos
                SqlDataReader dr = sql.ExecuteReader();

                string[] resultado = null;
                while (dr.Read())
                {
                    string[] datos =
                    {
                        //Guarda lo que esta en la posicion 1 de la tabla
                        //nombre de torneo
                        dr[1].ToString(),
                        dr[3].ToString(),
                        dr[4].ToString()
                    };
                    resultado = datos;
                }
                connection.Close();
                return resultado;

            }
        }





        //metodo para mostrar el informacion de los equipos que se mostrara en los label al usuario
        public string[] captar_info_equipos(int id_equipo)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand("exec J_B_buscar_soloun_equipo @id_equipo='" + id_equipo + "'", connection);
                //lee lo que esta en la base de datos
                SqlDataReader dr = sql.ExecuteReader();

                string[] resultado = null;
                while (dr.Read())
                {
                    string[] datos =
                    {
                        //Guarda lo que esta en la posicion 1 de la tabla
                        //nombre de torneo
                        dr[1].ToString(),

                    };
                    resultado = datos;
                }
                connection.Close();
                return resultado;

            }
        }


        //metodo para llenar los combobox con los jugadores que existen dentro de los equipos que han juagado en el id juego
        public void busqueda_tabla_jugadoress_por_equipo(ComboBox cc, int id_juego, int id_torneo)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                cc.Items.Clear();
                connection.Open();
                SqlCommand sql = new SqlCommand("exec J_C_buscar_los_nombres__juga_de_equipoosssss @nombre_equipo=chelsea'" + id_juego + "'" + "," + "@id_torneo='" + id_torneo + "'", connection);
                //lee lo que esta en la tabla                      
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    //se guarda en una variable lo que esta en la posicion 1 de la tabla que seria el ID
                    cc.Items.Add(dr[0].ToString());
                }
                connection.Close();
                //mensaje q se mostrara en el combobox
                //cc.Items.Insert(0, "----Seleccione un Torneo----");
                //cc.SelectedIndex = 0;
            }
        }


        //metodo para poner en texbox el dpi del jugador y el  numero del equipo al que pertence segun su nombre
        public string[] captar_info_jugador_dpi_equipo(string nombre)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand("exec J_B_buscar_jugador_por_nombre  @nombres='" + nombre + "'", connection);
                //lee lo que esta en la base de datos
                SqlDataReader dr = sql.ExecuteReader();

                string[] resultado = null;
                while (dr.Read())
                {
                    string[] datos =
                    {
                        //Guarda lo que esta en la posicion 1 de la tabla
                        //nombre de torneo
                        dr[0].ToString(),
                        dr[1].ToString()

                    };
                    resultado = datos;
                }
                connection.Close();
                return resultado;

            }
        }


        //metodo para poner en texbox el nombre del equipo al que pertenece cada jugador segun su dpi
        public string[] captar_info_nombre_equipo_id_equipo(int codigo_equipo)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand("exec J_B_buscar_nombre_equipo_codigo_equipo  @id_equipo='" + codigo_equipo + "'", connection);
                //lee lo que esta en la base de datos
                SqlDataReader dr = sql.ExecuteReader();

                string[] resultado = null;
                while (dr.Read())
                {
                    string[] datos =
                    {
                        //Guarda lo que esta en la posicion 1 de la tabla
                        //nombre de torneo
                        dr[0].ToString(),


                    };
                    resultado = datos;
                }
                connection.Close();
                return resultado;

            }
        }


        //metodo para insertar nuevos cambios en los juegos
        public void Agregar_nuevos_cambios(CAMBIO tipo_cambio)
        {
            //$"insert into TIPO_PRODUCTO (NOMBRE)values(@nombre)"+
            string query = "exec J_C_Agregar_cambio  @Id_Juego,@DPI_JugadorEntra,@DPI_JugadorSALE,@TiempoEntrada,@TiempoSalida";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connec);
                sql.Parameters.AddWithValue("@Id_Juego", tipo_cambio.Id_Juego);
                sql.Parameters.AddWithValue("@DPI_JugadorEntra", tipo_cambio.DPI_JugadorEntra);
                sql.Parameters.AddWithValue("@DPI_JugadorSALE", tipo_cambio.DPI_JugadorSALE);
                sql.Parameters.AddWithValue("@TiempoEntrada", tipo_cambio.TiempoEntrada);
                sql.Parameters.AddWithValue("@TiempoSalida", tipo_cambio.TiempoSalida);



                try
                {
                    connec.Open();
                    sql.ExecuteNonQuery();
                    connec.Close();
                    MessageBox.Show("Se Realizo correctamente LA SUSTITUCION de jugadores ");
                    banera_agregar = 1;
                }
                catch (Exception ex)
                {
                    banera_agregar = 0;
                    MessageBox.Show("ERROR " + ex.Message);
                }

            }

        }


        //metodo que servira para seleccionar un registro de cambios para editar
        public CAMBIO Get_cambios_A_EDITAR(int? id_cambio)
        {
            CAMBIO cambio_editar = new CAMBIO();
            string query = "exec J_C_buscar_editar_cambio    @Id_Cambio";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connec);
                sql.Parameters.AddWithValue("@Id_Cambio", id_cambio); //pasandole a la variable el parametro
                try
                {
                    connec.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read(); //leer solo un registro (read)
                    cambio_editar.Id_Cambio = reader.GetInt32(0);
                    cambio_editar.Id_Juego = reader.GetInt32(1);
                    cambio_editar.DPI_JugadorEntra = reader.GetInt64(2);
                    cambio_editar.DPI_JugadorSALE = reader.GetInt64(3);
                    cambio_editar.TiempoEntrada = reader.GetInt32(4);
                    cambio_editar.TiempoSalida = reader.GetInt32(5);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener solo un registro de la base de datos " + ex.Message);
                }
                return cambio_editar;
            }
        }

        //metodo par actualizar la tabla cambios de la bases de datos
        public void Actualizar_sustituciones(int? id_cambio, long dpi_entra, long dpisale, int tiempo_entra, int tiempo_sale)
        {


            string query = "exec J_C_actualizar_cambios  @Id_Cambio,@DPI_JugadorEntra,@DPI_JugadorSALE,@TiempoEntrada,@TiempoSalida";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(query, connec);
                command.Parameters.AddWithValue("@Id_Cambio", id_cambio);
                command.Parameters.AddWithValue("@DPI_JugadorEntra", dpi_entra);
                command.Parameters.AddWithValue("@DPI_JugadorSALE", dpisale);
                command.Parameters.AddWithValue("@TiempoEntrada", tiempo_entra);
                command.Parameters.AddWithValue("@TiempoSalida", tiempo_sale);

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




        //metodo para elimar la tabla cambios, se va eliminar un solo registro
        public void Eliminar_sustitucion(int? id_cambio)
        {
            // delete from TIPO_PRODUCTO  where TIPO_PRODUCTO=@id
            string query = "exec J_C_eliminar_sustitucion  @Id_Cambio";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(query, connec);
                command.Parameters.AddWithValue("@Id_Cambio", id_cambio);
                try
                {
                    connec.Open();
                    command.ExecuteNonQuery();
                    connec.Close();
                    MessageBox.Show("Se elimino un registro de SUSTITUCIONES.\n CODIGO CAMBIO: " + id_cambio);
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR..........\nNo se puede eliminar a esta sustitucion,se esta usando el codigo cambio en otra tabla");
                }

            }
        }


        //metodo para llenar los combobox con los jugadores que existen dentro de los equipos que han juagado en el id juego
        public void buscar_codigos_equipos_ids(ComboBox cc, int id_juego, int id_torneo)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                cc.Items.Clear();
                connection.Open();
                SqlCommand sql = new SqlCommand("exec J_C_busqueda_equipos_id_juego_nombresss  @Id_Juego='" + id_juego + "'" + "," + "@id_torneo='" + id_torneo + "'", connection);
                //lee lo que esta en la tabla
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    //se guarda en una variable lo que esta en la posicion 1 de la tabla que seria el ID
                    cc.Items.Add(dr[0].ToString());
                    cc.Items.Add(dr[1].ToString());

                }
                connection.Close();
                //mensaje q se mostrara en el combobox
                //cc.Items.Insert(0, "----Seleccione un Torneo----");
                //cc.SelectedIndex = 0;
            }
        }



        //metodo para llenar los combobox con los jugadores que existen dentro de los equipos que han juagado en el id juego
        public void buscar_jugadores_segun_equipo(ComboBox cc, string nombre_equippo, int id_torneo)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                cc.Items.Clear();
                connection.Open();
                SqlCommand sql = new SqlCommand("exec J_C_buscar_los_nombres__juga_de_equipoosssss @nombre_equipo='" + nombre_equippo + "'" + "," + "@id_torneo='" + id_torneo + "'", connection);
                //lee lo que esta en la tabla
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    //se guarda en una variable lo que esta en la posicion 1 de la tabla que seria el ID
                    cc.Items.Add(dr[0].ToString());


                }
                connection.Close();
                //mensaje q se mostrara en el combobox
                //cc.Items.Insert(0, "----Seleccione un Torneo----");
                //cc.SelectedIndex = 0;
            }
        }

        //procedimiento para extraer la hora inicial  del partido

        public string[] captar_info_horas_de_partidos(int id_juego)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand("exec J_C_obtener_horas_de_partido @Id_Juego='" + id_juego + "'", connection);
                //lee lo que esta en la base de datos
                SqlDataReader dr = sql.ExecuteReader();

                string[] resultado = null;
                while (dr.Read())
                {
                    string[] datos =
                    {
                        //Guarda lo que esta en la posicion 1 de la tabla
                        //nombre de torneo
                        dr[0].ToString(),
                        dr[1].ToString(),

                    };
                    resultado = datos;
                }
                connection.Close();
                return resultado;

            }
        }
    }
}

