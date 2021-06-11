using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using AdminitracionDeTorneosP.Database;
using AdminitracionDeTorneosP.Model;

namespace AdminitracionDeTorneosP.View
{
    public partial class CRUD_CAMBIOS : Form
    {
        public CAMBIO_DB cambio_context = new CAMBIO_DB();
        public CAMBIO jugador_seleccionado = new CAMBIO();
        CAMBIO_DB combo = new CAMBIO_DB();
        CAMBIO_DB combo2 = new CAMBIO_DB();
        CAMBIO_DB combo3 = new CAMBIO_DB();
        CAMBIO_DB combo4 = new CAMBIO_DB();
        ErrorProvider error = new ErrorProvider();

        public int accion = 1;

        public int ID_JUEGO;

        TimeSpan hora_inicio;
        TimeSpan hora_final;


        public CRUD_CAMBIOS(int Id_Juego)
        {
            InitializeComponent();
            ID_JUEGO = Id_Juego;
            mostrar_jugaadores_datagrid();
            
           // combo2.busqueda_tabla_jugadoress_por_equipo(cmb_jugadores_salen, ID_JUEGO);
            
            lista_cambios_data_grid.AllowUserToAddRows = false;
            lista_cambios_data_grid.AllowDrop = false;
            lista_cambios_data_grid.AllowUserToDeleteRows = false;
            txt_id_juego.Text = ID_JUEGO.ToString();
            txt_id_local.Visible = false;
            txt_id_visita.Visible = false;
            txt_id_juego.Enabled = false;
            txt_id_equipo_entra.Visible = false;
            txt_id_equipo_sale.Visible = false;
            txt_id_juego.Visible = false;
            textBox1.Visible = false;
            label5.Visible = false;
            txt_sale.Enabled = false;




        }
        //metod quie me va actualizando la infoirmacion de mi base de datos
        public void mostrar_jugaadores_datagrid()
        {

            lista_cambios_data_grid.DataSource = cambio_context.busqueda_CAMBIOS_total();
        }


        private void lista_cambios_data_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CRUD_CAMBIOS_Load(object sender, EventArgs e)
        {

        }

        private void txt_id_juego_TextChanged(object sender, EventArgs e)
        {
            //Muesta en el label el nombre del id seleccionado
            string[] datos = cambio_context.captar_info_partidos(Convert.ToInt32(txt_id_juego.Text));

            //tendra dentro de el ,el codigo del equipo local
            txt_id_local.Text = datos[1];
            //tendra dentro de el, el equipo visitante
            txt_id_visita.Text = datos[2];
            textBox1.Text = datos[0];

            combo3.buscar_codigos_equipos_ids(cmb_equuipos_encuentros, ID_JUEGO, Convert.ToInt32(textBox1.Text));
            string[] datoss = cambio_context.captar_info_horas_de_partidos(Convert.ToInt32(txt_id_juego.Text));

            //tendra dentro de el ,el codigo del equipo local
            txt_hora_inicio.Text = datoss[0];
            
            //tendra dentro de el, el equipo visitante
            txt_hora_final.Text = datoss[1];
            

        }

        private void txt_id_local_TextChanged(object sender, EventArgs e)
        {
            //Muesta en el label el nombre del id seleccionado
            string[] datos = cambio_context.captar_info_equipos(Convert.ToInt32(txt_id_local.Text));
            //tendra dentro de él, el nombre del equipo local
            label6.Text = datos[0];
        }

        private void txt_id_visita_TextChanged(object sender, EventArgs e)
        {
            //Muesta en el label el nombre del id seleccionado
            string[] datos = cambio_context.captar_info_equipos(Convert.ToInt32(txt_id_visita.Text));
            //tendra dentro el nombre del equipo visitante
            label8.Text = datos[0];
        }

