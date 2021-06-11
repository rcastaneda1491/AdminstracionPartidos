using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminitracionDeTorneosP.Database;
using AdminitracionDeTorneosP.Model;
using AdminitracionDeTorneosP.View;

namespace AdminitracionDeTorneosP.View
{
    public partial class vISTA_ENCUENTROS_WIN : Form
    {
        public Vista_Encuentros_DB ReporteTorneoContext = new Vista_Encuentros_DB();

        public vISTA_ENCUENTROS_WIN()
        {

            InitializeComponent();
            ReporteTorneoContext.seleccionar(cmbid_torneo);
            
            lista_encuentros_datagrid.AllowUserToAddRows = false;
            lista_encuentros_datagrid.AllowDrop = false;
            lista_encuentros_datagrid.AllowUserToDeleteRows = false;
            textBox1_id.Visible = false;

        }
        public void mostrar_ENCUENTROS_datagrid()
        {

            lista_encuentros_datagrid.DataSource = ReporteTorneoContext.busqueda_encuentros_torneo(Convert.ToInt32(textBox1_id.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbid_torneo.Text == "Seleccione una opcion")
            {
                MessageBox.Show("Seleccione una opcion valida");
            }
            else
            {
                mostrar_ENCUENTROS_datagrid();
            }
            
        }

        private void cmbid_torneo_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (cmbid_torneo.SelectedIndex >= 0)
            {
                //Muesta en el label el nombre del id seleccionado
                string[] datos = ReporteTorneoContext.captar_info(cmbid_torneo.Text);
                textBox1_id.Text = datos[0];
            }

        }
    }
}
