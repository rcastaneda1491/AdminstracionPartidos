using AdminitracionDeTorneosP.Database;
using System;
using System.Windows.Forms;

namespace AdminitracionDeTorneosP.View
{
    public partial class Reporte_Utilidades : Form
    {
        Reporte_UtilidadesDB reporte_UtilidadesDB = new Reporte_UtilidadesDB();
        public Reporte_Utilidades()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
            if (((txtFechaInicio.Text == "") && (txtFechaFinal.Text == "")))
            {
                MessageBox.Show("valores en blanco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            else
            {
                DateTime fechainicio;
                DateTime fechafinal;
                if (!DateTime.TryParse(txtFechaInicio.Text, out fechainicio) || !DateTime.TryParse(txtFechaFinal.Text, out fechafinal))
                {
                    MessageBox.Show("Formato de fecha incorrecto Fecha correcta: DD/MM/AA", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    

                    ListUtilidades.DataSource = reporte_UtilidadesDB.GetReporte_Utilidades(fechainicio.Date, fechafinal.Date);
                    if (ListUtilidades.Rows.Count == 0)
                    {
                        MessageBox.Show($"No existe informacion aun en este torneo)", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    txtFechaInicio.Clear();
                    txtFechaFinal.Clear();
                }
            }
        }
    }
}
