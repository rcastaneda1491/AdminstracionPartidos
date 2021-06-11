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
    public partial class ViewUsuario : Form
    {
        UsuariosDB usuarioController = new UsuariosDB();
        int opcion = 1;

        public ViewUsuario()
        {
            InitializeComponent();
            updateTable();
        }

        private void updateTable()
        {
            listUsuarios.DataSource = usuarioController.getUsuarios();
        }

        private int getID()
        {
            try
            {
                return int.Parse(listUsuarios.Rows[listUsuarios.CurrentRow.Index].Cells[0].Value.ToString());
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
                if (txtDPI.Text == "" || txtNombres.Text == "" || txtApellidos.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" || txtPuesto.Text == "" || txtUsuario.Text == "" || txtContrasena.Text == "")
                {
                    MessageBox.Show("Debe llenar todos los datos", "Error");
                }
                else
                {
                    Usuarios Usuario = new Usuarios();
                    Usuario.dpi = txtDPI.Text;
                    Usuario.nombres = txtNombres.Text;
                    Usuario.apellidos = txtApellidos.Text;
                    Usuario.usuario = txtUsuario.Text;
                    Usuario.contrasena = txtContrasena.Text;
                    Usuario.telefono = txtTelefono.Text;
                    Usuario.direccion = txtDireccion.Text;
                    Usuario.correo = txtCorreo.Text;
                    Usuario.puesto = txtPuesto.Text;
                    Usuario.rol = Convert.ToString(cbxRol.SelectedItem);

                    usuarioController.addUsuarios(Usuario);

                }
            } else if (opcion == 0)
            {
                if (txtDPI.Text == "" || txtNombres.Text == "" || txtApellidos.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" || txtPuesto.Text == "" || txtUsuario.Text == "" || txtContrasena.Text == "")
                {
                    MessageBox.Show("Debe llenar todos los datos", "Error");
                }
                else
                {
                    Usuarios Usuario = new Usuarios();
                    Usuario.dpi = txtDPI.Text;
                    Usuario.nombres = txtNombres.Text;
                    Usuario.apellidos = txtApellidos.Text;
                    Usuario.usuario = txtUsuario.Text;
                    Usuario.contrasena = txtContrasena.Text;
                    Usuario.telefono = txtTelefono.Text;
                    Usuario.direccion = txtDireccion.Text;
                    Usuario.correo = txtCorreo.Text;
                    Usuario.puesto = txtPuesto.Text;
                    Usuario.rol = Convert.ToString(cbxRol.SelectedItem);

                    usuarioController.updateUsuario(Usuario);
                }
            }

            txtDPI.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtCorreo.Clear();
            txtPuesto.Clear();
            txtUsuario.Clear();
            txtContrasena.Clear();
            updateTable();
            opcion = 1;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int userID = getID();

            Usuarios Usuario = usuarioController.getUsuarioByID(userID);
            txtDPI.Text = Usuario.dpi;
            txtNombres.Text = Usuario.nombres;
            txtApellidos.Text = Usuario.apellidos;
            txtUsuario.Text = Usuario.usuario;
            txtContrasena.Text = Usuario.contrasena;
            txtTelefono.Text = Usuario.telefono;
            txtDireccion.Text = Usuario.direccion;
            txtCorreo.Text = Usuario.correo;
            txtPuesto.Text = Usuario.puesto;
            cbxRol.Text = Usuario.rol;
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            usuarioController.desactivarUsuario(getID());
            updateTable();
        }
    }
}
