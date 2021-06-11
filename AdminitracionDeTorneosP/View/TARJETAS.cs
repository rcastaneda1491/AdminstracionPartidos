using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminitracionDeTorneosP.Model;
using AdminitracionDeTorneosP.Database;



namespace AdminitracionDeTorneosP.View
{
    public partial class TARJETAS : Form
    {
        public TARJETAS_DB TarjetasContext = new TARJETAS_DB();
        public Model.TARJETAS TarjetaSeleccionada = new Model.TARJETAS();
        TARJETAS_DB combo = new TARJETAS_DB();
        public TARJETAS()
        {
            InitializeComponent();
            combo.Get_Torneo(comboBox1);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowDrop = false;
            dataGridView1.AllowUserToDeleteRows = false;
            label1.Visible = false;
            textBox1.Visible = false;



        }

        public void mostrar_Tablas_General()
        {
            dataGridView1.DataSource = TarjetasContext.busqueda_Tarjetas_total(Convert.ToInt32(textBox1.Text));

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //mostrar_Tablas_General();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0)
            {
                string[] datos = TarjetasContext.captar_info_nombre_toreno((comboBox1.Text));
                //Muesta en el texbox muestra el dpi del jugador a salir
                textBox1.Text = datos[0];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show($"Seleccione una opcin valida", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
              
                 mostrar_Tablas_General();
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show($"No existe informacion aun en este torneo)", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }


            }

           
        }
    }
}
