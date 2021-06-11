using AdminitracionDeTorneosP.Database;
using AdminitracionDeTorneosP.Model;
using System;
using System.Windows.Forms;

namespace AdminitracionDeTorneosP.View
{
    public partial class refereeView : Form
    {
        //instancia de las clases 
        refereeDB refereeDB = new refereeDB();
        refereeModel refereeModel = new refereeModel();
        //ICONOS se muetra al lado del texbox un icono de error, esto ayuda a mostrar un pequeño mensaje al usuario en como deberia llenar el texbox
        ErrorProvider error = new ErrorProvider();
        ErrorProvider error2 = new ErrorProvider();
        public int action = 1;
        public refereeView()
        {
            InitializeComponent();
            //cargar lectura de los datos al iniciarse la pestaña 
            refereeList.DataSource = refereeDB.getRefereee();
            refereeList.Columns[1].HeaderText = "Nombre";
            refereeList.Columns[2].HeaderText = "Apellido";
            refereeList.Columns[3].HeaderText = "Dirección";
            refereeList.Columns[4].HeaderText = "Telefono";
            refereeList.Columns[5].HeaderText = "Nacionalidad";
            refereeList.Columns[6].HeaderText = "Fecha de Nacimiento";
            refereeList.Columns[7].HeaderText = "Correo";
            refereeList.Columns[8].HeaderText = "Rol";

        }

