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
    public partial class Reporte_punteo_general : Form
    {
        public PUNTEO_GENERAL_DB Reporte_equipo_localContext = new PUNTEO_GENERAL_DB();
        PUNTEO_GENERAL_DB combo = new PUNTEO_GENERAL_DB();
        public Reporte_punteo_general()
        {
            InitializeComponent();
            //metiendo informacion al combobox
            combo.buscar_torneos_existentes(comboBox1);
            //estableciendoi atributos al data grid
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowDrop = false;
            dataGridView1.AllowUserToDeleteRows = false;
            textBox1.Visible = false;
        }
        //metodo que me mostrara la informacion de la abses de datos al datagrid
        public void mostrar_reporte_punteo_general()
        {

            dataGridView1.DataSource = Reporte_equipo_localContext.Reporte_punteo_general(Convert.ToInt32(textBox1.Text));
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //validando que no existan valores vacios en el combobox
            if (comboBox1.Text == "Seleccione una opcion")
            {
                MessageBox.Show("Seleccione una opcion valida");
            }
            else
            {
                
                mostrar_reporte_punteo_general();
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show($"No existe informacion aun en este torneo)", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ingresando valores al texbox dependiendo del combobox
            if (comboBox1.SelectedIndex >= 0)
            {
                //Muestra en el texbox el id del torneo
                string[] datos = Reporte_equipo_localContext.captar_info_tonreos_existentes(comboBox1.Text);
                textBox1.Text = datos[0];
            }
        }
    }
}
