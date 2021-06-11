using AdminitracionDeTorneosP.Database;
using AdminitracionDeTorneosP.Model;
using System;
using System.Windows.Forms;

namespace AdminitracionDeTorneosP.View
{
    public partial class CRUDArbitro_Partido : Form
    {
        Arbitro_PartidoDB arbitro_PartidoDB = new Arbitro_PartidoDB();
        public int accion = 1;
        public int Id_Juego;
        public CRUDArbitro_Partido(int Juego)
        {
            InitializeComponent();
            ListArbitro.AllowUserToAddRows = false;
            ListArbitro.AllowDrop = false;
            ListArbitro.AllowUserToDeleteRows = false;
            ListArbitro.MultiSelect = false;
            arbitro_PartidoDB.Get_Arbitros(cbxArbitro);
            Id_Juego = Juego;
            GetArbitro();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (accion)
            {
                //1 = Guardar
                case 1:
                    if (cbxArbitro.Text == "" || txtPago.Text == "")
                    {
                        MessageBox.Show("Valores en blanco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string Arbitro = Convert.ToString(cbxArbitro.SelectedItem);
                        string[] ArbitroArray = Arbitro.Split(' ');
                        //Nombre almacenado en la posicion 0
                        //Apellidos almacenado en la posicion 1
                        string Nombres = "";
                        string Apellidos = "";
                        if (ArbitroArray.Length == 2)
                        {
                            Nombres = ArbitroArray[0];
                            Apellidos = ArbitroArray[1];
                        }
                        else if (ArbitroArray.Length == 4)
                        {
                            Nombres = $"{ArbitroArray[0]} {ArbitroArray[1]}";
                            Apellidos = $"{ArbitroArray[2]} {ArbitroArray[3]}";
                        }

                        Arbitro_Partido arbitro_Partido = new Arbitro_Partido();
                        arbitro_Partido.DPI_Arbitro = arbitro_PartidoDB.DPI_Arbitros(Nombres, Apellidos);
                        arbitro_Partido.Pago = Convert.ToDecimal(txtPago.Text);

                        arbitro_PartidoDB.AddArbitroPartido(arbitro_Partido, Id_Juego);
                        GetArbitro();
                    }
                    break;
                case 2:

                    if (cbxArbitro.Text == "" || txtPago.Text == "")
                    {
                        MessageBox.Show("Valores en blanco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        long? DPI_Arbitro_Buscar = GetDPI();

                        string Arbitro = Convert.ToString(cbxArbitro.Text);
                        string[] ArbitroArray = Arbitro.Split(' ');
                        //Nombre almacenado en la posicion 0
                        //Apellidos almacenado en la posicion 1
                        string Nombres = "";
                        string Apellidos = "";
                        if (ArbitroArray.Length == 2)
                        {
                            Nombres = ArbitroArray[0];
                            Apellidos = ArbitroArray[1];
                        }
                        else if (ArbitroArray.Length == 4)
                        {
                            Nombres = $"{ArbitroArray[0]} {ArbitroArray[1]}";
                            Apellidos = $"{ArbitroArray[2]} {ArbitroArray[3]}";
                        }

                        Arbitro_Partido arbitro_Partido = new Arbitro_Partido();
                        arbitro_Partido.DPI_Arbitro = arbitro_PartidoDB.DPI_Arbitros(Nombres, Apellidos);
                        arbitro_Partido.Pago = Convert.ToDecimal(txtPago.Text); 
                        
                        arbitro_PartidoDB.UpdateArbitroPartido(arbitro_Partido, Id_Juego, Convert.ToInt64(DPI_Arbitro_Buscar));
                        accion = 1;
                        GetArbitro();
                        
                    }
                    break;
            }


        }

        private void GetArbitro()
        {
            ListArbitro.DataSource = arbitro_PartidoDB.Get_Arbitro();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            MessageBoxButtons eliminar = MessageBoxButtons.YesNo;
            DialogResult dr2 = MessageBox.Show("¿SEGURO DE QUE DESEA Actualizar Arbitro", "ALERTA", eliminar, MessageBoxIcon.Warning);
            if (dr2 == DialogResult.Yes)
            {
                accion = 2;
                //Se muestra en el texbox los datos del Torneo Seleccionado
                long? DPI = GetDPI();
                arbitro_PartidoDB.Arbitros(cbxArbitro, Convert.ToInt32(DPI));
                Arbitro_Partido arbitro_Partido = arbitro_PartidoDB.GetArbitro(Id_Juego, Convert.ToInt64(DPI));
                txtPago.Text = Convert.ToString(arbitro_Partido.Pago);

                arbitro_PartidoDB.Get_Arbitros(cbxArbitro);
            }
            else if (dr2 == DialogResult.No)
            {
                MessageBox.Show("Se cancelo correctamnete la actualizacion de datos");
            }
        }

        private int? GetDPI()
        {
            try
            {
                return int.Parse(
                    ListArbitro.Rows[ListArbitro.CurrentRow.Index].Cells[0].Value.ToString()
                    );
            }
            catch
            {
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        
    }
}

    
