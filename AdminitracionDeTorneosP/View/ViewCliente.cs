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
    public partial class ViewCliente : Form
    {
        ClienteDB clienteController = new ClienteDB();
        int opcion = 1;

        public ViewCliente()
        {
            InitializeComponent();
            updateTable();
        }

        private void updateTable()
        {
            listClientes.DataSource = clienteController.getClientes();
        }

        private int getID()
        {
            try
            {
                return int.Parse(listClientes.Rows[listClientes.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return 0;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (opcion == 1)
            {
                if (txtDPI.Text == "" || txtNombres.Text == "" || txtApellidos.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "")
                {
                    MessageBox.Show("Debe llenar todos los datos", "Error");
                }
                else
                {
                    Cliente cliente = new Cliente();

                    cliente.dpi = txtDPI.Text;
                    cliente.nombres = txtNombres.Text;
                    cliente.apellidos = txtApellidos.Text;
                    cliente.telefono = txtTelefono.Text;
                    cliente.correo = txtCorreo.Text;

                    clienteController.addCliente(cliente);
                }
            }
            else if (opcion == 0)
            {
                if (txtDPI.Text == "" || txtNombres.Text == "" || txtApellidos.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "")
                {
                    MessageBox.Show("Debe llenar todos los datos", "Error");
                }
                else
                {
                    Cliente cliente = new Cliente();

                    cliente.dpi = txtDPI.Text;
                    cliente.nombres = txtNombres.Text;
                    cliente.apellidos = txtApellidos.Text;
                    cliente.telefono = txtTelefono.Text;
                    cliente.correo = txtCorreo.Text;
                    cliente.id = getID();

                    clienteController.updateCliente(cliente);
                }
            }
            txtDPI.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            updateTable();
            opcion = 1;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            opcion = 0;

            int clienteID = getID();

            Cliente cliente = clienteController.getClienteById(clienteID);

            txtDPI.Text = cliente.dpi;
            txtNombres.Text = cliente.nombres;
            txtApellidos.Text = cliente.apellidos;
            txtTelefono.Text = cliente.telefono;
            txtCorreo.Text = cliente.correo;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            clienteController.deleteCliente(getID());
            updateTable();   
        }
    }
}
