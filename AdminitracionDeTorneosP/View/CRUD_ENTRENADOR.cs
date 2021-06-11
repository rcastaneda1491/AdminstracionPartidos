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
    public partial class CRUD_ENTRENADOR : Form
    {
        //Declaración de switch para hacer cambio de actualización a guardado y viceversa
        public int action = 1;
        //instancia de clases 
        coachModel coachModel = new coachModel();
        coachDB coachDB = new coachDB();
        ErrorProvider error = new ErrorProvider();
        ErrorProvider error2 = new ErrorProvider();
        public CRUD_ENTRENADOR()
        {
            InitializeComponent();
            //cargar lectura de datos desde que la aplicaión inicia 
            loadCoaches();
            coachesList.Columns[1].HeaderText = "Nombre";
            coachesList.Columns[2].HeaderText = "Apellido";
            coachesList.Columns[3].HeaderText = "Telefono";
            coachesList.Columns[4].HeaderText = "Fecha de Nacimiento";
            coachesList.Columns[5].HeaderText = "Correo";
            coachesList.Columns[6].HeaderText = "Tiempo";
            coachesList.Columns[7].HeaderText = "Salario";
        }

        //función para cargar lista de entrenadores ya ingresados 
        public void loadCoaches()
        {
            coachesList.DataSource = coachDB.getCoach();
        }

        //método para obtner el DPI de los entrenadores en la datagridview 
        private long? getDPI()
        {
            try
            {
                //Retorna el dato encontrado en la celda 0 del datagridiew 
                return long.Parse(
                    coachesList.Rows[coachesList.CurrentRow.Index].Cells[0].Value.ToString()
                    );
            }
            catch
            {
                //Caso contrario no encuentre nada retorna un nulo. 
                return null;
            }
        }

        private void textName_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            coachesList.Enabled = false;
            MessageBoxButtons eliminar = MessageBoxButtons.YesNo;
            DialogResult dr2 = MessageBox.Show("¿SEGURO DE QUE DESEA actualizar informacion del  ENTRENADOR?", "ALERTA", eliminar, MessageBoxIcon.Warning);
            if (dr2 == DialogResult.Yes)
            {


                //varible tipo date time quepermitira validar si se ingreso un afecha correcta o un formato de fecha pedido

                //El swicth cambia de 1 a 0 para indicar que se realizara una actualización. 
                action = 0;
                //el dpi encontrado se guarda en una variable 
                long? DPI = getDPI();

                //se envia la variable que tiene guardada el dpi al metodo que retornará los datos del entrenador que coincidan con el dpi. 
                coachModel udCoach = coachDB.getCoachByDPI(DPI);
                //los datos obtenidos se mostraran en sus respectivos textbox para poder ser manipulados 
                textDPI.Text = udCoach.DPI.ToString();

                textName.Text = udCoach.name;
                textLastname.Text = udCoach.lastname;
                textPhone.Text = udCoach.phone;
                textBirthDate.Text = Convert.ToString(udCoach.birthDate);
                textEmail.Text = udCoach.email;
                textTime.Text = udCoach.time;
                textSalary.Text = Convert.ToString(udCoach.salary);
                coachesList.Enabled = false;
            }
        
            else if (dr2==DialogResult.No)
            {
                coachesList.Enabled = true;
                MessageBox.Show("Actualizacion cancelada exitosamente");
            }










}

