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
    public partial class CRUD_JUGADORES : Form

    {
        [System.ComponentModel.TypeConverter(typeof(System.Windows.Forms.OpacityConverter))]
        public double Opacity { get; set; }
        //creando instaciaas para crear usar sus metodos o variables
        public JUGADORES_DB jugador_context = new JUGADORES_DB();
        public JUGADORES jugador_seleccionado = new JUGADORES();
        //ICONOS se muetra al lado del texbox un icono de error, esto ayuda a mostrar un pequeño mensaje al usuario en como deberia llenar el texbox
        ErrorProvider error = new ErrorProvider();
        ErrorProvider error2 = new ErrorProvider();
        public int accion = 1;

        public CRUD_JUGADORES()
        {
            InitializeComponent();
            //llamado de metodque funciona para poder refrescar un nuestro data grid con informacion
            mostrar_jugadores_datagrid();
            lista_jugadores_datagrid.AllowUserToAddRows = false;
            lista_jugadores_datagrid.AllowDrop = false;
            lista_jugadores_datagrid.AllowUserToDeleteRows = false;
            label20.Visible = false;
        }

        public void mostrar_jugadores_datagrid()
        {

            lista_jugadores_datagrid.DataSource = jugador_context.busqueda_jugadores_total();
        }

        private void CRUD_JUGADORES_Load(object sender, EventArgs e)
        {
           
        }

        private void txtfecha_A_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (accion)
            {
                case 1:
                    //creandi istancia con variable de para poder acceder al agregar un nuevo cliene o un nuevo query
                    JUGADORES agregando_jugador = new JUGADORES();
                    //validacion para que no existan valores nullos
                    if (((txtdpi_a.Text == "") && (txtfecha_A.Text == "")) || ((txtfecha_A.Text != "") && (txtdpi_a.Text == "")) || ((txtfecha_A.Text == "") && (txtdpi_a.Text != "")))
                    {
                        MessageBox.Show("valores en blanco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    }
                    else
                    {
                        //varible tipo date time quepermitira validar si se ingreso un afecha correcta o un formato de fecha pedido
                        DateTime nacimento;
                        if (!DateTime.TryParse(txtfecha_A.Text, out nacimento))
                        {
                            MessageBox.Show("Formato de fecha incorrecto Fecha correcta: DD/MM/AA", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            //agregando infirmacion a la base de datos
                            agregando_jugador.DPI_Jugador = Convert.ToInt64(txtdpi_a.Text);
                            agregando_jugador.Nombres = txtnombres_A.Text;
                            agregando_jugador.Apellidos = txtapeliidos_A.Text;
                            agregando_jugador.Fecha_nac = Convert.ToDateTime(txtfecha_A.Text);
                            agregando_jugador.Direccion = txtdireccion_A.Text;
                            agregando_jugador.Nacionalidad = txtnacionalida_A.Text;
                            agregando_jugador.Correo = txtcorreo_A.Text;
                            agregando_jugador.Telefono = txttelefonos_A.Text;
                            jugador_context.Agregar_Jugadores(agregando_jugador);
                            mostrar_jugadores_datagrid();


                            // bandera funciona para limpiar texbox cuando si se agrega un cliente a la base de datos
                            if (jugador_context.banera_agregar == 1)
                            {
                                txtdpi_a.Text = "";
                                txtnombres_A.Text = "";
                                txtapeliidos_A.Text = "";
                                txtfecha_A.Text = "";
                                txtdireccion_A.Text = "";
                                txtnacionalida_A.Text = "";
                                txtdireccion_A.Text = "";
                                txttelefonos_A.Text = "";
                                txtcorreo_A.Text = "";

                            }
                        }
                    }
                    jugador_context.banera_agregar = 0;

                    break;
                case 2:
                    
                    if  (txtfecha_A.Text=="")
                    {
                        MessageBox.Show("valores en blanco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    }
                    else
                    {
                        //varible tipo date time quepermitira validar si se ingreso un afecha correcta o un formato de fecha pedido
                        DateTime nacimentosss;
                        if (!DateTime.TryParse(txtfecha_A.Text, out nacimentosss))
                        {
                            MessageBox.Show("Formato de fecha incorrecto Fecha correcta: DD/MM/AA", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            long? dpi_jugador_confirmar = Get_dpi_jugador_seleccionado();
                            string nombre_editar = txtnombres_A.Text;
                            string apellido_editar = txtapeliidos_A.Text;
                            DateTime fecha_actualizar = Convert.ToDateTime(txtfecha_A.Text);
                            string direccion_actualizar = txtdireccion_A.Text;
                            string nacionalidad_actualizar = txtnacionalida_A.Text;
                            string correo_actualizar = txtcorreo_A.Text;
                            string telefono_actualizar = txttelefonos_A.Text;
                  

                            jugador_context.Actualizar_jugador(dpi_jugador_confirmar, nombre_editar, apellido_editar, fecha_actualizar, direccion_actualizar, nacionalidad_actualizar, correo_actualizar, telefono_actualizar);
                            mostrar_jugadores_datagrid();
                            lista_jugadores_datagrid.Enabled = true;
                            accion = 1;
                            txtdpi_a.Enabled = true;
                            txtdpi_a.Text = "";
                            txtnombres_A.Text = "";
                            txtapeliidos_A.Text = "";
                            txtfecha_A.Text = "";
                            txtdireccion_A.Text = "";
                            txtnacionalida_A.Text = "";
                            txtdireccion_A.Text = "";
                            txttelefonos_A.Text = "";
                            txtcorreo_A.Text = "";
                            label20.Visible = false;
                            label3.Visible = true;
                            txtdpi_a.Visible = true;
                        }
                    }

                    break;
            
            





















            }
        }

        private void txtnombres_A_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtapeliidos_A_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtnacionalida_A_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txttelefonos_A_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validacion de solo numeros en el texbox
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Agregar solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        //metodo para validacion de fechas
        private void txtfecha_A_Validating(object sender, CancelEventArgs e)
        {
            //validando la fecha
            DateTime fecha_nacimiento;


            if (!DateTime.TryParse(txtfecha_A.Text, out fecha_nacimiento))
            {

                error.SetError(txtfecha_A, "El formato debe ser: (DD/MM/AA)");
                
            }
            else
            {
                error.SetError(txtfecha_A, "");

            }


            if (txtfecha_A.Text == "")
            {
                error.SetError(txtfecha_A, "Este campo no puede ir vacio");

            }
            else
            {
                error.SetError(txtdpi_a, "");

            }



        }
        //metodo para validad que no existan valores en blanco
        private void txtdpi_a_Validating(object sender, CancelEventArgs e)
        {
            //validacion para alertas no nulas
            if (txtdpi_a.Text == "")
            {
                error.SetError(txtdpi_a, "Este campo no puede ir vacio");
                
            }
            else
            {
                error.SetError(txtdpi_a, "");
                
            }

            
        }
        //metodo que permitira seleccionar el dpi del jugador, cuando le de clik a alguno de los jugadores del fatagrid
        private long? Get_dpi_jugador_seleccionado()
        {
            try
            {
                return long.Parse(lista_jugadores_datagrid.Rows[lista_jugadores_datagrid.CurrentRow.Index].Cells[0].Value.ToString());
            }

            catch
            {
                return null;
            }

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            txtdpi_a.Enabled = false;
            label20.Visible = true;
            label3.Visible = false;
            txtdpi_a.Visible = false;
            lista_jugadores_datagrid.Enabled = false;
            MessageBoxButtons eliminar = MessageBoxButtons.YesNo;
            DialogResult dr2 = MessageBox.Show("¿SEGURO DE QUE DESEA actualizar informacion del  JUGADOR?", "ALERTA", eliminar, MessageBoxIcon.Warning);
            if (dr2 == DialogResult.Yes)
            {
                accion = 2;
                //llamado al dpi del jugador a travez del datagrid
                long? dpi_jugador = Get_dpi_jugador_seleccionado();

                JUGADORES jugador_edita_v = jugador_context.Get_jugador_A_EDITAR(dpi_jugador);
                txtdpi_a.Text = jugador_edita_v.DPI_Jugador.ToString();
                txtnombres_A.Text = jugador_edita_v.Nombres;
                txtapeliidos_A.Text = jugador_edita_v.Apellidos;
                txtfecha_A.Text = jugador_edita_v.Fecha_nac.ToString();
                txtdireccion_A.Text = jugador_edita_v.Direccion;
                txtnacionalida_A.Text = jugador_edita_v.Nacionalidad;
                txtcorreo_A.Text = jugador_edita_v.Correo;
                txttelefonos_A.Text = jugador_edita_v.Telefono;

            }
            else if (dr2==DialogResult.No)
            {
                txtdpi_a.Enabled = true;
                lista_jugadores_datagrid.Enabled = true;
                label20.Visible = false;
                label3.Visible = true;
                txtdpi_a.Visible = true;
                MessageBox.Show("Actualizacion cancelada exitosamente");
            }
       



        }

        private void btn_confirmar_AC_Click(object sender, EventArgs e)
        {

            
        }

        private void txtnombres_AC_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validacion que el texbos solo tenga letras
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

        private void txtapellidos_AC_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validacion de solo ingresar letras
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

        private void txtnacionalidad_AC_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validacion para solo letas
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

        private void txttelefono_AC_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validacion para solo numeros
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Agregar solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtfecha_AC_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //boton paraeliminar un registro
            //confirmacion para eliminar al jugador
            //creando una variable de tipo MessageBoxButtons.YesNo
            
            
            MessageBoxButtons eliminar = MessageBoxButtons.YesNo;
            DialogResult dr= MessageBox.Show("¿SEGURO DE QUE DESEA ELIMINAR AL JUGADOR?","ALERTA",eliminar,MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                long? dpi_jugador = Get_dpi_jugador_seleccionado();
                jugador_context.Eliminar_jugador(dpi_jugador);
                
                mostrar_jugadores_datagrid();

            }
            else if (dr==DialogResult.No)
            {
                MessageBox.Show("Se cancelo la eliminacion correctamente");
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtdepi_ac_Validating(object sender, CancelEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.BackColor = Color.FromArgb(50, Color.White);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
