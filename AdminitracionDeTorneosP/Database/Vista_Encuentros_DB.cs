using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using AdminitracionDeTorneosP.Database;
using AdminitracionDeTorneosP.Model;

namespace AdminitracionDeTorneosP.Database
{
    public class Vista_Encuentros_DB
    {


        //variable que me permitira hacer una conexion a mi base de datos
        private string connectionstring = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";
        SqlConnection conn;
        public int banera_agregar;
        public Vista_Encuentros_DB()
        {
        }
        //metodo para verificar si existe la conexion a la base de datos
        public void OPENCONEXION()
        {
            try
            {
                conn = new SqlConnection(connectionstring);
                conn.Open();
                MessageBox.Show("Conexion a la base de datos con exito!!!!!!\nVista ENCUETROS");
            }
            catch
            {
                MessageBox.Show("No se pudo conectar a abase de datos ");
            }

        }



        //METODO PARA hacer la busqueda de los encuentros
        public List<Vista_Encuentros> busqueda_encuentros_torneo(int id_buscar)
        {
            List<Vista_Encuentros> listado_encuentros = new List<Vista_Encuentros>();
            string query = "exec J_C_vista_de_los_encuentros   @id_torneo='" + id_buscar + "'";

            using (SqlConnection connec = new SqlConnection(connectionstring))
            {

                SqlCommand sql = new SqlCommand(query, connec);
                try
                {
                    connec.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        Vista_Encuentros encuentro = new Vista_Encuentros();

                        encuentro.Id_Torneo = reader.GetInt32(0);
                        encuentro.Nombre_torneo = reader.GetString(1);
                        encuentro.equipo_local = reader.GetString(2);
                        encuentro.equipo_visita = reader.GetString(3);


                        listado_encuentros.Add(encuentro);
                    }
                    reader.Close();
                    connec.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al traer los datos en la base de datos" + ex.Message);
                }
            }
            return listado_encuentros;
        }

        //Seleccionar partido, necesitamos la informacion
        public void seleccionar(ComboBox cb)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                cb.Items.Clear();
                connection.Open();
                SqlCommand sql = new SqlCommand("SELECT * FROM torneo", connection);
                //lee lo que esta en la tabla
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    //se guarda en una variable lo que esta en la posicion 1 de la tabla que seria el ID
                    cb.Items.Add(dr[1].ToString());
                }
                connection.Close();
                //mensaje q se mostrara en el combobox
                //cb.Items.Insert(0, "----Seleccione un Torneo----");
                //cb.SelectedIndex = 0;
            }
        }

        //Muestra Nombre de Torneo
        public string[] captar_info(string  nombre_torneo)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand sql = new SqlCommand("SELECT * FROM torneo WHERE Nombre ='" + nombre_torneo + "'", connection);
                //lee lo que esta en la base de datos
                SqlDataReader dr = sql.ExecuteReader();

                string[] resultado = null;
                while (dr.Read())
                {
                    string[] datos =
                    {
                        //Guarda lo que esta en la posicion 1 de la tabla
                        //nombre de torneo
                        dr[0].ToString()
                    };
                    resultado = datos;
                }
                connection.Close();
                return resultado;

            }
        }
    }
}