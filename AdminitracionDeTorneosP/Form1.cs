using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using AdminitracionDeTorneosP.Database;

namespace AdminitracionDeTorneosP
{
    public partial class Form1 : Form
    {
        LoginDB loginController = new LoginDB();
        int idUsuario;
        string rol;

        public Form1(int idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.rol = loginController.getRol(idUsuario);

            if (rol == "Administrador")
            {
                button2.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button11.Enabled = true;
                button15.Enabled = true;
                button10.Enabled = true;
                button5.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button6.Enabled = true;
                button12.Enabled = true;
                button7.Enabled = true;
                button13.Enabled = true;
                btnClientes.Enabled = true;
                btnUsuarios.Enabled = true;
                button13.Enabled = true;
                btnAlquilerCancha.Enabled = true;
                button26.Enabled = true;
                btnHorario.Enabled = true;
            }
            else if (rol == "Operador")
            {
                btnHorario.Enabled = false;
                btnAlquilerCancha.Enabled = false;
                button2.Enabled = false;
                button8.Enabled = true;
                button9.Enabled = true;
                button11.Enabled = true;
                button15.Enabled = false;
                button10.Enabled = true;
                button5.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button6.Enabled = true;
                button12.Enabled = true;
                button7.Enabled = true;
                button13.Enabled = true;
                btnClientes.Enabled = true;
                btnUsuarios.Enabled = false;
                button13.Enabled = false;
                button26.Enabled = false;
            }
            else if (rol == "Reportes")
            {
                btnHorario.Enabled = false;
                button2.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button11.Enabled = false;
                button15.Enabled = false;
                button10.Enabled = false;
                button5.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button6.Enabled = false;
                button12.Enabled = false;
                button7.Enabled = false;
                btnClientes.Enabled = false;
                btnAlquilerCancha.Enabled = false;
                btnUsuarios.Enabled = false;
                button13.Enabled = false;
                button26.Enabled = true;
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(MenuVertical.Width == 250)
            {
                MenuVertical.Width = 70;
            }
            else
            {
                MenuVertical.Width = 250;
            }
        }

        private void iconoCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconoMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 70;
            }
            else
            {
                MenuVertical.Width = 250;
            }
        }

        private void AbrirFormInPanel(object Formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new View.Bienvenida());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Torneo";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.Torneo2());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Incripcion Equipo";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.MenuIncripcionEquipo());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Incripcion Jugador";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.MenuIncripcionJugador());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Amonestacion";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.CRUD_AMONESTACION());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Jornadas Partido";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.JornadasPartido());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Comenzar Partido";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.ComenzarPartido());
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Entrenador";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.CRUD_ENTRENADOR());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Equipo";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.CRUD_EQUIPO());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Arbitro";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.refereeView());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Jugadores";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.CRUD_JUGADORES());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Encuentros";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.vISTA_ENCUENTROS_WIN());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Pago Tarjeta";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.VISTA_PAGOS_TARGETAS());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Disponibilidad";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.disponibilidad_Cancha());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Cancha";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.Agregar_Cancha());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Reporte Local";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.VISTA_REPORTE_LOCAL());
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Portero Menos Vencido";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.VISTA_PORTERO_MENOS_VENCIDO());
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Portero Menos Vencido";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.Reporte_Tabla_Visitante());
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Tabla Goleador";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.GOLEADOR());

        }

        private void button22_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Partidos Afectados";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.reporteJuegosAfectados());
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Tarjetas";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.TARJETAS());
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Planilla Arbitro";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.reportePlanillaArbitro());
        }

        private void button21_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Tiempo uso Canchas";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.tiempoUsoCanchas());

        }

        private void button23_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Entrenador del Equipo";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.ReporteEstadisticasDelEquipo());

        }

        private void button24_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Reporte de Utilidades";
            loginController.addBitacora(idUsuario, accion, fecha, hora);

            AbrirFormInPanel(new View.Reporte_Utilidades());
        }

        private void button25_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Reporte punteo general";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.Reporte_punteo_general());

        }

        private void button26_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Reportes";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.Bienvenida());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Clientes";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.ViewCliente());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Usuarios";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.UsuariosView());
        }

        private void btnHorario_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Horario";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.ViewHorario());
        }

        private void btnAlquilerCancha_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("hh:mm");
            string accion = "Alquiler Cancha";
            loginController.addBitacora(idUsuario, accion, fecha, hora);
            AbrirFormInPanel(new View.ViewAlquilerCancha());
        }
    }
}
