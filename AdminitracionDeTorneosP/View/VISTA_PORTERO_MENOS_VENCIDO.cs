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
    public partial class VISTA_PORTERO_MENOS_VENCIDO : Form
    {
        // se esta creando instacias para acceder a los metodos de las clases 
        public REPORTE_PORTEO_MENOS_VENCIDO_DB Reporte_portero_menos_vencidolContext = new REPORTE_PORTEO_MENOS_VENCIDO_DB();
        REPORTE_PORTEO_MENOS_VENCIDO_DB combo = new REPORTE_PORTEO_MENOS_VENCIDO_DB();
        public VISTA_PORTERO_MENOS_VENCIDO()
        {
            InitializeComponent();
            //metiendo informacion al combobox
            combo.buscar_torneos_existentes(comboBox1);
            //asigandole atributos a el data grid
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowDrop = false;
            dataGridView1.AllowUserToDeleteRows = false;
            textBox1.Visible = false;
        }
        public void mostrar_reporte_portero()
        {

            dataGridView1.DataSource = Reporte_portero_menos_vencidolContext.Reporte_portero_menos_vencido(Convert.ToInt32(textBox1.Text));
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
                mostrar_reporte_portero();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ingresando valores al texbox dependiendo del combobox
            if (comboBox1.SelectedIndex >= 0)
            {
                //Muestra en el texbox el id del torneo
                string[] datos = Reporte_portero_menos_vencidolContext.captar_info_tonreos_existentes(comboBox1.Text);
                textBox1.Text = datos[0];
            }
        }

        private void VISTA_PORTERO_MENOS_VENCIDO_Load(object sender, EventArgs e)
        {

        }
    }
}
