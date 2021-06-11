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
using AdminitracionDeTorneosP.View;

namespace AdminitracionDeTorneosP.View
{
    public partial class Agregar_Cancha : Form
    {
        public CANCHA_DB CanchaContext = new CANCHA_DB();
        public CANCHA CanchaSeleccionada = new CANCHA();
        public int opciones = 1;
        

        public Agregar_Cancha()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowDrop = false;
            dataGridView1.AllowUserToDeleteRows = false;
            Mostrar();

        }
        public void Mostrar()
        {
            dataGridView1.DataSource = CanchaContext.Muestra_Cancha();
        }
        private void Agregar_Cancha_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
         
            

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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (opciones)
            {
                case 1:
                    if ( textBox2.Text==""||comboBox1.Text==""||comboBox2.Text==""||txtPrecio.Text=="")
                    {
                        MessageBox.Show("Valores en Blanco","Alerta",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    else
                    {
                        CANCHA Ingreso_Cancha = new CANCHA();
                        
                        Ingreso_Cancha.Nombre = textBox2.Text;
                        Ingreso_Cancha.TipoCancha = comboBox1.Text;
                        Ingreso_Cancha.Disponibilidad = comboBox2.Text;
                        Ingreso_Cancha.precio_hora = Convert.ToDecimal(txtPrecio.Text);
                        CanchaContext.Insertar_Cancha(Ingreso_Cancha);
                        Mostrar();
                     
                        textBox2.Text = "";
                        comboBox1.Text = "";
                        comboBox2.Text = "";
                        txtPrecio.Text = "";
                    }
                    break;
                case 2:
                    if ( textBox2.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || txtPrecio.Text == "")
                    {
                        MessageBox.Show("Valores en Blanco", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        CANCHA canchaagregada = new CANCHA();
                        canchaagregada.NumeroCancha = Convert.ToInt32(buscar_id());
                        canchaagregada.Nombre = textBox2.Text;
                        canchaagregada.TipoCancha =comboBox1.Text;
                        canchaagregada.Disponibilidad = comboBox2.Text;
                        canchaagregada.precio_hora = Convert.ToDecimal(txtPrecio.Text);
                        CanchaContext.actualizar_Cancha(canchaagregada);
                         
                                                                     
                        Mostrar();
                       
                        textBox2.Clear();
                        comboBox1.Text = "";
                        comboBox2.Text = "";
                        txtPrecio.Text = "";

                    }
                    break;


            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
                     
            int? id = buscar_id();
            CanchaContext.eliminar_Cancha(id);
            Mostrar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            
            MessageBoxButtons eliminar = MessageBoxButtons.YesNo;
            DialogResult dr2 = MessageBox.Show("¿SEGURO DE QUE DESEA ACTUALIZAR LA INFROMACION DE CANCHA?", "ALERTA", eliminar, MessageBoxIcon.Warning);
            if (dr2 == DialogResult.Yes)
            {
                opciones = 2;
                int? Id_Cancha = buscar_id();
                 CANCHA TarjetaEditada = CanchaContext.buscar_cancha(Convert.ToInt32(Id_Cancha));
                textBox2.Text = TarjetaEditada.Nombre;
                comboBox1.Text = TarjetaEditada.TipoCancha;
                comboBox2.Text = TarjetaEditada.Disponibilidad;
                txtPrecio.Text = TarjetaEditada.precio_hora.ToString();
              
            }
            else if (dr2 == DialogResult.No)
            {
                
                MessageBox.Show("Se cancelo correctamnete la actualizacion de datos");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }



             




}
