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
        private string connectionstring = "Server=DESKTOP-EJ193JG;Database=PROYECTO_TORNEOS;User Id=capacitacion;Password=12345;";
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
        public void Get_Torneos(ComboBox cbx)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                cbx.Items.Clear();
                connection.Open();
                //Query de consulta para obtener equipos
                SqlCommand sql = new SqlCommand("SELECT * FROM torneo", connection);
                //Lectura de datos y agregar al combo box los datos
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    //Agregar registros al combo box
                    cbx.Items.Add($"{dr[0]}- {dr[1]}");
                }
                connection.Close();
            }
        }

    }
}