using AdminitracionDeTorneosP.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminitracionDeTorneosP.View
{
    public partial class reporteJuegosAfectados : Form
    {
        reportesLourdes l = new reportesLourdes();
        public reporteJuegosAfectados()
        {
            InitializeComponent();
            //mostrar los datos de la consulta en el datagridview 
            dataGridView1.DataSource = l.getPartidosAfectados();
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show($"No existe informacion aun en este torneo)", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cerrar la pestaña 
            this.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void reporteJuegosAfectados_Load(object sender, EventArgs e)
        {

        }
    }
}
