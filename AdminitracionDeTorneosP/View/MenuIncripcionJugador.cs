using System;
using System.Windows.Forms;
using AdminitracionDeTorneosP.Database;

namespace AdminitracionDeTorneosP.View
{
    public partial class MenuIncripcionJugador : Form
    {
        public EQUIPO_TORNEODB equipoTorneoContext = new EQUIPO_TORNEODB();

        public MenuIncripcionJugador()
        {
            InitializeComponent();

            comboBox1.DataSource = equipoTorneoContext.CargarComboTorneo(); // Solicitando la informacion de la base de datos para cargarla en el combobox
            comboBox1.DisplayMember = "Nombre"; // Asignando el valor que se mostrara en el combobox
            comboBox1.ValueMember = "Id_Torneo"; // Valor que estara detras de Display

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = equipoTorneoContext.GetEquiposEnTorneoDatosDelEquipo(Convert.ToInt32(comboBox1.SelectedValue)); // Actualizando listado de tipos
        }

        private int GetIdEquipo()
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
        private string GetNombreEquipo()
        {
            try
            {
                return string.Format(
                    dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString() // Obteniendo el numero de ID seleccioado por medio de la primera columna de la seleccion
                    );
            }
            catch
            {
                return "";
            }
        }
        private long GetDPIJugador()
        {
            try
            {
                return long.Parse(
                    dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[4].Value.ToString() // Obteniendo el numero de ID seleccioado por medio de la primera columna de la seleccion
                    );
            }
            catch
            {
                return 0;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show($"Actualmente la lista de equipos se encuentra vacio\n\n(Seleccione un equipo)", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else

            {

                comboBox1.Enabled = false;

                int Id_Torneo = Convert.ToInt32(comboBox1.SelectedValue);
                int IdEquipo = GetIdEquipo();

                dataGridView2.DataSource = equipoTorneoContext.obtenerJugadoresDelEquipo(Id_Torneo, IdEquipo);

                textBox1.Text = GetNombreEquipo();

                comboBox2.DataSource = equipoTorneoContext.CargarComboJugadores(); // Solicitando la informacion de la base de datos para cargarla en el combobox
                comboBox2.DisplayMember = "NombreCompleto"; // Asignando el valor que se mostrara en el combobox
                comboBox2.ValueMember = "DPI_Jugador"; // Valor que estara detras de Display

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Id_Torneo = Convert.ToInt32(comboBox1.SelectedValue);
            int Id_Equipo = GetIdEquipo();

            int edadJugador = equipoTorneoContext.ObtenerEdadJugador(Convert.ToInt64(comboBox2.SelectedValue));
            int edadMinima = equipoTorneoContext.ObtenerEdadMinimaTorneo(Id_Torneo);
            int edadMaxima = equipoTorneoContext.ObtenerEdadMaximaTorneo(Id_Torneo);

            int maximoPermitido = equipoTorneoContext.ObtenerMaximoPermitido(Id_Torneo);
            int cantidadJugadores = equipoTorneoContext.CantidadJugadoresEnEquipoTorneo(Id_Torneo,Id_Equipo);

            bool torneoEmpezado = equipoTorneoContext.obtenerTorneoComenzado(Id_Torneo);

            if(torneoEmpezado == true)
            {
                MessageBox.Show($"El torneo ha comenzado\nNo se puede agregar mas jugadores", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (cantidadJugadores >= maximoPermitido)
                {
                    MessageBox.Show($"El equipo ha llegado al limite de jugadores\nCantidad actual en el equipo:{cantidadJugadores}\nCantidad permitida:{maximoPermitido}", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (edadJugador < edadMinima && edadJugador > edadMaxima)
                    {
                        MessageBox.Show($"La edad del jugador no es admitida en el torneo\nEdad del jugador:{edadJugador}\nEdad Minima:{edadMinima}\nEdadMaxima:{edadMaxima}", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if(comboBox3.Text == "" || textBox2.Text == "")
                        {
                            MessageBox.Show($"Por favor, Ingrese los datos solicitados", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            int disponibilidadCamiseta = equipoTorneoContext.obtenerCantidadJugadoresConNumeroDeCamiseta(Id_Torneo, Id_Equipo, Convert.ToInt32(textBox2.Text));
                            if (disponibilidadCamiseta > 0)
                            {
                                MessageBox.Show($"El numero de camisola actualmente esta ocupada", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                int cantidadDeEquiposPorElJugador = equipoTorneoContext.obtenerJugadorDiferenteEquipoMismoTorneo(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt64(comboBox2.SelectedValue));
                                if (cantidadDeEquiposPorElJugador > 0)
                                {
                                    MessageBox.Show($"Actualmente este jugador no se encuntra disponible", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                {

                                    Model.POSICION_JUGADOR jugador = new Model.POSICION_JUGADOR();
                                    jugador.Id_Torneo = Convert.ToInt32(comboBox1.SelectedValue);
                                    jugador.Id_Equipo = Id_Equipo;
                                    jugador.DPI_JUGADOR = Convert.ToInt64(comboBox2.SelectedValue);
                                    jugador.Posicion = comboBox3.Text;
                                    jugador.NumeroCamisola = Convert.ToInt32(textBox2.Text);

                                    equipoTorneoContext.AddJugadorAEquipo(jugador); // Ingresando en la base de datos la informacion

                                    dataGridView2.DataSource = equipoTorneoContext.obtenerJugadoresDelEquipo(Id_Torneo, GetIdEquipo());

                                }

                            }
                        }
                    }
                }
            }
        }

        int opcion = 0;
        int numeroAnterior;
        private void button2_Click(object sender, EventArgs e)
        {
            if(opcion == 0)
            {
                if (dataGridView2.Rows.Count == 0)
                {
                    MessageBox.Show($"Actualmente la lista de jugadores se encuentra vacio", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); MessageBox.Show("valores vacioos");
                }

                else

                {

                    long DPI_Jugador = GetDPIJugador();
                    int codigoEquipo = GetIdEquipo();

                    Model.POSICION_JUGADOR jugadorAEditar = equipoTorneoContext.GetJugadorPosicion(Convert.ToInt32(comboBox1.SelectedValue), codigoEquipo, DPI_Jugador);
                    comboBox2.Text = Convert.ToString(jugadorAEditar.DPI_JUGADOR);
                    textBox2.Text = Convert.ToString(jugadorAEditar.NumeroCamisola);
                    comboBox3.Text = jugadorAEditar.Posicion;

                    numeroAnterior = jugadorAEditar.NumeroCamisola;

                    dataGridView2.Enabled = false;
                    button3.Enabled = false;
                    button1.Enabled = false;
                    comboBox2.Enabled = false;

                    button2.Text = "Confirmar";

                    opcion = 1;

                }
            }
            else
            {
                int codigoEquipo = GetIdEquipo();
                int numeroCamisola = Convert.ToInt32(textBox2.Text);
                int disponibilidadCamiseta = equipoTorneoContext.obtenerCantidadJugadoresConNumeroDeCamiseta(Convert.ToInt32(comboBox1.SelectedValue), codigoEquipo, numeroCamisola);

                if (numeroAnterior == numeroCamisola)
                {
                    long DPI_Jugador = GetDPIJugador();

                    string posicion = comboBox3.Text;

                    equipoTorneoContext.UpdatePosJugador(Convert.ToInt32(comboBox1.SelectedValue), codigoEquipo, DPI_Jugador, posicion, numeroCamisola); // Actualizando informacion en la base de datos

                    button2.Text = "Actualizar";

                    opcion = 0;

                    dataGridView2.Enabled = true;
                    button3.Enabled = true;
                    comboBox3.Enabled = true;
                    button1.Enabled = true;

                    int Id_Torneo = Convert.ToInt32(comboBox1.SelectedValue);
                    int IdEquipo = GetIdEquipo();

                    dataGridView2.DataSource = equipoTorneoContext.obtenerJugadoresDelEquipo(Id_Torneo, IdEquipo);
                }
                else
                {
                    if (disponibilidadCamiseta > 0)
                    {
                        MessageBox.Show($"El numero de camisola actualmente esta ocupada", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        long DPI_Jugador = GetDPIJugador();

                        string posicion = comboBox3.Text;

                        equipoTorneoContext.UpdatePosJugador(Convert.ToInt32(comboBox1.SelectedValue), codigoEquipo, DPI_Jugador, posicion, numeroCamisola); // Actualizando informacion en la base de datos

                        dataGridView2.Enabled = true;
                        button3.Enabled = true;
                        comboBox3.Enabled = true;
                        button1.Enabled = true;

                        button2.Text = "Actualizar";

                        opcion = 0;

                        int Id_Torneo = Convert.ToInt32(comboBox1.SelectedValue);
                        int IdEquipo = GetIdEquipo();

                        dataGridView2.DataSource = equipoTorneoContext.obtenerJugadoresDelEquipo(Id_Torneo, IdEquipo);

                    }
                }
            }


            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBoxButtons botones = MessageBoxButtons.YesNo; //Mensaje de advetencia
            DialogResult dr = MessageBox.Show("¿Seguro desea eliminar el jugador del registro? Esta opcion no se puede deshacer", "Advertencia", botones, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                int Id_Torneo = Convert.ToInt32(comboBox1.SelectedValue);

                long DPI_Jugador = GetDPIJugador();
                int codigoEquipo = GetIdEquipo();

                bool torneoEmpezado = equipoTorneoContext.obtenerTorneoComenzado(Id_Torneo);

                if (torneoEmpezado == true)
                {
                    MessageBox.Show($"El torneo ha comenzado\nNo se puede agregar mas jugadores", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    equipoTorneoContext.DeleteJugadorDeEquipo(Convert.ToInt32(comboBox1.SelectedValue), codigoEquipo, DPI_Jugador); // Ejecutando DELETE en la base de datos
                    dataGridView2.DataSource = equipoTorneoContext.obtenerJugadoresDelEquipo(Convert.ToInt32(comboBox1.SelectedValue), codigoEquipo);
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validaciones = new Validaciones();
            validaciones.validarNumeros(e); //Valida si lo ingresado NO es un numero
        }
    }
}
