using System;
using System.Windows.Forms;
using AdminitracionDeTorneosP.Database;
using AdminitracionDeTorneosP.Model;

namespace AdminitracionDeTorneosP.View
{
    public partial class JornadasPartido : Form
    {
        public AdministraciónDeJornadasDB jornadaContext = new AdministraciónDeJornadasDB();

        public JornadasPartido()
        {
            InitializeComponent();
            comboBox1.DataSource = jornadaContext.CargarComboTorneo(); // Solicitando la informacion de la base de datos para cargarla en el combobox
            comboBox1.DisplayMember = "Nombre"; // Asignando el valor que se mostrara en el combobox
            comboBox1.ValueMember = "Id_Torneo"; // Valor que estara detras de Display
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            comboBox2.Enabled = false;
            textBox2.Enabled = false;
            button8.Enabled = false;
            buttonDetalles.Enabled = false;
        }



        private string GetNombreEquipoLocal()
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
        private string GetNombreEquipoVisita()
        {
            try
            {
                return string.Format(
                    dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString() // Obteniendo el numero de ID seleccioado por medio de la primera columna de la seleccion
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
                    dataGridView2.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString() // Obteniendo el numero de ID seleccioado por medio de la primera columna de la seleccion
                    );
            }
            catch
            {
                return 0;
            }
        }
        private int GetIdEquipoGol()
        {
            try
            {
                return int.Parse(
                    dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[2].Value.ToString() // Obteniendo el numero de ID seleccioado por medio de la primera columna de la seleccion
                    );
            }
            catch
            {
                return 0;
            }
        }
        private int GetIdJuego()
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

        private TimeSpan GetIdHoraInicio()
        {
            try
            {
                return TimeSpan.Parse(
                    dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString() // Obteniendo el numero de ID seleccioado por medio de la primera columna de la seleccion
                    );
            }
            catch
            {
                return TimeSpan.Parse("00:00");
            }
        }

