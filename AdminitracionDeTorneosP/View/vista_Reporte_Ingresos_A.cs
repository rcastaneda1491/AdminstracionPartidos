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
    public partial class vista_Reporte_Ingresos_A : Form
    {
        private string connectionString = "";

        public vista_Reporte_Ingresos_A()
        {
            InitializeComponent();
        }

        private void cargarDataGrid()
        {
            string fechaInicio = $"{Convert.ToDateTime(txtInicio.Text).Year}/{Convert.ToDateTime(txtInicio.Text).Month}/{Convert.ToDateTime(txtInicio.Text).Day}";
            string fechaFinal = $"{Convert.ToDateTime(txtFinal.Text).Year}/{Convert.ToDateTime(txtFinal.Text).Month}/{Convert.ToDateTime(txtFinal.Text).Day}";
            string query = $"EXEC REPORTE_INGRESOS_A '{fechaInicio}', '{fechaFinal}'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter sqll = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();

                    sqll.Fill(data);

                    listaCancha.DataSource = data;
                    connection.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "No se obtuvieron registros");
                }
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarDataGrid();
        }
    }
}
