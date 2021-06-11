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
    public partial class UsuariosView : Form
    {
        UsuariosDB usuarioController = new UsuariosDB();
        int opcion = 1;

        public UsuariosView()
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

        private Boolean getEstado()
        {
            try
            {
                return Boolean.Parse(listUsuarios.Rows[listUsuarios.CurrentRow.Index].Cells[11].Value.ToString());
            }
            catch
            {
                return false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (opcion == 1)
            {
                if (txtDPI.Text == "" || txtNombres.Text == "" || txtApellidos.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" || txtPuesto.Text == "" || txtUser.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Debe llenar todos los datos", "Error");
                }
                else
                {
                    Usuarios Usuario = new Usuarios();
                    Usuario.dpi = txtDPI.Text;
                    Usuario.nombres = txtNombres.Text;
                    Usuario.apellidos = txtApellidos.Text;
                    Usuario.usuario = txtUser.Text;
                    Usuario.contrasena = txtPassword.Text;
                    Usuario.telefono = txtTelefono.Text;
                    Usuario.direccion = txtDireccion.Text;
                    Usuario.correo = txtCorreo.Text;
                    Usuario.puesto = txtPuesto.Text;
                    Usuario.rol = Convert.ToString(cbxRol.SelectedItem);

                    usuarioController.addUsuarios(Usuario);

                }
            }
            else if (opcion == 0)
            {
                if (txtDPI.Text == "" || txtNombres.Text == "" || txtApellidos.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" || txtPuesto.Text == "" || txtUser.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Debe llenar todos los datos", "Error");
                }
                else
                {
                    Usuarios usuario = new Usuarios();
                    usuario.id = getID();
                    usuario.dpi = txtDPI.Text;
                    usuario.nombres = txtNombres.Text;
                    usuario.apellidos = txtApellidos.Text;
                    usuario.usuario = txtUser.Text;
                    usuario.contrasena = txtPassword.Text;
                    usuario.telefono = txtTelefono.Text;
                    usuario.direccion = txtDireccion.Text;
                    usuario.correo = txtCorreo.Text;
                    usuario.puesto = txtPuesto.Text;
                    usuario.rol = Convert.ToString(cbxRol.SelectedItem);

                    usuarioController.updateUsuario(usuario);
                }
            }

            txtDPI.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtCorreo.Clear();
            txtPuesto.Clear();
            txtUser.Clear();
            txtPassword.Clear();
            cbxRol.Text = "";
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
            txtUser.Text = Usuario.usuario;
            txtPassword.Text = Usuario.contrasena;
            txtTelefono.Text = Usuario.telefono;
            txtDireccion.Text = Usuario.direccion;
            txtCorreo.Text = Usuario.correo;
            txtPuesto.Text = Usuario.puesto;
            cbxRol.Text = Usuario.rol;
            opcion = 0;
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            usuarioController.desactivarUsuario(getID(), getEstado());
            updateTable();
        }
    }
}