        private TimeSpan GetIdHoraFinal()
        {
            try
            {
                return TimeSpan.Parse(
                    dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString() // Obteniendo el numero de ID seleccioado por medio de la primera columna de la seleccion
                    );
            }
            catch
            {
                return TimeSpan.Parse("00:00");
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            int Id_Equipo1 = jornadaContext.ObtenerIdEquipo(GetNombreEquipoLocal());
            int Id_Equipo2 = jornadaContext.ObtenerIdEquipo(GetNombreEquipoVisita());

            dataGridView2.DataSource = jornadaContext.obtenerJugadoresDeEquipos(Convert.ToInt32(comboBox1.SelectedValue), Id_Equipo1, Id_Equipo2);

            button4.Enabled = true;
            button5.Enabled = true;
            comboBox2.Enabled = true;
            textBox2.Enabled = true;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0 || comboBox2.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show($"Ingrese los datos solicitados", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                TimeSpan horaInicio = GetIdHoraInicio();
                TimeSpan horaFinal = GetIdHoraFinal();

                Double tiempoPermitido = Convert.ToDouble(horaFinal.TotalMinutes - horaInicio.TotalMinutes);

                if(Convert.ToDouble(textBox2.Text) < 0 || Convert.ToDouble(textBox2.Text) > tiempoPermitido)
                {
                    MessageBox.Show($"El tiempo del gol no es permitido\nEl Gol debe de darse en el intervalo de 0 - {tiempoPermitido}", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    long DPI_JUGADOR = GetDPIJugador();
                    int Id_Juego = GetIdJuego();
                    string tipoGol = comboBox2.Text;
                    string tiempo = textBox2.Text;

                    int Id_EquipoGol = GetIdEquipoGol();

                    GOL agregando_goles = new GOL();
                    agregando_goles.Id_Juego = Id_Juego;
                    agregando_goles.DPI_Jugador = DPI_JUGADOR;
                    agregando_goles.Tipo = tipoGol;
                    agregando_goles.Tiempo = tiempo;

                    jornadaContext.Agregar_Nuevos_Goles(agregando_goles);

                    int cantidadPunteoPartido = jornadaContext.ObtenerPunteoYaCreado(Id_Juego);

                    if (cantidadPunteoPartido > 0)
                    {
                        int punteoLocal = jornadaContext.obtenerPunteoEquipoLocal(Id_Juego);
                        int punteoVisita = jornadaContext.obtenerPunteoEquipoVisita(Id_Juego);

                        int Id_EquipoLocal = jornadaContext.obtenerIdLocal(Id_Juego);

                        if (Id_EquipoLocal == Id_EquipoGol)
                        {
                            punteoLocal = punteoLocal + 1;
                        }
                        else
                        {
                            punteoVisita = punteoVisita + 1;
                        }

                        jornadaContext.ActualizarPunteo(Id_Juego, punteoLocal, punteoVisita);

                        label3.Text = $"{punteoLocal} : {punteoVisita}";

                    }
                    else
                    {
                        int Id_EquipoLocal = jornadaContext.ObtenerIdEquipo(GetNombreEquipoLocal());
                        int Id_EquipoVisita = jornadaContext.ObtenerIdEquipo(GetNombreEquipoVisita());

                        int punteoLocal = 0; int punteoVisita = 0;

                        if (Id_EquipoLocal == Id_EquipoGol)
                        {
                            punteoLocal = 1;
                        }
                        else
                        {
                            punteoVisita = 1;
                        }

                        Punteo punteo = new Punteo();
                        punteo.Id_Juego = Id_Juego;
                        punteo.Id_EquipoLocal = Id_EquipoLocal;
                        punteo.Id_EquipoVisita = Id_EquipoVisita;
                        punteo.PunteoEquipoLocal = punteoLocal;
                        punteo.PunteoEquipoLocal = punteoVisita;

                        jornadaContext.AddPunteo(punteo);

                        label3.Text = $"{punteoLocal} : {punteoVisita}";
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show($"Actualmente no hay ningún partido asignado en el torneo\n\n(Seleccione un partido)", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else

            {
                int Id_Equipo1 = jornadaContext.ObtenerIdEquipo(GetNombreEquipoLocal());
                int Id_Equipo2 = jornadaContext.ObtenerIdEquipo(GetNombreEquipoVisita());

                int Id_Juego = GetIdJuego();

                int cantidadPunteoPartido = jornadaContext.ObtenerPunteoYaCreado(Id_Juego);

                button4.Enabled = false;
                button5.Enabled = false;

                if (cantidadPunteoPartido > 0)
                {
                    int punteoLocal = jornadaContext.obtenerPunteoEquipoLocal(Id_Juego);
                    int punteoVisita = jornadaContext.obtenerPunteoEquipoVisita(Id_Juego);

                    label3.Text = $"{punteoLocal} : {punteoVisita}";

                }
                else
                {
                    label3.Text = $"0 : 0";
                }

                button3.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int Id_Juego = GetIdJuego();

            View.CRUD_GOL crudGol = new CRUD_GOL(Id_Juego);
            crudGol.ShowDialog();

            int Id_Equipo1 = jornadaContext.ObtenerIdEquipo(GetNombreEquipoLocal());
            int Id_Equipo2 = jornadaContext.ObtenerIdEquipo(GetNombreEquipoVisita());

            int Id_Torneo = Convert.ToInt32(comboBox1.SelectedValue);

            int punteoEquipoLocal = jornadaContext.obtenerGolesDeEquipoTorneo(Id_Equipo1, Id_Torneo);
            int punteoEquipoVisita = jornadaContext.obtenerGolesDeEquipoTorneo(Id_Equipo2, Id_Torneo);

            jornadaContext.ActualizarPunteo(Id_Juego, punteoEquipoLocal, punteoEquipoVisita);

            label3.Text = $"{punteoEquipoLocal} : {punteoEquipoVisita}";



        }

        private void button6_Click(object sender, EventArgs e)
        {
            int Id_Juego = GetIdJuego();

            View.CRUD_CAMBIOS crudCambio = new CRUD_CAMBIOS(Id_Juego);
            crudCambio.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int Id_Juego = GetIdJuego();

            View.CRUD_REGISTRO_AMONESTACION amonestaciones = new CRUD_REGISTRO_AMONESTACION(Id_Juego);
            amonestaciones.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int Id_Juego = GetIdJuego();

            View.CRUDArbitro_Partido arbitro_Partido = new CRUDArbitro_Partido(Id_Juego);
            arbitro_Partido.ShowDialog();
        }

 

        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = jornadaContext.GetEnfrentamientoDeTorneo(Convert.ToInt32(comboBox1.SelectedValue));
            button2.Enabled = true;
            buttonDetalles.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validaciones = new Validaciones();
            validaciones.validarNumeros(e); //Valida si lo ingresado NO es un numero
        }

        private void buttonDetalles_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show($"Actualmente no hay ningún partido asignado en el torneo\n\n(Seleccione un partido)", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int idJuego = GetIdJuego();
                detallesPartido d = new detallesPartido(dataGridView1,idJuego, Convert.ToInt32(comboBox1.SelectedValue));
                d.Show();
            }
        }
    }
}