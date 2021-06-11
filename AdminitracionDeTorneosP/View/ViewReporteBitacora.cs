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
    public partial class ViewReporteBitacora : Form
    {

        private string connectionString = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";

        public ViewReporteBitacora()
        {
            InitializeComponent();
            getUsuarios(cbxUsuario);
        }

        public void getUsuarios(ComboBox cbx)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cbx.Items.Clear();
                connection.Open();
                SqlCommand sql = new SqlCommand("SELECT * FROM USUARIOS", connection);
                SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    cbx.Items.Add($"{dr[0]}| {dr[2]} {dr[3]}");
                }
                connection.Close();
            }
        }

        private void loadData(string query)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter sqll = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();

                    sqll.Fill(data);

                    listIngresosCancha.DataSource = data;
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al obtener los registros");
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string usuario = Convert.ToString(cbxUsuario.Text);
            string[] usuarioArray = usuario.Split('|');
            int idUsuario = Convert.ToInt32(usuarioArray[0]);

            string fechaInicio = $"{Convert.ToDateTime(txtFechaInicio.Text).Year}/{Convert.ToDateTime(txtFechaInicio.Text).Month}/{Convert.ToDateTime(txtFechaInicio.Text).Day}";
            string fechaFinal = $"{Convert.ToDateTime(txtFechaFinal.Text).Year}/{Convert.ToDateTime(txtFechaFinal.Text).Month}/{Convert.ToDateTime(txtFechaFinal.Text).Day}";
            string query = $"EXEC SP_REPORTE_BITACORA '{fechaInicio}', '{fechaFinal}', {idUsuario}";

            loadData(query);
        }
    }
}
