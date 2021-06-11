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
    public class PAGOS_TARGETAS_DB
    {
        private string connectionstring = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";
        SqlConnection conn;
        public int banera_agregar;
        public PAGOS_TARGETAS_DB()
        {


        }


        //METODO PARA BUSCAR A TODOS Los reistros de la tabla regsitro amonestaciones
        public List<PAGOS_TAREGTAS> busqueda_pagos_targetas_total()
        {
            List<PAGOS_TAREGTAS> listado_de_pagos = new List<PAGOS_TAREGTAS>();
            string query = "exec J_B_get_all_registro_amonestacion";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {

                SqlCommand sql = new SqlCommand(query, connec);
                try
                {
                    connec.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        PAGOS_TAREGTAS pagos = new PAGOS_TAREGTAS();

                        pagos.Id_Juego = reader.GetInt32(1);
                        pagos.DPI_Jugador = reader.GetInt64(2);
                        pagos.Id_Tarjeta = reader.GetInt32(3);
                        pagos.Tiempo = reader.GetString(4);
                        pagos.Pagada = reader.GetString(5);
                        pagos.Fecha_Pago = reader.GetString(6);
                        listado_de_pagos.Add(pagos);
                    }
                    reader.Close();
                    connec.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al traer los datos en la base de datos" + ex.Message);
                }
            }
            return listado_de_pagos;
        }

        //metodo que servira para seleccionar un registro de cambios para editar
        public PAGOS_TAREGTAS Get_pagos_A_EDITAR(int? id_juego)
        {
            PAGOS_TAREGTAS pagos_editar = new PAGOS_TAREGTAS();
            string query = "exec J_B_busqueda_registro_pago_id_codigo  @Id_Juego";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connec);
                sql.Parameters.AddWithValue("@Id_Juego", id_juego); //pasandole a la variable el parametro
                try
                {
                    connec.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read(); //leer solo un registro (read)
                    pagos_editar.Id_Juego = reader.GetInt32(1);
                    pagos_editar.DPI_Jugador = reader.GetInt64(2);
                    pagos_editar.Id_Tarjeta = reader.GetInt32(3);
                    pagos_editar.Tiempo = reader.GetString(4);
                    pagos_editar.Pagada = reader.GetString(5);
                    pagos_editar.Fecha_Pago = reader.GetString(6);




                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener solo un registro de la base de datos " + ex.Message);
                }
                return pagos_editar;
            }
        }
        //MEOTODO PARTA BUSCAR EL NOMBRE DEL JUGADOR SEGUN DPI
        public string[] captar_nombre_jugadores(int DPI_JUGADOR)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand("exec nombre_jug_dpi_pago_targeta @dpi='" + DPI_JUGADOR + "'", connection);
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





        //metodo par actualizar la tabla cambios de la bases de datos
        public void Actualizar_pagos_targetas(int? id_juego, string pagada, DateTime fecha_pago)
        {


            string query = "exec J_C_actualizar_pagos    @Id_Juego,@Pagada,@Fecha_Pago";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(query, connec);
                command.Parameters.AddWithValue("@Id_Juego", id_juego);
                command.Parameters.AddWithValue("@Pagada", pagada);
                command.Parameters.AddWithValue("@Fecha_Pago", fecha_pago);
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
    }
}