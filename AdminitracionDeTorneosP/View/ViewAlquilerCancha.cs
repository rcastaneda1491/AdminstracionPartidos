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
    public partial class ViewAlquilerCancha : Form
    {
        AlquilerCanchaDB alquilerCanchaController = new AlquilerCanchaDB();

        public ViewAlquilerCancha()
        {
            InitializeComponent();
            txtPrecioCancha.Enabled = false;
            alquilerCanchaController.getClientes(cbxCliente);
            updateTable();
        }

        private void updateTable()
        {
            alquilerCanchaController.getAlquiler(listAlquilerCancha);
        }

        private int getId()
        {
            try
            {
                return int.Parse(listAlquilerCancha.Rows[listAlquilerCancha.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return 0;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime fecha = Convert.ToDateTime(txtFechaApartada.Text);
            TimeSpan horaInicio = new TimeSpan(Convert.ToDateTime(txtHoraInicio.Text).Hour, Convert.ToDateTime(txtHoraInicio.Text).Minute, Convert.ToDateTime(txtHoraInicio.Text).Second);
            TimeSpan horaFinal = new TimeSpan(Convert.ToDateTime(txtHoraFinal.Text).Hour, Convert.ToDateTime(txtHoraFinal.Text).Minute, Convert.ToDateTime(txtHoraFinal.Text).Second);
            string nombreDia = fecha.ToString("dddd");

            List<Horario> horario = alquilerCanchaController.getHorario();

            for (int i = 0; i < horario.Count; i++)
            {
                if (horario[i].dia.ToLower() == nombreDia)
                {
                    if (horaInicio >= horario[i].horaApertura && horaFinal <= horario[i].horaCierre)
                    {
                        if (cbxCliente.Text == "" || cbxCancha.Text == "" || txtFechaApartada.Text == "" || txtHoraInicio.Text == "" || txtHoraFinal.Text == "" || txtPrecioCancha.Text == "")
                        {
                            MessageBox.Show("Ingresa todos los campos", "ERROR");
                        }
                        else
                        {
                            string cliente = Convert.ToString(cbxCliente.SelectedItem);
                            string[] clienteArray = cliente.Split(' ');

                            string Nombres = "";
                            string Apellidos = "";
                            int idCliente = 0;
                            if (clienteArray.Length == 2)
                            {
                                Nombres = clienteArray[0];
                                Apellidos = clienteArray[1];
                                idCliente = alquilerCanchaController.getIdCliente(Nombres, Apellidos);
                            }
                            else if (clienteArray.Length == 4)
                            {
                                Nombres = $"{clienteArray[0]} {clienteArray[1]}";
                                Apellidos = $"{clienteArray[2]} {clienteArray[3]}";
                                idCliente = alquilerCanchaController.getIdCliente(Nombres, Apellidos);
                            }
                            if (cbArbitraje.Checked == true)
                            {

                                string cancha = Convert.ToString(cbxCancha.SelectedItem);
                                string[] arrayCancha = cancha.Split('|');
                                int numeroCancha = Convert.ToInt32(arrayCancha[0]);

                                decimal totalAlquilerCancha = alquilerCanchaController.totalAlquilerCancha(horaInicio, horaFinal, numeroCancha);

                                AlquilarCancha alquilarCancha = new AlquilarCancha();

                                if (cbxArbitro.Items.Count == 0)
                                {
                                    MessageBox.Show("No hay arbitros disponibles en ese horario");
                                }
                                else
                                {
                                    string arbitro = Convert.ToString(cbxArbitro.SelectedItem);
                                    string[] arbitrosArray = arbitro.Split('|');
                                    int dpiArbitro = Convert.ToInt32(arbitrosArray[0]);

                                    decimal totalArbitraje = alquilerCanchaController.totalPrecioArbitraje(horaInicio, horaFinal, dpiArbitro);
                                    alquilarCancha.NumeroCancha = numeroCancha;
                                    alquilarCancha.IDCliente = idCliente;
                                    alquilarCancha.FechaApartada = fecha;
                                    alquilarCancha.HoraInicio = horaInicio;
                                    alquilarCancha.HoraFinal = horaFinal;
                                    alquilarCancha.TotalPrecio = totalAlquilerCancha;

                                    alquilerCanchaController.addAlquilerCancha(alquilarCancha);
                                    int idAlquilerCancha = alquilerCanchaController.getIdAlquiler();
                                    alquilerCanchaController.addArbitroAlquilado(fecha, horaInicio, horaFinal, dpiArbitro, idAlquilerCancha, totalArbitraje);
                                    updateTable();
                                }
                            }
                            else
                            {

                                string cancha = Convert.ToString(cbxCancha.SelectedItem);
                                string[] arrayCancha = cancha.Split('|');
                                int numeroCancha = Convert.ToInt32(arrayCancha[0]);

                                decimal totalAlquilerCancha = alquilerCanchaController.totalAlquilerCancha(horaInicio, horaFinal, numeroCancha);

                                AlquilarCancha alquilar_Canchas = new AlquilarCancha();
                                alquilar_Canchas.NumeroCancha = numeroCancha;
                                alquilar_Canchas.IDCliente = idCliente;
                                alquilar_Canchas.FechaApartada = fecha;
                                alquilar_Canchas.HoraInicio = horaInicio;
                                alquilar_Canchas.HoraFinal = horaFinal;
                                alquilar_Canchas.TotalPrecio = totalAlquilerCancha;

                                alquilerCanchaController.addAlquilerCancha(alquilar_Canchas);
                                updateTable();
                            }
                        }
                        txtPrecioCancha.Clear();
                    }
                    else
                    {
                        MessageBox.Show("La hora no esta dentro del horario");
                    }
                    break;
                }


            }
        }

        private void cbxCancha_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cancha = Convert.ToString(cbxCancha.Text);
            string[] arrayCancha = cancha.Split('|');
            int numeroCancha = Convert.ToInt32(arrayCancha[0]);

            txtPrecioCancha.Text = Convert.ToString(alquilerCanchaController.getPrecioCancha(numeroCancha));
        }

        private void cbxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxCancha.Enabled = true;
            DateTime fecha = Convert.ToDateTime(txtFechaApartada.Text);
            TimeSpan horaInicio = new TimeSpan(Convert.ToDateTime(txtHoraInicio.Text).Hour, Convert.ToDateTime(txtHoraInicio.Text).Minute, Convert.ToDateTime(txtHoraInicio.Text).Second);
            TimeSpan horaFinal = new TimeSpan(Convert.ToDateTime(txtHoraFinal.Text).Hour, Convert.ToDateTime(txtHoraFinal.Text).Minute, Convert.ToDateTime(txtHoraFinal.Text).Second);

            alquilerCanchaController.getCanchas(cbxCancha, fecha, horaInicio, horaFinal);
        }

        private void cbArbitraje_CheckedChanged(object sender, EventArgs e)
        {
            DateTime fecha = Convert.ToDateTime(txtFechaApartada.Text);
            TimeSpan horaInicio = new TimeSpan(Convert.ToDateTime(txtHoraInicio.Text).Hour, Convert.ToDateTime(txtHoraInicio.Text).Minute, Convert.ToDateTime(txtHoraInicio.Text).Second);
            TimeSpan horaFinal = new TimeSpan(Convert.ToDateTime(txtHoraFinal.Text).Hour, Convert.ToDateTime(txtHoraFinal.Text).Minute, Convert.ToDateTime(txtHoraFinal.Text).Second);
            if (cbArbitraje.Checked == true)
            {
                cbxArbitro.Visible = true;
                label6.Visible = true;
                alquilerCanchaController.getArbitroDisponible(cbxArbitro, fecha, horaInicio, horaFinal);
            }
            else
            {
                cbxArbitro.Visible = false;
                label6.Visible = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idAlquiler = getId();
            alquilerCanchaController.deleteAlquiler(idAlquiler);
            updateTable();
        }
    }
}
