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
    public partial class VISTA_PAGOS_TARGETAS : Form
    {
        public PAGOS_TARGETAS_DB pago_context = new PAGOS_TARGETAS_DB();
        public PAGOS_TAREGTAS registros_targeta_seleccionado = new PAGOS_TAREGTAS();
        ErrorProvider error = new ErrorProvider();
        ErrorProvider error2 = new ErrorProvider();
        public int accion = 1;

        public VISTA_PAGOS_TARGETAS()
        {
            InitializeComponent();
            mostrar_registro_pagos_datagrid();
            lista_amonstaciones_datagrid .AllowUserToAddRows = false;
            lista_amonstaciones_datagrid.AllowDrop = false;
            lista_amonstaciones_datagrid.AllowUserToDeleteRows = false;
            txt_id_juego.Enabled = false;
            txt_dpi.Enabled = false;
            txt_id_targeta.Enabled = false;
            txt_tiempo.Enabled = false;
        }
        public void mostrar_registro_pagos_datagrid()
        {

            lista_amonstaciones_datagrid.DataSource = pago_context.busqueda_pagos_targetas_total();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //metodo que permitira seleccionar el dpi del jugador, cuando le de clik a alguno de los jugadores del fatagrid
        private int? Get_idjuego_seleccionado()
        {
            try
            {
                return int.Parse(lista_amonstaciones_datagrid.Rows[lista_amonstaciones_datagrid.CurrentRow.Index].Cells[0].Value.ToString());
            }

            catch
            {
                return null;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            lista_amonstaciones_datagrid.Enabled = false;
            MessageBoxButtons eliminar = MessageBoxButtons.YesNo;
            DialogResult dr2 = MessageBox.Show("¿SEGURO DE QUE DESEA actualizar informacion ?", "ALERTA", eliminar, MessageBoxIcon.Warning);
            if (dr2 == DialogResult.Yes)
            {
                accion = 2;
                //llamado al dpi del jugador a travez del datagrid
                int? id_juego = Get_idjuego_seleccionado();

                PAGOS_TAREGTAS cambio_edita_v = pago_context.Get_pagos_A_EDITAR(id_juego);

                txt_id_juego.Text = cambio_edita_v.Id_Juego.ToString();
                txt_dpi.Text = cambio_edita_v.DPI_Jugador.ToString();
                txt_id_targeta.Text = cambio_edita_v.Id_Tarjeta.ToString();
                cmb_pagada.Text = cambio_edita_v.Pagada;
                txt_tiempo.Text = cambio_edita_v.Tiempo;
                txt_fecha.Text = cambio_edita_v.Fecha_Pago;
            }
            else if (dr2 == DialogResult.No)
            {

                lista_amonstaciones_datagrid.Enabled = true;
                MessageBox.Show("Actualizacion cancelada exitosamente");
            }

        }
        //txt_id_juego.Text
        //    txt_dpi.Text
        //    txt_id_targeta
        //txt_tiempo.Text

        private void button2_Click(object sender, EventArgs e)
        {


            switch (accion)
            {
                case 1:
                    break;
                case 2:
                    if ((cmb_pagada.Text == "Seleccione una opcion") || (txt_fecha.Text == ""))
                    {
                        MessageBox.Show("Existen campos nulos o no se eligio una opcion valida", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DateTime fecha;
                        if (!DateTime.TryParse(txt_fecha.Text, out fecha))
                        {
                            MessageBox.Show("Formato de fecha incorrecto Fecha correcta: DD/MM/AA", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {

                            int? id_juego = Get_idjuego_seleccionado();
                            string pagada_act = cmb_pagada.Text;
                            DateTime fecha_pagada = Convert.ToDateTime(txt_fecha.Text);

                            pago_context.Actualizar_pagos_targetas(id_juego, pagada_act, fecha_pagada);

                            mostrar_registro_pagos_datagrid();
                            lista_amonstaciones_datagrid.Enabled = true;
                            accion = 1;
                            cmb_pagada.Text = "Seleccione una opcion";
                            txt_fecha.Text = "";
                            txt_id_juego.Text = "";
                            txt_dpi.Text = "";
                            txt_id_targeta.Text = "";
                            txt_tiempo.Text = "";
                        }

                    }
                    




                    break;
            
            }
            












        }

        private void txt_fecha_Validating(object sender, CancelEventArgs e)
        {
            //validando la fecha
            DateTime fecha_nacimiento;


            if (!DateTime.TryParse(txt_fecha.Text, out fecha_nacimiento))
            {

                error2.SetError(txt_fecha, "El formato debe ser: (DD/MM/AA)");

            }
            else
            {
                error2.SetError(txt_fecha, "");

            }

            //validar 2 campos vacios
            if (txt_fecha.Text == "")
            {
                error.SetError(txt_fecha, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(txt_fecha, "");

            }

        }

        private void cmb_pagada_Validating(object sender, CancelEventArgs e)
        {
            //validar que se elija una opcion correcta
            if (cmb_pagada.Text == "Seleccione una opcion")
            {
                error.SetError(cmb_pagada, "Debe seleccinar una opcion valida");

            }
            else
            {
                error.SetError(cmb_pagada, "");

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txt_id_targeta_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
