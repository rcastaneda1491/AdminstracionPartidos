using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using AdminitracionDeTorneosP.Model;
using AdminitracionDeTorneosP.Database;


namespace AdminitracionDeTorneosP.Database
{
   public class GOLEADOR_BD
    {
        private string connectionstring = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";

        public void Get_Torneo(ComboBox cbx)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                cbx.Items.Clear();
                connection.Open();

                SqlCommand sql = new SqlCommand("SELECT * FROM torneo ", connection);
                //  Lectura de datos y agregar al combo box los datos
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    //Agregar registros al combo box
                    cbx.Items.Add(dr[1].ToString());


                }
                connection.Close();
                cbx.Items.Insert(0, "Seleccione una opcion");
                cbx.SelectedIndex = 0;
            }

        }

        public string[] captar_info_nombre_toreno(string Nombre_Torneo)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand("Exec BG_Obtener_Id_toreo @Nombre_Torneo='" + Nombre_Torneo + "'", connection);
                //lee lo que esta en la base de datos
                SqlDataReader dr = sql.ExecuteReader();

                string[] resultado = null;
                while (dr.Read())
                {
                    string[] datos =
                    {
                        //Guarda lo que esta en la posicion 0 de la tabla
                        //nombre de torneo
                        dr[0].ToString(),


                    };
                    resultado = datos;
                }
                connection.Close();
                return resultado;

            }
        }

        public List<GOLEADOR> busqueda_Tarjetas_total(int id_torneo)
        {
            List<GOLEADOR> listado_Goleador = new List<GOLEADOR>();
            string query = "exec J_C_goleadores_equipos @id_torneo='" + id_torneo + "'";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {

                SqlCommand sql = new SqlCommand(query, connec);
                try
                {
                    connec.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        GOLEADOR goleadordatos = new GOLEADOR();

                        goleadordatos.Equipo = reader.GetString(0);
                        goleadordatos.DPI_Jugador = reader.GetInt64(1);
                        goleadordatos.Nombres = reader.GetString(2);
                        goleadordatos.Apellidos = reader.GetString(3);
                        goleadordatos.NumeroCamisola = reader.GetInt32(4);
                        goleadordatos.cantidad_de_goles_anotados = reader.GetInt32(5);
                      

                        listado_Goleador.Add(goleadordatos);
                    }
                    reader.Close();
                    connec.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al traer los datos en la base de datos" + ex.Message);
                }
            }
            return listado_Goleador;
        }





    }
}
