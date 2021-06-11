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
    public partial class CRUD_REGISTRO_AMONESTACION : Form
    {
        Registro_AmonestacionDB registro_AmonestacionDB = new Registro_AmonestacionDB();
        
        public int Id_Juego;
        public long DPI;
        public int accion = 1;
        public CRUD_REGISTRO_AMONESTACION(int Id_Juegoo)
        {
            InitializeComponent();
            Id_Juego = Id_Juegoo;
            LIstAmonestaciones.AllowUserToAddRows = false;
            LIstAmonestaciones.AllowDrop = false;
            LIstAmonestaciones.AllowUserToDeleteRows = false;
            LIstAmonestaciones.MultiSelect = false;
            registro_AmonestacionDB.Equipos_Partido(cmbEquipos, Id_Juego);
            cmbJugador.Enabled = false;
            cmbTarjeta.Enabled = false;
            txtTiempo.Enabled = false;
            Get_Registro();
        }

        private void cmbEquipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string equipo = Convert.ToString(cmbEquipos.SelectedItem);
            string[] equipoArray = equipo.Split('-');
            //Codigo del equipo almacenado en la posicion 0
            int idEquipo = Convert.ToInt32(equipoArray[0]);

            registro_AmonestacionDB.Jugadores_Equipo(cmbJugador, idEquipo);
            cmbJugador.Enabled = true;

        }

        private void cmbJugador_SelectedIndexChanged(object sender, EventArgs e)
        {
            registro_AmonestacionDB.GetTarjetas(cmbTarjeta);
            cmbTarjeta.Enabled = true;
        }

        private void cmbTarjeta_SelectedIndexChanged(object sender, EventArgs e)
        {            
            txtTiempo.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (accion)
            {
                //1 = Guardar
                case 1:
                    if (cmbEquipos.Text == "" || cmbJugador.Text == "" || cmbTarjeta.Text == "" || txtTiempo.Text == "")
                    {
                        MessageBox.Show("Valores en blanco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string equipo = Convert.ToString(cmbJugador.SelectedItem);
                        string[] equipoArray = equipo.Split(' ');
                        //Nombre almacenado en la posicion 0
                        //Apellidos almacenado en la posicion 1
                        string Nombres = "";
                        string Apellidos = "";
                        if(equipoArray.Length == 2)
                        {
                            Nombres = equipoArray[0];
                            Apellidos = equipoArray[1];
                        }else if (equipoArray.Length == 4)
                        {
                            Nombres = $"{equipoArray[0]} {equipoArray[1]}";
                            Apellidos = $"{equipoArray[2]} {equipoArray[3]}";
                        }
                        

                        string Tarjeta = Convert.ToString(cmbTarjeta.SelectedItem);
                        string[] ArregloTarjeta = Tarjeta.Split('-');

                        int Id_Tarjeta = Convert.ToInt32(ArregloTarjeta[0]);

                        Registro_Amonestacion registro_Amonestacion = new Registro_Amonestacion();
                        registro_Amonestacion.Tiempo = txtTiempo.Text;
                        registro_Amonestacion.DPI_Jugador = registro_AmonestacionDB.DPI_Jugador(Nombres, Apellidos);
                        registro_Amonestacion.Id_Tarjeta = Id_Tarjeta;
                        registro_AmonestacionDB.AddRegistroAmonestacion(registro_Amonestacion, Id_Juego);
                        Get_Registro();
                    }
                    break;
                case 2:

                    if (cmbEquipos.Text == "" || cmbJugador.Text == "" || cmbTarjeta.Text == "" || txtTiempo.Text == "")
                    {
                        MessageBox.Show("Valores en blanco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        long? Buscar_DPI_Jugador = GetDPI();
                        int? Buscar_Id_Tarjeta = GetTarjeta();

                        string equipo = Convert.ToString(cmbJugador.Text);
                        string[] equipoArray = equipo.Split(' ');
                        //Nombre almacenado en la posicion 0
                        //Apellidos almacenado en la posicion 1
                        string Nombres = "";
                        string Apellidos = "";
                        if (equipoArray.Length == 2)
                        {
                            Nombres = equipoArray[0];
                            Apellidos = equipoArray[1];
                        }
                        else if (equipoArray.Length == 4)
                        {
                            Nombres = $"{equipoArray[0]} {equipoArray[1]}";
                            Apellidos = $"{equipoArray[2]} {equipoArray[3]}";
                        }


                        string Tarjeta = Convert.ToString(cmbTarjeta.Text);
                        string[] ArregloTarjeta = Tarjeta.Split('-');

                        int Id_Tarjeta = Convert.ToInt32(ArregloTarjeta[0]);

                        

                        Registro_Amonestacion registro_Amonestacion = new Registro_Amonestacion();
                        registro_Amonestacion.Tiempo = txtTiempo.Text;
                        registro_Amonestacion.DPI_Jugador = registro_AmonestacionDB.DPI_Jugador(Nombres, Apellidos);
                        registro_Amonestacion.Id_Tarjeta = Id_Tarjeta;
                        registro_AmonestacionDB.UpdateRegistro(registro_Amonestacion, Id_Juego, Convert.ToInt64(Buscar_DPI_Jugador), Convert.ToInt32(Buscar_Id_Tarjeta));
                        accion = 1;
                        Get_Registro();
                    }
                        break;
            }
        }

        private void Get_Registro()
        {
            LIstAmonestaciones.DataSource = registro_AmonestacionDB.GetRegistro_Amonestacions();
        }

        private int? GetDPI()
        {
            try
            {
                return int.Parse(
                    LIstAmonestaciones.Rows[LIstAmonestaciones.CurrentRow.Index].Cells[1].Value.ToString()
                    );
            }
            catch
            {
                return null;
            }
        }

        private int? GetTarjeta()
        {
            try
            {
                return int.Parse(
                    LIstAmonestaciones.Rows[LIstAmonestaciones.CurrentRow.Index].Cells[2].Value.ToString()
                    );
            }
            catch
            {
                return null;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            MessageBoxButtons eliminar = MessageBoxButtons.YesNo;
            DialogResult dr2 = MessageBox.Show("¿SEGURO DE QUE DESEA actualizar informacion de la Amonestacion?", "ALERTA", eliminar, MessageBoxIcon.Warning);
            if (dr2 == DialogResult.Yes)
            {
                accion = 2;
                //Se muestra en el texbox los datos del Torneo Seleccionado
                long? DPI = GetDPI();
                int? Tarjeta = GetTarjeta();
                registro_AmonestacionDB.Jugadores(cmbJugador, Convert.ToInt32(DPI));
                cmbTarjeta.Enabled = true;
                txtTiempo.Enabled = true;
                registro_AmonestacionDB.Tarjetas(cmbTarjeta, Convert.ToInt32(Tarjeta));
                registro_AmonestacionDB.GetTarjetas(cmbTarjeta);
                Registro_Amonestacion editar_Registro = registro_AmonestacionDB.Get_Amonestacion(Id_Juego, Convert.ToInt64(DPI), Convert.ToInt32(Tarjeta));
                txtTiempo.Text = editar_Registro.Tiempo;
            }
            else if (dr2 == DialogResult.No)
            {
                MessageBox.Show("Se cancelo correctamnete la actualizacion de datos");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBoxButtons eliminar = MessageBoxButtons.YesNo;
            DialogResult dr2 = MessageBox.Show("¿SEGURO DE QUE DESEA Eliminar informacion de la Amonestacion?", "ALERTA", eliminar, MessageBoxIcon.Warning);
            if (dr2 == DialogResult.Yes)
            {
                long DPI_Jugador = Convert.ToInt64(GetDPI());
                int Id_Tarjeta = Convert.ToInt32(GetTarjeta());

                registro_AmonestacionDB.DeleteRegistro(Id_Juego,DPI_Jugador, Id_Tarjeta);
                Get_Registro();
            }
            else if (dr2 == DialogResult.No)
            {
                MessageBox.Show("Se cancelo Eliminar ");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
