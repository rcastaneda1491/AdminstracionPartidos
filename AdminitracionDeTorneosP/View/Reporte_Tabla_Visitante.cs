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
    public partial class Reporte_Tabla_Visitante : Form
    {
        Reporte_Tabla_VisitanteDB Reporte_Tabla_VisitanteContext = new Reporte_Tabla_VisitanteDB();
        public Reporte_Tabla_Visitante()
        {
            InitializeComponent();
            Reporte_Tabla_VisitanteContext.Get_Torneos(cmxTorneo);
        }

        private void cmxTorneo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Torneo = Convert.ToString(cmxTorneo.SelectedItem);
            string[] TorneoArray = Torneo.Split('-');
            //Id de torneo almacenado en la posicion 0

            int id_torneo = Convert.ToInt32(TorneoArray[0]);

            ListReporteVisita.DataSource = Reporte_Tabla_VisitanteContext.GetTabla_Visitantes(id_torneo);
            //validaccion para mostrar si existe informacion enla bases de datos
            if (ListReporteVisita.Rows.Count == 0)
            {
                MessageBox.Show($"No existe informacion aun en este torneo)", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Reporte_Tabla_Visitante_Load(object sender, EventArgs e)
        {

        }

        private void ListReporteVisita_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
