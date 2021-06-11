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
    public partial class CRUD_AMONESTACION : Form
    {
        AmonestacionDB AmonestacionContext = new AmonestacionDB();
        
        public CRUD_AMONESTACION()
        {
            InitializeComponent();
            ListTarjetas.AllowUserToAddRows = false;
            ListTarjetas.AllowDrop = false;
            ListTarjetas.AllowUserToDeleteRows = false;
            ListTarjetas.MultiSelect = false;
           
            Get_Tarjetas();
        }

        int opciones = 1;
        private void Get_Tarjetas()
        {
            ListTarjetas.DataSource = AmonestacionContext.GetAmonestacion();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (opciones)
            {
                case 1:

                    if (txtColorTarjeta.Text == "" || txtValorMulta.Text == "" || txtComentario.Text == "")
                    {
                        MessageBox.Show("Valores en blanco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Amonestacion amonestacion = new Amonestacion();
                        //se guarda lo ingresado en el texbox en una lista
                        amonestacion.Color_Tarjeta = txtColorTarjeta.Text;
                        amonestacion.Valor_Multa = Convert.ToDecimal(txtValorMulta.Text);
                        amonestacion.Comentario = txtComentario.Text;
                        AmonestacionContext.AddTarjeta(amonestacion);
                        //Get_Torneo();

                        txtColorTarjeta.Clear();
                        txtValorMulta.Clear();
                        txtComentario.Clear();
                        Get_Tarjetas();
                    }            
                    break;
                case 2:
                    if (txtColorTarjeta.Text == "" || txtValorMulta.Text == "" || txtComentario.Text == "")
                    {
                        MessageBox.Show("Valores en blanco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //Guarda lo del Texbox 
                        Amonestacion amonestacion = new Amonestacion();
                        amonestacion.Id_Tarjeta = Convert.ToInt32(GetId());
                        amonestacion.Color_Tarjeta = txtColorTarjeta.Text;
                        amonestacion.Valor_Multa = Convert.ToDecimal(txtValorMulta.Text);
                        amonestacion.Comentario = txtComentario.Text;
                        AmonestacionContext.UpdateTarjeta(amonestacion);

                        txtColorTarjeta.Clear();
                        txtValorMulta.Clear();
                        txtComentario.Clear();
                        btnEliminar.Enabled = true ;
                        Get_Tarjetas();
                    }
                    break;
            }
            opciones = 1;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ListTarjetas.Enabled = false;
            MessageBoxButtons eliminar = MessageBoxButtons.YesNo;
            DialogResult dr2 = MessageBox.Show("¿SEGURO DE QUE DESEA actualizar informacion de la Tarjeta?", "ALERTA", eliminar, MessageBoxIcon.Warning);
            if (dr2 == DialogResult.Yes)
            {
                opciones = 2;
                //Se muestra en el texbox los datos del Torneo Seleccionado
                int? Id_Tarjeta = GetId();
                Amonestacion TarjetaEditada = AmonestacionContext.GetTarjeta(Convert.ToInt32(Id_Tarjeta));
                txtColorTarjeta.Text = TarjetaEditada.Color_Tarjeta;
                txtValorMulta.Text = Convert.ToString(TarjetaEditada.Valor_Multa);
                txtComentario.Text = TarjetaEditada.Comentario;
                btnEliminar.Enabled = false;
            }
            else if (dr2 == DialogResult.No)
            {
                ListTarjetas.Enabled = true;
                MessageBox.Show("Se cancelo correctamnete la actualizacion de datos");
            }
        }

        private int? GetId()
        {
            try
            {
                return int.Parse(
                    ListTarjetas.Rows[ListTarjetas.CurrentRow.Index].Cells[0].Value.ToString()
                    );
            }
            catch
            {
                return null;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBoxButtons eliminar = MessageBoxButtons.YesNo;
            DialogResult dr = MessageBox.Show("¿SEGURO DE QUE DESEA ELIMINAR EL TORNEO?", "ALERTA", eliminar, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                int? Id_Tarjeta = GetId();
                AmonestacionContext.DeleteTorneo(Convert.ToInt32(Id_Tarjeta));
                Get_Tarjetas();
            }
            else if (dr == DialogResult.No)
            {
                MessageBox.Show("Se cancelo la eliminacion correctamente");
            }
        }
    }
}