        private void cmb_jugadores_entran_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmb_jugadores_entran.SelectedIndex >= 0)
            {
                string[] datos = cambio_context.captar_info_jugador_dpi_equipo((cmb_jugadores_entran.Text));
                //Muesta en el texbox muestra el dpi del jugador a salir
                txt_dpi_entra.Text = datos[0];

             
            }
        }

        private void txt_dpi_entra_TextChanged(object sender, EventArgs e)
        {
          



        }

        private void cmb_jugadores_salen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_jugadores_salen.SelectedIndex >= 0)
            {
                string[] datos = cambio_context.captar_info_jugador_dpi_equipo((cmb_jugadores_salen.Text));
                //Muesta en el texbox muestra el dpi del jugador a salir
                txt_dpi_sale.Text = datos[0];

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {



            switch (accion)


            {
                case 1:
                    //creandi istancia con variable de para poder acceder al agregar un nuevo cliene o un nuevo query
                    CAMBIO agregando_cambio = new CAMBIO();
                    if ((cmb_jugadores_entran.Text == "Elige una opcion") || (cmb_jugadores_salen.Text == "Elige una opcion") || (txt_tiempo_entra.Text == "") || (txt_sale.Text == ""))
                    {
                        MessageBox.Show("Espacion en balco u opciones no selecionadas", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    else
                    {
                        if ((Convert.ToInt32(txt_tiempo_entra.Text) <= 0) || (Convert.ToInt32(txt_sale.Text) <= 0))
                        {
                            MessageBox.Show("El tiempo no puede ir negativos", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {
                            if ((txt_dpi_entra.Text == txt_dpi_sale.Text))
                            {
                                MessageBox.Show("Para hacer un cambio de jugador en el juego\nDebe seleccionar un jugador Distinto", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {

                                if (txt_id_equipo_entra.Text == txt_id_equipo_sale.Text)
                                {
                                    //agregando validacion par las horas esten en el rango
                                    hora_inicio = TimeSpan.Parse(txt_hora_inicio.Text);
                                    hora_final = TimeSpan.Parse(txt_hora_final.Text);

                                    Double tiempoPermitido = Convert.ToDouble(hora_final.TotalMinutes - hora_inicio.TotalMinutes);
                                    if (Convert.ToDouble(txt_tiempo_entra.Text) < 0 || Convert.ToDouble(txt_tiempo_entra.Text) > tiempoPermitido)
                                    {
                                        MessageBox.Show($"El tiempo del gol no es permitido\nEl Gol debe de darse en el intervalo de 0 - {tiempoPermitido}", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                    else
                                    {
                                        //agregando infirmacion a la base de datos
                                        agregando_cambio.Id_Juego = Convert.ToInt32(txt_id_juego.Text);
                                        agregando_cambio.DPI_JugadorEntra = Convert.ToInt64(txt_dpi_entra.Text);
                                        agregando_cambio.DPI_JugadorSALE = Convert.ToInt64(txt_dpi_sale.Text);
                                        agregando_cambio.TiempoEntrada = Convert.ToInt32(txt_tiempo_entra.Text);
                                        agregando_cambio.TiempoSalida = Convert.ToInt32(txt_sale.Text);

                                        cambio_context.Agregar_nuevos_cambios(agregando_cambio);
                                        mostrar_jugaadores_datagrid();


                                        // bandera funciona para limpiar texbox cuando si se agrega un cliente a la base de datos
                                        if (cambio_context.banera_agregar == 1)
                                        {
                                            txt_dpi_entra.Text = "";
                                            txt_dpi_sale.Text = "";
                                            txt_tiempo_entra.Text = "";
                                            txt_sale.Text = "";
                                            cmb_jugadores_entran.Text = "Elige una opcion";
                                            cmb_jugadores_salen.Text = "Elige una opcion";
                                        }
                                    }


                                  
                                }
                                else
                                {

                                    MessageBox.Show("No se puede hacer el cambio...\nLos jugadores son de quipos distintos\nPara Realizar el cambio ambos jugadores deben ser del mismo equipo", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                                }

                            }

                        }
                    }
                    break;







                case 2:
                    if ((cmb_jugadores_entran.Text == "Elige una opcion") || (cmb_jugadores_salen.Text == "Elige una opcion") || (txt_tiempo_entra.Text == "") || (txt_sale.Text == ""))
                    {
                        MessageBox.Show("Espacion en balco u opciones no selecionadas", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    else
                    {
                        if ((Convert.ToInt32(txt_tiempo_entra.Text) <= 0) || (Convert.ToInt32(txt_sale.Text) <= 0))
                        {
                            MessageBox.Show("El tiempo no puede ir negativos", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {
                            if ((txt_dpi_entra.Text == txt_dpi_sale.Text))
                            {
                                MessageBox.Show("Para hacer un cambio de jugador en el juego\nDebe seleccionar un jugador Distinto", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                if (txt_id_equipo_entra.Text == txt_id_equipo_sale.Text)
                                {
                                    int? iod_cambio = Get_idcambio_seleccionado();
                                    long dpi_entra = Convert.ToInt64(txt_dpi_entra.Text);
                                    long dpisale = Convert.ToInt64(txt_dpi_sale.Text);
                                    int tiempo_entrada = Convert.ToInt32(txt_tiempo_entra.Text);
                                    int tiemposalida = Convert.ToInt32(txt_sale.Text);
                                    cambio_context.Actualizar_sustituciones(iod_cambio, dpi_entra, dpisale, tiempo_entrada, tiemposalida);
                                    mostrar_jugaadores_datagrid();
                                    lista_cambios_data_grid.Enabled = true;
                                    accion = 1;


                                    txt_dpi_entra.Text = "";
                                    txt_dpi_sale.Text = "";
                                    txt_tiempo_entra.Text = "";
                                    txt_sale.Text = "";
                                    cmb_jugadores_entran.Text = "Elige una opcion";
                                    cmb_jugadores_salen.Text = "Elige una opcion";
                                    //combo.busqueda_tabla_jugadoress_por_equipo(cmb_jugadores_entran, ID_JUEGO);
                                    //combo2.busqueda_tabla_jugadoress_por_equipo(cmb_jugadores_salen, ID_JUEGO);
                                    txt_id_juego.Text = ID_JUEGO.ToString();

                                }
                                else
                                {

                                    MessageBox.Show("No se puede hacer el cambio...\nLos jugadores son de quipos distintos\nPara Realizar el cambio ambos jugadores deben ser del mismo equipo", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                                }

                            }

                        }
                    }

                    break;

            }

        }
       

        private void txt_tiempo_entra_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validacion de solo numeros en el texbox
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Agregar solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txt_sale_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validacion de solo numeros en el texbox
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Agregar solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void cmb_jugadores_entran_Validating(object sender, CancelEventArgs e)
        {
            //validacion para alertas no nulas
            if (cmb_jugadores_entran.Text == "Elige una opcion")
            {
                error.SetError(cmb_jugadores_entran, "Debe elegir una opcion");

            }
            else
            {
                error.SetError(cmb_jugadores_entran, "");

            }
        }

        private void cmb_jugadores_salen_Validating(object sender, CancelEventArgs e)
        {
            //validacion para alertas no nulas
            if (cmb_jugadores_salen.Text == "Elige una opcion")
            {
                error.SetError(cmb_jugadores_salen, "Debe elegir una opcion");

            }
            else
            {
                error.SetError(cmb_jugadores_salen, "");

            }

        }

        private void txt_tiempo_entra_Validating(object sender, CancelEventArgs e)
        {
            //validacion para alertas no nulas
            if (txt_tiempo_entra.Text == "")
            {
                error.SetError(txt_tiempo_entra, "Este campo no puede ser vacio");

            }
            else
            {
                error.SetError(txt_tiempo_entra, "");

            }

        }

        private void txt_sale_Validating(object sender, CancelEventArgs e)
        {
            //validacion para alertas no nulas
            if (txt_sale.Text == "")
            {
                error.SetError(txt_sale, "Este campo no puede ser vacio");

            }
            else
            {
                error.SetError(txt_sale, "");

            }

        }
        //metodo que permitira seleccionar el dpi del jugador, cuando le de clik a alguno de los jugadores del fatagrid
        private int? Get_idcambio_seleccionado()
        {
            try
            {
                return int.Parse(lista_cambios_data_grid.Rows[lista_cambios_data_grid.CurrentRow.Index].Cells[0].Value.ToString());
            }

            catch
            {
                return null;
            }

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
         
            lista_cambios_data_grid.Enabled = false;
            MessageBoxButtons eliminar = MessageBoxButtons.YesNo;
            DialogResult dr2 = MessageBox.Show("¿SEGURO DE QUE DESEA actualizar informacion ?", "ALERTA", eliminar, MessageBoxIcon.Warning);
            if (dr2 == DialogResult.Yes)
            {
                accion = 2;
                //llamado al dpi del jugador a travez del datagrid
                int? id_cambio = Get_idcambio_seleccionado();

                CAMBIO cambio_edita_v = cambio_context.Get_cambios_A_EDITAR(id_cambio);
                txt_id_juego.Text = cambio_edita_v.Id_Juego.ToString();
                txt_dpi_entra.Text = cambio_edita_v.DPI_JugadorEntra.ToString();
                txt_dpi_sale.Text = cambio_edita_v.DPI_JugadorSALE.ToString();
                txt_tiempo_entra.Text = Convert.ToString(cambio_edita_v.TiempoEntrada);
                txt_sale.Text = Convert.ToString(cambio_edita_v.TiempoSalida);
                //combo.busqueda_tabla_jugadoress_por_equipo(cmb_jugadores_entran, Convert.ToInt32(txt_id_juego.Text));
                //combo2.busqueda_tabla_jugadoress_por_equipo(cmb_jugadores_salen, Convert.ToInt32(txt_id_juego.Text));
              


            }
            else if (dr2 == DialogResult.No)
            {
      
                lista_cambios_data_grid.Enabled = true;
                MessageBox.Show("Actualizacion cancelada exitosamente");
            }








        }

        private void button1_Click(object sender, EventArgs e)
        {
            //boton paraeliminar un registro
            //confirmacion para eliminar al jugador
            //creando una variable de tipo MessageBoxButtons.YesNo


            MessageBoxButtons eliminar = MessageBoxButtons.YesNo;
            DialogResult dr = MessageBox.Show("¿SEGURO DE QUE DESEA ELIMINAR EL REGISTRO DE SUSTITUCION?", "ALERTA", eliminar, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                int? id_sustitucion = Get_idcambio_seleccionado();
                cambio_context.Eliminar_sustitucion(id_sustitucion);

                mostrar_jugaadores_datagrid();

            }
            else if (dr == DialogResult.No)
            {
                MessageBox.Show("Se cancelo la eliminacion correctamente");
            }
        }

        private void txt_id_equipo_entra_TextChanged(object sender, EventArgs e)
        {
            string[] datos = cambio_context.captar_info_nombre_equipo_id_equipo(Convert.ToInt32(txt_id_equipo_entra.Text));
            //Muesta en el texbox muestra el dpi del jugador a salir
            //label_equipo1.Text = datos[0];
        }

        private void txt_dpi_sale_TextChanged(object sender, EventArgs e)
        {
   
        }

        private void txt_id_equipo_sale_TextChanged(object sender, EventArgs e)
        {
            string[] datos = cambio_context.captar_info_nombre_equipo_id_equipo(Convert.ToInt32(txt_id_equipo_sale.Text));
            //Muesta en el texbox muestra el dpi del jugador a salir
            //label_equipo2.Text = datos[0];

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmb_equuipos_encuentros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_equuipos_encuentros.SelectedIndex >= 0)
            {
                combo3.buscar_jugadores_segun_equipo(cmb_jugadores_entran, cmb_equuipos_encuentros.Text,Convert.ToInt32(textBox1.Text));
                combo3.buscar_jugadores_segun_equipo(cmb_jugadores_salen, cmb_equuipos_encuentros.Text, Convert.ToInt32(textBox1.Text));

            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txt_tiempo_entra_TextChanged(object sender, EventArgs e)
        {
            txt_sale.Text = txt_tiempo_entra.Text;
        }
    }
}
