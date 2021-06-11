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
    public partial class reportePlanillaArbitro : Form
    {
        reportesLourdes l = new reportesLourdes();
        public reportePlanillaArbitro()
        {
            InitializeComponent();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            //guardar las fechas de rango de busqueda en variables 
            
            //Enviar las fechas de busqueda al método de busqueda en la base de datos y mostrar el resultado en el datagridview 
            if (((textFechaInicio.Text == "") && (textFechaFinal.Text == "")))
            {
                MessageBox.Show("valores en blanco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            else
            {

                DateTime fechainicio;
                DateTime fechafinal;
                
                if (!DateTime.TryParse(textFechaInicio.Text, out fechainicio) || !DateTime.TryParse(textFechaFinal.Text, out fechafinal))
                {
                    MessageBox.Show("Formato de fecha incorrecto Fecha correcta: DD/MM/AA", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else 
                {
                    DateTime fechaInicio = DateTime.Parse(textFechaInicio.Text);
                    DateTime fechaFin = DateTime.Parse(textFechaFinal.Text);
                    dataGridView1.DataSource = l.getPagoArbitros(fechaInicio, fechaFin);
                    if (dataGridView1.Rows.Count == 0)
                    {
                        MessageBox.Show($"No existe informacion aun en este torneo)", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }

            }

           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
