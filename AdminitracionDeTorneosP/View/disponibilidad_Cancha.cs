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
    public partial class disponibilidad_Cancha : Form
    {
        disponibilidadCanchaDB canchaDB = new disponibilidadCanchaDB();
        public disponibilidad_Cancha()
        {
            //cambiar los nombres de las columnas del datagridview 
            InitializeComponent();




            dataGridView1.DataSource = canchaDB.getDisponibilidadCancha();
            dataGridView1.Columns[0].HeaderText = "Numero de cancha";
            dataGridView1.Columns[3].HeaderText = "Numero de partido que se esta disputando";
            dataGridView1.Columns[4].HeaderText = "Fecha y hora de inicio del partido";
            dataGridView1.Columns[4].HeaderText = "Fecha y hora de final del partido";


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void disponibilidad_Cancha_Load(object sender, EventArgs e)
        {

        }
    }
}
