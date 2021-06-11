using AdminitracionDeTorneosP.Database;
using AdminitracionDeTorneosP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminitracionDeTorneosP.View
{
    public partial class detallesPartido : Form
    {
        private string connectionstring = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";

        Partidos partidos = new Partidos();
        public AdministraciónDeJornadasDB jornadaContext = new AdministraciónDeJornadasDB();
        detallesPartidoDB db = new detallesPartidoDB();
        public int idPartido;
        public int idTorneo;
        public DataGridView data;

        public detallesPartido(DataGridView dataGridView ,int id_Partido, int id_Torneo)
        {
            idPartido = id_Partido;
            idTorneo = id_Torneo;
            InitializeComponent();
            getNames();
            this.data = dataGridView;
        }

        public void getNames()
        {
            string query = "exec LA_obtenerNombreCanchas";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                   comboNombreCanchas.Items.Add(reader["nombre"].ToString());
                }
                connection.Close();
            }
        }





        private void button1_Click(object sender, EventArgs e)
        {
            DateTime fechaInicioTorneo = db.getFechaInicio(idTorneo);
            DateTime fechaFinTorneo = db.getFechaFin(idTorneo);

            string nombreCancha = comboNombreCanchas.Text;

            int idCancha = db.getIdCancha(nombreCancha);

            DateTime fechaPartido = DateTime.Parse(textFecha.Text);

            TimeSpan horaInicioPartido = TimeSpan.Parse(textHoraInicio.Text);
            TimeSpan horaFinPartido = TimeSpan.Parse(textHoraFin.Text);

            if (fechaPartido >= fechaInicioTorneo && fechaPartido <= fechaFinTorneo)
            {

                db.updateDetallesPartido(idPartido, idCancha, fechaPartido, horaInicioPartido, horaFinPartido);

                comboNombreCanchas.Text = "";
                textFecha.Text = "";
                textHoraInicio.Text = "";
                textHoraFin.Text = "";

            }
            else
            {
                MessageBox.Show("La fecha del partido debe estar entre" + fechaInicioTorneo + " y " + fechaFinTorneo);
                textFecha.Text = " ";
            }

            
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime fechaInicioTorneo = db.getFechaInicio(idTorneo);
            DateTime fechaFinTorneo = db.getFechaFin(idTorneo);

            textFecha.Text = Convert.ToString(fechaInicioTorneo);
            textHoraInicio.Text = Convert.ToString(fechaFinTorneo);

        }

        private void detallesPartido_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            data.DataSource = jornadaContext.GetEnfrentamientoDeTorneo(idTorneo);
            this.Dispose();
        }
    }
}