private void buttonSave_Click(object sender, EventArgs e)
        {
            //Si el action esta en 1 se procede a guardar el objeto obtenido
            if (action == 1)
            {
                if(textDPI.Text == "" || textName.Text == "" || textLastname.Text == "" || textBirthDate.Text == "" || textEmail.Text == "" || textTime.Text == "" || textSalary.Text == "")
                {
                    MessageBox.Show("Valores en blanco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //varible tipo date time quepermitira validar si se ingreso un afecha correcta o un formato de fecha pedido
                    DateTime nacimento;
                    if (!DateTime.TryParse(textBirthDate.Text, out nacimento))
                    {
                        MessageBox.Show("Formato de fecha incorrecto\nFecha correcta: DD/MM/AA", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //se guradan los datos obtneidos del textbox en cada variable del coachmodel 
                        coachModel.DPI = long.Parse(textDPI.Text);
                        coachModel.name = textName.Text;
                        coachModel.lastname = textLastname.Text;
                        coachModel.phone = textPhone.Text;
                        coachModel.birthDate = DateTime.Parse(textBirthDate.Text);
                        coachModel.email = textEmail.Text;
                        coachModel.time = textTime.Text;
                        coachModel.salary = decimal.Parse(textSalary.Text);
                        //se envia el objeto al metodo para que lo guarde en la base de datos 
                        coachDB.addCoach(coachModel);
                        //recargar la lsita de entrenadores 
                        loadCoaches();
                        //limpiar los textbox 
                        textDPI.Text = "";
                        textName.Text = "";
                        textLastname.Text = "";
                        textPhone.Text = "";
                        textBirthDate.Text = "";
                        textEmail.Text = "";
                        textTime.Text = "";
                        textSalary.Text = "";
                    }
                }
            }
            //Caso contrario el action tenga valor 0 indica que se guardaran los cambios 
            else if (action == 0)
            {
                if (textName.Text == "" || textLastname.Text == "" || textBirthDate.Text == "" || textEmail.Text == "" || textTime.Text == "" || textSalary.Text == "")
                {
                    MessageBox.Show("Valores en blanco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //varible tipo date time quepermitira validar si se ingreso un afecha correcta o un formato de fecha pedido
                    DateTime nacimento;
                    if (!DateTime.TryParse(textBirthDate.Text, out nacimento))
                    {
                        MessageBox.Show("Formato de fecha incorrecto\nFecha correcta: DD/MM/AA", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        //El numero de dpi se guarda en una variable temporal 
                        long? DPI = getDPI();
                    //todos los datos obtenidos se cambian en variable temporales 
                    string name = textName.Text;
                    string lastname = textLastname.Text;
                    string phone = textPhone.Text;
                    DateTime birthDate = DateTime.Parse(textBirthDate.Text);
                    string email = textEmail.Text;
                    string time = textTime.Text;
                    decimal salary = decimal.Parse(textSalary.Text);
                    //las variables temporales se envian al metodo de actualización 
                    coachDB.updateCoach(DPI, name, lastname, phone, birthDate, email, time, salary);
                    //se recarga la lista de entrenadores 
                    loadCoaches();
                    //se limpian los campos 
                    textDPI.Text = "";
                    textName.Text = "";
                    textLastname.Text = "";
                    textPhone.Text = "";
                    textBirthDate.Text = "";
                    textEmail.Text = "";
                    textTime.Text = "";
                    textSalary.Text = "";
                    //El action cambia a 1 para que vuelva al estado de guardado normal 
                    action = 1;

                    coachesList.Enabled = true;
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
            DialogResult dr = MessageBox.Show("¿SEGURO DE QUE DESEA ELIMINAR AL ENTRENADOR?", "ALERTA", eliminar, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                //el numerod e dpi seleccionado se guarda en una variable temporal que se envia al metodo de eliminar 
                long? DPI = getDPI();
            coachDB.deleteCoach(DPI);
            //Se recarga la lista de entrenadores
            loadCoaches();
            }
            else if (dr == DialogResult.No)
            {
                MessageBox.Show("Se cancelo la eliminacion correctamente");

            }
        }

        private void textDPI_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CRUD_ENTRENADOR_Load(object sender, EventArgs e)
        {

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

        private void textLastname_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validacion para solo numeros
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Agregar solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validacion para solo numeros
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Agregar solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textDPI_Validating(object sender, CancelEventArgs e)
        {
            // validacion para alertas no nulas
            if (textDPI.Text == "")
            {
                error.SetError(textDPI, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(textDPI, "");

            }

        }

        private void textName_Validating(object sender, CancelEventArgs e)
        {
            // validacion para alertas no nulas
            if (textName.Text == "")
            {
                error.SetError(textName, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(textName, "");

            }

        }

        private void textLastname_Validating(object sender, CancelEventArgs e)
        {
            // validacion para alertas no nulas
            if (textLastname.Text == "")
            {
                error.SetError(textLastname, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(textLastname, "");

            }
        }

        private void textPhone_Validating(object sender, CancelEventArgs e)
        {
            // validacion para alertas no nulas
            if (textPhone.Text == "")
            {
                error.SetError(textPhone, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(textPhone, "");

            }

        }

        private void textBirthDate_Validating(object sender, CancelEventArgs e)
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

        private void textEmail_Validating(object sender, CancelEventArgs e)
        {
            //validacion para alertas no nulas
            if (textEmail.Text == "")
            {
                error.SetError(textEmail, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(textEmail, "");

            }

        }

        private void textTime_Validating(object sender, CancelEventArgs e)
        {
            //validacion para alertas no nulas
            if (textTime.Text == "")
            {
                error.SetError(textTime, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(textTime, "");

            }

        }

        private void textSalary_Validating(object sender, CancelEventArgs e)
        {
            //validacion para alertas no nulas
            if (textSalary.Text == "")
            {
                error.SetError(textSalary, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(textSalary, "");

            }


        }

        private void textDPI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Agregar solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void coachesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textLastname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
