using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using AdminitracionDeTorneosP.Database;
using AdminitracionDeTorneosP.Model;
using AdminitracionDeTorneosP.View;


namespace AdminitracionDeTorneosP.View
{
    public partial class CRUD_EQUIPO : Form
    {
        private string connectionstring = "Server=DESKTOP-U4PFR0A;Database=PROYECTO_TORNEOS;User Id=Rogelio;Password=12345;";
        public EUIPO_DB EquipoContext = new  EUIPO_DB();
        public EQUIPO EquipoSeleccionado = new EQUIPO();
        ErrorProvider error = new ErrorProvider();
        ErrorProvider error2 = new ErrorProvider();
        public int action = 1;
        public string nombreSeleccionado;
        public string apellidoSeleccionado;
        public string nombrebusqueda;

        public CRUD_EQUIPO()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowDrop = false;
            dataGridView1.AllowUserToDeleteRows = false;
            Mostrar();
            getNombreEntrenador();
            //comboNombreEntrenador.DataSource = EquipoContext.getNombreEntrenador(); // Solicitando la informacion de la base de datos para cargarla en el combobox
            //comboNombreEntrenador.DisplayMember = "nombre"; // Asignando el valor que se mostrara en el combobox
            //comboNombreEntrenador.ValueMember = "nombre"; // Valor que estara detras de Display


        }
        private void getApellidoEntrenador(string nombre)
        {

            string query = "exec obtener_Apellido_Entrenadores @nombre";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                sql.Parameters.AddWithValue("@nombre", nombre);
                connection.Open();
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    comboApellidoEntrenador.Items.Add(reader["Apellidos"].ToString());
                }
                connection.Close();
            }
        }

        private void getNombreEntrenador()
        {

            string query = "exec obtner_Nombre_Entrenadores";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand sql = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    comboNombreEntrenador.Items.Add(reader["nombre"].ToString());
                }
                connection.Close();
            }
        }



        public void Mostrar()
        {
            dataGridView1.DataSource = EquipoContext.Muestra_equipos();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBoxButtons eliminar = MessageBoxButtons.YesNo;
            DialogResult dr = MessageBox.Show("¿SEGURO DE QUE DESEA ELIMINAR AL EQUIPO?", "ALERTA", eliminar, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                int? id = buscar_id();
            EquipoContext.eliminar_Equipo(id);
            Mostrar();
            }
            else if (dr == DialogResult.No)
            {
                MessageBox.Show("Se cancelo la eliminacion correctamente");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textNombreEquipo.Text == "" ||  textRepresentante.Text == "")
            {
                MessageBox.Show("Valores en blanco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (action == 1)
                {
                      
                    EQUIPO Ingreso_Equipo = new EQUIPO();
                    Ingreso_Equipo.Nombre = textNombreEquipo.Text;
                    Ingreso_Equipo.Representante = textRepresentante.Text;
                    Ingreso_Equipo.DPI_Entrenador = EquipoContext.getEntrenadorDPI(comboNombreEntrenador.Text,apellidoSeleccionado);
                    EquipoContext.Insertar_Equipo(Ingreso_Equipo);
                    Mostrar();

                    textNombreEquipo.Text = "";

                    textRepresentante.Text = "";
                    comboNombreEntrenador.Text = "";
                    comboApellidoEntrenador.Text = "";
                }
                else if(action == 0)
                {
                    
                    int? ID = buscar_id();
                    string Nombre_editar = textNombreEquipo.Text;
                    string Representante = textRepresentante.Text;
                    long DPI_Entrenador = EquipoContext.getEntrenadorDPI(comboNombreEntrenador.Text,apellidoSeleccionado);

                    EquipoContext.actualizar_Equipo(ID, Nombre_editar, Representante, DPI_Entrenador);
                    Mostrar();

                    dataGridView1.Enabled = true;
                    buttonSeleccionar.Enabled = true;
                    action = 1;
                    textNombreEquipo.Text = "";

                    textRepresentante.Text = "";
                    comboApellidoEntrenador.Text = "";
                    comboNombreEntrenador.Text = "";

                    buttonAgregar.Enabled = true;
                    buttonEliminar.Enabled = true;
                    

                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            MessageBoxButtons eliminar = MessageBoxButtons.YesNo;
            DialogResult dr2 = MessageBox.Show("¿SEGURO DE QUE DESEA actualizar informacion del  EQUIPO?", "ALERTA", eliminar, MessageBoxIcon.Warning);
            if (dr2 == DialogResult.Yes)
            {
                action = 0;
                int? id = buscar_id();
            EQUIPO equipo_actualizar = EquipoContext.buscar(id);
            textNombreEquipo .Text = equipo_actualizar.Nombre;
            textRepresentante.Text = equipo_actualizar.Representante;
            

            buttonEliminar.Enabled = false;
            buttonSeleccionar.Enabled = false;
                
            }
            else if (dr2 == DialogResult.No)
            {
                dataGridView1.Enabled = true;
                MessageBox.Show("Actualizacion cancelada exitosamente");
            }

        }
        private int? buscar_id()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }

            catch
            {
                return null;
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            //validacion de solo numeros en el texbox
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Agregar solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validacion de solo numeros en el texbox
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Agregar solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //validacion para alertas no nulas
            if (textNombreEquipo.Text == "")
            {
                error.SetError(textNombreEquipo, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(textNombreEquipo, "");

            }
        }

        private void textBox2_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            //validacion para alertas no nulas
            if (textRepresentante.Text == "")
            {
                error.SetError(textRepresentante, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(textRepresentante, "");

            }

        }

        

        private void textBox7_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            

        }

       

        private void textBox2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
           

        }

        private void comboApellidoEntrenador_SelectedIndexChanged(object sender, EventArgs e)
        {
            apellidoSeleccionado = comboApellidoEntrenador.Text;
            
        }

        private void comboNombreEntrenador_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboApellidoEntrenador.Items.Clear();
            nombreSeleccionado = comboNombreEntrenador.Text;
            getApellidoEntrenador(nombreSeleccionado);
            nombreSeleccionado = "";
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            long dpi = EquipoContext.getEntrenadorDPI(comboNombreEntrenador.Text,apellidoSeleccionado);
            label2.Text = Convert.ToString(dpi);

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
