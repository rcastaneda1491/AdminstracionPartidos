using System;
using System.Windows.Forms;
using AdminitracionDeTorneosP.Model;
using AdminitracionDeTorneosP.Database;

namespace AdminitracionDeTorneosP.View
{
    public partial class Torneo2 : Form
    {
        public TorneoDB TorneoContext = new TorneoDB();
        public bool Proceso_Torneo;
        //ICONOS se muetra al lado del texbox un icono de error, esto ayuda a mostrar un pequeño mensaje al usuario en como deberia llenar el texbox
        ErrorProvider error = new ErrorProvider();
        ErrorProvider error2 = new ErrorProvider();
        public Torneo2()
        {
            InitializeComponent();
            Get_Torneo();
            ListTorneos.AllowUserToAddRows = false;
            ListTorneos.AllowDrop = false;
            ListTorneos.AllowUserToDeleteRows = false;
            ListTorneos.MultiSelect = false;
        }

        public int accion = 1;

        //Procedimiento que muestra los datos de la tabla
        private void Get_Torneo()
        {
            ListTorneos.DataSource = TorneoContext.GetTorneos();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (accion)
            {
                //1 = Guardar
                case 1:
                    
                    if(txtName.Text == "" || txtDateInicio.Text == "" || txtDateFIn.Text == "" ||
                        txtType.Text == "" ||
                        txtMaxPlayer.Text == "" ||
                        txtEdadMinima.Text == "" ||
                        txtEdadMaxima.Text == "" ||
                        txtPuntosVictoria.Text == "" ||
                        txtPuntosEmpate.Text == "" ||
                        txtPuntosDerrota.Text == "")
                    {
                        MessageBox.Show("Valores en blanco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        //validando fechas que esten en el formato correcto
                        DateTime fechas,fechas1;
                        if (!DateTime.TryParse(txtDateInicio.Text, out fechas) || (!DateTime.TryParse(txtDateFIn.Text, out fechas1)))
                        {
                            MessageBox.Show("Formato de fecha incorrecto\nFecha permitida: DD/MM/AA", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {

                            Torneos torneos = new Torneos();
                            //se guarda lo ingresado en el texbox en una lista
                            torneos.Nombre = txtName.Text;
                            torneos.FechaIncio = Convert.ToDateTime(txtDateInicio.Text);
                            torneos.FechaFinaliza = Convert.ToDateTime(txtDateFIn.Text);
                            torneos.Tipo = txtType.Text;
                            torneos.NumeroMaximoJugadores = Convert.ToInt32(txtMaxPlayer.Text);
                            torneos.EdadMinima = Convert.ToInt32(txtEdadMinima.Text);
                            torneos.EdadMaxima = Convert.ToInt32(txtEdadMaxima.Text);
                            torneos.PuntosVictoria = Convert.ToInt32(txtPuntosVictoria.Text);
                            torneos.PuntosEmpate = Convert.ToInt32(txtPuntosEmpate.Text);
                            torneos.PuntosDerrota = Convert.ToInt32(txtPuntosDerrota.Text);
                            torneos.tipoFutbolTorneo = comboBox1.Text;
                            torneos.costo =  Convert.ToDouble(txtCosto.Text);
                            TorneoContext.AddTorneo(torneos);
                            Get_Torneo();

                            txtName.Text = "";
                            txtDateInicio.Text = "";
                            txtDateFIn.Text = "";
                            txtType.Text = "";
                            txtMaxPlayer.Text = "";
                            txtEdadMinima.Text = "";
                            txtEdadMaxima.Text = "";
                            txtPuntosVictoria.Text = "";
                            txtPuntosEmpate.Text = "";
                            txtPuntosDerrota.Text = "";
                            txtCosto.Text = "";
                        }

                        
                    }
                break;
                //2 = Modificar
                case 2:
                    

                        if (txtName.Text == "" || txtDateInicio.Text == "" || txtDateFIn.Text == "" ||
                        txtType.Text == "" ||
                        txtMaxPlayer.Text == "" ||
                        txtEdadMinima.Text == "" ||
                        txtEdadMaxima.Text == "" ||
                        txtPuntosVictoria.Text == "" ||
                        txtPuntosEmpate.Text == "" ||
                        txtPuntosDerrota.Text == "" ||
                        txtCosto.Text == ""
                        )
                        {
                            MessageBox.Show("valores en blanco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            //validando fechas que esten en el formato correcto
                            DateTime fechas, fechas1;
                            if (!DateTime.TryParse(txtDateInicio.Text, out fechas) || (!DateTime.TryParse(txtDateFIn.Text, out fechas1)))
                            {
                                MessageBox.Show("Formato de fecha incorrecto\nFecha permitida: DD/MM/AA", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                //Guarda lo del Texbox en Variables
                                int? Id_Torneo = GetId();
                                string Nombre = txtName.Text;
                                DateTime FechaIncio = Convert.ToDateTime(txtDateInicio.Text);
                                DateTime FechaFinaliza = Convert.ToDateTime(txtDateFIn.Text);
                                string Tipo = txtType.Text;
                                int NumeroMaximoJugadores = Convert.ToInt32(txtMaxPlayer.Text);
                                int EdadMinima = Convert.ToInt32(txtEdadMinima.Text);
                                int EdadMaxima = Convert.ToInt32(txtEdadMaxima.Text);
                                int PuntosVictoria = Convert.ToInt32(txtPuntosVictoria.Text);
                                int PuntosEmpate = Convert.ToInt32(txtPuntosEmpate.Text);
                                int PuntosDerrota = Convert.ToInt32(txtPuntosDerrota.Text);
                                string tipoFutbolTorneo = comboBox1.Text;
                                double costo = Convert.ToDouble(txtCosto.Text);
                                Proceso_Torneo = false;
                                TorneoContext.UpdateTorneo(Convert.ToInt32(Id_Torneo), Nombre, FechaIncio, FechaFinaliza, Tipo, NumeroMaximoJugadores, EdadMinima, EdadMaxima, PuntosVictoria, PuntosEmpate, PuntosDerrota, tipoFutbolTorneo, costo, Proceso_Torneo);
                                Get_Torneo();
                                accion = 1;
                                ListTorneos.Enabled = true;
                                btnEliminar.Enabled = true;
                                txtName.Text = "";
                                txtDateInicio.Text = "";
                                txtDateFIn.Text = "";
                                txtType.Text = "";
                                txtMaxPlayer.Text = "";
                                txtEdadMinima.Text = "";
                                txtEdadMaxima.Text = "";
                                txtPuntosVictoria.Text = "";
                                txtPuntosEmpate.Text = "";
                                txtPuntosDerrota.Text = "";
                                txtPuntosDerrota.Text = "";
                        }
                        }

                    break;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
        ListTorneos.Enabled = false;
        MessageBoxButtons eliminar = MessageBoxButtons.YesNo;
        DialogResult dr2 = MessageBox.Show("¿SEGURO DE QUE DESEA actualizar informacion del  TORNEO?", "ALERTA", eliminar, MessageBoxIcon.Warning);
        if (dr2 == DialogResult.Yes) 
        {
            accion = 2;
            //Se muestra en el texbox los datos del Torneo Seleccionado
            int? Id_Torneo = GetId();
            Torneos torneoeditado = TorneoContext.GetTorneo(Id_Torneo);
                if (torneoeditado.Proceso == true)
                {
                    MessageBox.Show("No se Puede Modificar porque el Torneo esta en Proceso");
                }
                else
                {
                    txtName.Text = torneoeditado.Nombre;
                    txtDateInicio.Text = Convert.ToString(torneoeditado.FechaIncio);
                    txtDateFIn.Text = Convert.ToString(torneoeditado.FechaFinaliza);
                    txtType.Text = torneoeditado.Tipo;
                    txtMaxPlayer.Text = Convert.ToString(torneoeditado.NumeroMaximoJugadores);
                    txtEdadMinima.Text = Convert.ToString(torneoeditado.EdadMinima);
                    txtEdadMaxima.Text = Convert.ToString(torneoeditado.EdadMaxima);
                    txtPuntosVictoria.Text = Convert.ToString(torneoeditado.PuntosVictoria);
                    txtPuntosEmpate.Text = Convert.ToString(torneoeditado.PuntosEmpate);
                    txtPuntosDerrota.Text = Convert.ToString(torneoeditado.PuntosDerrota);
                    comboBox1.Text = Convert.ToString(torneoeditado.tipoFutbolTorneo);
                    txtCosto.Text = Convert.ToString(torneoeditado.costo);
                    ListTorneos.Enabled = false;
                    btnEliminar.Enabled = false;
                }
         }
            else if (dr2 == DialogResult.No)
            {
                ListTorneos.Enabled = true;
                MessageBox.Show("Se cancelo correctamnete la actualizacion de datos");
            }





        }

        //Procedimieno que obtiene el Id del Torneo Seleccionado
        private int? GetId()
        {
            try
            {
                return int.Parse(
                    ListTorneos.Rows[ListTorneos.CurrentRow.Index].Cells[0].Value.ToString()
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
                int? Id_Torneo = GetId();
                Torneos torneoeliminar = TorneoContext.GetTorneo(Id_Torneo);
                if (torneoeliminar.Proceso == true)
                {
                    MessageBox.Show("No se Puede Eliminar porque el Torneo esta en Proceso");
                }
                else
                {
                    TorneoContext.DeleteTorneo(Convert.ToInt32(Id_Torneo));
                    Get_Torneo();
                }
            }
            else if (dr == DialogResult.No)
            {
                MessageBox.Show("Se cancelo la eliminacion correctamente");
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validacion de solo nombres en el texbox
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo Letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtMaxPlayer_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validacion de solo numeros en el texbox
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Agregar solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtEdadMinima_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validacion de solo numeros en el texbox
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Agregar solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtEdadMaxima_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validacion de solo numeros en el texbox
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Agregar solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPuntosVictoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validacion de solo numeros en el texbox
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Agregar solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPuntosEmpate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validacion de solo numeros en el texbox
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Agregar solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPuntosDerrota_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validacion de solo numeros en el texbox
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Agregar solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //validacion para alertas no nulas
            if (txtName.Text == "")
            {
                error.SetError(txtName, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(txtName, "");

            }
        }

        private void txtDateInicio_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //validando la fecha
            DateTime fecha_nacimiento;


            if (!DateTime.TryParse(txtDateInicio.Text, out fecha_nacimiento))
            {

                error2.SetError(txtDateInicio, "El formato debe ser: (DD/MM/AA)");

            }
            else
            {
                error2.SetError(txtDateInicio, "");

            }

            //validacion para alertas no nulas
            if (txtDateInicio.Text == "")
            {
                error.SetError(txtDateInicio, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(txtDateInicio, "");

            }
        }

        private void txtDateFIn_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //validando la fecha
            DateTime fecha_fin;


            if (!DateTime.TryParse(txtDateFIn.Text, out fecha_fin))
            {

                error2.SetError(txtDateFIn, "El formato debe ser: (DD/MM/AA)");

            }
            else
            {
                error2.SetError(txtDateFIn, "");

            }
            //validacion para alertas no nulas
            if (txtDateFIn.Text == "")
            {
                error.SetError(txtDateFIn, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(txtDateFIn, "");

            }

        }

        private void txtType_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //validacion para alertas no nulas
            if (txtType.Text == "")
            {
                error.SetError(txtType, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(txtType, "");

            }

        }

        private void txtMaxPlayer_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //validacion para alertas no nulas
            if (txtMaxPlayer.Text == "")
            {
                error.SetError(txtMaxPlayer, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(txtMaxPlayer, "");

            }

        }

        private void txtEdadMinima_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            //validacion para alertas no nulas
            if (txtEdadMinima.Text == "")
            {
                error.SetError(txtEdadMinima, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(txtEdadMinima, "");

            }

        }

        private void txtEdadMaxima_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //validacion para alertas no nulas
            if (txtEdadMaxima.Text == "")
            {
                error.SetError(txtEdadMaxima, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(txtEdadMaxima, "");

            }

        }

        private void txtPuntosVictoria_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //validacion para alertas no nulas
            if (txtPuntosVictoria.Text == "")
            {
                error.SetError(txtPuntosVictoria, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(txtPuntosVictoria, "");

            }

        }

        private void txtPuntosEmpate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //validacion para alertas no nulas
            if (txtPuntosEmpate.Text == "")
            {
                error.SetError(txtPuntosEmpate, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(txtPuntosEmpate, "");

            }

        }

        private void txtPuntosDerrota_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //validacion para alertas no nulas
            if (txtPuntosDerrota.Text == "")
            {
                error.SetError(txtPuntosDerrota, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(txtPuntosDerrota, "");

            }


        }

      
    }
}
