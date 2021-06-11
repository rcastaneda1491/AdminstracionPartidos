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
    public partial class tiempoUsoCanchas : Form
    {
        reportesLourdes l = new reportesLourdes();
        public tiempoUsoCanchas()
        {//inicializar todos los componentes 
            InitializeComponent();
            buscar.Visible = true;
            textFechaInicio.Visible = false;
            textFechaFin.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            textNombre.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
        }

        private void buttonFecha_CheckedChanged(object sender, EventArgs e)
        {
            //crear un nuevo objeto de radiobutton 
            RadioButton rd = sender as RadioButton;

            if (rd.Checked)
            {
             //si el radio button esta seleccionado se muestran los textbox y labels correspondientes   
                textFechaInicio.Visible = true;
                textFechaFin.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
            }
            else
            {
                //si no se ocultan 
                textFechaInicio.Visible = false;
                textFechaFin.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
            }

        }

        private void buscar_Click(object sender, EventArgs e)
        {
            if(buttonFecha.Checked == true)
            {
                //guardar los datos segun el paramtro de busqueda seleccionado y enviar al métpdo de busqueda en la base de datos 
                DateTime fechaInicio = DateTime.Parse(textFechaInicio.Text);
                DateTime fechaFinal = DateTime.Parse(textFechaFin.Text);
                dataGridView1.DataSource =  l.getTiempos(fechaInicio, fechaFinal);


            }else if(radioNombreCancha.Checked == true)
            {
                string nombre = textNombre.Text;
                dataGridView1.DataSource = l.getTiemposPorNombreCancha(nombre);
            }
            else if(radioNombreTorneo.Checked == true)
            {
                string nombre = textNombre.Text;
                dataGridView1.DataSource = l.getTiemposPorNombreTorneo(nombre);
            }
        }

        private void tiempoUsoCanchas_Load(object sender, EventArgs e)
        {

        }

        private void radioNombreCancha_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = sender as RadioButton;

            if (rd.Checked)
            {
                //si el radio button esta seleccionado se muestran los textbox y labels correspondientes   
                textNombre.Visible = true;
                label4.Visible = true;
                label4.Text = "Nombre Cancha";
            }
            else
            {
                //si no se ocultan 
                textNombre.Visible = false;
                label4.Visible = false;
            }
        }

        private void radioNombreTorneo_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = sender as RadioButton;

            if (rd.Checked)
            {
                //si el radio button esta seleccionado se muestran los textbox y labels correspondientes   
                textNombre.Visible = true;
                label4.Visible = true;
                label4.Text = "Nombre Torneo";
            }
            else
            {
                //si no se ocultan 
                textNombre.Visible = false;
                label4.Visible = false;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
