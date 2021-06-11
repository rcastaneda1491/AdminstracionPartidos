using System.Windows.Forms;
using AdminitracionDeTorneosP.Model;
using AdminitracionDeTorneosP.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AdminitracionDeTorneosP.View
{
    public partial class ReporteEstadisticasDelEquipo : Form
    {
        public Reporte_EstadisticasDelEquipoDB reporteDB = new Reporte_EstadisticasDelEquipoDB();
        private string connectionString = "Server=DESKTOP-EJ193JG;Database=PROYECTO_TORNEOS;User Id=capacitacion;Password=12345;";

        public ReporteEstadisticasDelEquipo()
        {
            InitializeComponent();
            cmbTorneos.DataSource = reporteDB.CargarComboTorneo(); // Solicitando la informacion de la base de datos para cargarla en el combobox
            cmbTorneos.DisplayMember = "Nombre"; // Asignando el valor que se mostrara en el combobox
            cmbTorneos.ValueMember = "Id_Torneo"; // Valor que estara detras de Display
            GetNombresEquipo(Convert.ToInt32(cmbTorneos.SelectedValue));
        }

        private void GetNombresEquipo(int Id_Torneo)
        {

            string query = "exec proc_erick_cargar_NombreDeEquipoEnTorneo @Id_Torneo";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@Id_Torneo", Id_Torneo);
                connection.Open();
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    comboEquipos.Items.Add(reader["Nombre"].ToString());
                }
                connection.Close();
            }
        }

        private void cmbTorneos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboEquipos.Items.Clear();
            GetNombresEquipo(Convert.ToInt32(cmbTorneos.SelectedValue));
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            if(cmbTorneos.Text == "" || comboEquipos.Text == "")
            {
                MessageBox.Show($"Seleccione un Equipo", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                EstadisticaDelEquipo estadistica = reporteDB.Estadistica_Equipo(comboEquipos.Text, Convert.ToInt32(cmbTorneos.SelectedValue));
                textBox1.Text = Convert.ToString(estadistica.POS);
                label4.Text = estadistica.Nombre;
                textBox2.Text = Convert.ToString(estadistica.J);
                textBox4.Text = Convert.ToString(estadistica.G);
                textBox3.Text = Convert.ToString(estadistica.E);
                textBox5.Text = Convert.ToString(estadistica.P);
                textBox6.Text = Convert.ToString(estadistica.Puntos);
                comboEquipos.Text = "";
                if(
                     textBox1.Text == "" ||
                label4.Text == "" ||
                textBox2.Text == "" ||
                textBox4.Text == "" ||
                textBox3.Text == "" ||
                textBox5.Text == "" ||
                textBox6.Text == ""

                )
                {
                    MessageBox.Show($"No existe informacion relacionada a este torneo", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
               

            }
        }
    }
}
