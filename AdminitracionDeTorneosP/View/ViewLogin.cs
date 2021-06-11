using AdminitracionDeTorneosP.Database;
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
    public partial class ViewLogin : Form
    {
        LoginDB loginController = new LoginDB();
        public string fecha = DateTime.Now.ToString("yyyy-MM-dd");
        public string hora = DateTime.Now.ToString("hh:mm");
        public string accion = "Login";

        public ViewLogin()
        {
            InitializeComponent();
            txtContrasena.PasswordChar = '*';
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int id_usuario = loginController.getId(txtUsuario.Text, txtContrasena.Text);

            Boolean estado_user = loginController.getEstado(txtUsuario.Text, txtContrasena.Text);
            if (estado_user == true)
            {
                loginController.addBitacora(id_usuario, accion, fecha, hora);
                this.Hide();
                Form1 t = new Form1(id_usuario);
                t.Show();
            }
            else
            {
                MessageBox.Show("Datos incorrectos o usuario deshabilitado");
            }
        }
    }
}
