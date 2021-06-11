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
    public class REPORTE_EQUIPO_LOCAL_DB
    {



        //variable que me permitira hacer una conexion a mi base de datos
        private string connectionstring = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";
        SqlConnection conn;
        public int banera_agregar;
        public REPORTE_EQUIPO_LOCAL_DB()
        {
        }

        //METODO que me servira para poder mostrar el reporte de equipo local
        public List<REPORTE_LOCAL> Reporte_equipo_local(int id_toneo)
        {
            List<REPORTE_LOCAL> listado_punteo = new List<REPORTE_LOCAL>();
            string query = "exec tabla_general_seleccionando_datoss @id_torneo='"+ id_toneo + "'";
            using (SqlConnection connec = new SqlConnection(connectionstring))
            {

                SqlCommand sql = new SqlCommand(query, connec);
                try
                {
                    connec.Open();
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        REPORTE_LOCAL reporte_equipo = new REPORTE_LOCAL();

                        reporte_equipo.nombres = reader.GetString(0);
                        reporte_equipo.partidos_jugados = reader.GetInt32(1);
                        reporte_equipo.partidos_ganados = reader.GetInt32(2);
                        reporte_equipo.partidos_empatados = reader.GetInt32(3);
                        reporte_equipo.partidos_perdidos = reader.GetInt32(4);
                        reporte_equipo.goles_favor = reader.GetInt32(5);
                        reporte_equipo.goles_conttra = reader.GetInt32(6);
                        reporte_equipo.diferencia_goles = reader.GetInt32(7);
                        reporte_equipo.total_puntos = reader.GetInt32(11);
                        listado_punteo.Add(reporte_equipo);
                    }
                    reader.Close();
                    connec.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al traer los datos en la base de datos" + ex.Message);
                }
            }
            return listado_punteo;
        }



        //metodo para llevar a los combobox los torneos existentes
        //Seleccionar partido, necesitamos la informacion
        public void buscar_torneos_existentes(ComboBox cb)
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

        //Muestra Nombre de Torneo en un texbox que sera no visible al usuario 
        public string[] captar_info_tonreos_existentes(string  nombre_torneo)
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
