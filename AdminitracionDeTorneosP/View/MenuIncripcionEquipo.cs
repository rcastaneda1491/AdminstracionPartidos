using System;
using System.Windows.Forms;
using AdminitracionDeTorneosP.Database;

// Erick Eduardo Echeverría Garrido

namespace AdminitracionDeTorneosP.View
{
    public partial class MenuIncripcionEquipo : Form
    {
        public EQUIPO_TORNEODB equipoTorneoContext = new EQUIPO_TORNEODB();

        public MenuIncripcionEquipo()
        {
            InitializeComponent();

            comboBox1.DataSource = equipoTorneoContext.CargarComboTorneo(); // Solicitando la informacion de la base de datos para cargarla en el combobox
            comboBox1.DisplayMember = "Nombre"; // Asignando el valor que se mostrara en el combobox
            comboBox1.ValueMember = "Id_Torneo"; // Valor que estara detras de Display

            comboBox2.DataSource = equipoTorneoContext.CargarComboEquipos(); // Solicitando la informacion de la base de datos para cargarla en el combobox
            comboBox2.DisplayMember = "Nombre"; // Asignando el valor que se mostrara en el combobox
            comboBox2.ValueMember = "Id_Equipo"; // Valor que estara detras de Display

        }

        private void EquiposTorneo_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validaciones = new Validaciones();
            validaciones.validarNumeros(e); //Valida si lo ingresado NO es un numero
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double costoTorneo = equipoTorneoContext.ObtenerCostoTorneo(Convert.ToInt32(comboBox1.SelectedValue));

            bool obtenerTorneoComenzado = equipoTorneoContext.obtenerTorneoComenzado(Convert.ToInt32(comboBox1.SelectedValue));

            if(obtenerTorneoComenzado == true)
            {
                MessageBox.Show($"Actualmente el torneo ha comenzado y está bloqueado la agregación de equipos", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                if (Convert.ToDouble(textBox1.Text) == costoTorneo)
                {
                    Model.EQUIPO_TORNEO equipoAtorneo = new Model.EQUIPO_TORNEO();
                    equipoAtorneo.Id_Torneo = Convert.ToInt32(comboBox1.SelectedValue);
                    equipoAtorneo.Id_Equipo = Convert.ToInt32(comboBox2.SelectedValue);
                    equipoAtorneo.costoInscripcion = Convert.ToDecimal(textBox1.Text);

                    equipoTorneoContext.AddEquipoTorneo(equipoAtorneo); // Ingresando en la base de datos la informacion

                    dataGridView1.DataSource = equipoTorneoContext.GetEquiposEnTorneo(Convert.ToInt32(comboBox1.SelectedValue)); // Actualizando listado de tipos
                }
                else
                {
                    MessageBox.Show($"La cantidad de pago no corresponde al Torneo correspondiente\nCosto establecido:{costoTorneo}", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private int GetIdEquipo()
        {
            try
            {
                return int.Parse(
                    dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString() // Obteniendo el numero de ID seleccioado por medio de la primera columna de la seleccion
                    );
            }
            catch
            {
                return 0;
            }
        }

        private int GetIdTorneo()
        {
            try
            {
                return int.Parse(
                    dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString() // Obteniendo el numero de ID seleccioado por medio de la primera columna de la seleccion
                    );
            }
            catch
            {
                return 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int IdTorneo = GetIdTorneo();
            int IdEquipo = GetIdEquipo();

            int cantidadJugadoresActualesEnElEquipoMismoTorneo = equipoTorneoContext.contarJugadoresEnElEquipoMismoTorneo(IdTorneo,IdEquipo);


            bool obtenerTorneoComenzado = equipoTorneoContext.obtenerTorneoComenzado(Convert.ToInt32(comboBox1.SelectedValue));

            if (obtenerTorneoComenzado == true)
            {
                MessageBox.Show($"Actualmente el torneo ha comenzado y está bloqueado la agregación de equipos", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (cantidadJugadoresActualesEnElEquipoMismoTorneo > 0)
                {
                    MessageBox.Show($"Actualmente el Equipo Cuenta con Jugadores asignado\nCantidad: {cantidadJugadoresActualesEnElEquipoMismoTorneo}\n\nElimine los jugadores correspondientes", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBoxButtons botones = MessageBoxButtons.YesNo; //Mensaje de advetencia
                    DialogResult dr = MessageBox.Show("¿Seguro desea eliminar el equipo de la competencia? Esta opcion no se puede deshacer", "Advertencia", botones, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        equipoTorneoContext.DeleteEquipoCompetencia(IdTorneo, IdEquipo);
                        dataGridView1.DataSource = equipoTorneoContext.GetEquiposEnTorneo(IdTorneo);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = equipoTorneoContext.GetEquiposEnTorneo(Convert.ToInt32(comboBox1.SelectedValue));
        }
    }
}
