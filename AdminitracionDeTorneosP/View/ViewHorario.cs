using AdminitracionDeTorneosP.Database;
using AdminitracionDeTorneosP.Model;
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
    public partial class ViewHorario : Form
    {
        HorarioDB horarioController = new HorarioDB();
        int opcion = 1;

        public ViewHorario()
        {
            InitializeComponent();
            updateTable();
        }

        private void updateTable()
        {
            horarioController.getHorarios(listHorarios);
        }

        private string getDia()
        {
            try
            {
                return listHorarios.Rows[listHorarios.CurrentRow.Index].Cells[0].Value.ToString();
            }
            catch
            {
                return "";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TimeSpan Abierto = new TimeSpan(Convert.ToDateTime(txtHoraApertura.Text).Hour, Convert.ToDateTime(txtHoraApertura.Text).Minute, Convert.ToDateTime(txtHoraApertura.Text).Second);
            TimeSpan Cerrado = new TimeSpan(Convert.ToDateTime(txtHoraCierre.Text).Hour, Convert.ToDateTime(txtHoraCierre.Text).Minute, Convert.ToDateTime(txtHoraCierre.Text).Second);
            Horario horario = new Horario();

            if (opcion == 1)
            {
                horario.dia = cbxDia.Text;
                horario.horaApertura = Abierto;
                horario.horaCierre = Cerrado;

                horarioController.addHorario(horario);
            }
            else if (opcion == 0)
            {
                horario.dia = getDia();
                horario.horaApertura = Abierto;
                horario.horaCierre = Cerrado;

                horarioController.updateHorario(horario);
            }

            txtHoraApertura.Clear();
            txtHoraCierre.Clear();
            cbxDia.Text = "";
            opcion = 1;
            updateTable();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            opcion = 0;
            string dia = getDia();
            Horario horario = horarioController.getHorarioById(dia);
            txtHoraApertura.Text = horario.horaApertura.ToString();
            txtHoraCierre.Text = horario.horaCierre.ToString();
            cbxDia.Text = horario.dia;
        }

    }
}