        //obtner el dpi del cliente seleccionado 
        private long? getDPI()
        {
            try
            {
                return long.Parse(
                    refereeList.Rows[refereeList.CurrentRow.Index].Cells[0].Value.ToString()
                    );
            }
            catch
            {
                return null;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //iniciar accion en uno 
            if (action == 1)
            {
                if(textDPI.Text == "" || textName.Text == "" || textLastName.Text == "" || textAddress.Text == "" || textPhone.Text == "" || textNacionality.Text == "" || textBirthDate.Text == "" || textMail.Text == "" || textRole.Text == "" || txtPrecio.Text == "")
                {
                    MessageBox.Show("valores en blanco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DateTime nacimento;
                    if (!DateTime.TryParse(textBirthDate.Text, out nacimento))
                    {
                        MessageBox.Show("Formato de fecha incorrecto Fecha correcta: DD/MM/AA", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //enviar al modelo los datos obtenidos de los textboxs 
                        refereeModel.DPI = long.Parse(textDPI.Text);
                        refereeModel.name = textName.Text;
                        refereeModel.lastname = textLastName.Text;
                        refereeModel.address = textAddress.Text;
                        refereeModel.phone = textPhone.Text;
                        refereeModel.nacionality = textNacionality.Text;
                        refereeModel.birthDate = DateTime.Parse(textBirthDate.Text);
                        refereeModel.email = textMail.Text;
                        refereeModel.role = textRole.Text;
                        refereeModel.precio_hora = Convert.ToDecimal(txtPrecio.Text);
                        //enviar el referee model a la fución para guardar e la base de datos 
                        refereeDB.addReferee(refereeModel);
                        //Refrescar los datos de la base de datos 
                        refereeList.DataSource = refereeDB.getRefereee();
                        //limpiar los campos 
                        textAddress.Text = "";
                        textBirthDate.Text = "";
                        textLastName.Text = "";
                        textMail.Text = "";
                        textNacionality.Text = "";
                        textName.Text = "";
                        textPhone.Text = "";
                        textRole.Text = "";
                        textDPI.Text = "";
                        txtPrecio.Clear();
                    }
                }
                
            }
            //Cambiar accion 
            else if(action == 0)
            {
                if (textName.Text == "" || textLastName.Text == "" || textAddress.Text == "" || textPhone.Text == "" || textNacionality.Text == "" || textBirthDate.Text == "" || textMail.Text == "" || textRole.Text == "")
                {
                    MessageBox.Show("valores en blanco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DateTime nacimento;
                    if (!DateTime.TryParse(textBirthDate.Text, out nacimento))
                    {
                        MessageBox.Show("Formato de fecha incorrecto Fecha correcta: DD/MM/AA", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //guardar el dpi en una variable 
                        long? dpi = getDPI();
                        //guardar los datos obtenidos de los textboxs en variables temporales 
                        string name = textName.Text;
                        string lastname = textLastName.Text;
                        string address = textAddress.Text;
                        string phone = textPhone.Text;
                        string nacionality = textNacionality.Text;
                        DateTime birthDate = DateTime.Parse(textBirthDate.Text);
                        string email = textMail.Text;
                        string role = textRole.Text;
                        Decimal precio_hora = Convert.ToDecimal(txtPrecio.Text);
                        //enviar como parametro las variables temporales al metodo para actualizar 
                        refereeDB.updateReferee(dpi, name, lastname, address, phone, nacionality, birthDate, email, role, precio_hora);
                        action = 1;
                        //Refrescar dats 
                        refereeList.DataSource = refereeDB.getRefereee();
                        //limpiar campos 
                        textAddress.Text = "";
                        textBirthDate.Text = "";
                        textLastName.Text = "";
                        textMail.Text = "";
                        textNacionality.Text = "";
                        textName.Text = "";
                        textPhone.Text = "";
                        textRole.Text = "";
                        txtPrecio.Clear();
                        refereeList.Enabled = true;
                    }
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //boton paraeliminar un registro
            //confirmacion para eliminar al jugador
            //creando una variable de tipo MessageBoxButtons.YesNo


            MessageBoxButtons eliminar = MessageBoxButtons.YesNo;
            DialogResult dr = MessageBox.Show("¿SEGURO DE QUE DESEA ELIMINAR AL ARBITRO?", "ALERTA", eliminar, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                //guardar dpi en variable y enviar la metodo de busqueda en la vase de datos 
                long? dpi = getDPI();
            refereeDB.deleteReferee(Convert.ToInt64(dpi));
            //Refrescar datos 
            refereeList.DataSource = refereeDB.getRefereee();
            }
            else if (dr == DialogResult.No)
            {
                MessageBox.Show("Se cancelo la eliminacion correctamente");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            refereeList.Enabled = false;
            MessageBoxButtons eliminar = MessageBoxButtons.YesNo;
            DialogResult dr2 = MessageBox.Show("¿SEGURO DE QUE DESEA actualizar informacion del  arbitro?", "ALERTA", eliminar, MessageBoxIcon.Warning);
            if (dr2 == DialogResult.Yes)
            {

                //iniciar accion en 0 para indicar que se actualizará la data 
                action = 0;
                //guardar datos en variable 
                long? dpi = getDPI();
                refereeModel udRefereeModel = refereeDB.getRefereeByDPI(dpi);
                //enviar los datos a los textboxs 
                textName.Text = udRefereeModel.name;
                textLastName.Text = udRefereeModel.lastname;
                textAddress.Text = udRefereeModel.address;
                textNacionality.Text = udRefereeModel.nacionality;
                textBirthDate.Text = Convert.ToString(udRefereeModel.birthDate);
                textPhone.Text = udRefereeModel.phone;
                textRole.Text = udRefereeModel.role;
                textMail.Text = udRefereeModel.email;
                txtPrecio.Text = Convert.ToString(udRefereeModel.precio_hora);
            }
            else if (dr2 == DialogResult.No)
            {
                refereeList.Enabled = true;
                MessageBox.Show("Actualizacion cancelada exitosamente");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void textName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textLastName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textNacionality_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textDPI_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validacion de solo numeros en el texbox
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Agregar solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validacion de solo numeros en el texbox
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Agregar solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textDPI_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //validacion para alertas no nulas
            if (textDPI.Text == "")
            {
                error.SetError(textDPI, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(textDPI, "");

            }
        }

        private void textName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //validacion para alertas no nulas
            if (textName.Text == "")
            {
                error.SetError(textName, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(textName, "");

            }

        }

        private void textLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //validacion para alertas no nulas
            if (textLastName.Text == "")
            {
                error.SetError(textLastName, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(textLastName, "");

            }

        }

        private void textAddress_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //validacion para alertas no nulas
            if (textAddress.Text == "")
            {
                error.SetError(textAddress, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(textAddress, "");

            }

        }

        private void textPhone_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //validacion para alertas no nulas
            if (textPhone.Text == "")
            {
                error.SetError(textPhone, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(textPhone, "");

            }

        }

        private void textNacionality_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //validacion para alertas no nulas
            if (textNacionality.Text == "")
            {
                error.SetError(textNacionality, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(textNacionality, "");

            }

        }

        private void textBirthDate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //validando la fecha
            DateTime fecha_nacimiento;


            if (!DateTime.TryParse(textBirthDate.Text, out fecha_nacimiento))
            {

                error2.SetError(textBirthDate, "El formato debe ser: (DD/MM/AA)");

            }
            else
            {
                error2.SetError(textBirthDate, "");

            }
            //validacion para alertas no nulas
            if (textBirthDate.Text == "")
            {
                error.SetError(textBirthDate, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(textBirthDate, "");

            }

        }

        private void textMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textMail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //validacion para alertas no nulas

            if (textMail.Text == "")
            {
                error.SetError(textMail, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(textMail, "");

            }

        }

        private void textRole_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //validacion para alertas no nulas

            if (textRole.Text == "")
            {
                error.SetError(textRole, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(textRole, "");

            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
