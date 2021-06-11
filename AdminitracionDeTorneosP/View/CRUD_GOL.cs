using System;
using System.Windows.Forms;
using AdminitracionDeTorneosP.Database;
using AdminitracionDeTorneosP.Model;

namespace AdminitracionDeTorneosP.View
{
    public partial class CRUD_GOL : Form
    {

        public AdministraciónDeJornadasDB jornadaContext = new AdministraciónDeJornadasDB();

        int Juego;

        public CRUD_GOL(int Id_Juego)
        {
            InitializeComponent();

            dataGridView1.DataSource = jornadaContext.obtenerGolesJuego(Id_Juego);
            button3.Enabled = false;
            textBox1.Enabled = false;

            Juego = Id_Juego;

        }

        private int GetIdGol()
        {
            try
            {
                return int.Parse(
                    dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString() // Obteniendo el numero de ID seleccioado por medio de la primera columna de la seleccion
                    );
            }
            catch
            {
                return 0;
            }
        }

        private string GetJugador()
        {
            try
            {
                return string.Format(
                    dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString() // Obteniendo el numero de ID seleccioado por medio de la primera columna de la seleccion
                    );
            }
            catch
            {
                return "";
            }
        }

        private string GetMinuto()
        {
            try
            {
                return string.Format(
                    dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString() // Obteniendo el numero de ID seleccioado por medio de la primera columna de la seleccion
                    );
            }
            catch
            {
                return "";
            }
        }
        private string GetTipo()
        {
            try
            {
                return string.Format(
                    dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString() // Obteniendo el numero de ID seleccioado por medio de la primera columna de la seleccion
                    );
            }
            catch
            {
                return "";
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = GetJugador();
            textBox2.Text = GetMinuto();
            comboBox2.Text = GetTipo();

            dataGridView1.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;

            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int IdGol = GetIdGol();
            string tipo = comboBox2.Text;
            string tiempo = textBox2.Text;

            jornadaContext.ActualizarGol(IdGol,tipo,tiempo);

            dataGridView1.DataSource = jornadaContext.obtenerGolesJuego(Juego);

            dataGridView1.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;

            button3.Enabled = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBoxButtons botones = MessageBoxButtons.YesNo; //Mensaje de advetencia
            DialogResult dr = MessageBox.Show("¿Seguro desea eliminar el Gol del registro? Esta opcion no se puede deshacer", "Advertencia", botones, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                jornadaContext.DeleteGol(GetIdGol()) ;


            }
        }
    }
}
